﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Behavioral.Automation.Elements;
using Behavioral.Automation.FluentAssertions;
using Behavioral.Automation.Services;
using JetBrains.Annotations;
using OpenQA.Selenium;

namespace Behavioral.Automation.DemoBindings.Elements
{
    public class WebElementWrapper : IWebElementWrapper
    {
        private readonly Func<IWebElement> _elementSelector;

        public WebElementWrapper([NotNull] Func<IWebElement> elementSelector, [NotNull] string caption,
            [NotNull] IDriverService driverService)
        {
            _elementSelector = elementSelector;
            Driver = driverService;
            Caption = caption;
        }

        public string Caption { get; }

        public IWebElement Element => _elementSelector();

        public string Text
        {
            get
            {
                try
                {
                    return Regex.Replace(Element.Text, @"\t|\n|\r", " ").Replace("  ", " ");
                }
                catch (Exception e) when (e is NullReferenceException or StaleElementReferenceException)
                {
                    return string.Empty;
                }
            }
        }

        public string GetAttribute(string attribute)
        {
            try
            {
                return Element.GetAttribute(attribute);
            }
            catch (Exception e) when (e is NullReferenceException or StaleElementReferenceException)
            {
                return null;
            }
        }

        public void Click()
        {
            Assert.ShouldBecome(() => Enabled, true, $"Unable to click on {Caption}. The element was disabled");
            try
            {
                Element.Click();
            }
            catch (ElementClickInterceptedException)
            {
                MouseHover();
                Driver.MouseClick();
            }
        }

        public void MouseHover()
        {
            Assert.ShouldBecome(() => Displayed, true, $"{Caption} is not visible");
            Driver.ScrollTo(Element);
        }

        public void SendKeys(string text)
        {
            Assert.ShouldBecome(() => Enabled, true, $"{Caption} is disabled");
            Element.SendKeys(text);
        }

        public bool Displayed
        {
            get
            {
                try
                {
                    return Element is not null && Element.Displayed;
                }
                catch (Exception e) when (e is NullReferenceException or StaleElementReferenceException)
                {
                    return false;
                }
            }
        }

        public bool Enabled => Displayed && Element.Enabled && CustomAttributeEnabled;

        public string Tooltip => GetAttribute("data-test-tooltip-text");

        public string TagName => Element.TagName;

        public bool Stale
        {
            get
            {
                try
                {
                    // Calling any method forces a staleness check
                    var elementEnabled = Element.Enabled;
                    return false;
                }
                catch (Exception e) when (e is NullReferenceException or StaleElementReferenceException)
                {
                    return true;
                }
            }
        }

        public IWebElementWrapper FindSubElement(By locator, string caption)
        {
            var element = Assert.ShouldGet(() =>
                new WebElementWrapper(() => Element.FindElement(locator), caption, Driver));
            return element;
        }

        public IEnumerable<IWebElementWrapper> FindSubElements(By locator, string caption)
        {
            try
            {
                return ElementsToWrappers(Assert.ShouldGet(() => Element.FindElements(locator)), caption);
            }
            catch (Exception e) when (e is NullReferenceException or InvalidOperationException)
            {
                NUnit.Framework.Assert.Fail($"Couldn't find elements with {caption}");
                return null;
            }
        }

        private IEnumerable<IWebElementWrapper> ElementsToWrappers(IEnumerable<IWebElement> elements, string caption)
        {
            return elements.Select(element => new WebElementWrapper(() => element, caption, Driver));
        }

        protected IDriverService Driver { get; }

        private bool CustomAttributeEnabled
        {
            get
            {
                var ariaDisabled = Element.GetAttribute("aria-disabled");
                if (bool.TryParse(ariaDisabled, out var isDisabled))
                {
                    return !isDisabled;
                }

                return Element.GetAttribute("disabled") == null;
            }
        }
    }
}
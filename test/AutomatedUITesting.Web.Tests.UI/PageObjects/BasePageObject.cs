﻿using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutomatedUITesting.Web.Tests.UI.PageObjects
{
    public abstract class BasePageObject
    {
        public abstract string PagePath { get; }

        public abstract IPage Page { get; set; }

        public abstract IBrowser Browser { get; }

        public async Task NavigateAsync()
        {
            Page = await Browser.NewPageAsync();
            await Page.GotoAsync(PagePath);
        }
    }
}

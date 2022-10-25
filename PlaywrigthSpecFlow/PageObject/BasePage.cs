using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using SpecFlow.Actions.Playwright;

namespace PlaywrigthSpecFlow.PageObject
{
	/// <summary>
	/// Parent class for Page Objects
	/// </summary>
	public abstract class BasePage
	{
		private string baseUrl = "https://www.talent.com/";
		public readonly Task<IPage> _page;
		public readonly Interactions _actions;

		public BasePage(BrowserDriver driver)
		{
			//Inject BrowserDriver into the page and returns a page object returning
			//current driver instance
			_page = CreatePageAsync(driver.Current);
			_actions = new Interactions(_page);
		}
		
		/// <summary>
		/// Method initializes new page object
		/// </summary>
		/// <param name="browser"></param>
		/// <returns></returns>
		private async Task<IPage> CreatePageAsync(Task<IBrowser> browser)
		{
			return await (await browser).NewPageAsync();
		}

		/// <summary>
		/// Method awaits until browser URL equal the one specified in parameter 
		/// and in case of failure it opens the page via URL provided
		/// </summary>
		/// <param name="pageUrl"></param>
		/// <returns></returns>
		public async Task EnsurePageIsOpened(string pageUrl)
		{
			string fullUrl = baseUrl + pageUrl;
			if ((await _page).Url != fullUrl)
			{
				await _actions.GoToUrl(fullUrl);
			}
		}
	}
}

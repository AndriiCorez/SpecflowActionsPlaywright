using System.Threading.Tasks;
using PlaywrigthSpecFlow.PageObject;
using SpecFlow.Actions.Playwright;
using TechTalk.SpecFlow;

namespace PlaywrigthSpecFlow.Hooks
{
	/// <summary>
	/// Tool defines actions to be done before and after scenario run
	/// </summary>
	[Binding]
	public sealed class Hooks
	{
		// For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

		[BeforeScenario]
		public async Task BeforeScenarioAsync(TaxCalculatorPage page)
		{
			await page.EnsurePageIsOpened(page.getUrl);
			//await page.setViewportSize({ width: 1920, height: 1080 });
			//TODO: implement logic that has to run before executing each scenario
		}

		[AfterScenario]
		public void AfterScenario()
		{
			//TODO: implement logic that has to run after executing each scenario
		}
	}
}

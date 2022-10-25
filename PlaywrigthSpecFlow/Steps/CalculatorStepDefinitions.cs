using System.Threading.Tasks;
using FluentAssertions;
using PlaywrigthSpecFlow.PageObject;
using TechTalk.SpecFlow;
using static PlaywrigthSpecFlow.PageObject.TaxCalculatorPage;

namespace PlaywrigthSpecFlow.Steps
{
	[Binding]
	public sealed class CalculatorStepDefinitions
	{

		// For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
		private readonly TaxCalculatorPage page;

		public CalculatorStepDefinitions(TaxCalculatorPage page)
		{
			this.page = page;
		}

		[Given("the salary field is populated with (.*)")]
		public async Task GivenTheSalaryFieldIsPopulatedWith(int number)
		{
			await this.page.EnterSalaryValue(number);

		}

		[Given("the pay per period is (.*)")]
		public async Task GivenTheSecondNumberIs(string value)
		{
			await this.page.SelectPeriodOption(value);
		}

		[When("taxes are calculated")]
		public async Task WhenTaxesAreCalculated()
		{
			await this.page.ClickCalculateButton();
		}

		[Then(@"the Tax number result should be (.*)")]
		public async Task ThenTheTaxNumberResultShouldBe(string expectedTax)
		{
			string actualTaxNumber = await this.page.GetTotalTaxNumber();
			actualTaxNumber.Should().Be(expectedTax);
		}


		[Then("the Net pay result should be (.*)")]
		public async Task ThenTheNextPayResultShouldBe(string expectedResult)
		{
			string actualResult = await this.page.GetSalaryNetValue();
			actualResult.Should().Be(expectedResult);
		}
	}
}

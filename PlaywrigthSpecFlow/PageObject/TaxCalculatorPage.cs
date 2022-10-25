using System;
using System.Threading.Tasks;
using SpecFlow.Actions.Playwright;

namespace PlaywrigthSpecFlow.PageObject
{
	/// <summary>
	/// Page object for Tax Calculater page
	/// </summary>
	public class TaxCalculatorPage : BasePage
	{

        #region Selectors
        private protected const string pageUrl = "tax-calculator";

		private string SalaryInputField => "#salary-input";
		private string SalaryPerTimeDropDown => "#from-input";
		private string CalculateButton => ".btn.c-form__input--calculate";
		private string TotalTaxValue => "div[class='l-card__tag-container l-card__tag-right']";
		private string NetValue => "div[class='l-card__deductions c-card__deductions-highlight c-card__deductions-highlight--big'] div[class='timeBased']";

        #endregion

        public TaxCalculatorPage(BrowserDriver driver) : base(driver) { }

		public string getUrl {
			get { return pageUrl; } 
		}

		public enum SalaryPeriod
        {
			Day,
			Month,
			Annual
        }

        #region Page Actions

        public async Task EnterSalaryValue(int value)
		{
			await _actions.SendTextAsync(SalaryInputField, value.ToString());
		}

		public async Task SelectPeriodOption(string value)
        {
			await _actions.SelectDropdownOptionAsync(SalaryPerTimeDropDown, value);
        }

        public async Task<string> GetTotalTaxNumber()
        {
			await _actions.WaitForNonEmptyValue(TotalTaxValue);
            return await _actions.GetValueAttributeAsync(TotalTaxValue);
        }

        public async Task ClickCalculateButton()
		{
			await _actions.ClickAsync(CalculateButton);
		}

		public async Task<string> GetSalaryNetValue()
		{
			return await _actions.GetValueAttributeAsync(NetValue);
		}

        #endregion
    }
}

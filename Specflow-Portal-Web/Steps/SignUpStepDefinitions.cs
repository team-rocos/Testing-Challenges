using FluentAssertions;
using ROCO.Specflow.PortalWeb.Drivers;
using ROCO.Specflow.PortalWeb.Drivers.Interfaces;
using ROCO.Specflow.PortalWeb.Helpers.TestData;
using TechTalk.SpecFlow;

namespace ROCO.Specflow.PortalWeb.Steps
{
    [Binding]
    public sealed class SignUpStepDefinitions
    {
        private readonly ISignUpDriver _driver;
        private readonly string _invalidString = "x";

        public SignUpStepDefinitions(ISignUpDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I am on sign up page")]
        public void GivenIAmOnSignUpPage()
        {
            _driver.NavigateToPage();
        }
        
        [When(@"I leave all fields empty")]
        public void WhenILeaveAllFieldsEmpty()
        {
            _driver.SignUp(null, null, null, null, null, null, null);
        }

        [When(@"I input an invalid Email")]
        public void WhenIInputAnInvalidEmail()
        {
            _driver.InputEmail(_invalidString);
        }

        [When(@"I input an invalid password format")]
        public void WhenIInputAnInvalidPasswordFormat()
        {
            _driver.InputPassword(_invalidString);
        }

        [Then(@"I get a Password error message ""(.*)""")]
        public void ThenIGetAPasswordErrorMessage(string expectedErrorMsg)
        {
            var actualErrorMsg = _driver.GetTextBoxesErrorMessages();
            actualErrorMsg[SignUpDriver.Elements.Password].Should().Match(expectedErrorMsg);
        }

        [When(@"I input all valid customer details but an invalid Invitation Code")]
        public void WhenIInputAllValidCustomerDetailsButAnInvalidInvitationCode()
        {
            _driver.SignUp(CustomerDetailsConstant.FirstName, CustomerDetailsConstant.LastName, CustomerDetailsConstant.Email, CustomerDetailsConstant.AccountName
                , CustomerDetailsConstant.Password, CustomerDetailsConstant.Password, _invalidString);
        }

        [Then(@"I get a banner error message ""(.*)""")]
        public void ThenIGetAnErrorMessageOnThePage(string expectedErrorMsg)
        { 
            var actualErrorMsg = _driver.GetBannerErrorMessage();
            actualErrorMsg.Should().Match(expectedErrorMsg);
        }

        [Then(@"I get an Email error message ""(.*)""")]
        public void ThenIGetAnEmailErrorMessage(string expectedErrorMsg)
        {
            var actualErrorMsg = _driver.GetTextBoxesErrorMessages();
            actualErrorMsg[SignUpDriver.Elements.Email].Should().Match(expectedErrorMsg);
        }

        [When(@"I input an invalid Account Name")]
        public void WhenIInputAnInvalidAccountName()
        {
            _driver.InputAccountName(_invalidString);
        }

        [Then(@"I get an Account Name error message ""(.*)""")]
        public void ThenIGetAnAccountNameErrorMessageTest(string expectedErrorMsg)
        {
            var actualErrorMsg = _driver.GetTextBoxesErrorMessages();
            actualErrorMsg[SignUpDriver.Elements.AccountName].Should().Match(expectedErrorMsg);
        }

        [Then(@"I get textboxes error messages")]
        public void ThenIGetTextBoxesErrorMessages()
        {
            var errorMsgs = _driver.GetTextBoxesErrorMessages();
            errorMsgs[SignUpDriver.Elements.FirstName].Should().Match("Please enter First Name.");
            errorMsgs[SignUpDriver.Elements.LastName].Should().Match("Please enter Last Name.");
            errorMsgs[SignUpDriver.Elements.Email].Should().Match("Please enter Email.");
            errorMsgs[SignUpDriver.Elements.AccountName].Should().Match("Please enter Account Name.");
            errorMsgs[SignUpDriver.Elements.Password].Should().Match("Please enter Password.");
            errorMsgs[SignUpDriver.Elements.ConfirmPassword].Should().Match("Confirm your password.");
        }

    }
}

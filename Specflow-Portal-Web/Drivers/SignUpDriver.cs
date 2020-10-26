using ROCO.Specflow.PortalWeb.Drivers.Interfaces;
using ROCO.Specflow.PortalWeb.Drivers.PageObjects;
using ROCO.Specflow.PortalWeb.Infrastructure;
using System.Collections.Generic;

namespace ROCO.Specflow.PortalWeb.Drivers
{
    public class SignUpDriver: ISignUpDriver
    {
        private readonly BrowserDriver _browserDriver;
        private readonly SignUpPageObject _signUpPageObject;

        public enum Elements
        {
            FirstName,
            LastName,
            Email,
            AccountName,
            Password,
            ConfirmPassword
        }

        public SignUpDriver(BrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
            _signUpPageObject = new SignUpPageObject(_browserDriver.Current);
        }

        public void NavigateToPage()
        {
            _browserDriver.Navigate(_signUpPageObject.urlPath);
        }

        public void SignUp(string firstName, string lastName, string email, string accountName, string password, string confirmPassword, string invitationCode)
        {
            InputFirstName(firstName);
            InputLastName(lastName);
            InputEmail(email);
            InputAccountName(accountName);
            InputPassword(password);
            InputConfirmPassword(confirmPassword);
            InputInvitationCode(invitationCode);

            _signUpPageObject.SignUpButton.Submit();
        }

        public void InputConfirmPassword(string confirmPassword = null)
        {
            _signUpPageObject.ConfirmPassword.Clear();
            if (confirmPassword != null) _signUpPageObject.ConfirmPassword.SendKeys(confirmPassword);
        }

        public void InputFirstName(string firstName = null)
        {
            _signUpPageObject.FirstName.Clear();
            if (firstName != null) _signUpPageObject.FirstName.SendKeys(firstName);
        }

        public void InputLastName(string lastName = null)
        {
            _signUpPageObject.LastName.Clear();
            if (lastName != null) _signUpPageObject.LastName.SendKeys(lastName);
        }

        public void InputPassword(string password=null)
        {
            _signUpPageObject.Password.Clear();
            if (password != null) _signUpPageObject.Password.SendKeys(password);
        }

        public void InputAccountName(string accountName=null)
        {
            _signUpPageObject.AccountName.Clear(); 
            if (accountName != null) _signUpPageObject.AccountName.SendKeys(accountName);
        }

        public void InputEmail(string email=null)
        {
            _signUpPageObject.Email.Clear(); 
            if (email != null) _signUpPageObject.Email.SendKeys(email);
        }

        public void InputInvitationCode(string code = null)
        {
            _signUpPageObject.InvitationCode.Clear(); 
            if (code != null) _signUpPageObject.InvitationCode.SendKeys(code);
        }

        public Dictionary<Elements, string> GetTextBoxesErrorMessages()
        {
            var errorMsgs = new Dictionary<Elements, string>();
            errorMsgs.Add(Elements.FirstName, _signUpPageObject.FirstNameErrorMessage.Text);
            errorMsgs.Add(Elements.LastName, _signUpPageObject.LastNameErrorMessage.Text);
            errorMsgs.Add(Elements.Email, _signUpPageObject.EmailErrorMessage);
            errorMsgs.Add(Elements.AccountName, _signUpPageObject.AccountNameErrorMessage);
            errorMsgs.Add(Elements.Password, _signUpPageObject.PasswordErrorMessage);
            errorMsgs.Add(Elements.ConfirmPassword, _signUpPageObject.ConfirmPasswordErrorMessage.Text);
            return errorMsgs;
        }

        public string GetBannerErrorMessage()
        {
            return _signUpPageObject.Banner.Text;
        }

    }
}

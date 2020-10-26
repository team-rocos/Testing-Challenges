using System.Collections.Generic;

namespace ROCO.Specflow.PortalWeb.Drivers.Interfaces
{
    public interface ISignUpDriver
    {
        void NavigateToPage();

        string GetBannerErrorMessage();

        void InputConfirmPassword(string confirmPassword = null);

        void InputFirstName(string firstName = null);

        void InputLastName(string lastName = null);

        void InputPassword(string password = null);

        void InputAccountName(string accountName = null);

        void InputEmail(string email = null);

        void SignUp(string firstName, string lastName , string email ,
            string accountName, string password, string confirmPassword, string invitationCode);

        Dictionary<SignUpDriver.Elements, string> GetTextBoxesErrorMessages();
    }
}

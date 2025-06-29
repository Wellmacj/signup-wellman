using System.Web;
using Microsoft.Maui.Controls;

namespace signup_wellman;

public partial class SignupPage : ContentPage
{
    public SignupPage()
    {
        InitializeComponent();
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text?.Trim();
        string email = EmailEntry.Text?.Trim();
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;

        ErrorLabel.IsVisible = false;

        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(confirmPassword))
        {
            ErrorLabel.Text = "Please fill in all required fields.";
            ErrorLabel.IsVisible = true;
            return;
        }

        if (password != confirmPassword)
        {
            ErrorLabel.Text = "Passwords do not match.";
            ErrorLabel.IsVisible = true;
            return;
        }

        // Basic email validation (optional)
        if (!IsValidEmail(email))
        {
            ErrorLabel.Text = "Please enter a valid email address.";
            ErrorLabel.IsVisible = true;
            return;
        }

        // URL encode the parameters for safety
        string encodedUsername = Uri.EscapeDataString(username);
        string encodedEmail = Uri.EscapeDataString(email);

        // Navigate using URI-based navigation with query parameters
        await Shell.Current.GoToAsync($"profile?username={encodedUsername}&email={encodedEmail}");
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
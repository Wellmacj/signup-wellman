using Microsoft.Maui.Controls;

namespace signup_wellman;

[QueryProperty(nameof(Username), "username")]
[QueryProperty(nameof(Email), "email")]
public partial class ProfilePage : ContentPage
{
    private string _username;
    private string _email;

    public string Username
    {
        get => _username;
        set
        {
            _username = Uri.UnescapeDataString(value ?? string.Empty);
            OnPropertyChanged();
            UsernameLabel.Text = _username;
            WelcomeLabel.Text = $"Welcome, {_username}!";
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            _email = Uri.UnescapeDataString(value ?? string.Empty);
            OnPropertyChanged();
            EmailLabel.Text = $"Email: {_email}";
        }
    }

    public ProfilePage()
    {
        InitializeComponent();
    }

    private async void OnSignOutClicked(object sender, EventArgs e)
    {
        // Navigate back to Signup page
        await Shell.Current.GoToAsync("//signup");
    }
}

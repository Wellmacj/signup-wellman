namespace signup_wellman
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("signup", typeof(ProfilePage));
            Routing.RegisterRoute("profile", typeof (ProfilePage));
        }
    }
}

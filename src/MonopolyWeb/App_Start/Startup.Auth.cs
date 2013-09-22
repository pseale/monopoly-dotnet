using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Forms;
using Owin;

namespace MonopolyWeb
{
    // this class is used by Owin on app load
    // ReSharper disable once UnusedMember.Global
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            //app.UseApplicationSignInCookie();
            var authenticationOptions = new FormsAuthenticationOptions();
            authenticationOptions.AuthenticationType = "Application";
            authenticationOptions.AuthenticationMode = AuthenticationMode.Active;
            authenticationOptions.CookieName = ".AspNet.Application";
            authenticationOptions.LoginPath = "/NewGame";
            authenticationOptions.LogoutPath = "/QuitGame";
            FormsAuthenticationOptions options = authenticationOptions;
            FormsAuthenticationExtensions.UseFormsAuthentication(app, options);

            // Enable the application to use a cookie to temporarily store information about a user logging in with a third party login provider
            //app.UseExternalSignInCookie();

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication();
        }
    }
}
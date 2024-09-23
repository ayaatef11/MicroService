namespace microService.Configurations
{
    public class ServiceSettings
    {
        public string CoinsPriceUrl { get; set; }
        public string ApiKey {  get; set; } 
    }
}
/* creating and using User Secrets is crucial for managing sensitive data during the development process.
 * User secrets allow you to store sensitive configuration values (e.g., API keys, connection strings, passwords)
 * securely in your local development environment without hardcoding 
 * them into the project files or source code, especially for applications like ASP.NET Core.*/
/*
 Commands:
 dotnet user-secrets init ->to create a user secret and you can see it in the configuration settings 
 dotnet user-secrets set ServiceSettings:Api [the secret key]
here are the commands you need to configure for a propery defined in the appsettings
 */
//dotnet user-secret list 
//then y0u need to add a package that helps you to contact with the api
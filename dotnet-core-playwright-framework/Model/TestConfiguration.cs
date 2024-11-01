namespace Tests.Model
{
    public class TestConfiguration
    {
        public TestRail TestRail { get; set; }
        public Application Application { get; set; }
        public BrowserOptions Browser { get; set; }
    }

    public class TestRail
    {
        public string Url { get; set; }
        public int ProjectId { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool EnableWriting { get; set; }
    }

    public class Application
    {
        public string ApplicationUrl { get; set; }
    }

    public class Vault
    {
        public string Url { get; set; }
        public string TotpUser { get; set; }
        public string Password { get; set; }
    }

    public class IdentityApi
    {
        public string Url { get; set; }
    }

    public class BrowserOptions
    {
        public string BrowserName { get; set; }
        public string Version { get; set; }
        public string PlaywrightVersion { get; set; }
        public bool IsRemote { get; set; }
        public string RemoteHost { get; set; }
        public bool EnableVideo { get; set; }
        public bool EnableVNC { get; set; }
        public TimeOut TimeOut { get; set; }
    }

    public class TimeOut
    {
        public int DefaultMethodTimeout { get; set; }
        public int NavigationTimeout { get; set; }
        public int ConnectOptionsTimeout { get; set; }
    }

    public class AzureAdb2CApp
    {
        public string GfkDataPlatformOAuthUrl { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
    }
}
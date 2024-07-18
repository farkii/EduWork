namespace EduWork.UI.Core.Configurations
{
    public class AzureAdOptions
    {
        public const string Section = "AzureAd";

        public string ClientId { get; set; } = String.Empty;
        public string Authority { get; set; } = String.Empty;
        public string ValidateAuthority { get; set; } = String.Empty;
    }
}

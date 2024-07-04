namespace EduWork.WebAPI.Configurations
{
    public class AzureAdOptions
    {
        public const string Section = "AzureAd";

        public string Instance { get; set; } = String.Empty;
        public string Domain { get; set; } = String.Empty;
        public string TenantId { get; set; } = String.Empty;
        public string ClientId { get; set; } = String.Empty;
        public string CallbackPath { get; set; } = String.Empty;
        public string Scopes { get; set; } = String.Empty;
    }
}

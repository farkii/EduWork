namespace EduWork.WebAPI.Configurations
{
    public class SwaggerAzureAdOptions
    {
        public const string Section = "SwaggerAzureAd";

        public string AuthorizationUrl { get; set; } = String.Empty;
        public string TokenUrl {  get; set; } = String.Empty;
        public string Scope {  get; set; } = String.Empty;
        public string ClientId { get; set; } = String.Empty;
    }
}

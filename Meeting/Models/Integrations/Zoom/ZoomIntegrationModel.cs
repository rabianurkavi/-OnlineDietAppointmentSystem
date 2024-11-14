namespace Meeting.Models.Integrations.Zoom;

public class ZoomIntegrationModel
{
    public string? AccountId { get; set; }
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
}

public class ResponseModel
{
    public string? DirectUrl { get; set; }
    public string? JoinUrl { get; set; }
    public string? JoinID { get; set; }
    public string? Password { get; set; }
}
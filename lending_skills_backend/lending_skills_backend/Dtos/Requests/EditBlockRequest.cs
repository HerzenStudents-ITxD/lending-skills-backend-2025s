namespace lending_skills_backend.Dtos.Requests;

public class EditBlockRequest
{
    public Guid Id { get; set; }
    public string Data { get; set; }
    public string IsExample { get; set; }
    public int Type { get; set; }
}

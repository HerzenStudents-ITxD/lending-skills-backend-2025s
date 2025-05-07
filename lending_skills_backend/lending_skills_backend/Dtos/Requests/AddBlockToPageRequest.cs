namespace lending_skills_backend.Dtos.Requests;

public class AddBlockToPageRequest
{
    public Guid PageId { get; set; }
    public string Data { get; set; }
    public string IsExample { get; set; }
    public int Type { get; set; }
    public Guid? AfterBlockId { get; set; }
}

namespace Internship_7_Moodle.Application.Common.Model;

public class SuccessPostResponse
{
    public int? Id { get; init; }
    
    public SuccessPostResponse(int? id, List<string>? warnings=null, List<string>? infos=null)
    {
        Id = id;
    }

    public SuccessPostResponse()
    {
        
    }

}
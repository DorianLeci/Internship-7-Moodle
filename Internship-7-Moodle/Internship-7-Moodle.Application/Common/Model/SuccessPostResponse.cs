namespace Internship_7_Moodle.Application.Common.Model;

public class SuccessPostResponse
{
    public int? Id { get; init; }
    public List<string>? Warnings { get; init; }
    public List<string>? Infos { get; init; }

    public SuccessPostResponse(int? id, List<string>? warnings=null, List<string>? infos=null)
    {
        Id = id;
        Warnings = warnings;
        Infos = infos;
    }

    public SuccessPostResponse()
    {
        
    }

}
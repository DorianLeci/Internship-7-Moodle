namespace Internship_7_Moodle.Application.Response.User;

public class ChangeEmailResponse
{
    public int Id { get; init; }

    public string OldEmail { get; init; } = null!;

    public string NewEmail { get; init; } = null!;


}
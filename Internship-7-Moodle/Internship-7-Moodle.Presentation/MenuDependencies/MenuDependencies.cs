using Internship_7_Moodle.Presentation.Actions;

namespace Internship_7_Moodle.Presentation.MenuDependencies;

public class MenuDependencies
{
    public UserActions UserActions { get; init; }
    
    public CourseActions CourseActions { get; init; }
    
    public ChatActions ChatActions { get; init; }
}
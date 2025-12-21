using System.Text.Json.Serialization;

namespace Internship_7_Moodle.Domain.Common.Validation;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ValidationSeverity
{
    Error,
    Warning,
    Info
}
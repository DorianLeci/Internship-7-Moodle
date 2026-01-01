using System.Text.RegularExpressions;

namespace Internship_7_Moodle.Presentation.Helpers.Format;

public static class FormatAuthorName
{
    public static string FormatInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        input = input.Trim();
        input = Regex.Replace(input, @"\s+", " ");
        
        var words=input.Split(' ');

        for (var i = 0; i < words.Length; i++)
        {
            words[i]=char.ToUpper(words[i][0])+ words[i][1..];
        }
        
        return string.Join(" ",words);
        
    }
}
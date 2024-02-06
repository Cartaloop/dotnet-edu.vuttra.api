using System.Globalization;
using System.Text;

namespace edu.VuttraApp.Api.Handlers;

public class RemoveAccentsHandler
{
    public static string RemoveAccents(string text)
    {
        StringBuilder sbReturn = new StringBuilder();
        var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
        foreach (char letter in arrayText)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                sbReturn.Append(letter);
        }

        return sbReturn.ToString().ToLower();
    }
}
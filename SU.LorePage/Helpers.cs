using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace SU.LorePage;

public static class Helpers
{
    /// <summary>
    /// Get the current date in the format "yyyy-MM-dd".
    /// </summary>
    /// <returns>
    /// A string representing the current date in the format "yyyy-MM-dd".
    /// It is offset by +200 years.
    /// </returns>
    public static string GetCurrentDate()
    {
        return DateTime.Now.AddYears(200).ToString("yyyy-MM-dd");
    }

    /// <summary>
    /// Parses the content of a lore page. This includes replacing
    ///     - [date] with the current date
    ///     - [color=colorName] content [/color] with <span class="color-colorName"> content </span>
    ///     - [block=color] content [/block] with <p class="block block-color"> content </p>
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static string ParseContent(string content)
    {
        // First we escape any HTML tags
        content = content.Replace("<", "&lt;");
        content = content.Replace(">", "&gt;");
        
        // Then we replace the placeholders
        content = content.Replace("[date]", GetCurrentDate());
        content = ParseColor(content);
        content = ParseBlock(content);
        return content;
    }
    
    private static string ParseColor(string content)
    {
        int startIndex;
        while ((startIndex = content.IndexOf("[color=")) != -1)
        {
            var endIndex = content.IndexOf("]", startIndex);
            if (endIndex == -1)
                break;

            var colorName = content.Substring(startIndex + 7, endIndex - startIndex - 7);
            var closingTagIndex = content.IndexOf("[/color]", endIndex);
            if (closingTagIndex == -1)
                break;

            var replacement = $"<span class=\"color-{colorName}\">{content.Substring(endIndex + 1, closingTagIndex - endIndex - 1)}</span>";
            content = content.Remove(startIndex, closingTagIndex - startIndex + 8).Insert(startIndex, replacement);
        }

        return content;
    }
    
    private static string ParseBlock(string content)
    {
        int startIndex;
        while ((startIndex = content.IndexOf("[block=")) != -1)
        {
            var endIndex = content.IndexOf("]", startIndex);
            if (endIndex == -1)
                break;

            var colorName = content.Substring(startIndex + 7, endIndex - startIndex - 7);
            var closingTagIndex = content.IndexOf("[/block]", endIndex);
            if (closingTagIndex == -1)
                break;

            var replacement = $"<p class=\"block block-{colorName}\">{content.Substring(endIndex + 1, closingTagIndex - endIndex - 1)}</p>";
            content = content.Remove(startIndex, closingTagIndex - startIndex + 8).Insert(startIndex, replacement);
        }

        return content;
    }
}
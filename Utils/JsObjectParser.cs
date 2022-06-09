using System.Text.Json;
using Microsoft.AspNetCore.Html;

namespace razor_web_pages.Pages
{
    public static class JsObjectParser {
        public static IHtmlContent ToJsObject(object obj) {
            return new Microsoft.AspNetCore.Html.HtmlContentBuilder()
            .AppendHtml(JsonSerializer.Serialize(obj, new JsonSerializerOptions() {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }));
        }        
    }
}

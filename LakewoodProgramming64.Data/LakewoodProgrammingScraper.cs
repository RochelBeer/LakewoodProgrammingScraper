using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LakewoodProgramming64.Data
{
    public class LakewoodProgrammingScraper
    {

        public static List<Curriculum> Scrape()
        {
            var html = GetHtml();
            return ParseHtml(html);
        }
        private static string GetHtml()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                UseCookies = true
            };
            using var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.82 Safari/537.36");

            var url = $"https://lakewoodprogramming.com/#section-curriculum";
            var html = client.GetStringAsync(url).Result;
            return html;
        }
        private static List<Curriculum> ParseHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var divs = document.QuerySelectorAll("tr");
            var items = new List<Curriculum>();
            foreach (var div in divs)
            {
                Curriculum item = new();
                items.Add(item);

                var monthElement = div.QuerySelector("tr td");
                if (monthElement != null)
                {
                    item.Month = monthElement.TextContent;
                }
                var curriculumElement = div.QuerySelector("ul");
                if (curriculumElement != null)
                {
                    item.Topic = curriculumElement.TextContent;
                }
            }
            return items;
        }
        
    }
}

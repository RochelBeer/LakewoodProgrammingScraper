using LakewoodProgramming64.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace LakewoodProgramming64.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        [HttpGet]
        [Route("scrape")]
        public List<Curriculum> Scrape()
        {
            return LakewoodProgramming64.Data.LakewoodProgrammingScraper.Scrape();
        }
    }
}

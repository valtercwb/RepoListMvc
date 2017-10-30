using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AteliwareExam.Controllers
{
    public class HomeController : Controller
    {
        List<Item> repoList;

        public ActionResult Index() {

            return View();
        }

        public async Task<List<Item>> GetRepos(string language)
        {

            GitRepository gitRepo = new GitRepository();
            repoList = new List<Item>();

            //Hosted web API REST Service base url  
            string Baseurl = "https://api.github.com/";
   
                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();

                    //Define request data format   
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync(Baseurl + "search/repositories?q=language:" + language);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var Response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    gitRepo = JsonConvert.DeserializeObject<GitRepository>(Response);

                    for (int i = 0; i < 5; i++)
                    {
                        repoList.Add(gitRepo.items.ElementAt(i));
                    }
                    }
                    //returning the employee list to view  
                    return repoList;
                }
            }

        [HttpPost]
        public async Task<ActionResult> Index(string langName)
        {
           string d = langName;
            
            return 
                View(await this.GetRepos(d));
        }

        public ActionResult Details(Item item) {
            //item
            //repoList
            return View(item);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
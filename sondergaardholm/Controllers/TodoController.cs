using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace sondergaardholm.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        public  async Task<ActionResult> Index()
        {   
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("http://192.168.1.35:5001");
                }
                catch(Exception e)
                {
                    return View();
                }                                  
                
            }
                    
            return Redirect("http://192.168.1.35:5001");
        }
    }
}
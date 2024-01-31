using airline.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace airline
{
    public class CustomerController:Controller
    {
        public static List<Customer> custs = new List<Customer>();

        public async Task<ActionResult> ShowCustomers()
        {
            HttpClient client= new HttpClient();
                
            client.DefaultRequestHeaders.Clear();
            //Define request data format  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            HttpResponseMessage Res = await client.GetAsync("http://localhost:5048/api/Customer");

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var response = Res.Content.ReadAsStringAsync().Result;
                
                //Deserializing the response recieved from web api and storing into the Employee list  
                custs = JsonConvert.DeserializeObject<List<Customer>>(response);
            }
            //returning the employee list to view  
            return View(custs);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(Customer c)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(c), 
              Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:5048/api/Customer", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<Customer>(apiResponse);
                }
            }
            return RedirectToAction("ShowCustomers");
        }
        
        [HttpGet]
        public async Task<ActionResult> UpdateCustomer(int id)
        {
            Customer c = new Customer();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5048/api/Customer/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<Customer>(apiResponse);
                }
            }
            return View(c);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateCustomer(Customer c)
        {
            Customer c1 = new Customer();

            using (var httpClient = new HttpClient())
            {
                #region
                //var content = new MultipartFormDataContent();
                //content.Add(new StringContent(reservation.Empid.ToString()), "Empid");
                //content.Add(new StringContent(reservation.Name), "Name");
                //content.Add(new StringContent(reservation.Gender), "Gender");
                //content.Add(new StringContent(reservation.Newcity), "Newcity");
                //content.Add(new StringContent(reservation.Deptid.ToString()), "Deptid");
                #endregion
                int id = c.CustomerId;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(c)
                 , Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:5048/api/Customer/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    c1 = JsonConvert.DeserializeObject<Customer>(apiResponse);
                }
            }
            return RedirectToAction("ShowCustomers");
        }

        [HttpGet]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            TempData["customerid"] = id;
            Customer c = new Customer();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5048/api/Customer/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<Customer>(apiResponse);
                }
            }
            return View(c);
        }

        [HttpPost]
        //[ActionName("DeleteEmployee")]
        public async Task<ActionResult> DeleteCustomer(Customer c)
        {
            int customerid = Convert.ToInt32(TempData["customerid"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5048/api/Customer/" + customerid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("ShowCustomers");
        }

    }
}
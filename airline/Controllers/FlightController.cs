using airline.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace airline
{
    public class FlightController:Controller
    {
        public static List<Flight> flights = new List<Flight>();

        public async Task<ActionResult> ShowFlights()
        {
            HttpClient client= new HttpClient();
                
            client.DefaultRequestHeaders.Clear();
            //Define request data format  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            HttpResponseMessage Res = await client.GetAsync("http://localhost:5048/api/Flight");

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var response = Res.Content.ReadAsStringAsync().Result;
                
                //Deserializing the response recieved from web api and storing into the Employee list  
                flights = JsonConvert.DeserializeObject<List<Flight>>(response);
            }
            //returning the employee list to view  
            return View(flights);
        }

        public ActionResult AddFlight()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddFlight(Flight f)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(f), 
              Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:5048/api/Flight", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    f = JsonConvert.DeserializeObject<Flight>(apiResponse);
                }
            }
            return RedirectToAction("ShowFlights");
        }
        
        [HttpGet]
        public async Task<ActionResult> UpdateFlight(int id)
        {
            Flight f = new Flight();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5048/api/Flight/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    f = JsonConvert.DeserializeObject<Flight>(apiResponse);
                }
            }
            return View(f);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateFlight(Flight f)
        {
            Flight f1 = new Flight();

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
                int id = f.FlightId;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(f)
                 , Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:5048/api/Flight/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    f1 = JsonConvert.DeserializeObject<Flight>(apiResponse);
                }
            }
            return RedirectToAction("ShowFlights");
        }

        [HttpGet]
        public async Task<ActionResult> DeleteFlight(int id)
        {
            TempData["flightid"] = id;
            Flight f = new Flight();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5048/api/Flight/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    f = JsonConvert.DeserializeObject<Flight>(apiResponse);
                }
            }
            return View(f);
        }

        [HttpPost]
        //[ActionName("DeleteEmployee")]
        public async Task<ActionResult> DeleteFlight(Flight f)
        {
            int flightid = Convert.ToInt32(TempData["flightid"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5048/api/Flight/" + flightid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("ShowFlights");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            Flight f = new Flight();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5048/api/Flight/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    f = JsonConvert.DeserializeObject<Flight>(apiResponse);
                }
            }
            return View(f);
        }

        public ActionResult AddBooking(Flight f)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddBooking(Booking b)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(b), 
              Encoding.UTF8, "application/json");

                /*using (var response = await httpClient.PostAsync("http://localhost:5048/api/Flight", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    f = JsonConvert.DeserializeObject<Flight>(apiResponse);
                }*/
            }
            return RedirectToAction("BookingSuccess");
        }  

        public ActionResult BookingSuccess()
        {
            return View();
        }      
    }
}
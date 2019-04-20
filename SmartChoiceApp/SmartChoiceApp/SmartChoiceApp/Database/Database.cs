using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartChoiceApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartChoiceApp.Database
{
    public class Database
    {
        #region Properties
        private static HttpClient Client { get; set; }
        private static string URL { get; set; }
        private readonly string UrlHome = "https://smartchoiceapi.herokuapp.com/";
        object obj { get; set; }
        #endregion

        #region Constructor
        public Database()
        {
            URL = "";
            Client = new HttpClient();
        }
        #endregion

        #region User Functions
        public bool Login()
        {
            return true;
        }

        public bool SignUp()
        {
            return true;
        }
        public void GetUser()
        {

        }
        #endregion

        #region Product Funcions
        public async Task<ProductDetail> GetProductDetail(int ID)
        {
            URL = UrlHome + "checkinformation/" + ID.ToString();
            var httpResponse = await Client.GetAsync(URL);
            var response = await httpResponse.Content.ReadAsStringAsync();
            var product = JObject.Parse(response)["Result"].ToObject<ProductDetail>();
            return product;
        }

        public void GetProductType()
        {

        }

        public async Task<Manufacturer> GetManufacturerDetail(int ID)
        {
            URL = UrlHome + "producers/" + ID.ToString();
            var httpResponse = await Client.GetAsync(URL);
            var response = await httpResponse.Content.ReadAsStringAsync();
            var manufacturer = JObject.Parse(response)["Result"].ToObject<Manufacturer>();
            return manufacturer;
        }

        public async Task<List<PestilentInsect>> GetPestilentInsect(int ID)
        {
            URL = UrlHome + "checkinformation/pestilentinsect/" + ID.ToString();
            var httpResponse = await Client.GetAsync(URL);
            var response = await httpResponse.Content.ReadAsStringAsync();
            var manufacturer = JObject.Parse(response)["Result"].ToObject<List<PestilentInsect>>();
            return manufacturer;
        }

        public void GetReviewList()
        {

        }

        public async Task<bool> AddReview()
        {
            URL = UrlHome + "producers/";
            var httpResponse = await Client.GetAsync(URL);
            var response = await httpResponse.Content.ReadAsStringAsync();
            var manufacturer = JObject.Parse(response)["Result"].ToObject<Manufacturer>();
            if (manufacturer != null)
                return true;
            else
                return false;
        }
        #endregion
        #region Account 
        public async Task<bool> Login(string tendn, string matkhau)
        {
            URL = UrlHome + "users/login";
            obj = new { TenDangNhap = tendn, MatKhau = matkhau };
            var json = JsonConvert.SerializeObject(obj);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await Client.PostAsync(URL, data);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseString = httpResponse.Content.ReadAsStringAsync().Result;
                if(responseString == null || responseString == "{}")
                {
                    return false;
                }
                else
                {
                    var user = JObject.Parse(responseString)["Result"].ToObject<User>();
                    App.mainUser = new User();
                    App.mainUser = user;
                    return true;
                }
            }
            return false;

        }

        public async Task<bool> SignUp(User user)
        {
            URL = UrlHome + "users/";
            var json = JsonConvert.SerializeObject(user);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await Client.PostAsync(URL, data);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseString = httpResponse.Content.ReadAsStringAsync().Result;
                if ((int)JObject.Parse(responseString)["Message"]["affectedRows"] == 1)
                {
                    return true;
                }
                else return false;

            }
            else return false;
        }

        public async Task<bool> CheckExist(string tendangnhap)
        {
            URL = UrlHome + "users/checkexist";
            obj = new { TenDangNhap = tendangnhap }; 
            var json = JsonConvert.SerializeObject(obj);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await Client.PostAsync(URL, data);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseString = httpResponse.Content.ReadAsStringAsync().Result;
                return (bool)JObject.Parse(responseString)["Result"];              
            }
            else return false;
        }

        public async Task<bool> UpdateUser(User user)
        {
            URL = UrlHome + "users";
            var json = JsonConvert.SerializeObject(user);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await Client.PutAsync(URL, data);           
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                if ((int)JObject.Parse(responseString)["Message"]["affectedRows"] == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}

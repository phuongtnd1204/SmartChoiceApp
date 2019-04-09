using Newtonsoft.Json.Linq;
using SmartChoiceApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartChoiceApp.Database
{
    public class Database
    {
        #region Properties
        private static HttpClient Client { get; set; }
        private static string URL { get; set; }
        private readonly string UrlHome = "https://smartchoiceapi.herokuapp.com/";
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
    }
}

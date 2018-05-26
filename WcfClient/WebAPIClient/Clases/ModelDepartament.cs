using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace WebAPIClient
{
    class ModelDepartament
    {
        IViev viev;
        static HttpClient client = new HttpClient();
        public ModelDepartament(IViev Viev)
        {
            client.BaseAddress = new Uri("http://localhost:59851/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new
            MediaTypeWithQualityHeaderValue("application/json"));
            this.viev = Viev;
        }
        #region не актуально
        /// <summary>
        /// Получить весь список департаментов
        /// </summary>
        public async void GetAllDep()
        {
            IEnumerable<Departament> Departaments = await GetDepartamentsAsync(client.BaseAddress +
            "api/Departament");

            viev.DepTemp = Departaments;
        }
        #endregion
        /// <summary>
        /// Получить департамент по айди
        /// </summary>
        public async void GetIdDep(string id)
        {
            try
            {
                List<Departament> Departaments = new List<Departament>();
                if (id != String.Empty)
                {
                    Departament departament = await GetDepartamentAsync(client.BaseAddress +
                        "api/Departament/" + id);
                    if (departament != null)
                        Departaments.Add(departament);
                }
                else
                {
                    Departaments = (List<Departament>)await
                        GetDepartamentsAsync(client.BaseAddress + "api/Departament");
                }
                viev.DepTemp = Departaments;
            }
           catch(Exception)
            {

            }
        }
        /// <summary>
        /// Метод получения списка департаментов с веб сервиса
        /// </summary>
        static async Task<IEnumerable<Departament>> GetDepartamentsAsync(string path)
        {
            IEnumerable<Departament> departaments = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    departaments = await response.Content.ReadAsAsync<IEnumerable<Departament>>();
                }
            }
            catch (Exception)
            {
            }
            return departaments;
        }
        /// <summary>
        /// Метод получения департамента по айди, с веб сервиса
        /// </summary>
        static async Task<Departament> GetDepartamentAsync(string path)
        {
            Departament departament = null;

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                departament = await response.Content.ReadAsAsync<Departament>();
            }
            return departament;
        }
    }
}

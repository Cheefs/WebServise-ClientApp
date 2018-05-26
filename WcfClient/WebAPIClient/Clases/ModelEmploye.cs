using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace WebAPIClient
{
    class ModelEmploye
    {
        IViev viev;
        static HttpClient client = new HttpClient();
        /// <summary>
        /// Базовая конфигурация модели
        /// </summary>
        /// <param name="Viev">реализация интерфейса</param>
        public ModelEmploye(IViev Viev)
        {
            client.BaseAddress = new Uri("http://localhost:59851/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new
            MediaTypeWithQualityHeaderValue("application/json"));
            this.viev = Viev;
        }

        #region не актуально
        /// <summary>
        /// Получить весь список сотрудников 
        /// </summary>
        public async void GetAll()
        {
            IEnumerable<Employe> employes = await GetEmployesAsync(client.BaseAddress +
            "api/Employe");
             viev.EmployeTemp = employes;
        }
        #endregion


        /// <summary>
        /// Получить сотрудника по Айди
        /// </summary>
        public async void GetIdEmpl(string id)
        {
            try
            {
                List<Employe> employes = new List<Employe>();
                if (id != String.Empty)
                {
                    Employe employe = await GetEmployeAsync
                        (client.BaseAddress + "api/Employe/" + id);
                    if (employe != null)
                        employes.Add(employe);
                }
                else
                {
                    employes = (List<Employe>)await GetEmployesAsync(client.BaseAddress + "api/Employe");
                }
                viev.EmployeTemp = employes;
            }
           catch
            {

            }
        }
        /// <summary>
        /// Получение Списка сотрудников с веб сервиса
        /// </summary>

        static async Task<IEnumerable<Employe>> GetEmployesAsync(string path)
        {
            IEnumerable<Employe> employes = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    employes = await response.Content.ReadAsAsync<IEnumerable<Employe>>();
                }
            }
            catch (Exception)
            {
            }
            return employes;
        }
        /// <summary>
        /// Получение сотрудника по айди
        /// </summary>
        static async Task<Employe> GetEmployeAsync(string path)
        {
            Employe employe = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                employe = await response.Content.ReadAsAsync<Employe>();
            }
            return employe;
        }
    }
}

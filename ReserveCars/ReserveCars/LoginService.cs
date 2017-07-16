using Newtonsoft.Json;
using ReserveCars.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ReserveCars
{
    class LoginService
    {
        private const string URL = "https://aluracar.herokuapp.com/login";

        public async Task DoLogin(string email, string password)
        {
            var client = new HttpClient();
            HttpResponseMessage response = null;

            try
            {
                response = await client.PostAsync(URL, this.PrepareData(email, password));
            }
            catch
            {
                MessagingCenter.Send<LoginException>(new LoginException("Error accessing the server"), "LoginError");
            }

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<LoginResultDTO>(result);

                MessagingCenter.Send<User>(new User() {
                    Id = json.usuario.id,
                    Name = json.usuario.nome,
                    Email = json.usuario.email,
                    Phone = json.usuario.telefone
                }, "LoginSuccess");
            }
            else
            {
                MessagingCenter.Send<LoginException>(new LoginException("User or Password incorrect"), "LoginError");
            }
        }

        private FormUrlEncodedContent PrepareData(string email, string password)
        {
            return new FormUrlEncodedContent(new[] {
                 new KeyValuePair<string, string>("email", "joao@alura.com.br"),
                 new KeyValuePair<string, string>("senha", "alura123")
            });
        }
    }

    public class LoginException : Exception
    {
        public LoginException(string message) : base(message){}
    }

    class LoginResultDTO
    {
        public UserLoginDTO usuario { get; set; }
    }

    class UserLoginDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
    }
}

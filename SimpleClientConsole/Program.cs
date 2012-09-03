using System;
using System.Net.Http;
using ContactWebPack;

namespace SimpleClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();


            var response = client.GetAsync("http://localhost:9100/Contact/1").Result;
            var contact  = response.Content.ReadAsAsync<Contact>(Formatters.Available).Result;

            Console.WriteLine("{0} {1}",contact.FirstName,contact.LastName);


            var newContact = new Contact
            {
                FirstName = "Brian",
                LastName = "Buck"
            };

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://localhost:9100/Contact");
            requestMessage.Content = new ObjectContent<Contact>(newContact, new WebPackContactXmlFormatter(), Formatters.XML);
            response = client.SendAsync(requestMessage).Result;

            contact = response.Content.ReadAsAsync<Contact>(Formatters.Available).Result;
            Console.WriteLine("{0} {1}", contact.FirstName, contact.LastName);

            Console.Read();
        }
    }
}

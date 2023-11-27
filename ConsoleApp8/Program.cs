using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    static async Task Main()
    {
        string posilannya = "https://jsonplaceholder.typicode.com/todos/1"; //взяв просту версію
        using (HttpClient httpClient = new HttpClient())
        {
            try
            {
                HttpResponseMessage zapros = await httpClient.GetAsync(posilannya);
                if (zapros.IsSuccessStatusCode)
                {
               
                    string bodyofzapros = await zapros.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(bodyofzapros);
                    Console.WriteLine($"We have next data: ");
                    Console.WriteLine($"");
                    Console.WriteLine($"Id of User: {result.userId}");
                    Console.WriteLine($"ID: {result.id}");
                    Console.WriteLine($"Title: {result.title}");
                    Console.WriteLine($"Completed: {result.completed}");
                }
                else
                {
                    Console.WriteLine($"Error: {zapros.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

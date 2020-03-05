using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace tutorial1
{
    public class Program
    {
       public static async Task Main(string[] args)
        {
            var websiteurl = args[0];
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(websiteurl);
            if (response.IsSuccessStatusCode)
            {
                var htmlcontent = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z0-9-]+[a-z0-9]*@[a-z0-9-]+\\.[a-z]+", RegexOptions.IgnoreCase);
                var matches = regex.Matches(htmlcontent);
                foreach (var emailAdress in matches)
                {
                    Console.WriteLine(emailAdress);
                    
                }
            }
            Console.ReadKey();
        }
    }
}

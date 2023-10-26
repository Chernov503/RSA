using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    public static class RandomNumber
    {
        public static async Task<int> GetRandomNumber()
        {
            int result;
            using (HttpClient client = new HttpClient())
            {
                string url = "https://www.random.org/integers/?num=1&min=1&max=100&col=1&base=10&format=plain&rnd=new";
                HttpResponseMessage answer = await client.GetAsync(url);
                if (answer.IsSuccessStatusCode)
                {


                    string buff = await answer.Content.ReadAsStringAsync();
                    result = Convert.ToInt32(buff);



                }
                else
                {
                    Console.WriteLine("Рандомайзер не отвечает");
                    Console.ReadKey();
                    result = new Random().Next(100);

                }
            }
            return result;
        }
    }
}

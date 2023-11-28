using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class Bacsi
    {
        public string ma_lien_thong_co_so_kham_chua_benh { get; set; }
        public string password { get; set; }
        public List<string> Token {  get; set; }
    }
    public class Root
    {
        public List<Bacsi> Bacsis { get; set; }
    }
     class Program
    {
        static void Main(string[] args)
        {
            string link = "https://api.donthuocquocgia.vn/api/auth/dang-nhap-co-so-kham-chua-benh";

            WebRequest req = WebRequest.Create(link);
            req.Method = "POST";
            req.ContentType = "application/json";
            WebResponse res = req.GetResponse();

            using (Stream dataStream = res.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                
                Root root = JsonConvert.DeserializeObject<Root>(responseFromServer);

                foreach(Bacsi s in root.Bacsis)
                {
                    Console.WriteLine(s.ma_lien_thong_co_so_kham_chua_benh + "" + s.password +"" );
                    for(int i = 0; i < s.Token.Count; i++)
                    {
                        Console.WriteLine(s.Token[i]);
                    }    
                }    
            }
            Console.ReadLine();
        }
    }
}

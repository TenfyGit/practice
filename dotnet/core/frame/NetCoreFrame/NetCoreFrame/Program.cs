using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:5000/");
            httpListener.Start();
            while (true)
            {
                var context =  httpListener.GetContextAsync().Result;
                 context.Response.OutputStream.Write(Encoding.UTF8.GetBytes("Hello World"));
                context.Response.Close();
            }
        }
    }
}

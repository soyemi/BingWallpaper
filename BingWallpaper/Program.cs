using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Web;
using System.IO;
using System.Xml;

namespace BingWallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uriBing = new Uri("http://cn.bing.com/HPImageArchive.aspx?idx=0&n=1");
            WebRequest webRequest = WebRequest.Create(uriBing);
            WebResponse webResponse = webRequest.GetResponse();
            Stream stream = webResponse.GetResponseStream();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(stream);


            string picturePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string wallpaperSavePath = picturePath + "\\Bing\\";

            //check folder
            if(!Directory.Exists(wallpaperSavePath))
            {
                Directory.CreateDirectory(wallpaperSavePath);
            }

            string fullStartDate = xmldoc["images"]["image"]["fullstartdate"].InnerText;
            string urlBase = xmldoc["images"]["image"]["urlBase"].InnerText;

            string curImagePath = wallpaperSavePath + fullStartDate + ".jpg";

            if (File.Exists(curImagePath))
            {
                Console.WriteLine("skip download!");
            }
            else
            {
                string downloadUrl = "http://www.bing.com" + urlBase + "_1920x1080.jpg";
                WebClient webClient = new WebClient();

                try
                {
                    webClient.DownloadFile(downloadUrl, @curImagePath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Wallpaper.SetWallPaper(curImagePath);

            Console.WriteLine("done!");

            Environment.Exit(0);
        }

    }
}

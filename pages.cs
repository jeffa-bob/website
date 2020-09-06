using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace pdf2.web
{
  public class Page
  {
    private XmlDocument pagexml = new XmlDocument();
    public string page;

    public Page(string url)
    {
      string urlAddress = url;

      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
      HttpWebResponse response = (HttpWebResponse)request.GetResponse();

      if (response.StatusCode == HttpStatusCode.OK)
      {
        Stream receiveStream = response.GetResponseStream();
        StreamReader readStream = null;

        if (String.IsNullOrWhiteSpace(response.CharacterSet))
          readStream = new StreamReader(receiveStream);
        else
          readStream = new StreamReader(receiveStream, System.Text.Encoding.GetEncoding(response.CharacterSet));

        page = readStream.ReadToEnd();
        pagexml.LoadXml(page);

        response.Close();
        readStream.Close();
      }
    }
  }
}

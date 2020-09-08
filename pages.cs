using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

namespace pdf2.web
{
    public class Page
    {
        private XmlDocument pagexml = new XmlDocument();
        public string page;
        public MarkupString pagemark { get { return new MarkupString(page); } }
        public string urlAddress;


        public Page(string? url, string? @page = null)
        {
            if (url == null)
            {
                page = "#document\n<!DOCTYPE html>\n<html>\n<body>\nNOT VALID\n</body>\n</html>";
                pagexml.LoadXml(page);
                return;
            }

            urlAddress = url;

            if (@page != null)
            {
                this.page = @page;
                pagexml.LoadXml(page);
                return;
            }
        }
    }
}

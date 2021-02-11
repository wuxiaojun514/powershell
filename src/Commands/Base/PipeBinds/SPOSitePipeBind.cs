using System;
using System.Management.Automation;
using PnP.PowerShell.Commands.Model;

namespace PnP.PowerShell.Commands.Base.PipeBinds
{
    public class SPOSitePipeBind
    {
        private string _url;

        public string Url => _url;

        public SPOSitePipeBind(string url)
        {
            _url = url;
        }   

        public SPOSitePipeBind(Uri uri)
        {
            _url = uri.AbsoluteUri;
        }

        public SPOSitePipeBind(SPOSite site)
        {
            if(string.IsNullOrEmpty(site.Url))
            {
                throw new PSArgumentException("Site Url must be specified");
            }
            _url = site.Url;
        }

        
    }
}
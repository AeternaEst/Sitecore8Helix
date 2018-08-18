using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web;

namespace Sitecore8Helix.Website.SolrNet_Integration
{
    public class SharedServiceLocator : IServiceLocator
    {
        private const string SitecoreSolrDll = "Sitecore.ContentSearch.SolrProvider";
        IServiceLocator _sitecoreLocator;
        IServiceLocator _solrLocator;

        public SharedServiceLocator(IServiceLocator solrLocator)
        {
            _solrLocator = solrLocator;
        }

        public void SetSitecoreServiceLocator(IServiceLocator sitecoreLocator)
        {
            _sitecoreLocator = sitecoreLocator;
        }

        public object GetService(Type serviceType)
        {
            return (Assembly.GetCallingAssembly().FullName.StartsWith(SitecoreSolrDll) ? _sitecoreLocator : _solrLocator).GetInstance(serviceType);
        }

        public object GetInstance(Type serviceType)
        {
            return (Assembly.GetCallingAssembly().FullName.StartsWith(SitecoreSolrDll) ? _sitecoreLocator : _solrLocator).GetInstance(serviceType);
        }

        public object GetInstance(Type serviceType, string key)
        {
            return (Assembly.GetCallingAssembly().FullName.StartsWith(SitecoreSolrDll) ? _sitecoreLocator : _solrLocator).GetInstance(serviceType, key);
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return (Assembly.GetCallingAssembly().FullName.StartsWith(SitecoreSolrDll) ? _sitecoreLocator : _solrLocator).GetAllInstances(serviceType);
        }

        public TService GetInstance<TService>()
        {
            return (Assembly.GetCallingAssembly().FullName.StartsWith(SitecoreSolrDll) ? _sitecoreLocator : _solrLocator).GetInstance<TService>();
        }

        public TService GetInstance<TService>(string key)
        {
            return (Assembly.GetCallingAssembly().FullName.StartsWith(SitecoreSolrDll) ? _sitecoreLocator : _solrLocator).GetInstance<TService>(key);
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return (Assembly.GetCallingAssembly().FullName.StartsWith(SitecoreSolrDll) ? _sitecoreLocator : _solrLocator).GetAllInstances<TService>();
        }
    }
}
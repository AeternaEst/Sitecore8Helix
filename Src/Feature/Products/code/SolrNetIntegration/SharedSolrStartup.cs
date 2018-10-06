using Microsoft.Practices.ServiceLocation;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SolrProvider;
using Sitecore.ContentSearch.SolrProvider.DocumentSerializers;
using Sitecore.ContentSearch.SolrProvider.Parsers;
using Sitecore.ContentSearch.SolrProvider.SolrNetIntegration;
using SolrNet;
using SolrNet.Impl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sitecore8Helix.Feature.Products.SolrNetIntegration
{
    public class SharedSolrStartUp : ISolrStartUp, IProviderStartUp
    {
        private readonly DefaultSolrLocator<Dictionary<string, object>> operations;

        private readonly ISolrCache solrCache;

        protected internal virtual DefaultSolrLocator<Dictionary<string, object>> Operations => operations;

        private SharedServiceLocator _sharedServiceLocator;

        public SharedSolrStartUp(SharedServiceLocator sharedServiceLocator)
        {
            if (SolrContentSearchManager.EnableHttpCache)
            {
                solrCache = new HttpRuntimeCache();
            }
            operations = new DefaultSolrLocator<Dictionary<string, object>>();
            _sharedServiceLocator = sharedServiceLocator;
        }

        public virtual void AddCore(string coreId, Type documentType, string coreUrl)
        {
            ISolrConnection connection = CreateConnection(coreUrl);
            Operations.AddCore(coreId, documentType, coreUrl, connection);
        }

        public virtual void Initialize()
        {
            if (!SolrContentSearchManager.IsEnabled)
            {
                throw new InvalidOperationException("Solr configuration is not enabled. Please check your settings and include files.");
            }
            Operations.DocumentSerializer = new SolrFieldBoostingDictionarySerializer(Operations.FieldSerializer);
            Operations.HttpWebRequestFactory = SolrContentSearchManager.HttpWebRequestFactory;
            Operations.SchemaParser = new SolrSchemaParser();
            foreach (string core in SolrContentSearchManager.Cores)
            {
                AddCore(core, typeof(Dictionary<string, object>), $"{SolrContentSearchManager.ServiceAddress}/{core}");
            }
            if (SolrContentSearchManager.EnableHttpCache)
            {
                Operations.HttpCache = solrCache;
            }
            Operations.CoreAdmin = BuildCoreAdmin();

            _sharedServiceLocator.SetSitecoreServiceLocator(new DefaultServiceLocator<Dictionary<string, object>>(this.Operations));
            ServiceLocator.SetLocatorProvider(() => _sharedServiceLocator);

            SolrContentSearchManager.SolrAdmin = Operations.CoreAdmin;
            SolrContentSearchManager.Initialize();
        }

        public virtual bool IsSetupValid()
        {
            if (!SolrContentSearchManager.IsEnabled)
            {
                return false;
            }
            ISolrCoreAdminEx admin = BuildCoreAdmin();
            return (from defaultIndex in SolrContentSearchManager.Cores
                    select admin.Status(defaultIndex).First()).All((CoreResult status) => status.Name != null);
        }

        protected virtual ISolrCoreAdminEx BuildCoreAdmin()
        {
            ISolrConnection connection = CreateConnection(SolrContentSearchManager.ServiceAddress);
            return Operations.BuildCoreAdmin(connection);
        }

        protected virtual ISolrConnection CreateConnection(string serverUrl)
        {
            SolrConnection solrConnection = new SolrConnection(serverUrl);
            solrConnection.Timeout = SolrContentSearchManager.ConnectionTimeout;
            if (solrCache != null)
            {
                solrConnection.Cache = solrCache;
            }
            return solrConnection;
        }
    }
}
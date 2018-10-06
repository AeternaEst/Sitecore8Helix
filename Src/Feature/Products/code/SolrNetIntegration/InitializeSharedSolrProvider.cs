using Microsoft.Practices.ServiceLocation;
using Sitecore.ContentSearch.SolrProvider;
using Sitecore.ContentSearch.SolrProvider.SolrNetIntegration;
using Sitecore.Pipelines;
using Sitecore8Helix.Feature.Products.Models;
using SolrNet;

namespace Sitecore8Helix.Feature.Products.SolrNetIntegration
{
    public class InitializeSharedSolrProvider
    {
        public void Process(PipelineArgs args)
        {
            if (!SolrContentSearchManager.IsEnabled) return;

            if (IntegrationHelper.IsSolrConfigured())
            {
                IntegrationHelper.ReportDoubleSolrConfigurationAttempt(this.GetType());
            }
            else
            {
                Startup.Init<ProductSearchResultItem>("http://127.0.0.1:8983/solr/sitecore_master_index");

                //Place any custom SolrNet init prior to this line
                var sharedSolrStartUp = new SharedSolrStartUp(new SharedServiceLocator(ServiceLocator.Current));

                //init Sitecore's solr
                sharedSolrStartUp.Initialize();
            }
        }
    }
}
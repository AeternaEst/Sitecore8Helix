using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ninject;

namespace Sitecore8Helix.Foundation.IoC.DependencyInjection
{
    public static class Registration
    {
        public static IKernel GetKernel()
        {
            var kernel = new StandardKernel();

            #region Assemblies Load
            var foundationSearchAssembly = Assembly.Load("Sitecore8Helix.Foundation.Search");
            var featureStoresAssembly = Assembly.Load("Sitecore8Helix.Feature.Stores");
            var foundationPresentationAssembly = Assembly.Load("Sitecore8Helix.Foundation.Presentation");
            #endregion

            #region Handles
            var searchProductsHandle = foundationSearchAssembly.GetType("Sitecore8Helix.Foundation.Search.Handles.SearchProductsHandle");
            var searchSolrNetProductsHandle = foundationSearchAssembly.GetType("Sitecore8Helix.Foundation.Search.Handles.SearchSolrNetProductsHandle");
            var searchStoresHandle = featureStoresAssembly.GetType("Sitecore8Helix.Feature.Stores.Handles.SearchStoresHandle");

            kernel.Bind(searchProductsHandle).To(searchProductsHandle);
            kernel.Bind(searchSolrNetProductsHandle).To(searchSolrNetProductsHandle);
            kernel.Bind(searchStoresHandle).To(searchStoresHandle);
            #endregion

            #region Services
            var iSearchService = foundationSearchAssembly.GetType("Sitecore8Helix.Foundation.Search.Interfaces.ISearchService");
            var searchService = foundationSearchAssembly.GetType("Sitecore8Helix.Foundation.Search.Services.SearchService");
            var iPresentationService = foundationPresentationAssembly.GetType("Sitecore8Helix.Foundation.Presentation.Interfaces.IPresentationService");
            var presentationService = foundationPresentationAssembly.GetType("Sitecore8Helix.Foundation.Presentation.Services.PresentationService");

            kernel.Bind(iSearchService).To(searchService);
            kernel.Bind(iPresentationService).To(presentationService);
            #endregion

            return kernel;
        } 
    }
}
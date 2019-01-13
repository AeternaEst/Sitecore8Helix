using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.SecurityModel;

namespace Sitecore8Helix.Feature.News.Providers
{
    public class NewsItemProvider : ItemProvider
    {
        public override Item AddFromTemplate(string itemName, ID templateId, Item destination, ID newId)
        {
            if(destination.TemplateID == new ID("{8182D5C2-53F3-47DF-88E2-BD9D8EB88A2F}") &&
               templateId == new ID("{12BB53A5-F967-4CD0-8BE3-215EE251A3D3}"))
                return base.AddFromTemplate(itemName, templateId, GetNewsItemDestination(destination), newId);

            return base.AddFromTemplate(itemName, templateId, destination, newId);           
        }

        private Item GetNewsItemDestination(Item newsRoot)
        {
            var year = DateTime.Now.ToString("yyyy", CultureInfo.InvariantCulture);
            var month = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
            Item newDestination;

            using (new SecurityDisabler())
            {
                var yearFolder = newsRoot.Children.FirstOrDefault(child => child.Name == year) ??
                                 newsRoot.Add(year, new TemplateID(new ID("{A87A00B1-E6DB-45AB-8B54-636FEC3B5523}")));
                var monthFolder = yearFolder.Children.FirstOrDefault(child => child.Name == month) ??
                                  yearFolder.Add(month, new TemplateID(new ID("{A87A00B1-E6DB-45AB-8B54-636FEC3B5523}")));

                newDestination = monthFolder;
            }

            return newDestination;
        }
    }
}
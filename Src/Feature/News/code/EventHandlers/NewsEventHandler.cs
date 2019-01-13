using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Events;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Events;
using Sitecore.SecurityModel;

namespace Sitecore8Helix.Feature.News.EventHandlers
{
    public class NewsEventHandler
    {
        protected void OnNewsCreating(object sender, EventArgs args)
        {
            return;

            if (args != null)
            {
                var eventArgs = Event.ExtractParameter(args, 0) as ItemCreatingEventArgs;
                if (eventArgs != null && eventArgs.Parent.TemplateID == new ID("{8182D5C2-53F3-47DF-88E2-BD9D8EB88A2F}"))
                {
                    var year = DateTime.Now.ToString("yyyy", CultureInfo.InvariantCulture);
                    var month = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
                    var newsRoot = eventArgs.Parent;

                    using (new SecurityDisabler())
                    {
                        var yearFolder = newsRoot.Add(year,
                            new TemplateID(new ID("{A87A00B1-E6DB-45AB-8B54-636FEC3B5523}")));
                        var monthFolder = yearFolder.Add(month,
                            new TemplateID(new ID("{A87A00B1-E6DB-45AB-8B54-636FEC3B5523}")));

                        //eventArgs.Parent = monthFolder;
                        
                    }
                }
            }
        }

        protected void OnNewsAdded(object sender, EventArgs args)
        {
            if (args != null)
            {
                Item item = Event.ExtractParameter(args, 0) as Item;
                if (item != null && item.TemplateID == new ID("{A87A00B1-E6DB-45AB-8B54-636FEC3B5523}"))
                {
                    var db = Database.GetDatabase("master");
                    var newsRoot = db.GetItem(new ID("{C53443A2-91B3-4C89-9999-68980BE78D03}"));
                    if (newsRoot != null && item.Axes.IsDescendantOf(newsRoot) &&
                        item.Name.All(char.IsLetter) &&
                        string.IsNullOrEmpty(item[new ID("{BA3F86A2-4A1C-4D78-B63D-91C2779C1B5E}")]))
                    {
                        string[] monthNames = CultureInfo.InvariantCulture.DateTimeFormat.MonthNames;
                        int monthIndex = Array.IndexOf(monthNames, item.Name);
                        using (new SecurityDisabler())
                        {
                            item.Editing.BeginEdit();

                            item[new ID("{BA3F86A2-4A1C-4D78-B63D-91C2779C1B5E}")] = monthIndex.ToString();

                            item.Editing.EndEdit();
                        }
                    }
                }

                //if (item != null && item.TemplateID == new ID("{12BB53A5-F967-4CD0-8BE3-215EE251A3D3}"))
                //{
                //    Item myItem = item; //TODO: set to the appropriate item
                //    string load = String.Concat(new object[] { "item:load(id=", myItem.ID, ",language=", myItem.Language, ",version=", myItem.Version, ")" });
                //    Sitecore.Context.ClientPage.SendMessage(this, load);
                //    String refresh = String.Format("item:refreshchildren(id={0})", myItem.Parent.ID);
                //    Sitecore.Context.ClientPage.ClientResponse.Timer(refresh, 2000);
                //}
            }
        }

        protected void OnNewsSaving(object sender, EventArgs args)
        {
            Item item = Event.ExtractParameter(args, 0) as Item;

            if (item != null && item.TemplateID == new ID("{12BB53A5-F967-4CD0-8BE3-215EE251A3D3}"))
            {
                var itemBeforeSave = item.Database.GetItem(item.ID, item.Language, item.Version);
                if (itemBeforeSave != null)
                {
                    var updatedDateField = (DateField)item.Fields[new ID("{A9519CDD-C9A4-47B5-8E5F-70EF21A07CC1}")];
                    var beforeSaveDateField = (DateField)itemBeforeSave.Fields[new ID("{A9519CDD-C9A4-47B5-8E5F-70EF21A07CC1}")];

                    if (updatedDateField.DateTime != beforeSaveDateField.DateTime) //User updated date
                    {
                        var yearFolderName = item.Parent.Parent.Name;
                        var monthFolderName = item.Parent.Name;
                        var updatedYear = updatedDateField.DateTime.ToString("yyyy", CultureInfo.InvariantCulture);
                        var updatedMonth = updatedDateField.DateTime.ToString("MMMM", CultureInfo.InvariantCulture);

                        if (updatedYear != yearFolderName || updatedMonth != monthFolderName)
                        {
                            moveNewsItem(item, updatedYear, updatedMonth);
                        }
                    }
                }
            }
        }

        private void moveNewsItem(Item item, string updatedYear, string updatedMonth)
        {
            var newsRoot = item.Database.GetItem(new ID("{C53443A2-91B3-4C89-9999-68980BE78D03}"));
            var yearFolder = newsRoot.Children.FirstOrDefault(child => child.Name == updatedYear) ??
                             newsRoot.Add(updatedYear, new TemplateID(new ID("{A87A00B1-E6DB-45AB-8B54-636FEC3B5523}")));
            var monthFolder = yearFolder.Children.FirstOrDefault(child => child.Name == updatedMonth) ??
                              yearFolder.Add(updatedMonth, new TemplateID(new ID("{A87A00B1-E6DB-45AB-8B54-636FEC3B5523}")));

            item.MoveTo(monthFolder);
        }
    }
}
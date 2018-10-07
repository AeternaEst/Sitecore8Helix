# Sitecore8Helix

<h1>About</h1>
Sitecore test project that is primarily for experimenting with Solr, Unicorn and Helix.
Contains some basic searching and faceting with solr using both SolrNet and the Content Search API.
Right now all views and config files are located in the Sitecore8Helix.Website project which is incorrect for Helix.
Needs to implement a custom build process so views and config files can be copied from Features and Foundation projects.

<h1>Setup</h1>
<ol>
  <li>Install Solr 6.6.5</li>
  <li>Setup a local Sitecore 8.2 170407</li>
  <li>Syncronize Unicorn Items</li>
  <li>Reindex from Sitecore</li>
</ol>

<h3>Search With Content Search API</h3>
<ul>
  <li>/products?Filters=product_category_s=cloth</li>
  <li>/products?Filters=product_category_s=cloth|product_type_s=shoes</li>
  <li>/products?Filters=product_category_s=cloth,electronics</li>
</ul>

<h3>Search with SolrNet</h3>
<ul>
  <li>/solrnetproducts?Filters=product_category_s=cloth</li>
  <li>/solrnetproducts?Filters=product_category_s=cloth,electronics</li>
  <li>/solrnetproducts?Filters=product_category_s=cloth,electronics|product_type_s=shoes,t-shirt</li>
</ul>

<h1>TODO</h1>
Needs to implement a custom build process so views and config files can be copied from Features and Foundation projects.<br>
Add ex and tag to Content Search API so you can exclude facets.

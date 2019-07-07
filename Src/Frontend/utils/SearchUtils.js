

export function mergeFacets(facets, selectedFacets) {
    return facets.map(facet => {
        facet.values = facet.values.map(facetValue => {
            const containsFacet = selectedFacets.find(selectedFacet => selectedFacet.facetKey === facet.key);
            return {
                key: facetValue.key,
                count: facetValue.count,
                selected: containsFacet && containsFacet.facetValues.find(selectedFacetValue => selectedFacetValue === facetValue.key)
            }
        });
        return facet;
    });
} 
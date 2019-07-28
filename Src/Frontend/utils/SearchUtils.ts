import { FacetResult, SelectedFacet } from "../types/Facets";

interface MergedFacet {
    key: string;
    values: MergedFacetValue[];
}

interface MergedFacetValue {
    key: string;
    count: number;
    selected: string | undefined;
}

export function mergeFacets(facets: FacetResult[], selectedFacets: SelectedFacet[]): MergedFacet[] {
    return facets.map(facet => {
        const mergedFacet: MergedFacet = {
            key: facet.key,
            values: facet.values.map(facetValue => {
                const containsFacet = selectedFacets.find(selectedFacet => selectedFacet.facetKey === facet.key);
                const mergedFacetValue: MergedFacetValue = {
                    key: facetValue.key,
                    count: facetValue.count,
                    selected: containsFacet && containsFacet.facetValues.find(selectedFacetValue => selectedFacetValue === facetValue.key)
                }
                return mergedFacetValue;
            })
        }
        return mergedFacet;
    });
} 

export interface SelectedFacet {
    facetKey: string;
    facetValues: string[];
}

export interface FacetResult {
    key: string;
    values: FacetValue[];
}

interface FacetValue {
    key: string;
    count: number;
}
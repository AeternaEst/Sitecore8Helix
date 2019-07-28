import { Product } from "./Product";
import { FacetResult } from "./Facets";

export interface SearchResults {
    facetResults: FacetResult[];
    hits: number;
    results: Product[];
}
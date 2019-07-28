import * as React from 'react';
import { SelectedFacet } from '../../types/Facets';

export interface SelectedFacetsProps {
    selectedFacets: SelectedFacet[];
    onFacetSelect: (facetKey: string, facetValue: string) => void;
}

const SelectedFacets = (props: SelectedFacetsProps) => {
    const { selectedFacets, onFacetSelect } = props;
    return (
        <div className="selected-facets">
            {
                selectedFacets.map(selectedFacet => (
                    <div key={selectedFacet.facetKey}>
                        {
                            selectedFacet.facetValues.map(selectedFacetValue => (
                                <div key={selectedFacetValue} className="selected-facets__selected-facet" onClick={() => onFacetSelect(selectedFacet.facetKey, selectedFacetValue)}>
                                    {selectedFacetValue}
                                </div>
                            ))
                        }
                    </div>
                    
                ))
            }
        </div>
    );
}

export default SelectedFacets;
import * as React from 'react';

const SelectedFacets = props => {
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
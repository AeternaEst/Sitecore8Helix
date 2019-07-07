import React from 'react';
import SelectedFacets from './SelectedFacets';
import { mergeFacets } from '../../utils/SearchUtils';

const Facets = props => {
    const { facets, selectedFacets, onFacetSelect } = props;

    if(!facets)
        return (<p>No Facets</p>);

    const mergedFacets = mergeFacets(facets, selectedFacets);

    return (
        <div className="facets">
            {
                mergedFacets.map(facet => (
                    <select key={facet.key} multiple name={facet.key} onClick={event => onFacetSelect(facet.key, event.target.value)}>
                        {
                            facet.values.map(facetValue => (
                                <option key={facetValue.key} value={facetValue.key}>{facetValue.key} ({facetValue.count})
                                    {facetValue.selected ? "+" : "-"}
                                </option>
                            ))
                        }
                    </select>
                ))
            }
            <SelectedFacets selectedFacets={selectedFacets} onFacetSelect={onFacetSelect}/>
        </div>
    )
} 

export default Facets;
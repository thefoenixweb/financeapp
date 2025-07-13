/* eslint-disable no-unreachable */
import React, { JSX } from 'react'
import Card from '../Card/Card.tsx';
import { CompanySearch } from '../../../company';
//needed for ID and key values
import { v4 as uuidv4 } from "uuid";

interface Props {
  searchResults: CompanySearch[];
}

const CardList: React.FC<Props> = ({searchResults}: Props): JSX.Element => {
  console.log("[CardList] searchResults:", searchResults);
  
  return (
    /**STATIC RENDERS */
    // <div>
    //     <Card companyName="Apple" ticker='AAPL' price={100}/>
    //     <Card companyName="Microsoft" ticker='MSFT' price={150}/>
    //     <Card companyName="Tesla" ticker='TSLA' price={300}/>
    // </div>

    <>
    {/* if there are results  */}
      {searchResults.length > 0 ? (

        // if results are found then map over them and display card

        searchResults.map((result) => {
          console.log("[CardList] Processing result:", result);
          console.log("[CardList] Result symbol:", result.symbol);
          console.log("[CardList] Result symbol type:", typeof result.symbol);
          
          return (
            <Card 
              key={uuidv4()} 
              searchResult={result} 
            />
          );
        })
        
      ): (
        <p className="mb-3 mt-3 text-xl font-semibold text-center md:text-xl">
        No results!
      </p>

      )}
    </>)
  
};

export default CardList;
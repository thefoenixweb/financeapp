import React from 'react'
import "./Card.css";
import { Link } from 'react-router-dom';
import { CompanySearch } from '../../../company';
import AddPortfolio from '../Portfolio/AddPortfolio/AddPortfolio';

/**The interface tells us the details that are going into the cards */
type Props = {
  searchResult: CompanySearch;
}

const Card: React.FC<Props> = ({ searchResult }: Props): JSX.Element => {
  if (!searchResult || !searchResult.symbol) {
    return <div>Invalid search result</div>;
  }

  const symbol = String(searchResult.symbol);

  return (
    <div className="flex flex-col justify-between h-full rounded-lg border shadow-sm p-6 bg-neutral-800 border-neutral-700 light-mode:bg-white light-mode:border-gray-200">
      <div className="flex flex-col">
        <Link to={`/company/${symbol}/company-profile`} className="mb-4 text-xl font-semibold text-neutral-100 light-mode:text-neutral-900">
          {searchResult.name} ({symbol})
        </Link>
        <p className="text-neutral-400 light-mode:text-gray-500">{searchResult.currency} {searchResult.exchangeShortName}</p>
      </div>
      <AddPortfolio symbol={symbol} />
    </div>
  );
};

export default Card;
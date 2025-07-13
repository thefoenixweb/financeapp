import React from 'react';
import { CompanyBalanceSheet } from '../../../company';
import { formatLargeMonetaryNumber } from '../../Helpers/NumberFormatting';
import Table from '../Table/Table';

interface Props {
  balanceSheet: CompanyBalanceSheet[];
}

const BalanceSheet = ({ balanceSheet }: Props) => {
  const config = [
    {
      Label: "Date",
      render: (company: CompanyBalanceSheet) => company.date,
    },
    {
      Label: "Total Assets",
      render: (company: CompanyBalanceSheet) => formatLargeMonetaryNumber(company.totalAssets),
    },
    {
      Label: "Total Liabilities",
      render: (company: CompanyBalanceSheet) => formatLargeMonetaryNumber(company.totalLiabilities),
    },
    {
      Label: "Total Equity",
      render: (company: CompanyBalanceSheet) => formatLargeMonetaryNumber(company.totalStockholdersEquity),
    },
  ];

  return (
    <div>
      <Table data={balanceSheet} config={config} />
    </div>
  );
};

export default BalanceSheet;
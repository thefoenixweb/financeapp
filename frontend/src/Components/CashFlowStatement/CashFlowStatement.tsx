import React, { useEffect, useState } from 'react'
import { CompanyCashFlow } from '../../../company';
import { useOutletContext } from 'react-router-dom';
import { getCashFlowStatement } from '../../api.tsx';
import Table from '../Table/Table.tsx';
import Spinner from '../Spinner/Spinner.tsx';
import { formatLargeMonetaryNumber } from '../../Helpers/NumberFormatting.tsx';

interface ContextType {
    ticker: string;
}

const config = [
  {
    Label: "Date",
    render: (company: CompanyCashFlow) => company.date,
  },
  {
    Label: "Operating Cashflow",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.operatingCashFlow),
  },
  {
    Label: "Investing Cashflow",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.netCashUsedForInvestingActivites),
  },
  {
    Label: "Financing Cashflow",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(
        company.netCashUsedProvidedByFinancingActivities
      ),
  },
  {
    Label: "Cash At End of Period",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.cashAtEndOfPeriod),
  },
  {
    Label: "CapEX",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.capitalExpenditure),
  },
  {
    Label: "Issuance Of Stock",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.commonStockIssued),
  },
  {
    Label: "Free Cash Flow",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.freeCashFlow),
  },
  ];

  //Is making 240 calls for some reason?
const CashflowStatement = () => {
    const context = useOutletContext<ContextType | undefined>();
    const ticker = context?.ticker;

    if (!ticker) {
        return <Spinner />;
    }

    const [cashflowData, setCashflow] = useState<CompanyCashFlow[]>()

    useEffect(() => {

        //we wrap the await with a async function
        const fetchCashflow = async () => {
            const result = await getCashFlowStatement(ticker);
            setCashflow(result!.data)
        }
        fetchCashflow()
        
    },[ticker])
  return (
    <>
      {cashflowData ? (
        <Table config={config} data={cashflowData}/>
      ) : (
        // <h1>No Results</h1>
        <Spinner />
      )}
    </>
  )
}

export default CashflowStatement
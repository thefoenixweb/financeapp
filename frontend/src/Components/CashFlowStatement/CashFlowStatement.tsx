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
    label: "Date",
    render: (company: CompanyCashFlow) => company.date,
  },
  {
    label: "Operating Cashflow",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.operatingCashFlow),
  },
  {
    label: "Investing Cashflow",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.netCashUsedForInvestingActivites),
  },
  {
    label: "Financing Cashflow",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(
        company.netCashUsedProvidedByFinancingActivities
      ),
  },
  {
    label: "Cash At End of Period",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.cashAtEndOfPeriod),
  },
  {
    label: "CapEX",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.capitalExpenditure),
  },
  {
    label: "Issuance Of Stock",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.commonStockIssued),
  },
  {
    label: "Free Cash Flow",
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
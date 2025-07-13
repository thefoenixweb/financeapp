import React, { useEffect, useState } from 'react'
import { CompanyIncomeStatement } from '../../../company';
import { useOutletContext } from "react-router-dom"
import { getIncomeStatement } from '../../api.tsx';
import Table from '../Table/Table.tsx';
import Spinner from '../Spinner/Spinner.tsx';
import { formatLargeMonetaryNumber, formatRatio } from '../../Helpers/NumberFormatting.tsx';

interface Props {}

const configs = [
  // {
  //   label: "Date",
  //   render: (company: CompanyIncomeStatement) => company.date,
  // },
  // {
  //   label: "Revenue",
  //   render: (company: CompanyIncomeStatement) => company.revenue,
  // },
  // {
  //   label: "Cost Of Revenue",
  //   render: (company: CompanyIncomeStatement) => company.costOfRevenue,
  // },
  // {
  //   label: "Depreciation",
  //   render: (company: CompanyIncomeStatement) =>
  //     company.depreciationAndAmortization,
  // },
  // {
  //   label: "Operating Income",
  //   render: (company: CompanyIncomeStatement) => company.operatingIncome,
  // },
  // {
  //   label: "Income Before Taxes",
  //   render: (company: CompanyIncomeStatement) => company.incomeBeforeTax,
  // },
  // {
  //   label: "Net Income",
  //   render: (company: CompanyIncomeStatement) => company.netIncome,
  // },
  // {
  //   label: "Net Income Ratio",
  //   render: (company: CompanyIncomeStatement) => company.netIncomeRatio,
  // },
  // {
  //   label: "Earnings Per Share",
  //   render: (company: CompanyIncomeStatement) => company.eps,
  // },
  // {
  //   label: "Earnings Per Diluted",
  //   render: (company: CompanyIncomeStatement) => company.epsdiluted,
  // },
  // {
  //   label: "Gross Profit Ratio",
  //   render: (company: CompanyIncomeStatement) => company.grossProfitRatio,
  // },
  // {
  //   label: "Opearting Income Ratio",
  //   render: (company: CompanyIncomeStatement) => company.operatingIncomeRatio,
  // },
  // {
  //   label: "Income Before Taxes Ratio",
  //   render: (company: CompanyIncomeStatement) => company.incomeBeforeTaxRatio,
  // },

  //With number formatting

  {
    label: "Date",
    render: (company: CompanyIncomeStatement) => company.date,
  },
  {
    label: "Revenue",
    render: (company: CompanyIncomeStatement) =>
      formatLargeMonetaryNumber(company.revenue),
  },
  {
    label: "Cost Of Revenue",
    render: (company: CompanyIncomeStatement) =>
      formatLargeMonetaryNumber(company.costOfRevenue),
  },
  {
    label: "Depreciation",
    render: (company: CompanyIncomeStatement) =>
      formatLargeMonetaryNumber(company.depreciationAndAmortization),
  },
  {
    label: "Operating Income",
    render: (company: CompanyIncomeStatement) =>
      formatLargeMonetaryNumber(company.operatingIncome),
  },
  {
    label: "Income Before Taxes",
    render: (company: CompanyIncomeStatement) =>
      formatLargeMonetaryNumber(company.incomeBeforeTax),
  },
  {
    label: "Net Income",
    render: (company: CompanyIncomeStatement) =>
      formatLargeMonetaryNumber(company.netIncome),
  },
  {
    label: "Net Income Ratio",
    render: (company: CompanyIncomeStatement) =>
      formatRatio(company.netIncomeRatio),
  },
  {
    label: "Earnings Per Share",
    render: (company: CompanyIncomeStatement) => formatRatio(company.eps),
  },
  {
    label: "Earnings Per Diluted",
    render: (company: CompanyIncomeStatement) =>
      formatRatio(company.epsdiluted),
  },
  {
    label: "Gross Profit Ratio",
    render: (company: CompanyIncomeStatement) =>
      formatRatio(company.grossProfitRatio),
  },
  {
    label: "Opearting Income Ratio",
    render: (company: CompanyIncomeStatement) =>
      formatRatio(company.operatingIncomeRatio),
  },
  {
    label: "Income Before Taxes Ratio",
    render: (company: CompanyIncomeStatement) =>
      formatRatio(company.incomeBeforeTaxRatio),
  },
];

const IncomeStatement = (props: Props) => {

  const ticker = useOutletContext<string>();
  //Storing state                               //We use an array because we will be getting multiple years
  const [incomeStatement, setIncomeStatement] = useState<CompanyIncomeStatement[]>()

  //useEffect to fetch data from api
  useEffect(() => {
    const incomeStatementFetch = async () => {
      const result = await getIncomeStatement(ticker);
      // set state after fetching data
      if (result && 'data' in result) {
        setIncomeStatement(result.data);
      } else if (Array.isArray(result)) {
        setIncomeStatement(result);
      }
    }

    //call function after init
    incomeStatementFetch();
  }, [])
  return (
    // <div>IncomeStatement</div>
    <>

    {/* conditional render */}
      {incomeStatement ? (
        <>
          {/* render table using data from useState  */}
          <Table config={configs} data={incomeStatement} />
        </>
      ) : (
        <Spinner />
      )}
    </>
  )
}

export default IncomeStatement
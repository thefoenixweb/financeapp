import React from 'react'
import Table from '../../Components/Table/Table.tsx'
import { CompanyKeyMetrics } from '../../../company'
import { testIncomeStatementData } from '../../Components/Table/testData.tsx'

type Props = {}

//This tableConfig is for dummy data
const tableConfig = [
  {
    Label: "Market Cap",
    render: (company: CompanyKeyMetrics) => company.marketCapTTM,
    subTitle: "Total value of all a company's shares of stock",
  }
]

const DesignPage = (props: Props) => {
  return (
    <>
        <h1>Design Page</h1>
        <h2>Page where we place all of the design technicalities of the site</h2>
        <Table data={testIncomeStatementData} config={tableConfig}/>
    </>
  )
}

export default DesignPage
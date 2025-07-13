import React from 'react'
import { testIncomeStatementData } from './testData.tsx'

// const data = testIncomeStatementData;

type Props = {
  config: {
    Label: string;
    render: (company: any) => any;
  }[];
  data: any[];
}

// type Company = (typeof data)[0];


// //This is an object storing configuration specifications
// const configs = [

//     {
//         //This is just a hardcoded label
//         Label: "Year",

//         //this tells us to render a company object with the accepted date inside of it
//         render: (company: Company) => company.acceptedDate
//     },

//     {
//         Label: "Cost of Revenue",
//         render: (company: Company) => company.costOfRevenue
//     }
// ]


const Table = ({config, data}: Props) => {
  if (!Array.isArray(data)) {
    return null;
  }

  if (!Array.isArray(config)) {
    return null;
  }

  //map through company data
  const renderedRows = data.map((company: any, index: number) => {
    return (
      //return a row with index as key since we might not have cik
      <tr key={index}>
        {/* map over configs */}
        {config.map((val: any) => {
          //return a table cell for each config 
          return (
            <td key={val.Label} className="p-4 whitespace-nowrap text-sm font-normal text-neutral-900 light-mode:text-gray-900">
              {/* this is the map value from the outer map used as a parameter */}
              {val.render(company)}
            </td>
          );
        })}
      </tr>
    )
  })

  //mapping over config to retreive labels for header tags 
  const renderedHeaders = config.map((config: any) => {
    //label is used as both the key and the string 
    return (
      <th className="p-4 text-left text-xs font-medium text-fray-500 uppercase tracking wider"
        key={config.Label}
      >
        {config.Label}
      </th>
    )
  })
  
  return (
    <div className="bg-neutral-800 shadow rounded-lg p-4 sm:p-6 xl:p-8 light-mode:bg-white">
      <div className="overflow-x-auto">
        <table className="min-w-full divide-y divide-neutral-700 light-mode:divide-gray-200">
          <thead className="bg-neutral-700 light-mode:bg-gray-50">
            <tr>
              {config.map((item) => (
                <th
                  key={item.Label}
                  scope="col"
                  className="px-6 py-3 text-left text-xs font-medium text-neutral-400 uppercase tracking-wider light-mode:text-gray-500"
                >
                  {item.Label}
                </th>
              ))}
            </tr>
          </thead>
          <tbody className="bg-neutral-800 divide-y divide-neutral-700 light-mode:bg-white light-mode:divide-gray-200">
            {data.length > 0 ? (data.map((item, index) => (
              <tr key={index} className="hover:bg-neutral-700 light-mode:hover:bg-gray-50">
                {config.map((col) => (
                  <td
                    key={col.Label}
                    className="px-6 py-4 whitespace-nowrap text-sm font-medium text-neutral-100 light-mode:text-gray-900"
                  >
                    {col.render(item)}
                  </td>
                ))}
              </tr>
            ))) : (
              <tr>
                <td colSpan={config.length} className="px-6 py-4 whitespace-nowrap text-sm text-neutral-400 light-mode:text-gray-500 text-center">
                  No data available
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  )
}



export default Table
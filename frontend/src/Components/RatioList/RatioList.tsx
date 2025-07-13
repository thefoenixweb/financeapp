import React from 'react'
import { TestDataCompany } from '../Table/testData.tsx'

/**RATIOLIST RENDERING SINGLE OBJECT AS OPPOSSED TO ARRAY LIKE THE TABLE BUT LOGIC IS SIMILAR */

//Dont need to have logic inside props during dummy data mode 
// type Props = {}

type Props = {
    config: {
        Label: string;
        render: (company: any) => any;
        subTitle?: string;
    }[];
    data: any;
}

//bringing in the first dummy company
// const data = TestDataCompany[0]

// type Company = typeof data;

// const config = [
//     {
//         Label: "company name",
//         render: (company: Company) => company.companyName,
//         subTitle: "The company name is this"
//     }
// ]

const RatioList = ({ config, data }: Props) => {
    if (!data) {
        console.error("[RatioList] No data provided");
        return null;
    }

    if (!Array.isArray(config)) {
        console.error("[RatioList] Config is not an array:", config);
        return null;
    }

    const renderedRows = config.map((row: any) => {
        return (
            <li key={row.Label} className="py-3 sm:py-4">
                <div className="flex items-center space-x-4">
                    <div className="flex-1 min-w-0">
                        <p className="text-sm font-medium text-neutral-900 light-mode:text-gray-900 truncate">
                            {row.Label}
                        </p>
                        {row.subTitle && (
                            <p className="text-sm text-neutral-500 light-mode:text-gray-500 truncate">
                                {row.subTitle}
                            </p>
                        )}
                    </div>
                    <div className="inline-flex items-center text-base font-semibold text-neutral-900 light-mode:text-gray-900">
                        {row.render(data)}
                    </div>
                </div>
            </li>
        )
    })

    return (
        <div className="bg-white shadow rounded-lg ml-4 mt-4 mb-4 p-4 sm:p-6 h-full">
            <ul className="divide-y divide-gray-200">
                {renderedRows}
            </ul>
        </div>
    )
}

export default RatioList
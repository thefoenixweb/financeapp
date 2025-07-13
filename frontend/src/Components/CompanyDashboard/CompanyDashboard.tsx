import React from 'react'

type Props = {
    ticker: string;
    children: React.ReactNode;
}

const CompanyDashboard: React.FC<Props> = ({ ticker, children }: Props): JSX.Element => {
    if (!ticker || typeof ticker !== 'string') {
        return <div>Invalid ticker</div>;
    }

    return (
        <div className="relative md:ml-64 w-full">
            <div className="relative pt-20 pb-32">
                <div className="px-4 md:px-6 mx-auto w-full">
                    <div className="flex flex-wrap">
                        {children}
                    </div>
                </div>
            </div>
        </div>
    )
}

export default CompanyDashboard
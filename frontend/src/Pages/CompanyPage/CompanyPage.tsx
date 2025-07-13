import React from 'react'
import { Outlet } from 'react-router-dom'
import CompanyDashboard from '../../Components/CompanyDashboard/CompanyDashboard.tsx';
import Tile from '../../Components/Tile/Tile.tsx';
import Spinner from '../../Components/Spinner/Spinner.tsx';
import { useCompany } from '../../Context/CompanyContext';

const CompanyPage: React.FC = () => {
    const { ticker, companyData, isLoading } = useCompany();

    if (isLoading || !companyData || !ticker) {
        return <Spinner />;
    }

    return (
        <div className="w-full relative flex overflow-x-hidden">
            <CompanyDashboard ticker={ticker}>
                <Outlet />
            </CompanyDashboard>
        </div>
    );
}

export default CompanyPage
import React, { ChangeEvent, SyntheticEvent, useEffect, useState } from 'react';
import { PortfolioGet } from '../../Models/Portfolio.ts';
import { useAuth } from '../../Context/useAuth.tsx';
import { toast } from 'react-toastify';
import { searchCompanies, getPortfolio, addToPortfolio, removeFromPortfolio } from '../../api.tsx';
import { CompanySearch } from '../../../company';
import ListPortfolio from '../../Components/Portfolio/ListPortfolio/ListPortfolio.tsx';
import { useNavigate } from 'react-router-dom';
import Table from '../../Components/Table/Table.tsx';
import Tile from '../../Components/Tile/Tile.tsx';
import CardPortfolio from '../../Components/Portfolio/CardPortfolio/CardPortfolio.tsx';
import { mockMarketIndexes } from '../../MockData/mockMarketIndexes';

const DashboardPage: React.FC = () => {
    const { token } = useAuth();
    const navigate = useNavigate();
    const [portfolioValues, setPortfolioValues] = useState<PortfolioGet[] | null>([]);
    const [search, setSearch] = useState<string>("");
    const [companyData, setCompanyData] = useState<CompanySearch | null>(null);
    const [userPortfolio, setUserPortfolio] = useState<PortfolioGet[]>([]);
    const [isLoading, setIsLoading] = useState(true);

    const getPortfolioData = async () => {
        if (!token) {
            toast.warning("You must be logged in to view portfolio!");
            return;
        }
        try {
            setIsLoading(true);
            const response = await getPortfolio();
            if (response && response.data) {
                // The backend already returns the data in the correct format
                setPortfolioValues(response.data);
                setUserPortfolio(response.data);
            }
        } catch (error) {
            console.error("Error fetching portfolio:", error);
            toast.error("Failed to fetch portfolio data");
        } finally {
            setIsLoading(false);
        }
    };

    useEffect(() => {
        getPortfolioData();
    }, [token]);

    const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value);
    };

    const handleSearchSubmit = async (e: SyntheticEvent) => {
        e.preventDefault();
        if (!search.trim()) return;
        navigate(`/search?query=${search}`);
        setSearch(""); // Clear the search input after navigation
    };

    const onPortfolioCreate = async (e: any) => {
        if (!token) {
            toast.warning("You must be logged in to add to portfolio!");
            return;
        }
        e.preventDefault();
        try {
            await addToPortfolio(e.target.symbol);
            toast.success("Stock added to portfolio");
            getPortfolioData(); // Refresh portfolio after adding
        } catch (error) {
            console.error("Error adding to portfolio:", error);
            toast.error("Failed to add stock to portfolio");
        }
    };

    const onPortfolioDelete = async (symbol: string) => {
        if (!token) {
            toast.warning("You must be logged in to delete from portfolio!");
            return;
        }
        try {
            await removeFromPortfolio(symbol);
            toast.success("Stock removed from portfolio");
            getPortfolioData(); // Refresh portfolio after deleting
        } catch (error) {
            console.error("Error removing from portfolio:", error);
            toast.error("Failed to remove stock from portfolio");
        }
    };

    const marketIndexesConfig = [
        { label: "Symbol", render: (data: CompanySearch) => data.symbol },
        { label: "Name", render: (data: CompanySearch) => data.name },
        { label: "Exchange", render: (data: CompanySearch) => data.exchangeShortName },
        { label: "Currency", render: (data: CompanySearch) => data.currency },
    ];

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-6 text-neutral-100 light-mode:text-neutral-900">My Portfolio</h1>

            {/* Search Bar */}
            <div className="relative flex-1 max-w-xl mx-auto mb-6">
                <form onSubmit={handleSearchSubmit} className="relative">
                    <input
                        type="text"
                        value={search}
                        onChange={handleSearchChange}
                        placeholder="Search companies to add to portfolio..."
                        className="w-full px-4 py-2 border border-neutral-600 rounded-lg focus:outline-none focus:border-primary-green bg-neutral-700 text-neutral-100 light-mode:border-gray-300 light-mode:bg-white light-mode:text-neutral-900"
                    />
                    <button
                        type="submit"
                        className="absolute right-2 top-1/2 transform -translate-y-1/2 px-4 py-1 bg-primary-green text-white rounded hover:bg-primary-green-dark transition-colors"
                    >
                        Search
                    </button>
                </form>
            </div>

            {/* Portfolio Section */}
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6 mb-6">
                {isLoading ? (
                    <div>Loading portfolio...</div>
                ) : portfolioValues && portfolioValues.length > 0 ? (
                    portfolioValues.map((portfolio) => (
                        <CardPortfolio
                            key={portfolio.id}
                            portfolioValue={portfolio}
                            onDeleteClick={onPortfolioDelete}
                        />
                    ))
                ) : (
                    <div className="col-span-full text-center text-neutral-400">
                        No stocks in your portfolio. Search and add some!
                    </div>
                )}
            </div>

            {/* Portfolio List */}
            <div className="bg-neutral-800 p-6 rounded-lg shadow mb-6 light-mode:bg-white">
                <h2 className="text-xl font-semibold mb-4 text-neutral-100 light-mode:text-neutral-900">Portfolio List</h2>
                <div className="overflow-x-auto">
                    {isLoading ? (
                        <div>Loading portfolio list...</div>
                    ) : (
                        <ListPortfolio
                            portfolioValues={userPortfolio}
                            onPortfolioDelete={onPortfolioDelete}
                        />
                    )}
                </div>
            </div>

            {/* Market Indexes */}
            <div className="bg-neutral-800 p-6 rounded-lg shadow light-mode:bg-white">
                <h2 className="text-xl font-semibold mb-4 text-neutral-100 light-mode:text-neutral-900">Market Indexes</h2>
                <div className="overflow-x-auto">
                    {isLoading ? (
                        <div>Loading market indexes...</div>
                    ) : (
                        <Table config={marketIndexesConfig} data={mockMarketIndexes}/>
                    )}
                </div>
            </div>
        </div>
    );
};

export default DashboardPage; 
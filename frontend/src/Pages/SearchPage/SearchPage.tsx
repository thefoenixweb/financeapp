import React, { useEffect, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { CompanySearch } from '../../../company';
import { searchCompanies } from '../../api.tsx';
import CardList from '../../Components/CardList/CardList.tsx';
import { useAuth } from '../../Context/useAuth.tsx';

const SearchPage: React.FC = () => {
    const { token } = useAuth();
    const location = useLocation();
    const navigate = useNavigate();
    const searchQuery = new URLSearchParams(location.search).get('query');

    const [searchResults, setSearchResults] = useState<CompanySearch[]>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const [localSearchQuery, setLocalSearchQuery] = useState<string>(searchQuery || '');

    useEffect(() => {
        const fetchSearchResults = async () => {
            if (searchQuery) {
                setLoading(true);
                try {
                    const result = await searchCompanies(searchQuery);
                    if (typeof result === "string") {
                        console.error("Search error:", result);
                        setSearchResults([]);
                    } else if (result?.data && Array.isArray(result.data)) {
                        setSearchResults(result.data);
                    }
                } catch (error) {
                    console.error("Search error:", error);
                    setSearchResults([]);
                } finally {
                    setLoading(false);
                }
            } else {
                setSearchResults([]);
            }
        };

        fetchSearchResults();
    }, [searchQuery]);

    const handleSearch = (e: React.FormEvent) => {
        e.preventDefault();
        if (localSearchQuery.trim()) {
            navigate(`/search?query=${encodeURIComponent(localSearchQuery.trim())}`);
        }
    };

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setLocalSearchQuery(e.target.value);
    };

    return (
        <div className="p-6">
            {/* Search Form */}
            <div className="mb-8">
                <h1 className="text-2xl font-bold mb-6 text-neutral-100 light-mode:text-neutral-900">Search Companies</h1>
                <div className="relative flex-1 max-w-xl mx-auto mb-6">
                    <form onSubmit={handleSearch} className="relative">
                        <input
                            type="text"
                            value={localSearchQuery}
                            onChange={handleInputChange}
                            placeholder="Search companies by name or ticker symbol (e.g., Apple, AAPL)..."
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
            </div>

            {/* Search Results or Welcome Message */}
            {searchQuery ? (
                <div>
                    <h2 className="text-2xl font-bold mb-6 text-neutral-100 light-mode:text-neutral-900">Search Results for "{searchQuery}"</h2>
                    {loading ? (
                        <div className="text-center py-8">
                            <div className="inline-block animate-spin rounded-full h-8 w-8 border-b-2 border-primary-green"></div>
                            <p className="mt-2 text-neutral-400 light-mode:text-neutral-600">Searching...</p>
                        </div>
                    ) : searchResults.length > 0 ? (
                        <CardList searchResults={searchResults} />
                    ) : (
                        <div className="text-center py-8">
                            <p className="text-neutral-400 light-mode:text-neutral-600 text-lg">No results found for "{searchQuery}"</p>
                            <p className="text-neutral-500 light-mode:text-neutral-500 mt-2">Try adjusting your search terms or check the spelling</p>
                        </div>
                    )}
                </div>
            ) : (
                <div className="text-center py-12">
                    <div className="max-w-2xl mx-auto">
                        <div className="text-6xl mb-4">🔍</div>
                        <h2 className="text-2xl font-semibold text-neutral-200 light-mode:text-neutral-700 mb-4">Ready to Search?</h2>
                        <p className="text-neutral-400 light-mode:text-neutral-600 mb-6">
                            Search for companies by name or ticker symbol to view their financial information, 
                            company profiles, and more.
                        </p>
                    </div>
                </div>
            )}
        </div>
    );
};

export default SearchPage;
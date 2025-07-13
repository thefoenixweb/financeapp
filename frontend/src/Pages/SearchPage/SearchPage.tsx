import React, { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import { CompanySearch } from '../../../company';
import { searchCompanies } from '../../api.tsx';
import CardList from '../../Components/CardList/CardList.tsx';
import { useAuth } from '../../Context/useAuth.tsx';

const SearchPage: React.FC = () => {
    const { token } = useAuth();
    const location = useLocation();
    const searchQuery = new URLSearchParams(location.search).get('query');

    const [searchResults, setSearchResults] = useState<CompanySearch[]>([]);
    const [loading, setLoading] = useState<boolean>(false);

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

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-6">Search Results for "{searchQuery}"</h1>
            {loading ? (
                <p>Loading...</p>
            ) : searchResults.length > 0 ? (
                <CardList searchResults={searchResults} />
            ) : (
                <p>No results found.</p>
            )}
        </div>
    );
};

export default SearchPage;
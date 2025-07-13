import React, { ChangeEvent, SyntheticEvent, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';
import { useAuth } from '../../Context/useAuth.tsx';
import logo from './logo.png';
import { CompanySearch } from '../../../company';
import { searchCompanies } from '../../api.tsx';

interface Props {}

const NavBar = (props: Props) => {
  const { isLoggedIn, user, logout } = useAuth();
  const navigate = useNavigate();
  const [search, setSearch] = useState<string>("");
  const [searchResults, setSearchResults] = useState<CompanySearch[]>([]);
  const [showResults, setShowResults] = useState(false);

  const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value);
  };

  const handleSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    if (!search.trim()) return;

    try {
      const result = await searchCompanies(search);
      if (typeof result === "string") {
        console.error("Search error:", result);
        return;
      }
      if (result?.data && Array.isArray(result.data)) {
        setSearchResults(result.data);
        setShowResults(true);
      }
    } catch (error) {
      console.error("Search error:", error);
    }
  };

  const handleResultClick = (symbol: string) => {
    setShowResults(false);
    setSearch("");
    navigate(`/company/${symbol}/company-profile`);
  };

  return (
    <nav className="relative container mx-auto p-6">
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-20">
          
        </div>

        {isLoggedIn() ? (
          <div className="hidden lg:flex items-center space-x-6 text-back">
            <div className="hover:text-darkBlue">Welcome, {user?.userName}</div>
            <button
              onClick={logout}
              className="px-8 py-3 font-bold rounded text-white bg-lightGreen hover:opacity-70"
            >
              Logout
            </button>
          </div>
        ) : (
          <div className="hidden lg:flex items-center space-x-6 text-back">
            <Link to="login" className="hover:text-darkBlue">
              Login
            </Link>
            <Link
              to="/register"
              className="px-8 py-3 font-bold rounded text-white bg-lightGreen hover:opacity-70"
            >
              Signup
            </Link>
          </div>
        )}

        <div className="hidden font-bold lg:flex">
          
        </div>
      </div>
    </nav>
  );
};

export default NavBar;
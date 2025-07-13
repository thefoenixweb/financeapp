import React, { useState } from 'react';
import axios from 'axios';
import { useAuth } from '../../../Context/useAuth';
import { toast } from 'react-toastify';
import { portfolioAddAPI } from '../../../Services/PortfolioService';

interface Props {
    symbol: string;
    onSuccess?: () => void;
}

const AddPortfolio = ({ symbol, onSuccess }: Props) => {
    const { token } = useAuth();
    const [isLoading, setIsLoading] = useState(false);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        
        if (!token) {
            toast.warning("You must be logged in to add to portfolio!");
            return;
        }

        setIsLoading(true);
        try {
            const { data, error } = await portfolioAddAPI(symbol, token);

            if (error) {
                toast.error(error);
                return;
            }

            if (data) {
                toast.success("Stock added to portfolio successfully!");
                onSuccess?.();
            }
        } catch (error: any) {
            toast.error(error.message || "Failed to add stock to portfolio");
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <div className="flex flex-col items-center justify-end flex-1 space-x-4 space-y-2 md:flex-row md:space-y-0">
            <form onSubmit={handleSubmit}>
                <input readOnly={true} hidden={true} value={symbol} />
                <button
                    type="submit"
                    disabled={isLoading}
                    className={`p-2 px-8 text-white bg-darkBlue rounded-lg hover:opacity-70 focus:outline-none ${
                        isLoading ? 'opacity-50 cursor-not-allowed' : ''
                    }`}
                >
                    {isLoading ? 'Adding...' : 'Add'}
                </button>
            </form>
        </div>
    );
};

export default AddPortfolio;
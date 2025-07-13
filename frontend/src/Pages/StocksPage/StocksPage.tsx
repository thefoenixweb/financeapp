import React from 'react';
import Table from '../../Components/Table/Table.tsx';
import { mockStocks } from '../../MockData/mockData.ts';

const StocksPage: React.FC = () => {
  const stocksTableConfig = [
    { Label: "Symbol", render: (stock: any) => stock.symbol },
    { Label: "Company", render: (stock: any) => stock.companyName },
    { Label: "Price", render: (stock: any) => `$${stock.price.toFixed(2)}` },
    { Label: "Change", render: (stock: any) => `${stock.changes > 0 ? '+' : ''}${stock.changes.toFixed(2)}%` },
    { Label: "Volume", render: (stock: any) => `${(stock.volAvg / 1000000).toFixed(0)}M` },
  ];

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-6 text-neutral-100 light-mode:text-neutral-900">Stocks</h1>
      <div className="bg-neutral-800 rounded-lg shadow light-mode:bg-white">
        <div className="p-6">
          <div className="overflow-x-auto">
            <Table config={stocksTableConfig} data={mockStocks} />
          </div>
        </div>
      </div>
    </div>
  );
};

export default StocksPage; 
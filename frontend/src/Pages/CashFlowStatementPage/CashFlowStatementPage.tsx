import React, { useEffect, useState } from 'react';
import { CompanyCashFlow } from '../../../company';
import Spinner from '../../Components/Spinner/Spinner.tsx';
import { formatLargeMonetaryNumber, formatRatio, formatLargeNonMonetaryNumber } from '../../Helpers/NumberFormatting.tsx';
import { useCompany } from '../../Context/CompanyContext';
import { getCashFlowStatement } from '../../api';
import { Bar, Pie } from 'react-chartjs-2';
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend,
  ArcElement,
} from 'chart.js';

ChartJS.register(
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend,
  ArcElement
);

interface Props{}

const CashFlowStatementPage: React.FC = (props: Props) => {
  const { ticker, companyData } = useCompany();
  const [cashFlowData, setCashFlowData] = useState<CompanyCashFlow | null>(null);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchCashFlow = async () => {
      if (!ticker) return;
      
      try {
        setIsLoading(true);
        setError(null);
        const result = await getCashFlowStatement(ticker);
        if (result && result.length > 0) {
          setCashFlowData(result[0]);
        } else {
          setError('No cash flow statement data available');
        }
      } catch (err) {
        setError(err instanceof Error ? err.message : 'Failed to fetch cash flow statement data');
      } finally {
        setIsLoading(false);
      }
    };

    fetchCashFlow();
  }, [ticker]);

  if (isLoading) {
    return <Spinner />;
  }

  if (error || !cashFlowData || !companyData) {
    return <div className="p-6 text-red-500">{error || 'No data available'}</div>;
  }

  const {
    symbol,
    period,
    calendarYear,
    date,
    fillingDate,
    acceptedDate,
    reportedCurrency,
    cik,
    finalLink,
    netIncome,
    depreciationAndAmortization,
    deferredIncomeTax,
    stockBasedCompensation,
    changeInWorkingCapital,
    accountsReceivables,
    inventory,
    accountsPayables,
    otherWorkingCapital,
    netCashProvidedByOperatingActivities,
    investmentsInPropertyPlantAndEquipment,
    acquisitionsNet,
    purchasesOfInvestments,
    salesMaturitiesOfInvestments,
    otherInvestingActivites,
    netCashUsedForInvestingActivites,
    debtRepayment,
    commonStockIssued,
    commonStockRepurchased,
    dividendsPaid,
    otherFinancingActivites,
    netCashUsedProvidedByFinancingActivities,
    effectOfForexChangesOnCash,
    netChangeInCash,
    cashAtBeginningOfPeriod,
    cashAtEndOfPeriod,
    operatingCashFlow,
    capitalExpenditure,
    freeCashFlow
  } = cashFlowData;

  // Chart Data for Cash Flow Summary (Waterfall Chart)
  const cashFlowSummaryData = {
    labels: ['Cash at Beginning', 'Operating Activities', 'Investing Activities', 'Financing Activities', 'Forex Changes', 'Cash at End'],
    datasets: [
      {
        label: 'Cash Flow',
        data: [
          cashAtBeginningOfPeriod,
          netCashProvidedByOperatingActivities,
          netCashUsedForInvestingActivites,
          netCashUsedProvidedByFinancingActivities,
          effectOfForexChangesOnCash,
          cashAtEndOfPeriod
        ],
        backgroundColor: [
          'rgba(75, 192, 192, 0.6)',
          'rgba(153, 102, 255, 0.6)',
          'rgba(255, 159, 64, 0.6)',
          'rgba(54, 162, 235, 0.6)',
          'rgba(255, 99, 132, 0.6)',
          'rgba(75, 192, 192, 0.6)'
        ],
        borderColor: [
          'rgba(75, 192, 192, 1)',
          'rgba(153, 102, 255, 1)',
          'rgba(255, 159, 64, 1)',
          'rgba(54, 162, 235, 1)',
          'rgba(255, 99, 132, 1)',
          'rgba(75, 192, 192, 1)'
        ],
        borderWidth: 1,
      },
    ],
  };

  const cashFlowSummaryOptions = {
    responsive: true,
    plugins: {
      legend: { position: 'top' as const },
      title: { display: true, text: 'Cash Flow Summary' },
    },
  };

  // Chart Data for Operating Activities (Bar Chart)
  const operatingActivitiesData = {
    labels: ['Net Income', 'Depreciation & Amortization', 'Deferred Income Tax', 'Stock-Based Compensation', 'Change in Working Capital'],
    datasets: [
      {
        label: 'Amount',
        data: [netIncome, depreciationAndAmortization, deferredIncomeTax, stockBasedCompensation, changeInWorkingCapital],
        backgroundColor: 'rgba(75, 192, 192, 0.6)',
        borderColor: 'rgba(75, 192, 192, 1)',
        borderWidth: 1,
      },
    ],
  };

  const operatingActivitiesOptions = {
    responsive: true,
    plugins: {
      legend: { position: 'top' as const },
      title: { display: true, text: 'Operating Activities' },
    },
  };

  // Chart Data for Investing Activities (Bar Chart)
  const investingActivitiesData = {
    labels: ['Investments in PPE', 'Acquisitions', 'Purchases of Investments', 'Sales of Investments', 'Other Investing Activities'],
    datasets: [
      {
        label: 'Amount',
        data: [investmentsInPropertyPlantAndEquipment, acquisitionsNet, purchasesOfInvestments, salesMaturitiesOfInvestments, otherInvestingActivites],
        backgroundColor: 'rgba(153, 102, 255, 0.6)',
        borderColor: 'rgba(153, 102, 255, 1)',
        borderWidth: 1,
      },
    ],
  };

  const investingActivitiesOptions = {
    responsive: true,
    plugins: {
      legend: { position: 'top' as const },
      title: { display: true, text: 'Investing Activities' },
    },
  };

  // Chart Data for Financing Activities (Bar Chart)
  const financingActivitiesData = {
    labels: ['Debt Repayment', 'Common Stock Issued', 'Common Stock Repurchased', 'Dividends Paid', 'Other Financing Activities'],
    datasets: [
      {
        label: 'Amount',
        data: [debtRepayment, commonStockIssued, commonStockRepurchased, dividendsPaid, otherFinancingActivites],
        backgroundColor: 'rgba(255, 159, 64, 0.6)',
        borderColor: 'rgba(255, 159, 64, 1)',
        borderWidth: 1,
      },
    ],
  };

  const financingActivitiesOptions = {
    responsive: true,
    plugins: {
      legend: { position: 'top' as const },
      title: { display: true, text: 'Financing Activities' },
    },
  };

  return (
    <div className="p-6">
      {/* 1. Top Header: Company & Report Identification */}
      <div className="bg-neutral-800 p-4 rounded-lg shadow mb-6 flex flex-wrap justify-between items-center light-mode:bg-white">
        <div>
          <h2 className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{symbol} <span className="text-neutral-400 text-base light-mode:text-gray-600">({companyData.companyName})</span></h2>
          <p className="text-sm text-neutral-400 light-mode:text-gray-500">Central Index Key: {cik}</p>
        </div>
        <div className="text-right text-neutral-100 light-mode:text-neutral-900">
          <p className="text-lg font-semibold">Report Period: {period} {calendarYear}</p>
          <p>Report Date: {date}</p>
          <p>Filing Date: {fillingDate}</p>
          <p>Accepted Date: {acceptedDate}</p>
          <p>Currency: {reportedCurrency}</p>
          {finalLink && (
            <a href={finalLink} target="_blank" rel="noopener noreferrer" className="text-primary-gold hover:underline text-sm light-mode:text-blue-500 light-mode:hover:text-blue-700">
              Source Document <i className="fas fa-external-link-alt"></i>
            </a>
          )}
        </div>
      </div>

      {/* 2. Cash Flow Summary / Net Change (Central & Prominent KPIs) */}
      <div className="bg-neutral-800 p-6 rounded-lg shadow mb-6 light-mode:bg-white">
        <h2 className="text-lg font-semibold mb-4 text-neutral-100 light-mode:text-neutral-900">Cash Flow Summary</h2>
        <div className="grid grid-cols-3 gap-4">
          <div className="bg-neutral-700 p-4 rounded-lg light-mode:bg-gray-100">
            <p className="text-sm text-neutral-400 light-mode:text-gray-600">Net Change In Cash</p>
            <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(netChangeInCash)}</p>
          </div>
          <div className="bg-neutral-700 p-4 rounded-lg light-mode:bg-gray-100">
            <p className="text-sm text-neutral-400 light-mode:text-gray-600">Cash at Beginning</p>
            <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(cashAtBeginningOfPeriod)}</p>
          </div>
          <div className="bg-neutral-700 p-4 rounded-lg light-mode:bg-gray-100">
            <p className="text-sm text-neutral-400 light-mode:text-gray-600">Cash at End</p>
            <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(cashAtEndOfPeriod)}</p>
          </div>
        </div>
        <div className="mt-6">
          <Bar data={cashFlowSummaryData} options={cashFlowSummaryOptions} />
        </div>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
        {/* 3. Operating Activities (Left Column/Panel - Top) */}
        <div className="bg-neutral-800 p-6 rounded-lg shadow light-mode:bg-white">
          <h2 className="text-lg font-semibold mb-4 text-neutral-100 light-mode:text-neutral-900">Cash Flow from Operating Activities</h2>
          <div className="space-y-2 text-neutral-100 light-mode:text-neutral-900">
            <p className="flex justify-between"><span>Net Cash Provided By Operating Activities:</span> <span>{formatLargeMonetaryNumber(netCashProvidedByOperatingActivities)}</span></p>
            <p className="flex justify-between"><span>Net Income:</span> <span>{formatLargeMonetaryNumber(netIncome)}</span></p>
            <p className="flex justify-between"><span>Depreciation & Amortization:</span> <span>{formatLargeMonetaryNumber(depreciationAndAmortization)}</span></p>
            <p className="flex justify-between"><span>Deferred Income Tax:</span> <span>{formatLargeMonetaryNumber(deferredIncomeTax)}</span></p>
            <p className="flex justify-between"><span>Stock-Based Compensation:</span> <span>{formatLargeMonetaryNumber(stockBasedCompensation)}</span></p>
            <p className="flex justify-between"><span>Change in Working Capital:</span> <span>{formatLargeMonetaryNumber(changeInWorkingCapital)}</span></p>
          </div>
          <div className="mt-6">
            <Bar data={operatingActivitiesData} options={operatingActivitiesOptions} />
          </div>
        </div>

        {/* 4. Investing Activities (Middle Column/Panel) */}
        <div className="bg-neutral-800 p-6 rounded-lg shadow light-mode:bg-white">
          <h2 className="text-lg font-semibold mb-4 text-neutral-100 light-mode:text-neutral-900">Cash Flow from Investing Activities</h2>
          <div className="space-y-2 text-neutral-100 light-mode:text-neutral-900">
            <p className="flex justify-between"><span>Net Cash Used For Investing Activities:</span> <span>{formatLargeMonetaryNumber(netCashUsedForInvestingActivites)}</span></p>
            <p className="flex justify-between"><span>Investments in Property, Plant & Equipment:</span> <span>{formatLargeMonetaryNumber(investmentsInPropertyPlantAndEquipment)}</span></p>
            <p className="flex justify-between"><span>Acquisitions (Net):</span> <span>{formatLargeMonetaryNumber(acquisitionsNet)}</span></p>
            <p className="flex justify-between"><span>Purchases of Investments:</span> <span>{formatLargeMonetaryNumber(purchasesOfInvestments)}</span></p>
            <p className="flex justify-between"><span>Sales/Maturities of Investments:</span> <span>{formatLargeMonetaryNumber(salesMaturitiesOfInvestments)}</span></p>
            <p className="flex justify-between"><span>Other Investing Activities:</span> <span>{formatLargeMonetaryNumber(otherInvestingActivites)}</span></p>
          </div>
          <div className="mt-6">
            <Bar data={investingActivitiesData} options={investingActivitiesOptions} />
          </div>
        </div>

        {/* 5. Financing Activities (Right Column/Panel - Top) */}
        <div className="bg-neutral-800 p-6 rounded-lg shadow light-mode:bg-white">
          <h2 className="text-lg font-semibold mb-4 text-neutral-100 light-mode:text-neutral-900">Cash Flow from Financing Activities</h2>
          <div className="space-y-2 text-neutral-100 light-mode:text-neutral-900">
            <p className="flex justify-between"><span>Net Cash Used/Provided By Financing Activities:</span> <span>{formatLargeMonetaryNumber(netCashUsedProvidedByFinancingActivities)}</span></p>
            <p className="flex justify-between"><span>Debt Repayment:</span> <span>{formatLargeMonetaryNumber(debtRepayment)}</span></p>
            <p className="flex justify-between"><span>Common Stock Issued:</span> <span>{formatLargeMonetaryNumber(commonStockIssued)}</span></p>
            <p className="flex justify-between"><span>Common Stock Repurchased:</span> <span>{formatLargeMonetaryNumber(commonStockRepurchased)}</span></p>
            <p className="flex justify-between"><span>Dividends Paid:</span> <span>{formatLargeMonetaryNumber(dividendsPaid)}</span></p>
            <p className="flex justify-between"><span>Other Financing Activities:</span> <span>{formatLargeMonetaryNumber(otherFinancingActivites)}</span></p>
          </div>
          <div className="mt-6">
            <Bar data={financingActivitiesData} options={financingActivitiesOptions} />
          </div>
        </div>
      </div>

      {/* 6. Free Cash Flow & Other Details (Bottom Section) */}
      <div className="bg-neutral-800 p-6 rounded-lg shadow mt-6 light-mode:bg-white">
        <h2 className="text-lg font-semibold mb-4 text-neutral-100 light-mode:text-neutral-900">Key Cash Flow Metrics</h2>
        <div className="grid grid-cols-2 gap-4">
          <div className="bg-neutral-700 p-4 rounded-lg light-mode:bg-gray-100">
            <p className="text-sm text-neutral-400 light-mode:text-gray-600">Free Cash Flow</p>
            <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(freeCashFlow)}</p>
          </div>
          <div className="bg-neutral-700 p-4 rounded-lg light-mode:bg-gray-100">
            <p className="text-sm text-neutral-400 light-mode:text-gray-600">Effect of Forex Changes on Cash</p>
            <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(effectOfForexChangesOnCash)}</p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CashFlowStatementPage; 
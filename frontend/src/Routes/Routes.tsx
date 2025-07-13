import { createBrowserRouter } from "react-router-dom";
import App from "../App.tsx"; 
import React from "react";
import HomePage from "../Pages/HomePage/HomePage.tsx";
import CompanyPage from "../Pages/CompanyPage/CompanyPage.tsx";
import SearchPage from "../Pages/SearchPage/SearchPage.tsx";
import CompanyProfile from "../Components/CompanyProfile/CompanyProfile.tsx";
import IncomeStatementPage from "../Pages/IncomeStatementPage/IncomeStatementPage.tsx";
import DesignPage from "../Pages/DesignPage/DesignPage.tsx";
import BalanceSheetPage from "../Pages/BalanceSheetPage/BalanceSheetPage.tsx";
import CashFlowStatementPage from "../Pages/CashFlowStatementPage/CashFlowStatementPage.tsx";
import LoginPage from "../Pages/LoginPage/LoginPage.tsx";
import RegisterPage from "../Pages/RegisterPage/RegisterPage.tsx";
import ProtectedRoutes from "./ProtectedRoutes.tsx";
import DashboardPage from "../Pages/DashboardPage/DashboardPage.tsx";
import StocksPage from "../Pages/StocksPage/StocksPage.tsx";
import ContactPage from "../Pages/ContactPage/ContactPage.tsx";
import { CompanyProvider } from "../Context/CompanyContext";

//router-dom object that takes in our apps config(path, element etc..)
export const router = createBrowserRouter([
    { 
        path: "/",
        element: <App />,
        children: [
            {path: "", element: <HomePage />},
            {path: "login", element: <LoginPage />},
            {path: "register", element: <RegisterPage />},
            {path: "dashboard", element: <ProtectedRoutes><DashboardPage /></ProtectedRoutes> },
            {path: "stocks", element: <ProtectedRoutes><StocksPage /></ProtectedRoutes> },
            {path: "contact", element: <ProtectedRoutes><ContactPage /></ProtectedRoutes> },
            {path: "search", element: <ProtectedRoutes><SearchPage /></ProtectedRoutes>},
            {path: "design-guide", element: <DesignPage />},
            {
                path: "company/:ticker",
                element: (
                    <ProtectedRoutes>
                        <CompanyProvider>
                            <CompanyPage />
                        </CompanyProvider>
                    </ProtectedRoutes>
                ),
                children: [
                    { path: "company-profile", element: <CompanyProfile /> },
                    { path: "income-statement", element: <IncomeStatementPage /> },
                    { path: "balance-sheet", element: <BalanceSheetPage /> },
                    { path: "cashflow-statement", element: <CashFlowStatementPage /> }
                ]
            }
        ]
    }
])
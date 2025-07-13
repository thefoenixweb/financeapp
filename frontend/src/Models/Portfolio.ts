export interface PortfolioGet {
    id: number;
    symbol: string;
    companyName: string;
    purchase: number;
    lastDiv: number;
    industry: string;
    marketCap: number;
}

export type PortfolioPost = {
    symbol: string;
}
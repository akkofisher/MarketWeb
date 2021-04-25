export interface CompanyPriceData {
  CompanyId: number;
  MarketId: number;
  Price: number;
}

export interface CompanyPriceList {
  Id: number;
  Price: number;
  CompanyName: string;
  CompanyId: number;
  MarketName: string;
  MarketId: number;
}

export interface Market {
  code: string;
  id: number;
  name: string;
}

export interface Company {
  code: string;
  id: number;
  name: string;
}

export interface CompanyMarketPrice {
  companyId: number;
  companyName: string;
  id: number;
  marketId: number;
  marketName: string;
  price: number;
}

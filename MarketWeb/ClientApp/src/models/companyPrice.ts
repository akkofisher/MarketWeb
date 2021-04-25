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

export interface Currency {
  id: number;
  bidPrice: number;
  askPrice: number;
  lastRefreshed: string;
  toCurrencyCode: string;
  fromCurrencyCode: string;
}

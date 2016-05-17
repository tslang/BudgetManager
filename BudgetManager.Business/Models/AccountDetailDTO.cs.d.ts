declare module server {
	interface AccountDetailDTO {
		id: number;
		name: string;
		bank: string;
		amount: number;
		transactions: any[];
	}
}

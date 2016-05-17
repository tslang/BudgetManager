declare module server {
	interface AccountEditCommandModel {
		id: number;
		name: string;
		bank: string;
		amount: number;
		transactions: string[];
	}
}

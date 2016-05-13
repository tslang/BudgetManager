declare module BudgetManager.Account {
	interface AccountCreateCommandModel {
		name: string;
		bank: string;
		amount: number;
	}
}

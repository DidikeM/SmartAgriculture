export class User {
    id?:number;
    name!: string;
    surname!: string
    password!: string;
    email!: string;
    coinAddress!: string;
    externalCoinAddress? : string;
}
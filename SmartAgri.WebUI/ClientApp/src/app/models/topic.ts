import { User } from "./user";

export class Topic {
    id?: number;
    title!: string;
    content!: string;
    date?: Date;
    userId!: number;
    user?: User;
    replyCount?: number;
}
import { User } from "./user";
import { Topic } from "./topic";

export class Reply {
    id?: number;
    userId!: number;
    topicId!: number;
    date?: Date;
    text!: string;
    user?: User;
    topic?: Topic;
}
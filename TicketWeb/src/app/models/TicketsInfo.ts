import { Guid } from "guid-typescript";
import { User } from "./User";

export class TicketsInfo {
    Users: Array<User>;
    AgentId: Guid;
    constructor() {
        this.Users = new Array<User>();
    }
}
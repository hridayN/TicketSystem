import { User } from "./User";

export class LoginRequest {
    User: User;
    constructor() {
        this.User = new User();
    }
}
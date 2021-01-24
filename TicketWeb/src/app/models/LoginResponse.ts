import { Agent } from 'src/app/models/Agent';
import { TicketsInfo } from './TicketsInfo';
export class LoginResponse {
    TicketSystemInfo: Array<TicketsInfo>;

    constructor() {
        this.TicketSystemInfo = new Array<TicketsInfo>();
    }
}
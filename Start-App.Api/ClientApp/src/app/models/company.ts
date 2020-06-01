import { Employee } from './employee';

export class Company {
    id: string;
    name: string;
    introduction: string;
    country: string;
    industry: string;
    product: string;
    employees: Array<Employee>;
}
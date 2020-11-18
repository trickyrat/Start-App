export interface Employee {
    id: number;
    nationalIDNumber: string;
    organizationLevel: number;
    jobTitle: string;
    maritalStatus: string;
    gender: string;
}

export interface EmployeeDetail {
    id: number;
    nationalIdnumber: string;
    organizationLevel: number;
    jobTitle: string;
    birthDate: Date;
    maritalStatus: string;
    gender: string;
    hireDate: Date;
    salariedFlag: boolean;
    vacationHours: number;
    sickLeaveHours: number;
    currentFlag: boolean;
}
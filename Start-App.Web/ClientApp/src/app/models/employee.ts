export interface Employee {
    id: number;
    nationalIdnumber: string;
    organizationLevel: number;
    jobTitle: string;
    // birthDate: Date;
    maritalStatus: string;
    gender: string;
    // hireDate: Date;
    // salariedFlag: boolean;
    // vacationHours: number;
    // sickLeaveHours: number;
    // currentFlag: boolean;
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
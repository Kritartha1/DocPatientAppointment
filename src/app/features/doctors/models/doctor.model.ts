export interface Doctor {
    id: string;
    userName: string;
    email: string;
    name: string;
    qualifications: string;
    specialization: string;
    hospital: string;
    appts: object[];
    fees: number;
}
export class Employee {
  constructor(
    public id?: string,
    public firstName?: string,
    public lastName?: string,
    public positionId?: string,
    public salary?: string,
    public hireDate?: Date,
    public dismissalDate?: Date
  ) { }
}

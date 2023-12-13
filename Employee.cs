using System;

namespace PracticeTask1
{
    public class Employee : User
    {
        public List<DateTime> Vacations { get; set; } = [];
        private string Department {  get; set; }
        public Employee(string department,string firstName, string middleName, string lastName, int age)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Department = department;

            if (age > 0) Age = age;
            else throw new Exception("Возраст должен быть больше нуля.");
        }

        public string GetFullName()
        {
            return $"{FirstName} {MiddleName} {LastName}";
        }
        public void AddVacation(DateTime vacation)
        {
            if (!Vacations.Contains(vacation)) Vacations.Add(vacation);
        }
    }
}

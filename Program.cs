using System;

namespace PracticeTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            var hrVacations = new VacationMaster("HR");
            
            var ivanovII = new Employee("HR","Иван", "Иванович", "Иванов", 30);
            var petrovPP = new Employee("HR","Петр", "Петрович", "Петров", 30);
            var ulinaUU = new Employee("HR", "Юля", "Юлиановна", "Юлина", 30);
            var sidorovSS = new Employee("HR","Сидор", "Сидорович", "Сидоров", 30);
            var pavlovPP = new Employee("HR","Павел", "Павлович", "Павлов", 30);
            var georgievGG = new Employee("HR","Георг", "Георгиевич", "Георгиев", 30);


            var employees = new List<Employee>()
            {
                  ivanovII,
                  petrovPP,
                  ulinaUU,
                  sidorovSS,
                  pavlovPP,
                  georgievGG,
            };

            hrVacations.SetVacation(employees);

            hrVacations.PrintVacations(employees);

            Console.ReadKey();
        }
    }


}


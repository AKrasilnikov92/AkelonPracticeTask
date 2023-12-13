using System;

namespace PracticeTask1
{
    public class VacationMaster
    {
        private Guid Id { get; set; }
        private string Department { get; set; }
        private readonly List<string> workDays = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];
        private List<DateTime> employeeDateList = [];

        public VacationMaster(string department)
        {
            Id = Guid.NewGuid();
            Department = department;
        }

        /// <summary>
        /// Запись отпусков
        /// </summary>
        /// <param name="employees"></param>
        public void SetVacation(List<Employee> employees)
        {
            var allVacationsCount = 0;
            DateTime startYear = new(DateTime.Now.Year, 1, 1);
            DateTime endYear = new(DateTime.Today.Year, 12, 31);

            foreach (var employee in employees)
            {
                Random gen = new();
                Random step = new();
                int vacationCount = 28;

                while (vacationCount > 0)
                {
                    int range = (endYear - startYear).Days;
                    var startDate = startYear.AddDays(gen.Next(range));

                    if (workDays.Contains(startDate.DayOfWeek.ToString()))
                    {
                        string[] vacationSteps = ["7", "14"];
                        int vacIndex = gen.Next(vacationSteps.Length);
                        var endDate = new DateTime(DateTime.Now.Year, 12, 31);
                        int difference = 0;
                        if (vacationSteps[vacIndex] == "7")
                        {
                            endDate = startDate.AddDays(7);
                            difference = 7;
                        }
                        else
                        {
                            endDate = startDate.AddDays(14);
                            difference = 14;
                        }

                        if (vacationCount <= 7)
                        {
                            endDate = startDate.AddDays(7);
                            difference = 7;
                        }

                        if (CanCreateVacation(employee, startDate, endDate) && vacationCount > 0)
                        {
                            AddDay(employee, startDate, endDate);

                            allVacationsCount++;

                            vacationCount -= difference;
                        }
                        else continue;


                    }
                }

                for (int i = 0; i < employee.Vacations.Count; i++)
                {
                    employeeDateList.Add(employee.Vacations[i]);
                }
            }
        }

        /// <summary>
        /// Добавить день отпуска
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="startDate">Начальная дата</param>
        /// <param name="endDate">Конечная дата</param>
        private static void AddDay(Employee employee, DateTime startDate, DateTime endDate)
        {
            for (DateTime dt = startDate; dt < endDate; dt = dt.AddDays(1))
                employee.Vacations.Add(dt);
        }

        /// <summary>
        /// Можно ли добавить отпуск?
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="startDate">Начальная дата</param>
        /// <param name="endDate">Конечная дата</param>
        /// <returns>Возможность добавления отпуска</returns>
        private static bool CanCreateVacation(Employee employee, DateTime startDate, DateTime endDate)
        {
            bool existStart = false;
            bool existEnd = false;

            if (!employee.Vacations.Any(e => e >= startDate && e <= endDate))
            {
                if (!employee.Vacations.Any(e => e.AddDays(3) >= startDate && e.AddDays(3) <= endDate))
                {
                    existStart = employee.Vacations.Any(e => e.AddMonths(1) >= startDate && e.AddMonths(1) >= endDate);
                    existEnd = employee.Vacations.Any(e => e.AddMonths(-1) <= startDate && e.AddMonths(-1) <= endDate);
                    if (!existStart || !existEnd)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Вывести список отпусков и сотрудников в консоль
        /// </summary>
        /// <param name="employees">Список сотрудников</param>
        public void PrintVacations(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"Дни отпуска сотрудника {employee.GetFullName()}: ");

                foreach (var vacationDay in employee.Vacations)
                {
                    Console.WriteLine(vacationDay.ToShortDateString());
                }

                Console.WriteLine($"Всего дней: {employee.Vacations.Count}");
                Console.WriteLine(new string('-', 20));
            }
        }

        /// <summary>
        /// Получить список всех отпускных дней отдела
        /// </summary>
        /// <returns></returns>
        public List<DateTime> GetDepVacations()
        {
            return employeeDateList;
        }

    }
}


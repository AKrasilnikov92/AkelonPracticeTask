using System;

namespace PracticeTask1
{
    public abstract class User
    {
        private protected Guid Id { get; set; }
        private protected string FirstName { get; set; }
        private protected string LastName { get; set; }
        private protected string MiddleName { get; set; }
        private protected int Age { get; set; }
    }
}

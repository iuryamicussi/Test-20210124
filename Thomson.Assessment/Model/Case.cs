using System;
namespace Thomson.Assessment.Model
{
    public class Case
    {
        public string Number { get; set; }

        public string CourtName { get; set; }

        public string ResponsibleName { get; set; }

        public DateTime? RegistrationDate { get; set; }
    }
}
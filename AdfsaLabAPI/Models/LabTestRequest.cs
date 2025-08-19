using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdfsaLabAPI.Models
{
    public class LabTestRequest
    {
        public string LabCaseID { get; set; }
        public string Organization { get; set; }
        public string Category { get; set; }
        public Human Human { get; set; }   // optional
        public Animal Animal { get; set; }
        public FoodWater Food_Water { get; set; } // optional
    }

    // Human details (if needed in future)
    public class Human
    {
        public string Name { get; set; }
        public string EmiratesId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        // Add more if required
    }

    public class Animal
    {
        public string Species { get; set; }
        public string Owner_Id { get; set; }
        public string Owner_Emirates_Id { get; set; }
        public string Owner_Email { get; set; }
        public string Owner_Phone_Number { get; set; }
        public string Batch_Category { get; set; }
        public string Emirate_Or_Location { get; set; }
        public string Region { get; set; }
        public string Area { get; set; }
        public List<AnimalInfo> Animals { get; set; }
        public List<Test> Tests { get; set; }
    }

    public class AnimalInfo
    {
        public string Animal_Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public string Age { get; set; }
    }

    public class Test
    {
        public string Group_Code { get; set; }
        public string Test_Code { get; set; }
        public string Test_Name { get; set; }
        public string Sample_Type { get; set; }
        public decimal Price { get; set; }
    }

    // optional placeholder
    public class FoodWater
    {
        public string Type { get; set; }
        public string Source { get; set; }
    }
}
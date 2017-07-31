using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    // kk-TrainingProgram class will have the following entities: TrainingProgramName, StartDate, EndDate, MaxAttendees.
    public class TrainingProgram
    {
    // The key for the object will be the TrainingProgram id.  
        [Key]
        public int TrainingProgramId { get; set; }
        
        // kk - TrainingProgramName: the name/title of the training program.
        [Required]
        public string TrainingProgramName { get; set; }

        // kk - StartDate: This uses a DateTime object to input the starting date of a training program. It uses DateTime to store the year, month, and day.
        [Required]
        public DateTime StartDate { get; set; }

        
        // kk - EndDate object stores the starting date of a training program. It uses DateTime to store the year, month and day.
        public DateTime EndDate { get; set; }

        // kk - MaxAttendees object will store and output the maximum number of employees that may attend a training program. It will hold this number with an int type.
        public int MaxAttendees { get; set; }
        
        // TrainingProgram is connected to Employee via a TrainingProgram join table. When Employees is queried TrainingProgram will be able to be accessed.
        // public virtual ICollection<Employee> Employees { get; set; }
    }
}
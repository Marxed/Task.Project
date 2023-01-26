using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bundre.Task.Business.Models
{
    public class TaskModel: Entity
    {
        public string descriptionTask { get; set; }
        public string titleTask { get; set; }
        public Status statusTask { get; set; }
        public string dateCreation { get; set; }
        public string dateValidation { get; set; }
        public string photoTask { get; set; }
        public string idUser { get; set; }
        
        //EF
        public IEnumerable<TaskUserModel> TaskUserModel { get; set; }    
    }
}
// Server = localhost; Database = master; Trusted_Connection = True;
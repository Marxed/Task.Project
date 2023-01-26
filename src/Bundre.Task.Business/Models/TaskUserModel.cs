using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bundre.Tasks.Business.Models
{
    public class TaskUserModel : Entity
    {
        public Guid taskId { get; set; }
        public string userId { get; set; }
        public TaskRole taskRole { get; set; }

        //EF
        public TaskModel TaskModel { get; set; }
    }
}


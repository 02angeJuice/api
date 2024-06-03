using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Emp
    {
            public int EmpNo { get; set; }

            public string? Ename { get; set; } = string.Empty;

            public string? Job{ get; set; } = string.Empty;

            public string? Mgr { get; set; } = string.Empty;
            public DateTime? HireDate { get; set; }

            public int? Sal { get; set; }

            public int? Comm { get; set; }

            public string?  DeptNo { get; set; }
    }
}
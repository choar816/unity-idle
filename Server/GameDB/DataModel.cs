using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDB
{
    [Table("Test")]
    public class TestDb
    {
        // Convention : [클래스]Id로 명명하면 PK
        public int TestDbId { get; set; }
        public string Name { get; set; }
    }
}

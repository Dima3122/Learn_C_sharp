using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql
{
    class DropTableStatement : SqlStatement
    {
        override public void write_data()
        {
            Console.WriteLine(sql_script);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace sql
{
    class CreateTableStatatement : SqlStatement
    {
        private List<ColumnDef> columns;
        public void set_columns(ColumnDef columns)
        {
            this.columns.Add(columns);
        }
        public List<ColumnDef> get_columns()
        {
            return columns;
        }
        public CreateTableStatatement()
        {
            columns = new List<ColumnDef>();
        }
        override public void write_data()
        {
            Console.WriteLine(columns[0].TypeName_or_value);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql
{
    class DeleteStatement : SqlStatement
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
        public DeleteStatement()
        {
            columns = new List<ColumnDef>();
        }
        override public void write_data()
        {
            Console.WriteLine(columns[0].TypeName_or_value);
        }
    }
}

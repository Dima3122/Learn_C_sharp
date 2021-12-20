using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql
{
    struct ColumnDef
    {
        public string ColumnName;
        public string TypeName_or_value;
        public ColumnDef(string ColumName, string Typename_or_value)
        {
            this.ColumnName = ColumName;
            this.TypeName_or_value = Typename_or_value;
        }
    };
    struct Expression
    {
        public string Operand1;
        public string Operation;
        public string Operand2;
        public Expression(string Operand1, string Operation, string Operand2)
        {
            this.Operand1 = Operand1;
            this.Operation = Operation;
            this.Operand2 = Operand2;
        }
    };
    abstract class SqlStatement
    {
        public string TableName { get; set; }
        public abstract void write_data();
        ~SqlStatement(){}
    }
}

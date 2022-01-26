using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql
{
    class DeleteStatement : SqlStatement
    {
        private List<Expression> columns;
        public void set_columns(Expression columns)
        {
            this.columns.Add(columns);
        }
        public List<Expression> get_columns()
        {
            return columns;
        }
        public DeleteStatement()
        {
            columns = new List<Expression>();
        }
        override public void write_data()
        {
            Console.WriteLine(columns[0].Operand1);
            Console.WriteLine(columns[0].Operand2);
            Console.WriteLine(columns[0].Operation);
        }
        public override void Accept(ref ExecuteVisitor visitor)
        {
            DeleteStatement DeleteStatement = this;
            visitor.visit(ref DeleteStatement);
        }
    }
}

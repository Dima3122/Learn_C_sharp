using System;
using System.Collections.Generic;

namespace sql
{
    class SelectStatement : SqlStatement
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
        public SelectStatement()
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
            SelectStatement SelectStatement = this;
            visitor.visit(ref SelectStatement);
        }
    }
}

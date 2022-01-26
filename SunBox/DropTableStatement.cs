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
            Console.WriteLine(TableName);
        }
        public override void Accept(ref ExecuteVisitor visitor)
        {
            DropTableStatement DropTableStatement = this;
            visitor.visit(ref DropTableStatement);
        }
    }
}

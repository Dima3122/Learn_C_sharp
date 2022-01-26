using System;

namespace sql
{
    class ExecuteVisitor : Visitor
    {
        public override void visit(ref CreateTableStatatement CreateStatement)
        {
            CreateStatement.write_data();
        }
        public override void visit(ref SelectStatement SelectStatement)
        {
            SelectStatement.write_data();
        }
        public override void visit(ref InsertStatement InsertStatement)
        {
            InsertStatement.write_data();
        }
        public override void visit(ref DeleteStatement DeleteStatement)
        {
            DeleteStatement.write_data();
        }
        public override void visit(ref DropTableStatement DropStatement)
        {
            DropStatement.write_data();
        }
    }
}

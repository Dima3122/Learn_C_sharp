using System;

namespace sql
{
    abstract class Visitor
    {
        public abstract void visit(ref CreateTableStatatement CreateStatement);
        public abstract void visit(ref SelectStatement SelectStatement);
        public abstract void visit(ref InsertStatement InsertStatement);
        public abstract void visit(ref DeleteStatement DeleteStatement);
        public abstract void visit(ref DropTableStatement DropStatement);
        ~Visitor() { }
    }
}

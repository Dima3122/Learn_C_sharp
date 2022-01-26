using System;
using sql;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser(new Lexer(""));
            ExecuteVisitor visitor = new ExecuteVisitor();
            Parser.SqlScript sqlStatements = parser.Parse("SELECT TABLE garwmer ( name TEXT name, age INT name, coin REAL name ) ;");
            Console.WriteLine(sqlStatements.Statements[0].TableName);
            sqlStatements.Statements[0].write_data();
            sqlStatements.Statements[0].Accept(ref visitor);
        }
    }
}

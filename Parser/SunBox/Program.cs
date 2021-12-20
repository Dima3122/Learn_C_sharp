using System;
using sql;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Lexer lexer = new Lexer("");
            Parser parser = new Parser(lexer);
            Parser.SqlScript sqlStatements = parser.Parse("SELECT TABLE garwmer ( name TEXT name, age INT name, coin REAL name ) ;");
            Console.WriteLine(sqlStatements.Statements[0].TableName);
            sqlStatements.Statements[0].write_data();
        }
    }
}

using System;
using sql;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateTableStatatement statatement = new CreateTableStatatement();
            ColumnDef column = new ColumnDef("Hello world njk jk khkhj jkkjkj", "TYPENAME");
            statatement.set_columns(column);
            Lexer lexer = new Lexer("hello wo");
            Token token = lexer.Get_Token();
            Console.WriteLine(token.Lexem);
            token = lexer.Peek_Token();
            Console.WriteLine(token.Lexem);
            token = lexer.Get_Token();
            Console.WriteLine(token.Lexem);
            Parser parser = new Parser(lexer);
            //parser.Parse("CREATE wordld");
            //statatement.write_data();
        }
    }
}

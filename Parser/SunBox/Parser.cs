using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql
{
    class Parser
    {
        public struct Error
        {
            public string str;
            public string type;
            public string expected;
            public Error(string str, string type, string expected)
            {
                this.str = str;
                this.type = type;
                this.expected = expected;
            }
        };
        public struct SqlScript
        {
            public List<SqlStatement> Statements;
            public List<Error> Errors;
            public SqlScript(List<SqlStatement> Statements, List<Error> Errors)
            {
                this.Statements = Statements;
                this.Errors = Errors;
            }
        };
        private Lexer lexer;
        private SqlScript result;
        public Parser(Lexer lexer_)
        {
            lexer = lexer_;
        }
        public SqlStatement ParseCreateTableStatement()
        {
            CreateTableStatatement StatementCreate = new CreateTableStatatement();
            lexer.Get_Token();
            return StatementCreate;
        }
        public SqlStatement ParseSelectTableStatement()
        {
            SelectStatement StatementSelect = new SelectStatement();
            lexer.Get_Token();
            return StatementSelect;
        }
        public SqlStatement ParseDeleteTableStatement()
        {
            DeleteStatement StatementDelete = new DeleteStatement();
            lexer.Get_Token();
            return StatementDelete;
        }
        public SqlStatement ParseDropTableStatement()
        {
            DropTableStatement StatementDrop = new DropTableStatement();
            lexer.Get_Token();
            return StatementDrop;
        }
        public SqlStatement ParseInsertTableStatement()
        {
            InsertStatement StatementInsert = new InsertStatement();
            lexer.Get_Token();
            return StatementInsert;
        }
        public SqlScript Parse(string str)
        {
            Lexer lexer = new Lexer(str);
            Parser parser = new Parser(lexer);
            Token token = new Token();
            Error error = new Error();
            List<SqlStatement> Statements = new List<SqlStatement>();
            List<Error> errors = new List<Error>();
            SqlScript result = new SqlScript(Statements, errors);
            do
            {
                token = lexer.Peek_Token();
                if (token.TokenType == TokenType.Keyword && token.Lexem == "CREATE")
                {
                    result.Statements.Add(parser.ParseCreateTableStatement());
                }
                else if (token.TokenType == TokenType.Keyword && token.Lexem == "SELECT")
                {
                    result.Statements.Add(parser.ParseSelectTableStatement());
                }
                else if (token.TokenType == TokenType.Keyword && token.Lexem == "INSERT")
                {
                    result.Statements.Add(parser.ParseInsertTableStatement());
                }
                else if (token.TokenType == TokenType.Keyword && token.Lexem == "DELETE")
                {
                    result.Statements.Add(parser.ParseDeleteTableStatement());
                }
                else if (token.TokenType == TokenType.Keyword && token.Lexem == "DROP")
                {
                    result.Statements.Add(parser.ParseDropTableStatement());
                }
                else
                {
                    error.expected = "STATEMENT";
                    error.str = "Any statement expected";
                    error.type = "Keyword";
                    result.Errors.Add(error);
                }
            } while (token.TokenType != TokenType.FinalToken);
            return result;
        }
    };
}
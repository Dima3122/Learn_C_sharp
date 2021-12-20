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
        private SqlScript result = new SqlScript();
        public Parser(Lexer lexer_)
        {
            lexer = lexer_;
        }
        public SqlStatement ParseCreateTableStatement()
        {
            CreateTableStatatement StatementCreate = new CreateTableStatatement();
            Token token = lexer.Get_Token();
            Error error = new Error();
            if (!(token.TokenType == TokenType.Keyword && token.Lexem == "CREATE"))
            {
                error.expected = "DROP";
                error.str = "Create value expected";
                error.type = "Keyword";
                result.Errors.Add(error);
            }

            token = lexer.Get_Token();
            if (!(token.TokenType == TokenType.Keyword && token.Lexem == "TABLE"))
            {
                error.expected = "TABLE";
                error.str = "Table value expected";
                error.type = "Keyword";
                result.Errors.Add(error);
            }

            token = lexer.Get_Token();
            if (token.TokenType != TokenType.ID)
            {
                error.expected = "Table name";
                error.str = "Table title expected";
                error.type = "ID";
                result.Errors.Add(error);
            }
            StatementCreate.TableName = token.Lexem;
            token = lexer.Get_Token();
            if (token.TokenType == TokenType.ID && token.Lexem != "(")
            {
                error.expected = "(";
                error.str = "Expected (";
                error.type = "Bracket";
                result.Errors.Add(error);
            }
            
            token = lexer.Get_Token();
            while (true)
            {
                if (token.TokenType != TokenType.ID)
                {
                    error.expected = "Column name";
                    error.str = "Expected column name";
                    error.type = "ID";
                    result.Errors.Add(error);
                }
                ColumnDef columnDef;
                columnDef.ColumnName = token.Lexem;
                token = lexer.Get_Token();
                if (token.TokenType != TokenType.TypeName)
                {
                    error.expected = "column type";
                    error.str = "Expected column type";
                    error.type = "TypeName";
                    result.Errors.Add(error);
                }
                columnDef.TypeName_or_value = token.Lexem;
                StatementCreate.set_columns(columnDef);
                token = lexer.Get_Token();
                if(token.TokenType == TokenType.Bracket)
                {
                    break;
                }
                token = lexer.Get_Token();
            }
            token = lexer.Get_Token();
            if (token.TokenType != TokenType.Semicolon)
            {
                error.expected = ";";
                error.str = "Expected ;";
                error.type = "Semicolon";
                result.Errors.Add(error);
            }
            return StatementCreate;
        }
        public SqlStatement ParseSelectTableStatement()
        {
            SelectStatement StatementSelect = new SelectStatement();
            Token token = lexer.Get_Token();
            Error error = new Error();
            if (!(token.TokenType == TokenType.Keyword && token.Lexem == "SELECT"))
            {
                error.expected = "DROP";
                error.str = "Create value expected";
                error.type = "Keyword";
                result.Errors.Add(error);
            }

            token = lexer.Get_Token();
            if (!(token.TokenType == TokenType.Keyword && token.Lexem == "TABLE"))
            {
                error.expected = "TABLE";
                error.str = "Table value expected";
                error.type = "Keyword";
                result.Errors.Add(error);
            }

            token = lexer.Get_Token();
            if (token.TokenType != TokenType.ID)
            {
                error.expected = "Table name";
                error.str = "Table title expected";
                error.type = "ID";
                result.Errors.Add(error);
            }
            StatementSelect.TableName = token.Lexem;
            token = lexer.Get_Token();
            if (token.TokenType == TokenType.ID && token.Lexem != "(")
            {
                error.expected = "(";
                error.str = "Expected (";
                error.type = "Bracket";
                result.Errors.Add(error);
            }

            token = lexer.Get_Token();
            while (true)
            {
                if (token.TokenType != TokenType.ID)
                {
                    error.expected = "Column name";
                    error.str = "Expected column name";
                    error.type = "ID";
                    result.Errors.Add(error);
                }
                Expression columnDef;
                columnDef.Operand1 = token.Lexem;
                token = lexer.Get_Token();
                if (token.TokenType != TokenType.Operation)
                {
                    error.expected = "column type";
                    error.str = "Expected column type";
                    error.type = "TypeName";
                    result.Errors.Add(error);
                }
                columnDef.Operation = token.Lexem;
                token = lexer.Get_Token();
                if (token.TokenType != TokenType.Operation)
                {
                    error.expected = "column type";
                    error.str = "Expected column type";
                    error.type = "TypeName";
                    result.Errors.Add(error);
                }
                columnDef.Operand2 = token.Lexem;
                StatementSelect.set_columns(columnDef);
                token = lexer.Get_Token();
                if (token.TokenType == TokenType.Bracket)
                {
                    break;
                }
                token = lexer.Get_Token();
            }
            token = lexer.Get_Token();
            if (token.TokenType != TokenType.Semicolon)
            {
                error.expected = ";";
                error.str = "Expected ;";
                error.type = "Semicolon";
                result.Errors.Add(error);
            }
            return StatementSelect;
        }
        public SqlStatement ParseDeleteTableStatement()
        {
            DeleteStatement StatementDelete = new DeleteStatement();
            Token token = lexer.Get_Token();
            Error error = new Error();
            if (!(token.TokenType == TokenType.Keyword && token.Lexem == "SELECT"))
            {
                error.expected = "DROP";
                error.str = "Create value expected";
                error.type = "Keyword";
                result.Errors.Add(error);
            }

            token = lexer.Get_Token();
            if (!(token.TokenType == TokenType.Keyword && token.Lexem == "TABLE"))
            {
                error.expected = "TABLE";
                error.str = "Table value expected";
                error.type = "Keyword";
                result.Errors.Add(error);
            }

            token = lexer.Get_Token();
            if (token.TokenType != TokenType.ID)
            {
                error.expected = "Table name";
                error.str = "Table title expected";
                error.type = "ID";
                result.Errors.Add(error);
            }
            StatementDelete.TableName = token.Lexem;
            token = lexer.Get_Token();
            if (token.TokenType == TokenType.ID && token.Lexem != "(")
            {
                error.expected = "(";
                error.str = "Expected (";
                error.type = "Bracket";
                result.Errors.Add(error);
            }

            token = lexer.Get_Token();
            while (true)
            {
                if (token.TokenType != TokenType.ID)
                {
                    error.expected = "Column name";
                    error.str = "Expected column name";
                    error.type = "ID";
                    result.Errors.Add(error);
                }
                Expression columnDef;
                columnDef.Operand1 = token.Lexem;
                token = lexer.Get_Token();
                if (token.TokenType != TokenType.Operation)
                {
                    error.expected = "column type";
                    error.str = "Expected column type";
                    error.type = "TypeName";
                    result.Errors.Add(error);
                }
                columnDef.Operation = token.Lexem;
                token = lexer.Get_Token();
                if (token.TokenType != TokenType.Operation)
                {
                    error.expected = "column type";
                    error.str = "Expected column type";
                    error.type = "TypeName";
                    result.Errors.Add(error);
                }
                columnDef.Operand2 = token.Lexem;
                StatementDelete.set_columns(columnDef);
                token = lexer.Get_Token();
                if (token.TokenType == TokenType.Bracket)
                {
                    break;
                }
                token = lexer.Get_Token();
            }
            token = lexer.Get_Token();
            if (token.TokenType != TokenType.Semicolon)
            {
                error.expected = ";";
                error.str = "Expected ;";
                error.type = "Semicolon";
                result.Errors.Add(error);
            }
            return StatementDelete;
        }
        public SqlStatement ParseDropTableStatement()
        {
            DropTableStatement StatementDrop = new DropTableStatement();
            Token token = lexer.Get_Token();
            Error error = new Error();
            if (!(token.TokenType == TokenType.Keyword && token.Lexem == "DROP"))
            {
                error.expected = "DROP";
                error.str = "Drop value expected";
                error.type = "Keyword";
                result.Errors.Add(error);
            }
            token = lexer.Get_Token();
            if (!(token.TokenType == TokenType.Keyword && token.Lexem == "TABLE"))
            {
                error.expected = "TABLE";
                error.str = "Table value expected";
                error.type = "Keyword";
                result.Errors.Add(error);
            }
            token = lexer.Get_Token();
            if (token.TokenType != TokenType.ID)
            {
                error.expected = "Table name";
                error.str = "Table title expected";
                error.type = "ID";
                result.Errors.Add(error);
            }
            StatementDrop.TableName = token.Lexem;
            token = lexer.Get_Token();
            if (token.TokenType != TokenType.Semicolon)
            {
                error.expected = ";";
                error.str = "Expected ;";
                error.type = "Semicolon";
                result.Errors.Add(error);
            }
            return StatementDrop;
        }
        public SqlStatement ParseInsertTableStatement()
        {
            InsertStatement StatementInsert = new InsertStatement();
            Token token = lexer.Get_Token();
            Error error = new Error();
            if (!(token.TokenType == TokenType.Keyword && token.Lexem == "CREATE"))
            {
                error.expected = "DROP";
                error.str = "Create value expected";
                error.type = "Keyword";
                result.Errors.Add(error);
            }

            token = lexer.Get_Token();
            if (!(token.TokenType == TokenType.Keyword && token.Lexem == "TABLE"))
            {
                error.expected = "TABLE";
                error.str = "Table value expected";
                error.type = "Keyword";
                result.Errors.Add(error);
            }

            token = lexer.Get_Token();
            if (token.TokenType != TokenType.ID)
            {
                error.expected = "Table name";
                error.str = "Table title expected";
                error.type = "ID";
                result.Errors.Add(error);
            }
            StatementInsert.TableName = token.Lexem;
            token = lexer.Get_Token();
            if (token.TokenType == TokenType.ID && token.Lexem != "(")
            {
                error.expected = "(";
                error.str = "Expected (";
                error.type = "Bracket";
                result.Errors.Add(error);
            }

            token = lexer.Get_Token();
            while (true)
            {
                if (token.TokenType != TokenType.ID)
                {
                    error.expected = "Column name";
                    error.str = "Expected column name";
                    error.type = "ID";
                    result.Errors.Add(error);
                }
                ColumnDef columnDef;
                columnDef.ColumnName = token.Lexem;
                token = lexer.Get_Token();
                if (token.TokenType != TokenType.TypeName)
                {
                    error.expected = "column type";
                    error.str = "Expected column type";
                    error.type = "TypeName";
                    result.Errors.Add(error);
                }
                columnDef.TypeName_or_value = token.Lexem;
                StatementInsert.set_columns(columnDef);
                token = lexer.Get_Token();
                if (token.TokenType == TokenType.Bracket)
                {
                    break;
                }
                token = lexer.Get_Token();
            }
            token = lexer.Get_Token();
            if (token.TokenType != TokenType.Semicolon)
            {
                error.expected = ";";
                error.str = "Expected ;";
                error.type = "Semicolon";
                result.Errors.Add(error);
            }
            return StatementInsert;
        }
        public SqlScript Parse(string str)
        {
            lexer = new Lexer(str);
            Token token = new Token();
            Error error = new Error();
            List<SqlStatement> Statements = new List<SqlStatement>();
            List<Error> errors = new List<Error>();
            result = new SqlScript(Statements, errors);
            do
            {
                token = lexer.Peek_Token();
                if (token.TokenType == TokenType.Keyword && token.Lexem == "CREATE")
                {
                    result.Statements.Add(ParseCreateTableStatement());
                }
                else if (token.TokenType == TokenType.Keyword && token.Lexem == "SELECT")
                {
                    result.Statements.Add(ParseSelectTableStatement());
                }
                else if (token.TokenType == TokenType.Keyword && token.Lexem == "INSERT")
                {
                    result.Statements.Add(ParseInsertTableStatement());
                }
                else if (token.TokenType == TokenType.Keyword && token.Lexem == "DELETE")
                {
                    result.Statements.Add(ParseDeleteTableStatement());
                }
                else if (token.TokenType == TokenType.Keyword && token.Lexem == "DROP")
                {
                    result.Statements.Add(ParseDropTableStatement());
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
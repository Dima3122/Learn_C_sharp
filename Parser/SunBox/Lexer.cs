using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql {
    
    public enum TokenType
    {
        String = 0,
        Int = 1,
        Real = 2,
        Keyword = 3,
        ID = 4,
        Operation = 5,
        CommonSeparator = 6,
        Bracket = 7,
        Semicolon = 8,
        InvalidToken = 9,
        FinalToken = 10,
        Comma = 11,
        TypeName = 12
    };
    struct Token
    {
        public TokenType TokenType;
        public string Lexem;
        public Token(string Lexem, TokenType TokenType)
        {
            this.Lexem = Lexem;
            this.TokenType = TokenType;
        }
    };
    class Lexer
    {
        public struct Rule
        {
            public Regex regex;
            public TokenType Type;
            public Rule(Regex regex, TokenType Type)
            {
                this.regex = regex;
                this.Type = Type;
            }
        }
        private List<Rule> Rules = new List<Rule>();

        private string parse_str;
        private int pos_curs;
        public void set_parse_str(string parse_str)
        {
            this.parse_str = parse_str;
        }
        public string get_parse_str()
        {
            return parse_str;
        }
        public Lexer(string parse_str)
        {
            this.parse_str = parse_str;
            pos_curs = 0;
            Rules.Add(new Rule(new Regex("\".*?\""), TokenType.String));
            Rules.Add(new Rule(new Regex("[-+]?0|[-+]?[1-9][0-9]*"), TokenType.Int));
            Rules.Add(new Rule(new Regex("[-+]?0.[0-9]+|[1-9][0-9]*.[0-9]*"), TokenType.Real));
            Rules.Add(new Rule(new Regex("(SELECT|CREATE|INSERT|DELETE|DROP|FROM|TABLE|INTO|WHERE|VALUES)(?=\\W)"), TokenType.Keyword));
            Rules.Add(new Rule(new Regex("[a-z][a-z0-9]*"), TokenType.ID));
            Rules.Add(new Rule(new Regex("=|!=|<|>|>=|=<"), TokenType.Operation));
            Rules.Add(new Rule(new Regex("\t|\r|\n|\\s|$"), TokenType.CommonSeparator));
            Rules.Add(new Rule(new Regex("[\\{\\}\\(\\)]"), TokenType.Bracket));
            Rules.Add(new Rule(new Regex(";"), TokenType.Semicolon));
            Rules.Add(new Rule(new Regex("(INT|REAL|TEXT)(?=\\W)"), TokenType.TypeName));
        }
        public Token Get_Token()
        {
            Token token = Peek_Token();
            parse_str = parse_str.Replace(token.Lexem, "");
            return token;
        }
        public Token Peek_Token()
        {
            Token token = new Token();
            if (pos_curs >= parse_str.Length)
            {
                token.Lexem = "";
                token.TokenType = TokenType.FinalToken;
                return token;
            }
            foreach (var it in Rules)
            {
                Match match = it.regex.Match(parse_str);
                if (match.Success)
                {
                    token.Lexem = match.Value;
                    token.TokenType = it.Type;
                    return token;
                }
            }
            return token;
        }
    }
}

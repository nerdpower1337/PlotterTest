using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gcodes;
using System.IO;
using Gcodes.Tokens;
using Gcodes.Ast;

namespace Test2
{
    class Class1
    {
        static void Main(string[] args)
        {

            string src = File.ReadAllText("C:\\temp\\output_0004.ngc");

            var lexer = new Lexer(src);
            List<Token> tokens = lexer.Tokenize().ToList();

            var parser = new Parser(tokens);
            List<Code> gcodes = parser.Parse().ToList();

            int x = 0;


        }
    }
}

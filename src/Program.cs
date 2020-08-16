﻿using System;

using DataKeep.Tokens;
using DataKeep.ParserTypes;
using DataKeep.Syntax;

namespace DataKeep
{
    class Program
    {
        static void Main(string[] args)
        {

            Lexer lexer = new Lexer(new FileHandler("data.dk"));
            lexer.LexAllLines();

            foreach(Token[] ts in lexer.fileTokens)
            {
                Console.WriteLine("------------");
                Token[] tss = Token.RemoveBeginWhiteSpace(ts);

                foreach (Token t in tss)
                    Token.PrintToken(t);   
            }

            Parser parser = new Parser(lexer);

            parser.ParseAllLines();
            parser.GiveStructInheritance();
            parser.PrintAllData();


            SyntaxParser syntaxParser = new SyntaxParser(new FileHandler("main.dks"));
            syntaxParser.ParseAllLines();
            syntaxParser.PrintAllData();

            Linker linker = new Linker(syntaxParser, parser);
            linker.Convert();
            linker.OutputToFile("output.csbutnotcs");
            



        }
    }

  
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;

namespace CompiPascal.Analisis
{
    class Sintactico1: Grammar
    {
        public void analizar(String cadena)
        {
            Gramatica1 gramatica = new Gramatica1();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;            

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Irony.Ast;
using Irony.Parsing;

namespace CompiPascal.Analisis
{
    class Gramatica1: Grammar
    {
        public Gramatica1(): base (caseSensitive: true)
        {

            #region ER
            var NUMERO = new NumberLiteral("Numero");
            #endregion

            #region Terminales
            var REVALUAR = ToTerm("Evaluar");
            var PTCOMA = ToTerm(";");
            var PARIZQ = ToTerm("(");
            var PARDER = ToTerm(")");
            var CORIZQ = ToTerm("[");
            var CORDER = ToTerm("]");
            var MAS = ToTerm("+");
            var MENOS = ToTerm("-");
            var POR = ToTerm("*");
            var DIVIDIDO = ToTerm("/");

            RegisterOperators(1, MAS, MENOS);
            RegisterOperators(2, POR, DIVIDIDO);

            #endregion

            #region No Terminales
            NonTerminal ini = new NonTerminal("ini");
            NonTerminal instruccion = new NonTerminal("instruccion");
            NonTerminal instrucciones = new NonTerminal("instrucciones");
            NonTerminal expresion = new NonTerminal("expresion");
            #endregion

            #region Gramatica
            ini.Rule = instrucciones;

            instrucciones.Rule = instruccion + instrucciones
                | instruccion;

            instruccion.Rule = REVALUAR + CORIZQ + expresion + CORDER + PTCOMA;

            expresion.Rule = MENOS + expresion
                | expresion + MAS + expresion
                | expresion + MENOS + expresion
                | expresion + POR + expresion
                | expresion + DIVIDIDO + expresion
                | NUMERO
                | PARIZQ + expresion + PARDER;

            #endregion

            #region Preferencias
            this.Root = ini;
            #endregion

        }
    }
}

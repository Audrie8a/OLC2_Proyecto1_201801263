using System;
using System.Collections.Generic;
using System.Text;
using Irony.Ast;
using Irony.Parsing;

namespace CompiPascal.Analisis
{
    class Gramatica:Grammar
    {
        public Gramatica() : base(caseSensitive: true)
        {
            #region ER
            var NUMERO = new RegexBasedTerminal("NUMERO", "[0-9]+");
            var DECIMAL = new RegexBasedTerminal("DECIMAL", "[0-9]+'.'[0-9]+");
            StringLiteral CADENA = new StringLiteral("CADENA", "'");
            IdentifierTerminal ID = new IdentifierTerminal("ID");
            CommentTerminal COMENTARIOLINEA = new CommentTerminal("COMENTARIOLINEA", "//", "\n", "\r\n");
            CommentTerminal COMENTARIOMULTILINEA1 = new CommentTerminal("COMENTARIOMULTILINEA1", "(*", "*)");
            CommentTerminal COMENTARIOMULTILINEA2 = new CommentTerminal("COMENTARIOMULTILINEA2", "{", "}");
            var TAB = new RegexBasedTerminal("TAB", "\t|\n\t");
            #endregion

            #region Terminales
            var BOOLEANOT = ToTerm("true");
            var BOOLEANOF = ToTerm("false");
            var PROGRAM = ToTerm("program");
            var PTCOMA = ToTerm(";");
            var COMA = ToTerm(",");
            var CONST = ToTerm("const");
            var PUNTO = ToTerm(".");
            var USES = ToTerm("uses");
            var IGUAL = ToTerm("=");
            var VAR = ToTerm("var");
            var DOSPUNTOS = ToTerm(":");
            var STRING = ToTerm("string");
            var INTEGER = ToTerm("integer");
            var REAL = ToTerm("real");
            var BOOLEAN = ToTerm("boolean");
            var VOID = ToTerm("void");
            var TYPE = ToTerm("type");
            var OBJECT = ToTerm("object");
            var ARRAY = ToTerm("array");
            var CORCHETEIZQ = ToTerm("[");
            var CORCHETEDER = ToTerm("]");
            var OF = ToTerm("of");
            var PTOPTO = ToTerm("..");
            var DOSPTSIGUAL = ToTerm(":=");
            var BEGIN = ToTerm("begin");
            var END = ToTerm("end");
            var PARENTESISA = ToTerm("(");
            var PARENTESISC = ToTerm(")");
            var WRITELN = ToTerm("writeln");
            var WRITE = ToTerm("write");
            var GRAFICAR_TS = ToTerm("graficar_ts");
            var IF = ToTerm("if");
            var THEN = ToTerm("then");
            var ELSE = ToTerm("else");
            var CASE = ToTerm("case");
            var WHILE = ToTerm("while");
            var DO = ToTerm("do");
            var FOR = ToTerm("for");
            var TO = ToTerm("to");
            var DOWNTO = ToTerm("downto");
            var REPEAT = ToTerm("repeat");
            var UNTIL = ToTerm("until");
            var MAS = ToTerm("+");
            var MENOS = ToTerm("-");
            var POR = ToTerm("*");
            var DIV = ToTerm("/");
            var MOD = ToTerm("%");
            var MAYORQ = ToTerm(">");
            var MENORQ = ToTerm("<");
            var MAYORIGUALQ = ToTerm(">=");
            var MENORIGUALQ = ToTerm("<=");
            var NOIGUAL = ToTerm("<>");
            var AND = ToTerm("and");
            var OR = ToTerm("or");
            var NOT = ToTerm("not");


            //Parte del Analizador descendente
            var FUNCTION = ToTerm("funcition");
            var EXIT = ToTerm("exit");
            var PROCEDURE = ToTerm("procedure");

            //Presedencia
            RegisterOperators(1, AND, THEN, ELSE, OR);
            RegisterOperators(2, IGUAL, NOIGUAL, MAYORQ, MAYORIGUALQ, MENORQ, MENORIGUALQ);
            RegisterOperators(3, MENOS, MAS);
            RegisterOperators(4, POR, DIV, MOD);
            RegisterOperators(5, NOT);

            NonGrammarTerminals.Add(COMENTARIOLINEA);
            NonGrammarTerminals.Add(COMENTARIOMULTILINEA1);
            NonGrammarTerminals.Add(COMENTARIOMULTILINEA2);
            #endregion

            #region No Terminales
            NonTerminal ini = new NonTerminal("ini");
            NonTerminal encabezado = new NonTerminal("encabezado");
            NonTerminal librerias = new NonTerminal("librerias");
            NonTerminal declaraciones = new NonTerminal("declaraciones");
            NonTerminal ejecucion = new NonTerminal("ejecucion");

            NonTerminal declaracion = new NonTerminal("declaracion");

            NonTerminal globalconst = new NonTerminal("globalconst");
            NonTerminal tvar = new NonTerminal("tvar");
            NonTerminal comenatrios = new NonTerminal("comentarios");
            NonTerminal types = new NonTerminal("types");
            NonTerminal procedures = new NonTerminal("procedures");
            NonTerminal functions = new NonTerminal("functions");
            NonTerminal libreria = new NonTerminal("libreria");

            NonTerminal constante = new NonTerminal("constante");
            NonTerminal valor = new NonTerminal("valor");
            NonTerminal valores = new NonTerminal("valores");

            NonTerminal variable = new NonTerminal("variable");
            NonTerminal tipo = new NonTerminal("tipo");
            NonTerminal type = new NonTerminal("type");

            NonTerminal objects = new NonTerminal("objects");
            NonTerminal vars = new NonTerminal("vars");
            NonTerminal arrays = new NonTerminal("arrays");
            NonTerminal array = new NonTerminal("array");

            NonTerminal index_type = new NonTerminal("index_type");

            NonTerminal exp = new NonTerminal("exp");

            NonTerminal asignacionvar = new NonTerminal("asignacionvar");

            NonTerminal comentarios = new NonTerminal("comentarios");

            NonTerminal instrucciones = new NonTerminal("instrucciones");
            NonTerminal instruccion = new NonTerminal("instruccion");

            NonTerminal estructurascontrol = new NonTerminal("estructurascontrol");
            NonTerminal llamarfuncproc = new NonTerminal("llamarfuncproc");
            NonTerminal imprimir = new NonTerminal("imprimir");
            NonTerminal graficar = new NonTerminal("graficar");
            NonTerminal asignacionarreglo = new NonTerminal("asignacionarreglo");
            NonTerminal llamararreglo = new NonTerminal("llamararreglo");

            NonTerminal if_then = new NonTerminal("if_then");
            NonTerminal if_else = new NonTerminal("if_else");
            NonTerminal condicion = new NonTerminal("condicion");

            NonTerminal casos = new NonTerminal("casos");
            NonTerminal caso = new NonTerminal("caso");
            NonTerminal elsec = new NonTerminal("elsec");

            NonTerminal while_do = new NonTerminal("while_do");
            NonTerminal tcase = new NonTerminal("tcase");
            NonTerminal repeatuntil = new NonTerminal("repeatuntil");
            NonTerminal for_do = new NonTerminal("for_do");

            NonTerminal opciones = new NonTerminal("opciones");
            NonTerminal sentencia = new NonTerminal("sentencia");

            NonTerminal opcion = new NonTerminal("opcion");
            NonTerminal rango = new NonTerminal("rango");

            NonTerminal expa = new NonTerminal("expa");
            NonTerminal to_downto = new NonTerminal("to_downto");

            NonTerminal valorf = new NonTerminal("valorf");

            NonTerminal expl = new NonTerminal("expl");
            NonTerminal expr = new NonTerminal("expr");

            NonTerminal parametro = new NonTerminal("parametro");
            NonTerminal tipoparametro = new NonTerminal("tipoparametro");
            NonTerminal masparametros = new NonTerminal("masparametros");

            NonTerminal booleano= new NonTerminal("booleano");

            NonTerminal declaracionesfp= new NonTerminal("declaracionesfp");
            NonTerminal ejecucionf= new NonTerminal("ejecucionf");
            NonTerminal retorno= new NonTerminal("retorno");
            NonTerminal instrucciones2= new NonTerminal("instrucciones2");

            NonTerminal declaracionesfpp= new NonTerminal("declaracionesfpp");
            NonTerminal declaracionfp= new NonTerminal("declaracionfp");

            NonTerminal ejecucionp= new NonTerminal("ejecucionp");
            NonTerminal instrucciones2p= new NonTerminal("instrucciones2p");
            //NonTerminal = new NonTerminal("");
            #endregion

            #region Gramatica
            ini.Rule = encabezado + librerias + declaraciones + ejecucion + PUNTO;

            encabezado.Rule = PROGRAM + ID + PTCOMA;

            declaraciones.Rule = declaraciones + declaracion
                            | declaracion;

            declaracion.Rule = globalconst
                            | tvar
                            | comenatrios
                            | types
                            | procedures
                            | functions
                            | Empty;

            librerias.Rule = USES + libreria + PTCOMA;

            libreria.Rule = libreria + COMA + libreria
                        | ID;

            globalconst.Rule = CONST + constante + PTCOMA;

            constante.Rule = constante + PTCOMA + constante
                        | ID + IGUAL + valor;

            valores.Rule = valores + COMA + valor
                        | valor;

            tvar.Rule = VAR + variable + DOSPUNTOS + tipo + PTCOMA
                    | VAR + ID + DOSPUNTOS + tipo + IGUAL + valor + PTCOMA;

            variable.Rule = variable + COMA + ID
                        | ID;

            tipo.Rule = STRING
                        | INTEGER
                        | REAL
                        | BOOLEAN
                        | VOID
                        | ID;

            types.Rule = TYPE + type;

            type.Rule = objects + vars + END + PTCOMA
                    | arrays;

            objects.Rule = ID + IGUAL + OBJECT;

            arrays.Rule = arrays + array
                    | array;

            array.Rule = ID + IGUAL + ARRAY + CORCHETEIZQ + index_type + CORCHETEDER + OF + index_type + PTCOMA;

            index_type.Rule = INTEGER
                            | NUMERO + PTOPTO + NUMERO
                            | BOOLEAN;

            valor.Rule = exp
                        | CADENA
                        | BOOLEAN
                        | DECIMAL;

            asignacionvar.Rule = ID + DOSPTSIGUAL + valor + PTCOMA;

            comenatrios.Rule = COMENTARIOLINEA
                            | COMENTARIOMULTILINEA1
                            | COMENTARIOMULTILINEA2;

            ejecucion.Rule = instrucciones + instruccion
                            | instruccion;

            instruccion.Rule = asignacionvar
                            | estructurascontrol
                            | llamarfuncproc
                            | comenatrios
                            | imprimir
                            | graficar
                            | asignacionarreglo
                            | Empty;

            llamarfuncproc.Rule = ID + PARENTESISA + valores + PARENTESISC;

            imprimir.Rule = WRITELN + PARENTESISA + valores + PARENTESISC + PTCOMA
                            | WRITE + PARENTESISA + valores + PARENTESISC + PTCOMA;

            graficar.Rule = GRAFICAR_TS + PARENTESISA + PARENTESISC + PTCOMA;

            asignacionarreglo.Rule = ID + CORCHETEIZQ + valor + CORCHETEDER + DOSPTSIGUAL + valor + PTCOMA;

            llamararreglo.Rule = ID + CORCHETEIZQ + valor + CORCHETEDER;

            if_then.Rule = IF + PARENTESISA + condicion + PARENTESISC + THEN + TAB + instruccion + if_else;

            if_else.Rule = ELSE + TAB + instruccion
                           | Empty;

            tcase.Rule = CASE + PARENTESISA + exp + PARENTESISC + OF + TAB + casos + elsec + END + PTCOMA;

            casos.Rule = casos + caso
                        | caso;

            caso.Rule = opciones + DOSPUNTOS + sentencia;

            opciones.Rule = opciones + COMA + opcion
                            | opcion;

            opcion.Rule = valor
                        | rango;

            rango.Rule = valor + PTOPTO + valor;

            sentencia.Rule = imprimir
                            | asignacionvar
                            | asignacionarreglo
                            | graficar
                            | llamarfuncproc + PTCOMA
                            | ejecucion + PTCOMA;

            elsec.Rule = ELSE + instruccion
                        | Empty;

            while_do.Rule = WHILE + PARENTESISA + condicion + PARENTESISC + DO + ejecucion + PTCOMA;

            for_do.Rule = FOR + ID + DOSPTSIGUAL + expa + to_downto + expa + DO + TAB + sentencia;

            to_downto.Rule = TO
                            | DOWNTO;

            valorf.Rule = NUMERO
                        | llamararreglo
                        | llamarfuncproc
                        | ID;

            repeatuntil.Rule = REPEAT + TAB + instruccion + UNTIL + condicion + PTCOMA;

            condicion.Rule = expl
                            | expr
                            | ID;

            parametro.Rule = tipoparametro + variable + DOSPUNTOS + tipo + masparametros;

            tipoparametro.Rule = VAR
                                | Empty;

            masparametros.Rule = PTCOMA + parametro
                                | Empty;

            exp.Rule = expa
                    | expr
                    | expl;

            expa.Rule = expa + MAS + expa
                        | expa + MENOS + expa
                        | expa + POR + expa
                        | expa + DIV + expa
                        | expa + MOD
                        | valorf
                        | PARENTESISA + expa + PARENTESISC;

            expr.Rule = expr + MAYORQ + expr
                        | expr + MENORQ + expr
                        | expr + MAYORIGUALQ + expr
                        | expr + MENORIGUALQ + expr
                        | expr + IGUAL + expr
                        | expr + NOIGUAL + expr
                        | expa
                        | booleano
                        | PARENTESISA + expr + PARENTESISC;

            expl.Rule = expl + AND + expl
                        | expl + OR + expl
                        | NOT + expl
                        | expr
                        | booleano
                        | PARENTESISA + expl + PARENTESISC;

            booleano.Rule = BOOLEANOT
                            | BOOLEANOF;

            //Analizador descendente: Funciones y procedimientos
            functions.Rule = FUNCTION + ID + PARENTESISA + parametro + PARENTESISC + DOSPUNTOS + tipo + PTCOMA + declaracionesfp + ejecucionf;

            declaracionesfp.Rule = declaracionfp + declaracionesfpp;

            declaracionfp.Rule = globalconst
                                | tvar
                                | comenatrios
                                | procedures
                                | functions
                                | TYPE + arrays
                                | Empty;

            declaracionesfpp.Rule = declaracionfp + declaracionesfpp
                                | Empty;

            ejecucionf.Rule = BEGIN + instrucciones2 + retorno + END + PTCOMA;

            retorno.Rule = ID + DOSPTSIGUAL + valor + PTCOMA
                        | EXIT + PARENTESISA + valor + PARENTESISC + PTCOMA;

            procedures.Rule = PROCEDURE + ID + PARENTESISA + parametro + PARENTESISC + PTCOMA + declaracionesfp + ejecucionp;

            ejecucionp.Rule = BEGIN + instrucciones2 + END + PTCOMA;

            instrucciones2.Rule = instruccion + instrucciones2p;

            instrucciones2p.Rule = instruccion + instrucciones2p
                                | Empty;
            #endregion

            #region Preferencias
            this.Root = ini;
            #endregion
        }
    }
}

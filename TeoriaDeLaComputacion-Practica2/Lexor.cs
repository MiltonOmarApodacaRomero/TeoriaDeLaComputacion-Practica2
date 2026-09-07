using System.ComponentModel;
using System.Runtime.InteropServices.JavaScript;

namespace TeoriaDeLaComputacion_Practica2;


public class Lexor
{

    public static Form1 formulario;
    public static void Setup(Form1 form)
    {
        formulario = form;
        
    }

    public static readonly HashSet<char> LetrasSet = new HashSet<char> {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w',
        'x', 'y', 'z', 'A', 'B', 'C', 'D', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
        'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    };

    public static readonly HashSet<string> PalabrasReservadas = new HashSet<string> {
       "int","double","string","char","boolean","if","else","while","for","return",
        "do","switch","case","break","continue","default","try","catch","finally","throw",
        "public","private","protected","static","void","class","interface","enum","extends","implements",
        "import","package","new","this","super","null","true","false",
        "abstract","assert","boolean","byte","char","const","default","System","final","Console",
        "WriteLine","ReadLine","Math","Random","List","ArrayList","HashMap","HashSet","LinkedList",
        "Vector","foreach"
    };

    public static readonly HashSet<char> DigitosSet = new HashSet<char> {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
    };

    public static readonly HashSet<char> SS_1Set = new HashSet<char> {
        '!', '*', '/', '>', '<'
    };

    public static readonly HashSet<char> SS_2Set = new HashSet<char> {
        '@', '?', ';', '$', '#', ','
    };
    
    public enum TiposDatos
    {
        Letra,
        Digito,
        E,
        InLlave,
        FnLlave,
        InParentesis,
        FnParentesis,
        InCorchete,
        FnCorchete,
        Mas,
        Guion,
        GuionBajo,
        Comillas,
        Igual,
        Punto,
        DosPuntos,
        SS_1,
        SS_2,
        Espacio,
        FDC
    }

    public static readonly Dictionary<char, TiposDatos> CaracteresSet = new Dictionary<char, TiposDatos>();

    public static readonly Dictionary<int, String> msgError = new Dictionary<int, string>()
    {
            { 64, "No se puede iniciar un argumento con un ESPACIO." },
            { 100, "No se permite iniciar un argumento vacío." },
            { 111, "Argumentos iniciados con Alfanuméricos o '_' solo pueden contener otros Alfanuméricos y/o '_'." },
            { 128, "Los argumentos Numéricos solo deben contener otros Números, Puntos o Exponenciales 'E'." },
            { 200, "El argumento '-' solo debe negar Numéricos, o finalizar ya sea por sí mismo o seguido inmediatamente por '=' o '-'." },
            { 212, "Los argumentos Numericos con decimal, solo permiten más digitos o una 'E' de exponencial." },
            { 222, "Los argumentos Decimales despues del '.' deben de ser seguidos por al menos un digito." },
            { 256, "Los argumentos Numericos con Exponencial 'E' deben finalizar con al menos un Número." },
            { 300, "Los argumentos Numericos con Exponencial 'E' que incluyan '+' o '-' deben finalizar con al menos un Número." },
            { 333, "La Comilla Doble debe siempre terminar por una segunda Comilla Doble, sin importar si su contenido es NULO o no." },
            { 400, "La segunda Comilla Doble no debe recibir ningún otro argumento." },
            { 444, "No se permiten otro argumento posterior a '=' o '-'." },
            { 500, "Se esperaba el fin inmediato tras el primer argumento o un '='." },
            { 512, "Se esperaba el fin inmediato tras un argumento seguido de un '='" },
            { 524, "No se permiten otro argumento posterior a '=' o '+'." },
            { 536, "Se esperaba el fin inmediato tras la expresión '::'." },
            { 555, "Se esperaba el fin inmediatro tras el primer argumento o un segundo argumento de tipo '=' o '+'." },
            { 600, "Se esperaba el fin inmediatro tras el primer argumento." },
            { 666, "El argumento '(' solo debe finalizar por sí mismo o al ser proseguido inmediatamente por un ')'." },
            { 700, "El argumento '{' solo debe finalizar por sí mismo o al ser proseguido inmediatamente por un '}'." },
            { 777, "El argumento '[' solo debe finalizar por sí mismo o al ser proseguido inmediatamente por un ']'." },
            { 800, "El argumento ')' debe finalizar por sí mismo." },
            { 888, "El argumento '}' debe finalizar por sí mismo." },
            { 900, "El argumento ']' debe finalizar por sí mismo." },
            { 999, "El argumento ':' solo debe finalizar por sí mismo o al ser proseguido inmediatamente por otro ':'." }
    };
    
    public static int[,] matrizEstados = {
        {2, 3, 2, 21, 22, 19, 20, 25, 26, 16, 4, 2, 10, 14, 18, 23, 14, 18, 64, 100},
        {2, 2, 2, 111, 111, 111, 111, 111, 111, 111, 111, 2, 111, 111, 111, 111, 111, 111, 111, 0},
        {128, 3, 6, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 5, 128, 128, 128, 128,0},
        {200, 3, 200, 200, 200, 200, 200, 200, 200, 200, 13, 200, 200, 13, 200, 200, 200, 200, 200,0},
        {222, 7, 222, 222, 222, 222, 222, 222, 222, 222, 222, 222, 222, 222, 222, 222, 222, 222, 222, 222},
        {256, 8, 256, 256, 256, 256, 256, 256, 256, 9, 9, 256, 256, 256, 256, 256, 256, 256, 256, 256},
        {212, 7, 6, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212,0},
        {256, 8, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256,0},
        {300, 8, 300, 300, 300, 300, 300, 300, 300, 300, 300, 300, 300, 300, 300, 300, 300, 300, 300, 300},
        {11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 11, 11, 11, 11, 11, 11,333},
        {11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 11, 11, 11, 11, 11, 11,333},
        {400, 400, 400, 400, 400, 400, 400, 400, 400, 400, 400, 400, 400, 400, 400, 400, 400, 400, 400, 0},
        {444, 444, 444, 444, 444, 444, 444, 444, 444, 444, 444, 444, 444, 444, 444, 444, 444, 444, 444, 0},
        {500, 500, 500, 500, 500, 500, 500, 500, 500, 500, 500, 500, 500, 15, 500, 500, 500, 500, 500, 0},
        {512, 512, 512, 512, 512, 512, 512, 512, 512, 512, 512, 512, 512, 512, 512, 512, 512, 512, 512, 0},
        {555, 555, 555, 555, 555, 555, 555, 555, 555, 17, 555, 555, 555, 17, 555, 555, 555, 555, 555, 0},
        {524, 524, 524, 524, 524, 524, 524, 524, 524, 524, 524, 524, 524, 524, 524, 524, 524, 524, 524, 0},
        {600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600,0},
        {666, 666, 666, 666, 666, 666, 20, 666, 666, 666, 666, 666, 666, 666, 666, 666, 666, 666, 666, 0},
        {800, 800, 800, 800, 800, 800, 800, 800, 800, 800, 800, 800, 800, 800, 800, 800, 800, 800, 800, 0},
        {700, 700, 700, 700, 22, 700, 700, 700, 700, 700, 700, 700, 700, 700, 700, 700, 700, 700, 700, 0},
        {888, 888, 888, 888, 888, 888, 888, 888, 888, 888, 888, 888, 888, 888, 888, 888, 888, 888, 888, 0},
        {999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 24, 999, 999, 999, 0},
        {536, 536, 536, 536, 536, 536, 536, 536, 536, 536, 536, 536, 536, 536, 536, 536, 536, 536, 536, 0},
        {777, 777, 777, 777, 777, 777, 777, 777, 26, 777, 777, 777, 777, 777, 777, 777, 777, 777, 777, 0},
        {900, 900, 900, 900, 900, 900, 900, 900, 900, 900, 900, 900, 900, 900, 900, 900, 900, 900, 900, 0}
    };

    public static int minCodError = 64;
    
    private static void RegistrarSets()
    {

        foreach (char c in LetrasSet)
        {
            CaracteresSet[c] = TiposDatos.Letra;
        }

        foreach (char c in DigitosSet)
        {
            CaracteresSet[c] = TiposDatos.Digito;
        }

        CaracteresSet['E'] = TiposDatos.E;
        CaracteresSet['{'] = TiposDatos.InLlave;
        CaracteresSet['}'] = TiposDatos.FnLlave;
        CaracteresSet['('] = TiposDatos.InParentesis;
        CaracteresSet[')'] = TiposDatos.FnParentesis;
        CaracteresSet['['] = TiposDatos.InCorchete;
        CaracteresSet[']'] = TiposDatos.FnCorchete;
        CaracteresSet['+'] = TiposDatos.Mas;
        CaracteresSet['-'] = TiposDatos.Guion;
        CaracteresSet['_'] = TiposDatos.GuionBajo;
        CaracteresSet['"'] = TiposDatos.Comillas;
        CaracteresSet['='] = TiposDatos.Igual;
        CaracteresSet['.'] = TiposDatos.Punto;
        CaracteresSet[':'] = TiposDatos.DosPuntos;
        
        foreach (char c in SS_1Set)
        {
            CaracteresSet[c] = TiposDatos.SS_1;
        }
        
        foreach (char c in SS_2Set)
        {
            CaracteresSet[c] = TiposDatos.SS_2;
        }

        CaracteresSet[' '] = TiposDatos.Espacio;


    }

    public static void Procesar(string input)
    {
        if (PalabrasReservadas.Contains(input)) {
            Console.WriteLine("No puedes ingresar palabras reservadas.");
            MessageBox.Show("No puedes ingresar palabras reservadas.");
            
            if (formulario != null)
            {
               formulario.txtSalida.Text = "No puedes ingresar palabras reservadas.";
            }
            return;
        }
        
        RegistrarSets();

        int estado = 1;
        char[] inp = input.ToCharArray();
        Console.WriteLine(estado);
        
        
        foreach (char c in inp)
        {
            if (!CaracteresSet.ContainsKey(c))
            {
                MessageBox.Show("Se introdujeron Caracteres Ilegales a la cadena!");
                
                if (formulario != null)
                {
                    formulario.txtSalida.Text = "Se introdujeron Caracteres Ilegales a la cadena!";
                }
                
                return;
            }
            
            estado = matrizEstados[estado - 1, (int)CaracteresSet[c]];
            Console.WriteLine(estado);
            
            if (estado >= matrizEstados.GetLength(0) && estado >= minCodError)
            {
                MessageBox.Show("Error[" + estado + "]: " + msgError[estado]);
                formulario.txtSalida.Text = "Error[" + estado + "]: " + msgError[estado];
                break;
            }
        }
        
        if (estado < matrizEstados.GetLength(0))
        {
            estado = matrizEstados[estado - 1, (int)TiposDatos.FDC];

            if (estado == 0)
            {
                Console.WriteLine("Cadena Valida");
                
                if (formulario != null)
                {
                  formulario.txtSalida.Text = "Cadena Valida"; 
                  MessageBox.Show("Cadena Valida");
                  return;
                }
                
            }
            
            MessageBox.Show("Error[" + estado + "]: " + msgError[estado]);
            formulario.txtSalida.Text = "Error[" + estado + "]: " + msgError[estado];
        }

    }

}
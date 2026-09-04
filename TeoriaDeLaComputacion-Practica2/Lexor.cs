using System.ComponentModel;

namespace TeoriaDeLaComputacion_Practica2;


public class Lexor {
    
    public static readonly HashSet<char> LetrasSet = new HashSet<char> {
        'a', 'b', 'c', 'd', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w',
        'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
        'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
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
    
    // El enumerador "TiposDatos" funciona como una herramienta de apoyo para acceder más fácilmente a los índices de la matriz (Letra = 0, Dígito = 1,  E = 2, etcétera).
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
    
    //  ORDEN DE LA MATRÍZ ->
    //  Letras [a-Z] │ Dígitos [0-9] │ E │ { │ } │ ( │ ) │ [ │ ] │ + │ - │ _ │ " │ = │ . │ : │ SS_1 │ SS_2 │ Espacio │ FDC  
    //  26 Renglones │ 20 Columnas
    public static int[,] matrizEstados = {
        {2, 3, 2, 21, 22, 19, 20, 25, 26, 16, 4, 2, 10, 14, 18, 23, 14, 18, 64, 100},
        {2, 2, 2, 111, 111, 111, 111, 111, 111, 111, 111, 2, 111, 111, 111, 111, 111, 111, 111, 0}
    };

    public static int minCodError = 64;

    private static void RegistrarSets() {
        
        // ╔════════╗
        // ║ LETRAS ║
        // ╚════════╝
        foreach (char c in LetrasSet) {
            CaracteresSet[c] = TiposDatos.Letra;
        }
        
        // ╔═════════╗
        // ║ DÍGITOS ║
        // ╚═════════╝
        foreach (char c in DigitosSet) {
            CaracteresSet[c] = TiposDatos.Digito;
        }
        
        // ╔═════════════════════════╗
        // ║ CARÁCTERES INDIVIDUALES ║
        // ╚═════════════════════════╝
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
        
        // ╔════════════════════════════╗
        // ║ SET DE SÍMBOLOS 1 -> !/*>< ║
        // ╚════════════════════════════╝
        foreach (char c in SS_1Set) {
            CaracteresSet[c] = TiposDatos.SS_1;
        }
        
        // ╔═════════════════════════════╗
        // ║ SET DE SÍMBOLOS 2 -> @?;$#, ║
        // ╚═════════════════════════════╝
        foreach (char c in SS_2Set) {
            CaracteresSet[c] = TiposDatos.SS_2;
        }
        
        // ╔═════════╗
        // ║ ESPACIO ║
        // ╚═════════╝
        CaracteresSet[' '] = TiposDatos.Espacio;
        
        
    }

    public static void Procesar(string input) {
        RegistrarSets();
        
        int estado = 1;
        char[] inp = input.ToCharArray(); // Convertir el input ingresado a un array de caracteres

        
        Console.WriteLine(estado); // Imprimir estado inicial (de 1).
        
        foreach (char c in inp) {
            estado = matrizEstados[estado - 1, (int)CaracteresSet[c]];
            Console.WriteLine(estado);
            
            // Mostrar error en caso de introducir un símbolo o carácter que no se esperaba.
            if (estado >= matrizEstados.Length && estado >= minCodError) {
                Console.WriteLine("DIO ERROR NONO MUY MAL"); // todo: Cambiar por método con código de aceptación o error.
                break;
            }
        }
        
        // Mostrar conclusión tras un FDC si no hubo un error anteriormente.
        if (estado < matrizEstados.Length) {
            estado = matrizEstados[estado - 1, (int)TiposDatos.FDC];
            Console.WriteLine(estado);
            // todo: Cambiar por método con código de aceptación o error (aquí se llamaría todo lo referente al FDC).
        }
        
    }
    
}
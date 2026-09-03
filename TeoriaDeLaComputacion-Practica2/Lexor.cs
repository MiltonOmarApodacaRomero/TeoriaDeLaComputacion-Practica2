using System.ComponentModel;

namespace TeoriaDeLaComputacion_Practica2;


public class Lexor {

    public static readonly HashSet<char> LetrasSet = new HashSet<char> {
        'a', 'b', 'c', 'd', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w',
        'x', 'y', 'z'
    };

    public static readonly HashSet<char> DigitosSet = new HashSet<char> {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
    };

    public static readonly HashSet<char> SimbolosSimplesSet = new HashSet<char> {
        '+', '-', '*', '/', '(', ')', '[', ']', '{', '}', '!', '@', '#', '$', '%', '&', '<', '>', ':', ';', '?', '.', '='
    };
    
    public enum TiposDatos 
    {
        Letra,
        Digito,
        SS,
        Punto,
        FDC
        
    }
    
    public static readonly Dictionary<char, TiposDatos> CaracteresSet = new Dictionary<char, TiposDatos>();
    
    public static int[,] matrizEstados = {
        { 4, 2, 100, 500, 400 },
        { 400, 2, 100, 3, 0 },
        { 500, 2, 100, 500, 400 },
        { 4, 200, 100, 500, 0 }
    };

    public static int minCodError = 100;

    private static void RegistrarSets() {

        foreach (char c in LetrasSet) {
            CaracteresSet[c] = TiposDatos.Letra;
        }
        
        foreach (char c in DigitosSet) {
            CaracteresSet[c] = TiposDatos.Digito;
        }
        
        foreach (char c in SimbolosSimplesSet) {
            CaracteresSet[c] = TiposDatos.SS;
        }
        
        CaracteresSet['.'] = TiposDatos.Punto;

    }

    public static void Procesar(string input) {
        RegistrarSets();
        
        int estado = 1;
        char[] inp = input.ToCharArray();
        if (inp.Length <= 0) {
            Console.WriteLine("CADENA VACÍA"); // todo: Cambiar por método con código de aceptación o error
        }
        
        Console.WriteLine(estado);
        
        foreach (char c in inp) {
            estado = matrizEstados[estado - 1, (int)CaracteresSet[c]];
            Console.WriteLine(estado);
            
            
            if (estado >= matrizEstados.Length && estado >= minCodError) {
                Console.WriteLine("DIO ERROR NONO MUY MAL"); // todo: Cambiar por método con código de aceptación o error
                break;
            }
        }
        
        estado = matrizEstados[estado - 1, (int)TiposDatos.FDC];
        Console.WriteLine(estado);
        // todo: Cambiar por método con código de aceptación o error
        
    }
    
}
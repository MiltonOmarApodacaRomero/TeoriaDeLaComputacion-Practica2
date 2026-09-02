namespace TeoriaDeLaComputacion_Practica2;


public class Lexor {

    public static readonly HashSet<char> LetrasSet = new HashSet<char> {
        'a', 'b', 'c', 'd', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w',
        'x', 'y', 'z'
    };

    public static readonly HashSet<char> DigitosSet = new HashSet<char> {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
    };
    
    public enum TiposDatos
    {
        Letra,
        Digito,
        FDC
    }
    
    public static readonly Dictionary<char, TiposDatos> CaracteresSet = new Dictionary<char, TiposDatos>();
    
    public static int[,] matrizEstados = {
        { 3, 2, 400 },
        { 400, 400, 400 },
        { 3, 3, 400 }
    };

    public static int minCodError = 400;

    private static void RegistrarSets() {
        foreach (char c in LetrasSet) {
            CaracteresSet[c] = TiposDatos.Letra;
        }
        
        foreach (char c in DigitosSet) {
            CaracteresSet[c] = TiposDatos.Digito;
        }
    }

    public static void Procesar(string input) {
        RegistrarSets();
        
        int estado = 1;
        char[] inp = input.ToCharArray();
        
        foreach (char c in inp) {
            Console.WriteLine(estado);

            estado = matrizEstados[estado - 1, (int)CaracteresSet[c]];
            if (estado >= matrizEstados.Length) {
                Console.WriteLine("DIO ERROR NONO MUY MAL");
                break;
            }
        }
    }
    
}
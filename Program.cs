using System.Security.Cryptography;

namespace Cosmoray;

public class Program {
    private static Int32[] generate(Int32 count) {
        Int32[] result = new Int32[ count ];
        for ( Int32 i = 0; i < count; i++ ) {
            result[ i ] = RandomNumberGenerator.GetInt32(256);
        }
        return result;
    }
    private static Int32[] Diff(Int32[] a, Int32[] b, Int32[] c) {
        Int32[] result = new int[ a.Length ];
        for ( Int32 i = 0; i < result.Length; i++ )
            result[ i ] = (a[ i ] | b[ i ]) & c[ i ];
        return result;
    }
    private static Boolean AreCohesive(Int32[] a, Int32[] b) {
        if ( a.Length != b.Length ) return false;
        for ( Int32 i = 0; i < a.Length; i++ ) {
            if ( a[ i ] != b[ i ] ) return false;
        }
        return true;
    }

    private static readonly MTLib.Terminal.TypewriterConsoleWriter writer = new(22);
    private static readonly MTLib.Terminal.Style normal = new (ConsoleColor.Gray);
    private static readonly MTLib.Terminal.Style bright = new (ConsoleColor.White);
    private static readonly MTLib.Terminal.Style germa = new (ConsoleColor.DarkGreen);
    private static readonly MTLib.Terminal.Style terror = new (ConsoleColor.Red);
    private static readonly MTLib.Terminal.Style alert = new (ConsoleColor.White, ConsoleColor.Blue);
    private static readonly MTLib.Terminal.Style announce = new (ConsoleColor.Green);
    private static readonly Int32 complexity = 128;

    public static void Main(String[] args) {
        Console.Title = "Cosmoray - strahl detektor";

        Console.WindowWidth = 38;
        Console.WindowHeight = 32;

        normal.Write($"die komplexität: ", writer);
        alert.Write($"0x{Convert.ToString(complexity, 2)}", writer);
        normal.Write(".\n", writer);
        normal.Write("aufbau einer ", writer);
        alert.Write("datenbank", writer); // build db
        normal.Write("...\n", writer);
        Int32[] L1 = generate(complexity);
        Int32[] L2 = generate(complexity);
        Int32[] L3 = generate(complexity);
        Int32[] D1 = Diff(L1, L2, L3);
        bright.Write("erkennen ", writer);
        alert.Write("strahls", writer);
        normal.Write("...\n", writer);
        Int32 loop = 0;
        Int32 epoch = 0;
        while ( true ) {
            if ( !AreCohesive(D1, Diff(L1, L2, L3)) ) {
                Console.Beep(500, 1_000);
                Console.Beep(300, 1_000);
                Console.Beep(250, 1_000);
                alert.Write("eindringling Rochen wurde gefunden !!\n", writer);
                alert.Write($"@ {DateTime.Now}\n", writer);
            }
            if (loop % 2 == 0) {
                Thread.Sleep(1_000);
            }
            if (loop % 5 == 0) {
                normal.Write($"looper-nummer ", writer);
                alert.Write($"{loop}", writer);
                normal.Write(".\n", writer);
                epoch++;
            }
            loop++;
        }
    }
}
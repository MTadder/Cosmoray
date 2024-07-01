using System.Security.Cryptography;

namespace Cosmoray;

public class Program {
    private static Int32[] Generate(Int32 count) {
        Int32[] result = new Int32[ count ];
        for ( Int32 i = 0; i < count; i++ ) {
            result[ i ] = RandomNumberGenerator.GetInt32(256);
        }
        return result;
    }
    private static Int32[] Diff(Int32[] a, Int32[] b) {
        Int32[] result = new int[ a.Length ];
        for ( Int32 i = 0; i < result.Length; i++ )
            result[ i ] = a[ i ] ^ b[ i ];
        return result;
    }
    private static Boolean AreCohesive(Int32[] a, Int32[] b) {
        if ( a.Length != b.Length ) return false;
        for ( Int32 i = 0; i < a.Length; i++ ) {
            if ( a[ i ] != b[ i ] ) return false;
        }
        return true;
    }

    private static readonly MTLib.Terminal.TypewriterConsoleWriter writer = new(13);
    private static readonly MTLib.Terminal.Style normal = new (ConsoleColor.Gray);
    private static readonly MTLib.Terminal.Style bright = new (ConsoleColor.White);
    private static readonly MTLib.Terminal.Style germa = new (ConsoleColor.DarkGreen);
    private static readonly MTLib.Terminal.Style terror = new (ConsoleColor.Red);
    private static readonly MTLib.Terminal.Style alert = new (ConsoleColor.White, ConsoleColor.Blue);
    private static readonly MTLib.Terminal.Style announce = new (ConsoleColor.Green);
    private static Int32 complexity = 512;
    private static Int32 interval = 512;

    public static void Main(String[] args) {
        Console.Title = "Cosmoray - strahl detektor";

        for ( Int32 arg_i = 0; arg_i < args.Length; arg_i++ ) {
            switch ( args[ arg_i ] ) {
                case "-i":
                    if ( args[ arg_i + 1 ] is null )
                        throw new ArgumentException();
                    interval = Int32.Parse(args[ arg_i + 1 ]);
                    break;
                case "-c":
                    if ( args[ arg_i + 1 ] is null )
                        throw new ArgumentException();
                    complexity = Int32.Parse(args[ arg_i + 1 ]);
                    break;
            }
        }

        Console.WindowWidth = 38;
        Console.WindowHeight = 32;

        normal.Write($"geschwindigkeit: ", writer);
        alert.Write(interval.ToString(), writer);
        normal.Write($"ms\ndie komplexität: ", writer);
        alert.Write($"0x{Convert.ToString(complexity, 2)}", writer);
        normal.Write("|", writer);
        alert.Write(complexity.ToString(), writer);
        Int32[] L1 = Generate(complexity);
        Int32[] L2 = Generate(complexity);
        Int32[] D1 = Diff(L1, L2);
        normal.Write("\nerkennen ", writer);
        announce.Write($"strahls", writer);
        normal.Write(" @\n\t", writer);
        alert.Write(DateTime.Now.ToString(), writer);
        normal.Write("...\n", writer);
        Int32 loop = 0;
        Int32 epoch = 0;
        while ( true ) {
            if ( !AreCohesive(D1, Diff(L1, L2)) ) {
                Console.Beep(600, 500);
                Thread.Sleep(250);
                Console.Beep(600, 500);
                Thread.Sleep(250);
                Console.Beep(600, 500);
                alert.Write("\neindringling rochen wurde gefunden !!\n", writer);
                alert.Write($"@ {DateTime.Now}\n", writer);
            }
            Thread.Sleep(interval);
            if ( loop % (Console.WindowWidth - 1) == 0 && loop != 0 ) {
                writer.Write(new String('\b', Console.WindowWidth));
                epoch++;
                //switch ( epoch ) {
                //    case 0:
                //    case 2:
                //        bright.Write("\nsuche weiter, und die wahrheit wird\n\tans licht kommen\n", writer);
                //        break;
                //    case 6:
                //        bright.Write("\nes gibt viel zu entdecken\n", writer);
                //        break;
                //    case 9:
                //        bright.Write("\nversuchen sie ein kleineres intervall\n", writer);
                //        break;
                //    case 13:
                //        bright.Write("\n", writer);
                //        break;
                //}
            }
            terror.Write((loop % 2 == 0) ? "." : ",", writer);
            loop++;
        }
    }
}
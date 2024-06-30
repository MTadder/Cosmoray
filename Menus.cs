namespace Cosmoray;

internal static class Menus {
    private class Beepwriter : MTLib.Terminal.IConsoleWriter {
        public Int32 BeepDuration = 100;
        public Int32 WaitMSPerChar = 22;
        public Int32 BeepFrequency = 500;
        public Beepwriter() {

        }
        public void Clear() {
            Console.Beep(this.BeepFrequency /2, 1);
            Thread.Sleep(1000);
            Console.Clear();
            Console.Beep(this.BeepFrequency, this.BeepDuration);
        }
        public void Write(String text) {
            foreach ( Char c in text ) {
                Console.Write(c);
                Console.Beep(this.BeepFrequency, this.BeepDuration);
                Thread.Sleep(this.WaitMSPerChar);
            }
        }
        public void WriteLine(String text) {
            this.Write(text);
            Console.Write('\n');
        }
    }
    private static readonly Beepwriter beepwriter = new();
    private static readonly MTLib.Terminal.Style matrixStyle = new(ConsoleColor.Green);
    private static readonly MTLib.Terminal.Style matrixCarriageStyle = new(ConsoleColor.White);


    private static readonly MTLib.Terminal.Menu MainMenu = new() {
        Title = $"Cosmoray v${Meta.VersionName}",
        Writer = beepwriter,
        AllowHelp = true,
        Carriage = "~=> ",
        ClearConsole = true,
        MasterStyle = matrixStyle,
        CarriageStyle = matrixCarriageStyle,
        
    };
}

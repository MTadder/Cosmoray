using System.Collections;
using System.Security.Cryptography;

namespace Cosmoray;

internal static class Menus {
    private static readonly MTLib.Terminal.Style matrixStyle = new(ConsoleColor.Green);
    private static readonly MTLib.Terminal.Style matrixCarriageStyle = new(ConsoleColor.White);

    internal static MTLib.Terminal.Menu GetScanMenu() {
        return new MTLib.Terminal.Menu() {

        };
    }

    internal static MTLib.Terminal.Menu GetSettingsMenu() {
        return new MTLib.Terminal.Menu() {

        };
    }

    internal static MTLib.Terminal.Menu GetMainMenu() {
        return new MTLib.Terminal.Menu() {
            Title = $"Cosmoray",
            Description = "intrusive ray detektor",
            Writer = MTLib.Terminal.Writers.TypewriterConsoleWriter,
            AllowTriggerByIndex = true,
            AllowHelp = true,
            Carriage = "~=> ",
            ClearConsole = true,
            MasterStyle = matrixStyle,
            CarriageStyle = matrixCarriageStyle,
            PromptStyle = matrixCarriageStyle,
            Triggers = {
                { "begin", GetScanMenu() },
                { "settings", GetSettingsMenu() },
            },
            Hooks = {
                { "exit", MTLib.Terminal.Menu.Macros.Exit }
            },
        };
    }
}

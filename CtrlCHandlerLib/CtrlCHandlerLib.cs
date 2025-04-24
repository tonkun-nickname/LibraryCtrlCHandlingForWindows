namespace tonkun_nickname.CtrlCHandler;

public static class CtrlCHandler
{
    public static bool stopRequested = false;
    public static ConsoleCancelEventHandler? handller = null;

    public static void myHandler(object? sender, ConsoleCancelEventArgs args)
    {
        args.Cancel = true;
        stopRequested = true;
    }

    public static void registerHandler()
    {
        stopRequested = false;
        handller = new ConsoleCancelEventHandler(myHandler);
        Console.CancelKeyPress += handller;
    }

    public static void unregisterHandler()
    {
        if (handller != null)
        {
            Console.CancelKeyPress -= handller;
        }
    }
}

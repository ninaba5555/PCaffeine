using System.Runtime.InteropServices;

namespace PCaffeine;

internal static class SleepManager
{
    [DllImport("kernel32.dll")]
    private static extern uint SetThreadExecutionState(uint esFlags);

    private const uint EsContinuous = 0x80000000;
    private const uint EsSystemRequired = 0x00000001;

    public static void PreventSleep()
    {
        SetThreadExecutionState(
            EsContinuous |
            EsSystemRequired
        );
    }

    public static void AllowSleep()
    {
        SetThreadExecutionState(EsContinuous);
    }
}
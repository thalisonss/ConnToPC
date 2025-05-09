using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private DateTime _lastNotification = DateTime.MinValue;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var idleTime = GetIdleTime();
            if (idleTime.TotalMinutes >= 0 && (DateTime.Now - _lastNotification).TotalMinutes > 0)
            {
                WhatsAppService.EnviarMensagem("PC inativo há mais de 1 minuto!");
                _lastNotification = DateTime.Now;
            }
            await Task.Delay(10000, stoppingToken);
        }
    }

    public static TimeSpan GetIdleTime()
    {
        var info = new LASTINPUTINFO();
        info.cbSize = (uint)Marshal.SizeOf(info);
        GetLastInputInfo(ref info);
        return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime);
    }

    [DllImport("user32.dll")]
    private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

    private struct LASTINPUTINFO
    {
        public uint cbSize;
        public uint dwTime;
    }
}
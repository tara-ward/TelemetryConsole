using System;

namespace TardisTelemetryConsole.Models;

public class SensorReading
{
    public string Name { get; set; } = string.Empty;
    public double Value { get; set; }
    public string Unit { get; set; } = string.Empty;
    public double WarningThreshold { get; set; }
    public double CriticalThreshold { get; set; }
    public DateTime LastUpdated { get; set; }
}

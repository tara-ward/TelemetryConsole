using System.Collections.Generic;

namespace TardisTelemetryConsole.Models;

public class TardisSubsystem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public List<SensorReading> Readings { get; set; } = [];
    public List<SystemAlert> Alerts { get; set; } = [];
}

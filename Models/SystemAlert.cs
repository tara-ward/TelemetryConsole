using System;

namespace TardisTelemetryConsole.Models;

public class SystemAlert
{
    public int Id { get; set; }
    public int SubsystemId { get; set; }
    public string SubsystemName { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool IsAcknowledged { get; set; }
}

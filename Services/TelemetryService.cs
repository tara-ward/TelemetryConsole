using System;
using System.Collections.Generic;
using System.Linq;
using TardisTelemetryConsole.Models;

namespace TardisTelemetryConsole.Services;

public class TelemetryService
{
    private readonly Random _random = new();
    private readonly List<TardisSubsystem> _subsystems;
    private readonly List<SystemAlert> _activeAlerts = new();

    public TelemetryService()
    {
        _subsystems = BuildInitialSubsystems();
        RegenerateAlerts();
    }

    public List<TardisSubsystem> GetSubsystems()
    {
        return _subsystems.ToList();
    }

    public TardisSubsystem? GetSubsystemById(int id)
    {
        return _subsystems.FirstOrDefault(s => s.Id == id);
    }

    public List<SystemAlert> GetActiveAlerts()
    {
        return _activeAlerts.ToList();
    }

    public void SimulateTelemetryUpdate()
    {
        foreach (var subsystem in _subsystems)
        {
            foreach (var reading in subsystem.Readings)
            {
                // Small drift to simulate normal telemetry fluctuations.
                var change = (_random.NextDouble() * 8.0) - 4.0;
                reading.Value = Math.Round(Math.Clamp(reading.Value + change, 0, 100), 1);
                reading.LastUpdated = DateTime.UtcNow;
            }
        }

        RegenerateAlerts();
    }

    private void RegenerateAlerts()
    {
        _activeAlerts.Clear();
        var now = DateTime.UtcNow;

        foreach (var subsystem in _subsystems)
        {
            foreach (var reading in subsystem.Readings)
            {
                if (reading.Value >= reading.CriticalThreshold)
                {
                    _activeAlerts.Add(new SystemAlert
                    {
                        Id = _activeAlerts.Count + 1,
                        SubsystemId = subsystem.Id,
                        SubsystemName = subsystem.Name,
                        Message = $"{reading.Name} is in a critical state.",
                        Severity = "Critical",
                        CreatedAt = now,
                        IsAcknowledged = false
                    });
                }
                else if (reading.Value >= reading.WarningThreshold)
                {
                    _activeAlerts.Add(new SystemAlert
                    {
                        Id = _activeAlerts.Count + 1,
                        SubsystemId = subsystem.Id,
                        SubsystemName = subsystem.Name,
                        Message = $"{reading.Name} is above warning threshold.",
                        Severity = "Warning",
                        CreatedAt = now,
                        IsAcknowledged = false
                    });
                }
            }

            subsystem.Alerts = _activeAlerts
                .Where(a => a.SubsystemId == subsystem.Id)
                .ToList();
            subsystem.Status = GetSubsystemStatus(subsystem.Readings);
        }
    }

    private static string GetSubsystemStatus(List<SensorReading> readings)
    {
        if (readings.Any(r => r.Value >= r.CriticalThreshold))
        {
            return "Critical";
        }

        if (readings.Any(r => r.Value >= r.WarningThreshold))
        {
            return "Warning";
        }

        return "Stable";
    }

    private static List<TardisSubsystem> BuildInitialSubsystems()
    {
        var now = DateTime.UtcNow;

        return
        [
            new TardisSubsystem
            {
                Id = 1,
                Name = "Time Rotor Stability",
                Description = "Maintains stable temporal displacement during flight.",
                Status = "Nominal",
                Readings =
                [
                    new SensorReading { Name = "Harmonic Variance", Value = 42.5, Unit = "%", WarningThreshold = 65, CriticalThreshold = 80, LastUpdated = now },
                    new SensorReading { Name = "Rotor Oscillation", Value = 58.2, Unit = "%", WarningThreshold = 70, CriticalThreshold = 85, LastUpdated = now },
                    new SensorReading { Name = "Temporal Shear", Value = 33.9, Unit = "%", WarningThreshold = 60, CriticalThreshold = 78, LastUpdated = now }
                ],
                Alerts = []
            },
            new TardisSubsystem
            {
                Id = 2,
                Name = "Artron Energy Core",
                Description = "Primary power source and artron containment system.",
                Status = "Nominal",
                Readings =
                [
                    new SensorReading { Name = "Core Flux", Value = 61.4, Unit = "%", WarningThreshold = 75, CriticalThreshold = 90, LastUpdated = now },
                    new SensorReading { Name = "Containment Pressure", Value = 48.8, Unit = "bar", WarningThreshold = 68, CriticalThreshold = 84, LastUpdated = now },
                    new SensorReading { Name = "Energy Bleed", Value = 27.1, Unit = "%", WarningThreshold = 55, CriticalThreshold = 73, LastUpdated = now }
                ],
                Alerts = []
            },
            new TardisSubsystem
            {
                Id = 3,
                Name = "Chameleon Circuit",
                Description = "Controls external disguise and perceptual masking.",
                Status = "Nominal",
                Readings =
                [
                    new SensorReading { Name = "Morphic Alignment", Value = 39.7, Unit = "%", WarningThreshold = 62, CriticalThreshold = 79, LastUpdated = now },
                    new SensorReading { Name = "Identity Drift", Value = 46.3, Unit = "%", WarningThreshold = 66, CriticalThreshold = 82, LastUpdated = now }
                ],
                Alerts = []
            },
            new TardisSubsystem
            {
                Id = 4,
                Name = "Life Support Matrix",
                Description = "Regulates breathable atmosphere and onboard biosafety.",
                Status = "Nominal",
                Readings =
                [
                    new SensorReading { Name = "Atmospheric Mix Deviation", Value = 22.4, Unit = "%", WarningThreshold = 50, CriticalThreshold = 70, LastUpdated = now },
                    new SensorReading { Name = "Pressure Stability", Value = 29.6, Unit = "kPa", WarningThreshold = 52, CriticalThreshold = 72, LastUpdated = now },
                    new SensorReading { Name = "Biofield Integrity", Value = 35.8, Unit = "%", WarningThreshold = 58, CriticalThreshold = 76, LastUpdated = now }
                ],
                Alerts = []
            },
            new TardisSubsystem
            {
                Id = 5,
                Name = "Navigation Matrix",
                Description = "Handles dimensional coordinates and course correction.",
                Status = "Nominal",
                Readings =
                [
                    new SensorReading { Name = "Vector Drift", Value = 54.2, Unit = "%", WarningThreshold = 72, CriticalThreshold = 88, LastUpdated = now },
                    new SensorReading { Name = "Coordinate Lock Integrity", Value = 43.5, Unit = "%", WarningThreshold = 65, CriticalThreshold = 81, LastUpdated = now }
                ],
                Alerts = []
            },
            new TardisSubsystem
            {
                Id = 6,
                Name = "Exterior Shell Integrity",
                Description = "Monitors hull stress and dimensional seal quality.",
                Status = "Nominal",
                Readings =
                [
                    new SensorReading { Name = "Microfracture Density", Value = 37.9, Unit = "%", WarningThreshold = 60, CriticalThreshold = 79, LastUpdated = now },
                    new SensorReading { Name = "Hull Stress", Value = 49.1, Unit = "MPa", WarningThreshold = 67, CriticalThreshold = 84, LastUpdated = now },
                    new SensorReading { Name = "Dimensional Seal Cohesion", Value = 32.7, Unit = "%", WarningThreshold = 57, CriticalThreshold = 75, LastUpdated = now }
                ],
                Alerts = []
            }
        ];
    }
}

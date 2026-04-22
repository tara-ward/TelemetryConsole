## TARDIS Telemetry Console Project Checklist

## Project Purpose
- Built a small Blazor/.NET demo project for an IoT Programmer interview.
- The app is themed around the TARDIS from Doctor Who.
- The actual structure is based on an industrial IoT monitoring dashboard.
- It simulates equipment/sensor telemetry, evaluates readings, and displays system status and alerts.
- The goal was to demonstrate Blazor fundamentals, C#/.NET skills, component-based UI, routing, services, dependency injection, and dashboard-style data visualization.

## Initial Setup
- Checked installed .NET versions using:
  dotnet --info
- Confirmed Blazor templates were available using:
  dotnet new list blazor
- Created a new Blazor project using:
  dotnet new blazor -n TardisTelemetryConsole
- Entered the project folder using:
  cd TardisTelemetryConsole
- Ran the starter app using:
  dotnet run
- Confirmed the app launched locally at:
  http://localhost:5284
- Opened the project in Cursor.

## Project Structure Confirmed
- Confirmed the newer Blazor structure was being used.
- Routeable pages are located in:
  Components/Pages
- App file is located at:
  Components/App.razor
- Routes file is located at:
  Components/Routes.razor
- Main CSS file is located at:
  wwwroot/app.css
- Program.cs is located at the project root.

## Models Added
- Created a Models folder.
- Added TardisSubsystem model.
- Added SensorReading model.
- Added SystemAlert model.
- Used nullable-safe C#.
- Initialized strings and lists to avoid nullable warnings.

## TardisSubsystem Model Purpose
- Represents one monitored TARDIS system.
- Contains:
  Id
  Name
  Description
  Status
  Readings
  Alerts

## SensorReading Model Purpose
- Represents one simulated sensor value.
- Contains:
  Name
  Value
  Unit
  WarningThreshold
  CriticalThreshold
  LastUpdated

## SystemAlert Model Purpose
- Represents an alert generated from telemetry readings.
- Contains:
  Id
  SubsystemId
  SubsystemName
  Message
  Severity
  CreatedAt
  IsAcknowledged

## Telemetry Service Added
- Created a Services folder.
- Added TelemetryService.
- Registered TelemetryService in Program.cs using dependency injection.
- Used singleton registration so the same mock telemetry data stays available while the app is running.

## TelemetryService Purpose
- Acts as the mock IoT data source.
- Holds a list of TARDIS subsystems.
- Generates and updates simulated telemetry readings.
- Creates warning and critical alerts based on thresholds.
- Provides subsystem and alert data to the Blazor pages.

## TelemetryService Methods Added
- GetSubsystems()
- GetSubsystemById(int id)
- GetActiveAlerts()
- SimulateTelemetryUpdate()

## Mock TARDIS Subsystems Added
- Time Rotor Stability
- Artron Energy Core
- Chameleon Circuit
- Life Support Matrix
- Navigation Matrix
- Exterior Shell Integrity

## Telemetry Logic Added
- Each subsystem has simulated readings.
- Each reading has a value, unit, warning threshold, and critical threshold.
- SimulateTelemetryUpdate randomly changes the readings.
- The app checks readings against thresholds.
- If a value is normal, the system status is Stable.
- If a value reaches the warning threshold, the system status becomes Warning.
- If a value reaches the critical threshold, the system status becomes Critical.
- Warning alerts are generated for warning-level readings.
- Critical alerts are generated for critical-level readings.

## TARDIS-Inspired CSS Added
- Updated the app styling to use a TARDIS/sci-fi console theme.
- Used dark navy backgrounds.
- Used cyan borders and glow effects.
- Added rounded dashboard cards.
- Added readable text styling.
- Added responsive grid layout.
- Added status colours for Stable, Warning, and Critical.

## CSS Classes Added or Used
- tardis-page
- tardis-header
- tardis-grid
- tardis-card
- tardis-card-header
- reading-grid
- reading-tile
- status-pill
- status-stable
- status-warning
- status-critical
- alert-panel
- alert-item
- console-button

## Reusable Component Added
- Created SystemCard.razor.
- Placed it in Components/Tardis.
- Made it accept a TardisSubsystem parameter.
- Made it accept an OnViewDetails callback.
- Displays subsystem name.
- Displays subsystem description.
- Displays status pill.
- Displays sensor readings.
- Displays alert count.
- Displays View Diagnostics button.

## Dashboard Page Updated
- Updated Components/Pages/Home.razor.
- Used route "/".
- Injected TelemetryService.
- Injected NavigationManager.
- Added the main page title:
  TARDIS Telemetry Console
- Added subtitle:
  Simulated IoT-style systems monitoring dashboard
- Added Simulate Telemetry button.
- Added responsive dashboard grid.
- Displayed SystemCard components for each subsystem.
- Added Cloister Bell Alerts panel.
- Added active alert display.

## Simulate Telemetry Button
- Added a button on the dashboard.
- Button calls TelemetryService.SimulateTelemetryUpdate().
- Button refreshes subsystem data.
- Button refreshes active alerts.
- Button updates the UI immediately.
- Used this to simulate changing IoT telemetry data.

## View Diagnostics Button
- Added View Diagnostics button on each subsystem card.
- Button navigates to:
  /systems/{id}
- Used NavigationManager to route to the selected subsystem details page.

## Diagnostics Page Added
- Created routeable page:
  /systems/{id:int}
- Page shows details for one subsystem.
- Displays subsystem name.
- Displays subsystem description.
- Displays status.
- Displays current readings.
- Displays related alerts.
- Added friendly not-found message if subsystem does not exist.
- Added Back to Dashboard button.
- Fixed Back to Dashboard so it returns to route "/".

## Alerts Page Added
- Created routeable page:
  /alerts
- Injected TelemetryService.
- Displays active alerts.
- Shows severity.
- Shows subsystem name.
- Shows alert message.
- Shows created time.
- Displays friendly message if there are no active alerts.
- Removed the Simulate Telemetry button from the Alerts page because simulation belongs on the dashboard.

## Navigation Updated
- Updated the default Blazor navigation.
- Added Dashboard nav link.
- Added Alerts nav link.
- Kept routing simple.
- Restyled navigation to match the TARDIS theme.

## Default Blazor Theme Updated
- Restyled the default Blazor layout/navigation.
- Removed or overrode the default template look.
- Changed sidebar/nav styling to dark navy.
- Added cyan TARDIS-style accents.
- Styled active nav links like selected console buttons.
- Kept navigation readable and functional.
- Removed duplicate app branding/title above the nav bar.
- Kept the main dashboard title inside Home.razor.

## Critical Status Added
- Added support for Critical status.
- Critical appears when any reading reaches or exceeds its critical threshold.
- Critical status uses red styling.
- Warning uses yellow styling.
- Stable uses green/blue styling.
- Critical alerts show as red/critical in the UI.

## Testing Done
- Ran:
  dotnet build
- Confirmed the project builds successfully.
- Ran:
  dotnet run
- Opened the app locally.
- Confirmed the dashboard loads.
- Confirmed the TARDIS theme displays.
- Confirmed Simulate Telemetry updates values.
- Confirmed warning and critical statuses can appear.
- Confirmed View Diagnostics opens subsystem details.
- Confirmed Back to Dashboard works.
- Confirmed Alerts page displays alerts.
- Confirmed navigation links work.

## What the App Demonstrates
- Blazor fundamentals.
- .NET/C# project setup.
- Razor components.
- Component parameters.
- Event callbacks.
- Routing.
- NavigationManager.
- Dependency injection.
- Service layer architecture.
- C# models.
- Mock telemetry data.
- Conditional alert logic.
- Dashboard-style UI.
- Responsive CSS.
- User-facing data visualization.
- Debugging and iterative development.

## Future Improvements
- Add SQLite for saved settings.
- Add alert history.
- Add saved user preferences.
- Add charts for telemetry trends.
- Add authentication.
- Add real-time updates with SignalR.
- Add REST API integration.
- Add MQTT integration.
- Add OPC UA integration.
- Add SQL Server or production database support.
- Add real hardware or sensor data.
- Add unit tests.
- Add logging.
- Add exportable reports.

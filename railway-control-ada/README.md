# Railway Control System Simulation (Ada)

Concurrent & Real-Time Programming (PCTR) · UCLM · 2025/2026

**Authors:** David Calzado Olmo, Ignacio Romero Torres

## What it does

A concurrent simulation of a railway station control system built with Ada's tasking features. It models:

- Multiple trains of different types (Express, Regional, Freight), each running as its own task
- A single-track section with directional fairness
- Platform management with priority and anti-starvation
- A station controller based on rendezvous
- A periodic status monitor that prints statistics

## Project structure

```
src/
├── main.adb
├── config.ads                          simulation parameters
├── logger.ads        / logger.adb
├── controllers.ads   / controllers.adb station controller
├── monitor.ads       / monitor.adb     periodic status monitor
├── single_tracks.ads / single_tracks.adb
├── platforms.ads     / platforms.adb
├── trains.ads        / trains.adb
└── Makefile
```

## Build and run

Requires GNAT. From the `src/` directory:

```
make        # compile
make exec   # run
```

## Stress scenarios

Edit the constants in `src/config.ads` and recompile.

**Saturation**

```ada
Num_Trains_Express  : Natural := 4;
Num_Trains_Regional : Natural := 3;
Num_Trains_Freight  : Natural := 3;
Num_Platforms       : Platforms_Range := 2;
```

**Slack**

```ada
Num_Trains_Express  : Natural := 1;
Num_Trains_Regional : Natural := 1;
Num_Trains_Freight  : Natural := 1;
Num_Platforms       : Platforms_Range := 5;
```

**Express flood**

```ada
Num_Trains_Express  : Natural := 8;
Num_Trains_Regional : Natural := 0;
Num_Trains_Freight  : Natural := 2;
Num_Platforms       : Platforms_Range := 2;
```

# Bezier Surface Renderer

A professional implementation of a Bezier surface rendering engine, developed for the Computer Graphics course at the Faculty of Mathematics and Information Science (MiNI), Warsaw University of Technology.

## Overview

This project provides a robust environment for generating, manipulating, and rendering Bezier surfaces in real-time. It features a custom-built rendering pipeline that includes dynamic triangulation, advanced lighting models, and texture mapping.

## Features

### Surface Generation & Manipulation
- **Bezier Surfaces:** Mathematical implementation of surfaces based on a grid of control points.
- **Interactive Editing:** Real-time manipulation of control point positions via the UI or direct interaction.
- **Dynamic Triangulation:** Adjustable mesh density to control the level of detail and performance.
- **Transformations:** Support for surface rotation around the X and Z axes.

### Rendering & Lighting
- **Lighting Model:** A hybrid model incorporating:
  - **Lambertian Reflectance:** For diffuse surface coloring.
  - **Phong Specular Highlights:** For realistic light reflections.
- **Light Animation:** An animated light source that can orbit the surface, with adjustable height (Z-axis).
- **Parallel Processing:** Highly optimized triangle rendering utilizing multi-core processing for fluid performance.

### Advanced Shading
- **UV Texture Mapping:** Precise application of 2D textures onto the 3D surface.
- **Normal Mapping:** Enhanced surface detail and realism through the application of normal maps to simulate complex geometry.
- **Fast Bitmap Access:** Optimized pixel manipulation for low-latency rendering updates.

## Project Structure

- **BezierSurface:** Main Windows Forms application handling the UI, user interaction, and high-level rendering logic.
- **BezierSurface.Core:** Core mathematical library containing algorithms for Bezier surface calculation, mesh generation, and geometric primitives.
- **BezierSurface.Presentation:** Specialized logic for polygon filling, light intensity adjustment, and shading calculations.

## Requirements

- .NET 8.0 SDK or newer
- Windows OS (due to Windows Forms dependency)

## Getting Started

1. Clone the repository.
2. Open `BezierSurface.sln` in Visual Studio 2022 or higher.
3. Build the solution in Release mode for optimal performance.
4. Run the `BezierSurface` project.
5. Load control points from a text file to begin rendering (sample files included in the project directory if available).

## License

This project was developed for educational purposes at Warsaw University of Technology.

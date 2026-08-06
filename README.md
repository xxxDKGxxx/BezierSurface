# Bezier Surface Renderer

A professional 3D Bezier surface rendering engine and interactive graphics application developed for the Computer Graphics course at the Faculty of Mathematics and Information Science (MiNI), Warsaw University of Technology (WUT).

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Platform](https://img.shields.io/badge/platform-Windows-0078d7.svg)
![Framework](https://img.shields.io/badge/.NET-9.0--windows-512bd4.svg)
![Language](https://img.shields.io/badge/language-C%23-239120.svg)
![GUI](https://img.shields.io/badge/gui-Windows%20Forms-0078d7.svg)

---

## 🚀 Overview

**BezierSurface** provides a real-time environment for generating, evaluating, and shading bicubic Bézier surfaces. It features a custom software rendering pipeline with dynamic mesh triangulation, multi-threaded parallel triangle rasterization, Phong/Lambertian illumination models, animated light sources, UV texture mapping, and normal mapping.

---

## ✨ Features

### 🔲 Surface Generation & Interactive Manipulation
- **Bicubic Bézier Surfaces**: Mathematical evaluation of parametric surfaces based on a $4 \times 4$ grid of 3D control points.
- **Control Point Editing**: Real-time manipulation of control point positions via interactive UI controls and direct scene interaction.
- **Dynamic Triangulation Mesh**: Adjustable grid resolution and density ($N \times M$ division steps) to balance detail vs. performance.
- **3D Surface Transformations**: Real-time rotations around X and Z axes, scaling, and translation.

### 💡 Lighting & Shading Model
- **Hybrid Illumination**:
  - **Lambertian Reflectance**: Diffuse surface color calculations based on normal vectors.
  - **Phong Specular Highlights**: Realistic specular reflections and customizable shininess exponents.
- **Animated Light Source**: Interactive light orbiting around the surface with adjustable height ($Z$-axis) and color.
- **Parallel Multi-Core Rasterization**: Parallelized scanline algorithm for high-fps software rendering using `Parallel.For` and fast bitmap memory buffer access (`LockBits`).

### 🖼️ Advanced Texture & Normal Mapping
- **UV Texture Mapping**: Bilinear interpolation mapping 2D bitmap textures across the parametric surface ($u, v \in [0, 1]$).
- **Normal Mapping**: Bumpy surface micro-geometry simulation via tangent-space normal maps.

---

## 🛠️ Tech Stack & Architecture

- **Language**: C# (.NET 9.0)
- **Framework**: Windows Forms (WinForms)
- **Memory**: Unsafe pointers and `BitmapData.Scan0` for zero-allocation rendering buffers

### Solution Structure
- `BezierSurface.Core`: Mathematical evaluation algorithms for Bézier surfaces, derivative evaluations, normal vector calculations, and mesh generation.
- `BezierSurface.Presentation`: Triangle rasterization engine, scanline algorithm, shading pipeline, and lighting math.
- `BezierSurface`: Main GUI application, interactive canvas, control panel bindings, and scene file loading.
- `BezierSurface.CoreTests1`: Unit test suite for core mathematical evaluation algorithms.

---

## 💻 Getting Started

### Prerequisites

- **Visual Studio 2022** (v17.12 or newer with .NET 9 SDK)
- **Windows OS** (required for Windows Forms)

### Running the Application

1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-username/BezierSurface.git
   cd BezierSurface
   ```

2. **Build and Run via Visual Studio**:
   - Open `BezierSurface.sln`.
   - Set configuration to **Release** for optimal parallel rasterization performance.
   - Press **F5** to build and run.

3. **Or run via .NET CLI**:
   ```bash
   dotnet run --project BezierSurface/BezierSurface.csproj
   ```

---

## 📜 License

This project is licensed under the [MIT License](LICENSE).

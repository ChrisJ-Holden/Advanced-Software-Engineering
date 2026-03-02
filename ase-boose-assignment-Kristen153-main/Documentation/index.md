---
_layout: landing
title: BSE Documentation
---

# Welcome to **BOOSE Graphics Environment (BSE)**
**ver 1.0.0**

BOOSEGraphicsEnvironment (BSE) is a set of classes for implimenting the BOOSE language.
It provides a framework for creating a drawing application that allows users to draw shapes and text on a canvas using various commands.

Created for Advanced Software Engineering module at the University of Leeds Beckett.
created by: Kristen Holden - 2025/2026

---

## Classes

- **AppCanvas** - The main canvas class for drawing shapes and text.
- **AppForm** - The main application form that hosts the canvas and user interface.
- **BitmapManager** - Manages the underlying bitmap and graphics context.
- **Shapes** (namespace `BOOSEGraphicsEnvironment.Shapes`) - Abstract and concrete classes for shapes:
	- `Shape` - Abstract base class for shapes.
	- `EllipseShape` - Draws circles or ellipses.
	- `RectangleShape` - Draws rectangles.
	- `PolygonShape` - Draws triangles or other polygons.
- **Commands** (namespace `BOOSEGraphicsEnvironment.Commands`) - Insert message:
	- `CircleCommand` - Draws a circle on a canvas. Requires **1 parameter**: the radius. Validates input before drawing.  
    - `RectCommand` - Draws a rectangle on the canvas; takes **2 parameters** width and height. Validates input before drawing.
    - `TriCommand` - Draws a Triangle on the canvas; takes **2 parameters** width and height. Validates input before drawing.
	- `MoveToCommand` - Moves the drawing cursor to a specified position on the canvas; takes **2 parameters** X axis and Y axis. Validates before moving.  
	- `DrawToCommand` -  Draw to a specified position on the canvas; takes **2 parameters** X axis and Y axis. Validates before drawing.  
	- `PenColourCommand` - Change the pen colour to a specified colour; takes **3 parameter** red (0 - 255), green (0 - 255) and blue (0 - 255). Validates before changing.
- **AppCommandFactory** - Factory class that creates command instances based on command type strings and validates input.

## Interfaces

- **IDrawable** - Interface for objects that can be drawn on a canvas. Implementing classes must define a `Draw` method that takes a `Graphics` context, `Pen`, and coordinates.

## Tests
- **AppCanvasTests** - Tests bitmap creation, resizing, pen colour, movement, drawing shapes, writing text, clearing, resetting, and disposing.  
- **AppFormTests** - Tests form initialisation and canvas integration.
- **CommandsTests** (namespace `AppTest.CommandsTests`) - Tests for command classes:
	- `MoveToCommandTests` - Tests constructors, parameter checking, and execution with/without a canvas.  
	- `DrawToCommandTests` - Tests constructors, parameter checking, and execution with/without a canvas.
	- `PenCommandTests` - Tests constructors, parameter checking, and execution without a canvas.  
	- `RectCommandTests` - Tests constructors, parameter checking, and execution without a canvas.  
	- `TriCommandTests` - Tests constructors, parameter checking, and execution without a canvas.  
	- `CircleCommandTests` - Tests constructors, parameter checking, and execution without a canvas.
- **ShapesTests** (namespace `AppTest.ShapesTests`) - Tests for shape classes:
	- `EllipseShapeTests` - Tests constructors and drawing functionality.  
	- `RectangleShapeTests` - Tests constructors and drawing functionality.  
	- `PolygonShapeTests` - Tests constructors and drawing functionality.
- **BitmapManagerTests** - Tests bitmap creation, resizing, and disposing.
- **AppCommandFactoryTests** - Tests command creation and invalid command handling.
---

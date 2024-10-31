﻿using Kitware.VTK;
using OptomoMvvm.Interface;

namespace OptomoMvvm.Implementation
{
    internal class Renderer : IRenderer
    {
        private vtkRenderer renderer;

        public void Create(vtkActor2D Actor, double[] Position, double[] Background)
        {
            renderer = new vtkRenderer();
            renderer.AddActor(Actor);
            renderer.SetBackground(Background[0], Background[1], Background[2]);
            renderer.SetViewport(Position[0], Position[1], Position[2], Position[3]);
        }

        public void Create(vtkVolume Actor, double[] Position, double[] Background)
        {
            renderer = new vtkRenderer();
            renderer.AddActor(Actor);
            renderer.SetBackground(Background[0], Background[1], Background[2]);
            renderer.SetViewport(Position[0], Position[1], Position[2], Position[3]);
        }

        public vtkRenderer GetRenderer() => renderer;
    }
}
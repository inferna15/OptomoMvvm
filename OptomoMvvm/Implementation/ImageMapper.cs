﻿using Kitware.VTK;
using OptomoMvvm.Interface;

namespace OptomoMvvm.Implementation
{
    public class ImageMapper : IImageMapper
    {
        private vtkImageMapper mapper;

        public ImageMapper() => mapper = new vtkImageMapper();

        public void Create(vtkAlgorithmOutput Output) => mapper.SetInputConnection(Output);

        public vtkImageMapper GetMapper() => mapper;

        public void SetColorLevel(int Value) => mapper.SetColorLevel(Value);

        public void SetColorWindow(int Value) => mapper.SetColorWindow(Value);
    }
}

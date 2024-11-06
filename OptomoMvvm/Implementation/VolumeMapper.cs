using Kitware.VTK;
using OptomoMvvm.Interface;

namespace OptomoMvvm.Implementation
{
    public class VolumeMapper : IVolumeMapper
    {
        private vtkSmartVolumeMapper mapper;

        public void Create(vtkAlgorithmOutput Output)
        {
            mapper = new vtkSmartVolumeMapper();
            mapper.SetInputConnection(Output);
        }

        public vtkSmartVolumeMapper GetMapper() => mapper;

        public void SetAutoAdjustSampleDistances(bool Value) => mapper.SetAutoAdjustSampleDistances(Value ? 1 : 0);

        public void SetGlobalIlluminationReach(float Value) => mapper.SetGlobalIlluminationReach(Value);

        public void SetInteractiveAdjustSampleDistances(bool Value) => mapper.SetInteractiveAdjustSampleDistances(Value ? 1 : 0);

        public void SetInteractiveUpdateRate(double Value) => mapper.SetInteractiveUpdateRate(Value);

        public void SetInterpolitionType(INTERPOLATION Interpolation) => mapper.SetInterpolationMode((int)Interpolation);

        public void SetMaxMemoryFraction(float Ratio) => mapper.SetMaxMemoryFraction(Ratio);

        public void SetMaxMemoryInBytes(int MaxMemoryInBytes) => mapper.SetMaxMemoryInBytes(MaxMemoryInBytes);

        public void SetRenderMode(RenderMode Mode) => mapper.SetRequestedRenderMode((int)Mode);

        public void SetUseJittering(bool Value) => mapper.SetUseJittering(Value ? 1 : 0);

        public void SetVolumetricScatteringBlending(float Value) => mapper.SetVolumetricScatteringBlending(Value);
    }
}

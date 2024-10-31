using Kitware.VTK;

namespace OptomoMvvm.Interface
{
    public enum RenderMode
    {
        DefaultRenderMode,
        RayCastRenderMode,
        GPURenderMode,
        OSPRayRenderMode,
        AnariRenderMode,
        UndefinedRenderMode,
        InvalidRenderMode
    }

    internal interface IVolumeMapper
    {
        void Create(vtkAlgorithmOutput Output);
        vtkSmartVolumeMapper GetMapper();
        void SetRenderMode(RenderMode Mode);
        void SetInterpolitionType(INTERPOLATION Interpolation);
        void SetMaxMemoryInBytes(int MaxMemoryInBytes);
        void SetMaxMemoryFraction(float Ratio);
        void SetInteractiveUpdateRate(double Value);
        void SetUseJittering(bool Value);
        void SetInteractiveAdjustSampleDistances(bool Value);
        void SetAutoAdjustSampleDistances(bool Value);
        void SetGlobalIlluminationReach(float Value);
        void SetVolumetricScatteringBlending(float Value);
    }
}

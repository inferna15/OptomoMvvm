using Kitware.VTK;

namespace OptomoMvvm.Interface
{
    internal interface IVolume
    {
        void Create();
        void SetMapper(vtkSmartVolumeMapper Mapper);
        void SetProperty(vtkVolumeProperty Property);
        vtkVolume GetVolume();
    }
}

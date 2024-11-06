using Kitware.VTK;
using OptomoMvvm.Interface;

namespace OptomoMvvm.Implementation
{
    public class Lines3D : ILines3D
    {
        private vtkLineSource[] lines3D;
        private double[,,] linePos3D;

        public Lines3D()
        {
            lines3D = new vtkLineSource[15];
            linePos3D = new double[15, 2, 3];
        }

        public void Create(vtkRenderer view3DRenderer)
        {
            for (int i = 0; i < 15; i++)
            {
                vtkPolyDataMapper lineMapper = new vtkPolyDataMapper();
                vtkActor lineActor = new vtkActor();
                lines3D[i] = new vtkLineSource();
                lineMapper.SetInputConnection(lines3D[i].GetOutputPort());
                lineActor.SetMapper(lineMapper);
                if (i / 4 == 0)
                {
                    lineActor.GetProperty().SetColor(1, 0, 0);
                }
                else if (i / 4 == 1)
                {
                    lineActor.GetProperty().SetColor(0, 1, 0);
                }
                else if (i / 4 == 2)
                {
                    lineActor.GetProperty().SetColor(0, 0, 1);
                }
                else if (i == 12)
                {
                    lineActor.GetProperty().SetColor(0, 1, 1);
                }
                else if (i == 13)
                {
                    lineActor.GetProperty().SetColor(1, 0, 1);
                }
                else if (i == 14)
                {
                    lineActor.GetProperty().SetColor(1, 1, 0);
                }
                view3DRenderer.AddActor(lineActor);
            }
        }

        public void SetAxialLines()
        {
            lines3D[4].SetPoint1(linePos3D[4, 0, 0], linePos3D[4, 0, 1], linePos3D[4, 0, 2]);
            lines3D[4].SetPoint2(linePos3D[4, 1, 0], linePos3D[4, 1, 1], linePos3D[4, 1, 2]);
            lines3D[5].SetPoint1(linePos3D[5, 0, 0], linePos3D[5, 0, 1], linePos3D[5, 0, 2]);
            lines3D[5].SetPoint2(linePos3D[5, 1, 0], linePos3D[5, 1, 1], linePos3D[5, 1, 2]);
            lines3D[6].SetPoint1(linePos3D[6, 0, 0], linePos3D[6, 0, 1], linePos3D[6, 0, 2]);
            lines3D[6].SetPoint2(linePos3D[6, 1, 0], linePos3D[6, 1, 1], linePos3D[6, 1, 2]);
            lines3D[7].SetPoint1(linePos3D[7, 0, 0], linePos3D[7, 0, 1], linePos3D[7, 0, 2]);
            lines3D[7].SetPoint2(linePos3D[7, 1, 0], linePos3D[7, 1, 1], linePos3D[7, 1, 2]);
            lines3D[12].SetPoint1(linePos3D[12, 0, 0], linePos3D[12, 0, 1], linePos3D[12, 0, 2]);
            lines3D[12].SetPoint2(linePos3D[12, 1, 0], linePos3D[12, 1, 1], linePos3D[12, 1, 2]);
            lines3D[14].SetPoint1(linePos3D[14, 0, 0], linePos3D[14, 0, 1], linePos3D[14, 0, 2]);
            lines3D[14].SetPoint2(linePos3D[14, 1, 0], linePos3D[14, 1, 1], linePos3D[14, 1, 2]);
        }

        public void SetAxialLinesPos(int Layer, int[] Extent, double[] Spacing)
        {
            linePos3D[4, 0, 1] = Layer * Spacing[1];
            linePos3D[4, 1, 1] = Layer * Spacing[1];
            linePos3D[5, 0, 1] = Layer * Spacing[1];
            linePos3D[5, 1, 1] = Layer * Spacing[1];
            linePos3D[6, 0, 1] = Layer * Spacing[1];
            linePos3D[6, 1, 1] = Layer * Spacing[1];
            linePos3D[7, 0, 1] = Layer * Spacing[1];
            linePos3D[7, 1, 1] = Layer * Spacing[1];
            linePos3D[12, 0, 1] = Layer * Spacing[1];
            linePos3D[12, 1, 1] = Layer * Spacing[1];
            linePos3D[14, 0, 1] = Layer * Spacing[1];
            linePos3D[14, 1, 1] = Layer * Spacing[1];
        }

        public void SetInitPoints()
        {
            for (int i = 0; i < 15; i++)
            {
                lines3D[i].SetPoint1(linePos3D[i, 0, 0], linePos3D[i, 0, 1], linePos3D[i, 0, 2]);
                lines3D[i].SetPoint2(linePos3D[i, 1, 0], linePos3D[i, 1, 1], linePos3D[i, 1, 2]);
            }
        }

        public void SetConstPointsPos(int[] Extent, double[] Spacing)
        {
            linePos3D[0, 0, 2] = 0;
            linePos3D[0, 1, 2] = 0;
            linePos3D[0, 0, 1] = 0;
            linePos3D[0, 1, 1] = Extent[3] * Spacing[1];
            linePos3D[1, 0, 2] = Extent[5] * Spacing[2];
            linePos3D[1, 1, 2] = Extent[5] * Spacing[2];
            linePos3D[1, 0, 1] = 0;
            linePos3D[1, 1, 1] = Extent[3] * Spacing[1];
            linePos3D[2, 0, 2] = 0;
            linePos3D[2, 1, 2] = Extent[5] * Spacing[2];
            linePos3D[2, 0, 1] = 0;
            linePos3D[2, 1, 1] = 0;
            linePos3D[3, 0, 2] = 0;
            linePos3D[3, 1, 2] = Extent[5] * Spacing[2];
            linePos3D[3, 0, 1] = Extent[3] * Spacing[1];
            linePos3D[3, 1, 1] = Extent[3] * Spacing[1];
            linePos3D[4, 0, 0] = 0;
            linePos3D[4, 1, 0] = Extent[1] * Spacing[0];
            linePos3D[4, 0, 2] = 0;
            linePos3D[4, 1, 2] = 0;
            linePos3D[5, 0, 0] = Extent[1] * Spacing[0];
            linePos3D[5, 1, 0] = Extent[1] * Spacing[0];
            linePos3D[5, 0, 2] = 0;
            linePos3D[5, 1, 2] = Extent[5] * Spacing[2];
            linePos3D[6, 0, 0] = Extent[1] * Spacing[0];
            linePos3D[6, 1, 0] = 0;
            linePos3D[6, 0, 2] = Extent[5] * Spacing[2];
            linePos3D[6, 1, 2] = Extent[5] * Spacing[2];
            linePos3D[7, 0, 0] = 0;
            linePos3D[7, 1, 0] = 0;
            linePos3D[7, 0, 2] = Extent[5] * Spacing[2];
            linePos3D[7, 1, 2] = 0;
            linePos3D[8, 0, 0] = 0;
            linePos3D[8, 1, 0] = 0;
            linePos3D[8, 0, 1] = 0;
            linePos3D[8, 1, 1] = Extent[3] * Spacing[1];
            linePos3D[9, 0, 0] = Extent[1] * Spacing[0];
            linePos3D[9, 1, 0] = Extent[1] * Spacing[0];
            linePos3D[9, 0, 1] = 0;
            linePos3D[9, 1, 1] = Extent[3] * Spacing[1];
            linePos3D[10, 0, 0] = 0;
            linePos3D[10, 1, 0] = Extent[1] * Spacing[0];
            linePos3D[10, 0, 1] = 0;
            linePos3D[10, 1, 1] = 0;
            linePos3D[11, 0, 0] = 0;
            linePos3D[11, 1, 0] = Extent[1] * Spacing[0];
            linePos3D[11, 0, 1] = Extent[3] * Spacing[1];
            linePos3D[11, 1, 1] = Extent[3] * Spacing[1];
            linePos3D[12, 0, 0] = 0;
            linePos3D[12, 1, 0] = Extent[1] * Spacing[0];
            linePos3D[13, 0, 1] = 0;
            linePos3D[13, 1, 1] = Extent[3] * Spacing[1];
            linePos3D[14, 0, 2] = 0;
            linePos3D[14, 1, 2] = Extent[5] * Spacing[2];
        }

        public void SetFrontalLines()
        {
            lines3D[8].SetPoint1(linePos3D[8, 0, 0], linePos3D[8, 0, 1], linePos3D[8, 0, 2]);
            lines3D[8].SetPoint2(linePos3D[8, 1, 0], linePos3D[8, 1, 1], linePos3D[8, 1, 2]);
            lines3D[9].SetPoint1(linePos3D[9, 0, 0], linePos3D[9, 0, 1], linePos3D[9, 0, 2]);
            lines3D[9].SetPoint2(linePos3D[9, 1, 0], linePos3D[9, 1, 1], linePos3D[9, 1, 2]);
            lines3D[10].SetPoint1(linePos3D[10, 0, 0], linePos3D[10, 0, 1], linePos3D[10, 0, 2]);
            lines3D[10].SetPoint2(linePos3D[10, 1, 0], linePos3D[10, 1, 1], linePos3D[10, 1, 2]);
            lines3D[11].SetPoint1(linePos3D[11, 0, 0], linePos3D[11, 0, 1], linePos3D[11, 0, 2]);
            lines3D[11].SetPoint2(linePos3D[11, 1, 0], linePos3D[11, 1, 1], linePos3D[11, 1, 2]);
            lines3D[12].SetPoint1(linePos3D[12, 0, 0], linePos3D[12, 0, 1], linePos3D[12, 0, 2]);
            lines3D[12].SetPoint2(linePos3D[12, 1, 0], linePos3D[12, 1, 1], linePos3D[12, 1, 2]);
            lines3D[13].SetPoint1(linePos3D[13, 0, 0], linePos3D[13, 0, 1], linePos3D[13, 0, 2]);
            lines3D[13].SetPoint2(linePos3D[13, 1, 0], linePos3D[13, 1, 1], linePos3D[13, 1, 2]);
        }

        public void SetFrontalLinesPos(int Layer, int[] Extent, double[] Spacing)
        {
            linePos3D[8, 0, 2] = Layer * Spacing[2];
            linePos3D[8, 1, 2] = Layer * Spacing[2];
            linePos3D[9, 0, 2] = Layer * Spacing[2];
            linePos3D[9, 1, 2] = Layer * Spacing[2];
            linePos3D[10, 0, 2] = Layer * Spacing[2];
            linePos3D[10, 1, 2] = Layer * Spacing[2];
            linePos3D[11, 0, 2] = Layer * Spacing[2];
            linePos3D[11, 1, 2] = Layer * Spacing[2];
            linePos3D[12, 0, 2] = Layer * Spacing[2];
            linePos3D[12, 1, 2] = Layer * Spacing[2];
            linePos3D[13, 0, 2] = Layer * Spacing[2];
            linePos3D[13, 1, 2] = Layer * Spacing[2];
        }

        public void SetSagittalLines()
        {
            lines3D[0].SetPoint1(linePos3D[0, 0, 0], linePos3D[0, 0, 1], linePos3D[0, 0, 2]);
            lines3D[0].SetPoint2(linePos3D[0, 1, 0], linePos3D[0, 1, 1], linePos3D[0, 1, 2]);
            lines3D[1].SetPoint1(linePos3D[1, 0, 0], linePos3D[1, 0, 1], linePos3D[1, 0, 2]);
            lines3D[1].SetPoint2(linePos3D[1, 1, 0], linePos3D[1, 1, 1], linePos3D[1, 1, 2]);
            lines3D[2].SetPoint1(linePos3D[2, 0, 0], linePos3D[2, 0, 1], linePos3D[2, 0, 2]);
            lines3D[2].SetPoint2(linePos3D[2, 1, 0], linePos3D[2, 1, 1], linePos3D[2, 1, 2]);
            lines3D[3].SetPoint1(linePos3D[3, 0, 0], linePos3D[3, 0, 1], linePos3D[3, 0, 2]);
            lines3D[3].SetPoint2(linePos3D[3, 1, 0], linePos3D[3, 1, 1], linePos3D[3, 1, 2]);
            lines3D[14].SetPoint1(linePos3D[14, 0, 0], linePos3D[14, 0, 1], linePos3D[14, 0, 2]);
            lines3D[14].SetPoint2(linePos3D[14, 1, 0], linePos3D[14, 1, 1], linePos3D[14, 1, 2]);
            lines3D[13].SetPoint1(linePos3D[13, 0, 0], linePos3D[13, 0, 1], linePos3D[13, 0, 2]);
            lines3D[13].SetPoint2(linePos3D[13, 1, 0], linePos3D[13, 1, 1], linePos3D[13, 1, 2]);
        }

        public void SetSagittalLinesPos(int Layer, int[] Extent, double[] Spacing)
        {
            linePos3D[0, 0, 0] = Layer * Spacing[0];
            linePos3D[0, 1, 0] = Layer * Spacing[0];
            linePos3D[1, 0, 0] = Layer * Spacing[0];
            linePos3D[1, 1, 0] = Layer * Spacing[0];
            linePos3D[2, 0, 0] = Layer * Spacing[0];
            linePos3D[2, 1, 0] = Layer * Spacing[0];
            linePos3D[3, 0, 0] = Layer * Spacing[0];
            linePos3D[3, 1, 0] = Layer * Spacing[0];
            linePos3D[13, 0, 0] = Layer * Spacing[0];
            linePos3D[13, 1, 0] = Layer * Spacing[0];
            linePos3D[14, 0, 0] = Layer * Spacing[0];
            linePos3D[14, 1, 0] = Layer * Spacing[0];
        }
    }
}

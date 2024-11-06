using Kitware.VTK;
using OptomoMvvm.Interface;

namespace OptomoMvvm.Implementation
{
    internal class Lines2D : ILines2D
    {
        private vtkLineSource[] lines2D;
        private double[,,] linePos2D;

        public Lines2D()
        {
            lines2D = new vtkLineSource[6];
            linePos2D = new double[6, 2, 2];
        }

        public void Create(vtkRenderer axialRenderer, vtkRenderer sagittalRenderer, vtkRenderer frontalRenderer)
        {
            for (int i = 0; i < 6; i++)
            {
                vtkPolyDataMapper2D lineMapper = new vtkPolyDataMapper2D();
                vtkActor2D lineActor = new vtkActor2D();
                lines2D[i] = new vtkLineSource();
                lineMapper.SetInputConnection(lines2D[i].GetOutputPort());
                lineActor.SetMapper(lineMapper);
                lineActor.GetProperty().SetLineWidth(1);
                // Renk Ayarlama
                if (i / 2 == 0)
                {
                    lineActor.GetProperty().SetColor(1, 0, 0);
                }
                else if (i / 2 == 1)
                {
                    lineActor.GetProperty().SetColor(0, 1, 0);
                }
                else if (i / 2 == 2)
                {
                    lineActor.GetProperty().SetColor(0, 0, 1);
                }
                // Panele Ekleme
                if (i == 3 || i == 5)
                {
                    sagittalRenderer.AddActor(lineActor);
                }
                else if (i == 0 || i == 4)
                {
                    axialRenderer.AddActor(lineActor);
                }
                else if (i == 1 || i == 2)
                {
                    frontalRenderer.AddActor(lineActor);
                }
            }
        }

        public void SetAxialLines()
        {
            lines2D[2].SetPoint1(linePos2D[2, 0, 0], linePos2D[2, 0, 1], 0);
            lines2D[2].SetPoint2(linePos2D[2, 1, 0], linePos2D[2, 1, 1], 0);
            lines2D[3].SetPoint1(linePos2D[3, 0, 0], linePos2D[3, 0, 1], 0);
            lines2D[3].SetPoint2(linePos2D[3, 1, 0], linePos2D[3, 1, 1], 0);
        }

        public void SetAxialLinesPos(int Layer, int[] Motion, double[] Ratio, int[] Offset, double[] Zoom, double width, double height)
        {
            linePos2D[2, 0, 0] = (Offset[2] + Motion[0] * Ratio[2]) * Zoom[2] - (width / 2 * (Zoom[2] - 1.0));
            linePos2D[2, 0, 1] = (Layer + Motion[1]) * Ratio[2];
            linePos2D[2, 1, 0] = width + (width / 2 * (Zoom[2] - 1.0)) - (Offset[2] * Zoom[2]) + (Motion[0] * Ratio[2] * Zoom[2]);
            linePos2D[2, 1, 1] = (Layer + Motion[1]) * Ratio[2];
            linePos2D[3, 0, 0] = (Layer + Motion[1]) * Ratio[0] + Offset[0];
            linePos2D[3, 0, 1] = (Motion[2] * Ratio[0] * Zoom[0]) - (height / 2 * (Zoom[0] - 1.0));
            linePos2D[3, 1, 0] = (Layer + Motion[1]) * Ratio[0] + Offset[0];
            linePos2D[3, 1, 1] = (Motion[2] * Ratio[0] * Zoom[0]) + height + (height / 2 * (Zoom[0] - 1.0));
        }

        public void SetFrontalLines()
        {
            lines2D[4].SetPoint1(linePos2D[4, 0, 0], linePos2D[4, 0, 1], 0);
            lines2D[4].SetPoint2(linePos2D[4, 1, 0], linePos2D[4, 1, 1], 0);
            lines2D[5].SetPoint1(linePos2D[5, 0, 0], linePos2D[5, 0, 1], 0);
            lines2D[5].SetPoint2(linePos2D[5, 1, 0], linePos2D[5, 1, 1], 0);
        }

        public void SetFrontalLinesPos(int Layer, int[] Motion, double[] Ratio, int[] Offset, double[] Zoom, double width, double height)
        {
            linePos2D[4, 0, 0] = (Offset[1] + Motion[0] * Ratio[1]) * Zoom[1] - (width / 2 * (Zoom[1] - 1.0));
            linePos2D[4, 0, 1] = (Layer + Motion[2]) * Ratio[1];
            linePos2D[4, 1, 0] = width + (width / 2 * (Zoom[1] - 1.0)) - (Offset[1] * Zoom[1]) + (Motion[0] * Ratio[1] * Zoom[1]);
            linePos2D[4, 1, 1] = (Layer + Motion[2]) * Ratio[1];
            linePos2D[5, 0, 0] = (Offset[0] + Motion[1] * Ratio[0]) * Zoom[0] - (width / 2 * (Zoom[0] - 1.0));
            linePos2D[5, 0, 1] = (Layer + Motion[2]) * Ratio[0];
            linePos2D[5, 1, 0] = width + (width / 2 * (Zoom[0] - 1.0)) - (Offset[0] * Zoom[0]) + (Motion[1] * Ratio[0] * Zoom[0]);
            linePos2D[5, 1, 1] = (Layer + Motion[2]) * Ratio[0];
        }

        public void SetSagittalLines()
        {
            lines2D[0].SetPoint1(linePos2D[0, 0, 0], linePos2D[0, 0, 1], 0);
            lines2D[0].SetPoint2(linePos2D[0, 1, 0], linePos2D[0, 1, 1], 0);
            lines2D[1].SetPoint1(linePos2D[1, 0, 0], linePos2D[1, 0, 1], 0);
            lines2D[1].SetPoint2(linePos2D[1, 1, 0], linePos2D[1, 1, 1], 0);
        }

        public void SetSagittalLinesPos(int Layer, int[] Motion, double[] Ratio, int[] Offset, double[] Zoom, double width, double height)
        {
            linePos2D[0, 0, 0] = (Layer + Motion[0]) * Ratio[1] + Offset[1];
            linePos2D[0, 0, 1] = (Motion[2] * Ratio[1] * Zoom[1]) - (height / 2 * (Zoom[1] - 1.0));
            linePos2D[0, 1, 0] = (Layer + Motion[0]) * Ratio[1] + Offset[1];
            linePos2D[0, 1, 1] = (Motion[2] * Ratio[1] * Zoom[1]) + height + (height / 2 * (Zoom[1] - 1.0));
            linePos2D[1, 0, 0] = (Layer + Motion[0]) * Ratio[2] + Offset[2];
            linePos2D[1, 0, 1] = (Motion[1] * Ratio[2] * Zoom[2]) - (height / 2 * (Zoom[2] - 1.0));
            linePos2D[1, 1, 0] = (Layer + Motion[0]) * Ratio[2] + Offset[2];
            linePos2D[1, 1, 1] = (Motion[1] * Ratio[2] * Zoom[2]) + height + (height / 2 * (Zoom[2] - 1.0));
        }
    }
}

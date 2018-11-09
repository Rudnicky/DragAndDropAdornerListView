using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace DragDropAdornerPoC.Adorners
{
    public class RectangleAdorner : Adorner
    {
        public RectangleAdorner(UIElement adornedElement)
                : base(adornedElement)
        {
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            var adornedElementRect = new Rect(this.AdornedElement.DesiredSize);
            var renderPen = new Pen(new SolidColorBrush(Colors.Black), 1.5);
            var renderBrush = new SolidColorBrush(Colors.Black);

            drawingContext.DrawLine(renderPen, adornedElementRect.TopLeft, adornedElementRect.TopRight);
            drawingContext.DrawLine(renderPen, adornedElementRect.TopLeft, adornedElementRect.BottomLeft);
            drawingContext.DrawLine(renderPen, adornedElementRect.BottomLeft, adornedElementRect.BottomRight);
            drawingContext.DrawLine(renderPen, adornedElementRect.TopRight, adornedElementRect.BottomRight);
        }

        private StreamGeometry GetTriangle(Point p1, Point p2, Point p3)
        {
            StreamGeometry streamGeometry = new StreamGeometry();
            using (StreamGeometryContext geometryContext = streamGeometry.Open())
            {
                geometryContext.BeginFigure(p1, true, true);
                PointCollection points = new PointCollection { p2, p3 };
                geometryContext.PolyLineTo(points, true, true);
            }

            streamGeometry.Freeze();
            return streamGeometry;
        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using TIAS.Core.Base;
using TIAS.Core.Enum;
using TIAS.Core.Models;
using TIAS.Core.Structure;
using TIAS.Elements;

namespace TIAS.Pages
{
    public partial class LoadLevel : Page
    {
        private HexMap CurrentLevel;
        private static readonly float _hexSize = 50f;

        private bool _isDragging = false;
        private Point _lastMousePosition;
        private double _scrollViewerHorizontalOffset;
        private double _scrollViewerVerticalOffset;

        private double _minHorizontalOffset = 0;
        private double _maxHorizontalOffset = 0;
        private double _minVerticalOffset = 0;
        private double _maxVerticalOffset = 0;

        public LoadLevel(HexMap currentLevel)
        {
            InitializeComponent();

            if (currentLevel == null)
            {
                return;
            }

            CurrentLevel = currentLevel;

            Loaded += (s, e) => UpdateScrollBounds();
            HexClicked += OnClickHex;
            CreateMap(currentLevel);
        }
        private void OnClickHex(HexCoord hex)
        {
            if(MainWindow.Instance.SelectUnit != null)
            {
                MessageBox.Show("Идем на этот хекс");
                MainWindow.Instance.SelectUnit.Move(hex);
                CreateMap(CurrentLevel);
                MainWindow.Instance.SelectUnit = null;
            }
        }
        private void CreateMap(HexMap currentLevel)
        {
            parrent.Children.Clear();

            // Устанавливаем размер Canvas
            UpdateCanvasSize();

            for (int i = 0; i < currentLevel.Width; i++)
            {
                for (int j = 0; j < currentLevel.Height; j++)
                {
                    HexCoord hexCoord = new HexCoord(i, j);
                    DrawHexCell(hexCoord);
                }
            }
        }

        private void UpdateCanvasSize()
        {
            float xOffset = _hexSize * (float)Math.Sqrt(3);
            float yOffset = _hexSize * 1.5f;

            double width = xOffset * CurrentLevel.Width + (xOffset / 2) + 200;
            double height = yOffset * CurrentLevel.Height + 200;

            parrent.Width = width;
            parrent.Height = height;
        }

        private void DrawHexCell(HexCoord hexCoord)
        {
            Point center = GetPixelPosition(hexCoord, _hexSize);
            Point[] points = GetHexVertices(center, _hexSize);

            Polygon hexagon = new Polygon()
            {
                Points = new PointCollection(points),
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Fill = GetTerrainBrush(hexCoord),
                Tag = hexCoord
            };
            hexagon.MouseLeftButtonDown += (s, e) => OnHexClicked(hexCoord);
            parrent.Children.Add(hexagon);
            Unit currentUnit = CurrentLevel.GetUnit(hexCoord);
            if (currentUnit != null)
            {
                ElementUnit unitElement = new ElementUnit(currentUnit);

                // Позиционируем юнита в центре гекса
                Canvas.SetLeft(unitElement, center.X - 20);
                Canvas.SetTop(unitElement, center.Y - 20);

                parrent.Children.Add(unitElement);
            }
        }


        public Point GetPixelPosition(HexCoord hexCoord, float hexSize)
        {
            float xOffset = hexSize * (float)Math.Sqrt(3);
            float yOffset = hexSize * 1.5f;

            float x = xOffset * hexCoord.Q;
            float y = yOffset * hexCoord.R;

            if (hexCoord.R % 2 == 1)
            {
                x += xOffset / 2;
            }

            return new Point(x, y);
        }

        private Point[] GetHexVertices(Point center, float size)
        {
            Point[] vertices = new Point[6];
            for (int i = 0; i < 6; i++)
            {
                double angle = 60 * i * Math.PI / 180;
                double x = center.X + size * Math.Sin(angle);
                double y = center.Y - size * Math.Cos(angle);
                vertices[i] = new Point(x, y);
            }
            return vertices;
        }

        private Brush GetTerrainBrush(HexCoord hexCoord)
        {
            CellType type = CurrentLevel.Cells[hexCoord.Q, hexCoord.R];
            switch (type)
            {
                case CellType.Plain: return new SolidColorBrush(Color.FromRgb(144, 238, 144));
                case CellType.Forest: return new SolidColorBrush(Color.FromRgb(34, 139, 34));
                case CellType.Hill: return new SolidColorBrush(Color.FromRgb(160, 82, 45));
                case CellType.Mountain: return new SolidColorBrush(Color.FromRgb(128, 128, 128));
                case CellType.Water: return new SolidColorBrush(Color.FromRgb(64, 164, 223));
                case CellType.City: return new SolidColorBrush(Color.FromRgb(169, 169, 169));
                default: return new SolidColorBrush(Color.FromRgb(200, 200, 200));
            }
            ;
        }

        // ============= УПРАВЛЕНИЕ ГРАНИЦАМИ =============

        private void UpdateScrollBounds()
        {
            if (MainScrollViewer == null || parrent == null)
                return;

            // Рассчитываем максимальные смещения
            _maxHorizontalOffset = Math.Max(0, parrent.Width - MainScrollViewer.ViewportWidth);
            _maxVerticalOffset = Math.Max(0, parrent.Height - MainScrollViewer.ViewportHeight);

            _minHorizontalOffset = 0;
            _minVerticalOffset = 0;
        }

        private void ClampScrollPosition()
        {
            if (MainScrollViewer == null)
                return;

            double currentH = MainScrollViewer.HorizontalOffset;
            double currentV = MainScrollViewer.VerticalOffset;

            double clampedH = Math.Max(_minHorizontalOffset, Math.Min(_maxHorizontalOffset, currentH));
            double clampedV = Math.Max(_minVerticalOffset, Math.Min(_maxVerticalOffset, currentV));

            if (Math.Abs(clampedH - currentH) > 0.01 || Math.Abs(clampedV - currentV) > 0.01)
            {
                MainScrollViewer.ScrollToHorizontalOffset(clampedH);
                MainScrollViewer.ScrollToVerticalOffset(clampedV);
            }
        }
        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;
            _lastMousePosition = e.GetPosition(MainScrollViewer);
            _scrollViewerHorizontalOffset = MainScrollViewer.HorizontalOffset;
            _scrollViewerVerticalOffset = MainScrollViewer.VerticalOffset;

            parrent.Cursor = Cursors.ScrollAll;
            e.Handled = true;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentMousePosition = e.GetPosition(MainScrollViewer);

                double deltaX = currentMousePosition.X - _lastMousePosition.X;
                double deltaY = currentMousePosition.Y - _lastMousePosition.Y;

                double newH = _scrollViewerHorizontalOffset - deltaX;
                double newV = _scrollViewerVerticalOffset - deltaY;

                newH = Math.Max(_minHorizontalOffset, Math.Min(_maxHorizontalOffset, newH));
                newV = Math.Max(_minVerticalOffset, Math.Min(_maxVerticalOffset, newV));

                MainScrollViewer.ScrollToHorizontalOffset(newH);
                MainScrollViewer.ScrollToVerticalOffset(newV);

                e.Handled = true;
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            parrent.Cursor = Cursors.Arrow;
            e.Handled = true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateScrollBounds();

            if (_maxHorizontalOffset > 0)
                MainScrollViewer.ScrollToHorizontalOffset(_maxHorizontalOffset / 2);
            if (_maxVerticalOffset > 0)
                MainScrollViewer.ScrollToVerticalOffset(_maxVerticalOffset / 2);
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateScrollBounds();
            ClampScrollPosition();
        }

        private void MainScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (!_isDragging)
            {
                ClampScrollPosition();
            }
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            double scrollSpeed = 50;
            double newH = MainScrollViewer.HorizontalOffset;
            double newV = MainScrollViewer.VerticalOffset;

            switch (e.Key)
            {
                case Key.Left:
                    newH -= scrollSpeed;
                    break;
                case Key.Right:
                    newH += scrollSpeed;
                    break;
                case Key.Up:
                    newV -= scrollSpeed;
                    break;
                case Key.Down:
                    newV += scrollSpeed;
                    break;
                default:
                    return;
            }

            newH = Math.Max(_minHorizontalOffset, Math.Min(_maxHorizontalOffset, newH));
            newV = Math.Max(_minVerticalOffset, Math.Min(_maxVerticalOffset, newV));

            MainScrollViewer.ScrollToHorizontalOffset(newH);
            MainScrollViewer.ScrollToVerticalOffset(newV);

            e.Handled = true;
        }

        public event Action<HexCoord> HexClicked;

        private void OnHexClicked(HexCoord hexCoord)
        {
            HexClicked?.Invoke(hexCoord);
        }
    }
}
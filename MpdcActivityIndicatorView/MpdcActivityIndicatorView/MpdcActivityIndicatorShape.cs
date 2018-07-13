using System;
using CoreAnimation;
using CoreGraphics;
using UIKit;

namespace MpdcActivityIndicatorView.MpdcActivityIndicatorView
{

    public enum MpdcActivityIndicatorShape
    {
        Circle,
        CircleSemi,
        Ring,
        RingTwoHalfVertical,
        RingTwoHalfHorizontal,
        RingThirdFour,
        Rectangle,
        Triangle,
        Line,
        Pacman,
        Stroke
    }

    public class MpdcActivityIndicatorShapeLayer
    {
        MpdcActivityIndicatorShape _indicatorShape;

        private static MpdcActivityIndicatorShapeLayer _instance;
        private static Object SyncRoot = new object();

        public static MpdcActivityIndicatorShapeLayer Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new MpdcActivityIndicatorShapeLayer();
                    }
                }

                return Instance;
            }
        }

        private MpdcActivityIndicatorShapeLayer()
        {

        }

        public void FactoryIndicatorShapeInitializer(MpdcActivityIndicatorShape shape)
        {
            _indicatorShape = shape;
        }

        public CALayer LayerWith(CGSize size, UIColor color)
        {
            CAShapeLayer layer = new CAShapeLayer();
            UIBezierPath path = new UIBezierPath();
            float lineWidth = 2;

            switch (_indicatorShape)
            {
                case MpdcActivityIndicatorShape.Circle:
                    path.AddArc(new CGPoint(size.Width / 2, size.Height / 2)
                                , size.Width / 2
                                , 0
                                , (float)(2 * Math.PI)
                                , false);
                    layer.FillColor = color.CGColor;
                    break;
                case MpdcActivityIndicatorShape.CircleSemi:
                    path.AddArc(new CGPoint(size.Width / 2, size.Height / 2)
                             , size.Width / 2
                                , (float)(-Math.PI / 6)
                             , (float)(-5 * Math.PI / 6)
                             , false);

                    path.ClosePath();
                    layer.FillColor = color.CGColor;
                    break;
                case MpdcActivityIndicatorShape.Ring:
                    path.AddArc(new CGPoint(size.Width / 2, size.Height / 2)
                             , size.Width / 2
                             , 0
                             , (float)(2 * Math.PI)
                             , false);

                    layer.FillColor = null;
                    layer.StrokeColor = color.CGColor;
                    layer.LineWidth = lineWidth;
                    break;
                case MpdcActivityIndicatorShape.RingTwoHalfVertical:
                    path.AddArc(new CGPoint(size.Width / 2, size.Height / 2)
                             , size.Width / 2
                                , (float)(-3 * Math.PI / 4)
                             , (float)(-Math.PI / 4)
                                , true);

                    path.MoveTo(
                        new CGPoint(size.Width / 2 - size.Width / 2 * Math.Cos((float)(Math.PI / 4)),
                                    size.Height / 2 + size.Height / 2 * Math.Sin((float)(Math.PI / 4)))
                    );

                    path.AddArc(new CGPoint(size.Width / 2, size.Height / 2),
                                size.Width / 2,
                                (float)(-5 * Math.PI / 4),
                                (float)(-7 * Math.PI / 4),
                                false);

                    layer.FillColor = null;
                    layer.StrokeColor = color.CGColor;
                    layer.LineWidth = lineWidth;
                    break;
                case MpdcActivityIndicatorShape.RingTwoHalfHorizontal:
                    path.AddArc(new CGPoint(size.Width / 2, size.Height / 2)
                            , size.Width / 2
                               , (float)(3 * Math.PI / 4)
                            , (float)(5 * Math.PI / 4)
                               , true);

                    path.MoveTo(
                        new CGPoint(size.Width / 2 + size.Width / 2 * Math.Cos((float)(Math.PI / 4)),
                                    size.Height / 2 - size.Height / 2 * Math.Sin((float)(Math.PI / 4)))
                    );

                    path.AddArc(new CGPoint(size.Width / 2, size.Height / 2),
                                size.Width / 2,
                                (float)(-Math.PI / 4),
                                (float)(Math.PI / 4),
                                true);

                    layer.FillColor = null;
                    layer.StrokeColor = color.CGColor;
                    layer.LineWidth = lineWidth;
                    break;
                case MpdcActivityIndicatorShape.RingThirdFour:
                    path.AddArc(new CGPoint(size.Width / 2, size.Height / 2),
                             size.Width / 2,
                             (float)(-3 * Math.PI / 4),
                             (float)(-Math.PI / 4),
                                false);

                    layer.FillColor = null;
                    layer.StrokeColor = color.CGColor;
                    layer.LineWidth = 2;
                    break;
                case MpdcActivityIndicatorShape.Rectangle:
                    path.MoveTo(new CGPoint(0, 0));
                    path.AddLineTo(new CGPoint(size.Width, 0));
                    path.AddLineTo(new CGPoint(size.Width, size.Height));
                    path.AddLineTo(new CGPoint(0, size.Height));
                    layer.FillColor = color.CGColor;
                    break;
                case MpdcActivityIndicatorShape.Triangle:
                    var offSet = size.Height / 4;

                    path.MoveTo(new CGPoint(0, size.Height - offSet));
                    path.AddLineTo(new CGPoint(size.Width / 2, size.Height / 2 - offSet));
                    path.AddLineTo(new CGPoint(size.Width, size.Height));
                    path.AddLineTo(new CGPoint(size.Width, size.Height - offSet));
                    path.ClosePath();

                    layer.FillColor = color.CGColor;
                    break;
                case MpdcActivityIndicatorShape.Line:
                    path = UIBezierPath.FromRoundedRect(new CGRect(0, 0, size.Width / 2, size.Height / 2), size.Width / 2);
                    layer.FillColor = color.CGColor;
                    break;
                case MpdcActivityIndicatorShape.Pacman:
                    path.AddArc(new CGPoint(size.Width / 2, size.Height / 2),
                             size.Width / 4,
                             0,
                                (float)(2 * Math.PI),
                                true);

                    layer.FillColor = null;
                    layer.StrokeColor = color.CGColor;
                    layer.LineWidth = 2;
                    break;
                case MpdcActivityIndicatorShape.Stroke:
                    path.AddArc(new CGPoint(size.Width / 2, size.Height / 2),
                             size.Width / 2,
                                (float)-(Math.PI / 2),
                                (float)(Math.PI + Math.PI /2),
                                true);

                    layer.FillColor = null;
                    layer.StrokeColor = color.CGColor;
                    layer.LineWidth = 2;
                    break;
            }

            layer.BackgroundColor = null;
            layer.Path = path.CGPath;
            layer.Frame = new CGRect(0, 0, size.Width, size.Height);

            return layer;
        }
    }
}

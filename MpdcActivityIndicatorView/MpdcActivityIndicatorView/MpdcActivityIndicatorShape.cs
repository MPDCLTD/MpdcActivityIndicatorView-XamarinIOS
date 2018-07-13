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

            switch(_indicatorShape)
            {
                case MpdcActivityIndicatorShape.Circle:
                    break;
                case MpdcActivityIndicatorShape.CircleSemi:
                    break;
                case MpdcActivityIndicatorShape.Ring:
                    break;
                case MpdcActivityIndicatorShape.RingTwoHalfVertical:
                    break;
                case MpdcActivityIndicatorShape.RingTwoHalfHorizontal:
                    break;
                case MpdcActivityIndicatorShape.RingThirdFour:
                    break;
                case MpdcActivityIndicatorShape.Rectangle:
                    break;
                case MpdcActivityIndicatorShape.Triangle:
                    break;
                case MpdcActivityIndicatorShape.Line:
                    break;
                case MpdcActivityIndicatorShape.Pacman:
                    break;
                case MpdcActivityIndicatorShape.Stroke:
                    break;
            }

            layer.BackgroundColor = null;
            layer.Path = path.CGPath;
            layer.Frame = new CGRect(0, 0, size.Width, size.Height);

            return layer;
        }
    }
}

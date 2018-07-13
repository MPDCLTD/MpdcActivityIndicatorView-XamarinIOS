using System;
using CoreAnimation;
using CoreGraphics;
using UIKit;

namespace MpdcActivityIndicatorView.MpdcActivityIndicatorView
{
    public interface IMpdcActivityIndicatorAnimationDelegate
    {
        void SetupAnimation(CALayer layer, CGSize size, UIColor color);
    }
}

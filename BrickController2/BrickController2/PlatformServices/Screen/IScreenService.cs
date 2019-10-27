using System;

namespace BrickController2.PlatformServices.Screen
{
    public interface IScreenService
    {
        float Brightness { get; set; }

        event EventHandler<ScreenTouchEventArgs> OnTouch;
    }
}

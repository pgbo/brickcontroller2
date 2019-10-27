using System;
using UIKit;
using BrickController2.PlatformServices.Screen;

namespace BrickController2.iOS.PlatformServices.Screen
{
    internal class ScreenService : IScreenService
    {
        public float Brightness
        {
            get => (float)UIScreen.MainScreen.Brightness;
            set => UIScreen.MainScreen.Brightness = AdjustBrightnessValue(value);
        }

        public event EventHandler<ScreenTouchEventArgs> OnTouch;

        public void OnTouchEvent()
        {
            OnTouch?.Invoke(this, new ScreenTouchEventArgs());
        }

        private float AdjustBrightnessValue(float value)
        {
            return Math.Min(Math.Max(value, 0), 1);
        }
    }
}
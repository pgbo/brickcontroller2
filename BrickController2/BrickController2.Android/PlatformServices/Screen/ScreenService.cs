using Android.Content;
using Android.Provider;
using Android.Views;
using BrickController2.PlatformServices.Screen;
using System;

namespace BrickController2.Droid.PlatformServices.Screen
{
    internal class ScreenService : IScreenService
    {
        private readonly Context _context;

        public ScreenService(Context context)
        {
            _context = context;
        }

        public float Brightness
        {
            get => IntBrightnessToFloat(Settings.System.GetInt(ContentResolver, Settings.System.ScreenBrightness));
            set => Settings.System.PutInt(ContentResolver, Settings.System.ScreenBrightness, FloatBrightnessToInt(value));
        }

        public event EventHandler<ScreenTouchEventArgs> OnTouch;

        public void OnTouchEvent(MotionEvent e)
        {
            OnTouch?.Invoke(this, new ScreenTouchEventArgs());
        }

        private ContentResolver ContentResolver => _context.ApplicationContext.ContentResolver;

        private int FloatBrightnessToInt(float value)
        {
            return (int)(Math.Min(Math.Max(value, 0), 1) * 255);
        }

        private float IntBrightnessToFloat(int value)
        {
            return value / 255F;
        }
    }
}
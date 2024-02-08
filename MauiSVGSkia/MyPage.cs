namespace MauiSVGSkia;

using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using System.Reflection.PortableExecutable;

public class MyPage : ContentPage
{
    public MyPage()
    {
        try
        {
            var skiaView = new SKCanvasView();
            skiaView.PaintSurface += OnPaintCanvas;

            var label = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = "Welcome to .NET MAUI!"
            };

            Content = new VerticalStackLayout
            {
                Children = { skiaView, label }
            };
        }
        catch (Exception)
        {
            int cur = 0;
        }
    }
    private void OnPaintCanvas(object sender, SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        canvas.Clear(SKColors.White);

        using (var paint = new SKPaint())
        {
            paint.IsAntialias = true;
            paint.Color = SKColors.Green;

            var centerX = e.Info.Width / 2;
            var centerY = e.Info.Height / 2;
            var radius = Math.Min(centerX, centerY) * 0.8f;

            canvas.DrawCircle(centerX, centerY, radius, paint);
        }
    }
}
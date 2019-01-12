using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Njit.Common.Helpers
{
    public static class GraphicsHelper
    {
        public static int DrawStringPair(Graphics g, Rectangle r, string caption, string text, System.Drawing.Font font, Brush captionBrush, Brush textBrush)
        {
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                sf.Trimming = StringTrimming.EllipsisCharacter;
                sf.FormatFlags = StringFormatFlags.NoWrap;

                SizeF szc = g.MeasureString(caption, font, r.Size, sf);
                int y = (int)szc.Height;
                if (szc.Width > r.Width) szc.Width = r.Width;
                Rectangle txrect = new Rectangle(r.Location, Size.Ceiling(szc));
                g.DrawString(caption, font, captionBrush, txrect, sf);
                txrect.X += txrect.Width;
                txrect.Width = r.Width;
                if (txrect.X < r.Right)
                {
                    SizeF szt = g.MeasureString(text, font, r.Size, sf);
                    y = Math.Max(y, (int)szt.Height);
                    txrect = Rectangle.Intersect(r, txrect);
                    g.DrawString(text, font, textBrush, txrect, sf);
                }
                return y;
            }
        }

        /// <summary>
        /// تبدیل یک متن به عکس
        /// </summary>
        /// <param name="message">متن مورد نظر</param>
        /// <param name="width">پهنا</param>
        /// <param name="height">ارتفاع</param>
        /// <returns>تصویر برگردانده می شود</returns>
        public static Image GetErrorImage(string message, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf.Trimming = StringTrimming.EllipsisWord;
            g.Clear(Color.White);
            System.Drawing.Font f = new System.Drawing.Font("Tahoma", 9);
            g.DrawString(message, f, Brushes.Red, new Rectangle(0, 0, bitmap.Width, bitmap.Height), sf);
            f.Dispose();
            sf.Dispose();
            g.Dispose();
            return bitmap;
        }

        public static GraphicsPath GenerateRoundedRectangle(this Graphics graphics, RectangleF rectangle, float radius, RectangleEdgeFilter filter)
        {
            return GenerateRoundedRectangle(rectangle, radius, filter);
        }

        public static GraphicsPath GenerateRoundedRectangle(RectangleF rectangle, float radius)
        {
            return GenerateRoundedRectangle(rectangle, radius, RectangleEdgeFilter.All);
        }

        public static GraphicsPath GetRoundedRectanglePath(Rectangle rectangle, int radius)
        {
            return GetRoundedRectanglePath(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, radius);
        }

        public static GraphicsPath GetRoundedRectanglePath(int x, int y, int width, int height, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(x + radius, y, x + width - radius, y);
            if (radius > 0)
                path.AddArc(x + width - 2 * radius, y, 2 * radius, 2 * radius, 270.0f, 90.0f);
            path.AddLine(x + width, y + radius, x + width, y + height - radius);
            if (radius > 0)
                path.AddArc(x + width - 2 * radius, y + height - 2 * radius, 2 * radius, 2 * radius, 0.0f, 90.0f);
            path.AddLine(x + width - radius, y + height, x + radius, y + height);
            if (radius > 0)
                path.AddArc(x, y + height - 2 * radius, 2 * radius, 2 * radius, 90.0f, 90.0f);
            path.AddLine(x, y + height - radius, x, y + radius);
            if (radius > 0)
                path.AddArc(x, y, 2 * radius, 2 * radius, 180.0f, 90.0f);
            return path;
        }

        public static GraphicsPath GenerateRoundedRectangle(RectangleF rectangle, float radius, RectangleEdgeFilter filter)
        {
            float diameter;
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0.0F || filter == RectangleEdgeFilter.None)
            {
                path.AddRectangle(rectangle);
                path.CloseFigure();
                return path;
            }
            else
            {
                if (radius >= (Math.Min(rectangle.Width, rectangle.Height)) / 2.0)
                    return GenerateCapsule(rectangle);
                diameter = radius * 2.0F;
                SizeF sizeF = new SizeF(diameter, diameter);
                RectangleF arc = new RectangleF(rectangle.Location, sizeF);
                if ((RectangleEdgeFilter.TopLeft & filter) == RectangleEdgeFilter.TopLeft)
                    path.AddArc(arc, 180, 90);
                else
                {
                    path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
                    path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
                }
                arc.X = rectangle.Right - diameter;
                if ((RectangleEdgeFilter.TopRight & filter) == RectangleEdgeFilter.TopRight)
                    path.AddArc(arc, 270, 90);
                else
                {
                    path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
                    path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X + arc.Width, arc.Y);
                }
                arc.Y = rectangle.Bottom - diameter;
                if ((RectangleEdgeFilter.BottomRight & filter) == RectangleEdgeFilter.BottomRight)
                    path.AddArc(arc, 0, 90);
                else
                {
                    path.AddLine(arc.X + arc.Width, arc.Y, arc.X + arc.Width, arc.Y + arc.Height);
                    path.AddLine(arc.X, arc.Y + arc.Height, arc.X + arc.Width, arc.Y + arc.Height);
                }
                arc.X = rectangle.Left;
                if ((RectangleEdgeFilter.BottomLeft & filter) == RectangleEdgeFilter.BottomLeft)
                    path.AddArc(arc, 90, 90);
                else
                {
                    path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X, arc.Y + arc.Height);
                    path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
                }
                path.CloseFigure();
            }
            return path;
        }

        public static GraphicsPath GenerateCapsule(this Graphics graphics, RectangleF rectangle)
        {
            return GenerateCapsule(rectangle);
        }

        public static GraphicsPath GenerateCapsule(RectangleF rectangle)
        {
            float diameter;
            RectangleF arc;
            GraphicsPath path = new GraphicsPath();
            try
            {
                if (rectangle.Width > rectangle.Height)
                {
                    diameter = rectangle.Height;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(rectangle.Location, sizeF);
                    path.AddArc(arc, 90, 180);
                    arc.X = rectangle.Right - diameter;
                    path.AddArc(arc, 270, 180);
                }
                else if (rectangle.Width < rectangle.Height)
                {
                    diameter = rectangle.Width;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(rectangle.Location, sizeF);
                    path.AddArc(arc, 180, 180);
                    arc.Y = rectangle.Bottom - diameter;
                    path.AddArc(arc, 0, 180);
                }
                else path.AddEllipse(rectangle);
            }
            catch { path.AddEllipse(rectangle); }
            finally { path.CloseFigure(); }
            return path;
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, float x, float y, float width, float height, float radius, RectangleEdgeFilter filter)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius, filter);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawPath(pen, path);
            graphics.SmoothingMode = old;
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, float x, float y, float width, float height, float radius)
        {
            graphics.DrawRoundedRectangle(pen, x, y, width, height, radius, RectangleEdgeFilter.All);
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, int x, int y, int width, int height, int radius)
        {
            graphics.DrawRoundedRectangle(
                    pen,
                    Convert.ToSingle(x),
                    Convert.ToSingle(y),
                    Convert.ToSingle(width),
                    Convert.ToSingle(height),
                    Convert.ToSingle(radius));
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle rectangle, int radius, RectangleEdgeFilter filter)
        {
            graphics.DrawRoundedRectangle(
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle rectangle, int radius)
        {
            graphics.DrawRoundedRectangle(
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleEdgeFilter.All);
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, RectangleF rectangle, int radius, RectangleEdgeFilter filter)
        {
            graphics.DrawRoundedRectangle(
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, RectangleF rectangle, int radius)
        {
            graphics.DrawRoundedRectangle(
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleEdgeFilter.All);
        }

        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, float x, float y, float width, float height, float radius, RectangleEdgeFilter filter)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius, filter);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillPath(brush, path);
            graphics.SmoothingMode = old;
        }

        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, float x, float y, float width, float height, float radius)
        {
            graphics.FillRoundedRectangle(
                    brush,
                    x,
                    y,
                    width,
                    height,
                    radius,
                    RectangleEdgeFilter.All);
        }

        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, int x, int y, int width, int height, int radius)
        {
            graphics.FillRoundedRectangle(
                    brush,
                    Convert.ToSingle(x),
                    Convert.ToSingle(y),
                    Convert.ToSingle(width),
                    Convert.ToSingle(height),
                    Convert.ToSingle(radius));
        }

        public static void FillRoundedRectangle(
            this Graphics graphics,
            Brush brush,
            Rectangle rectangle,
            int radius,
            RectangleEdgeFilter filter)
        {
            graphics.FillRoundedRectangle(
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }

        public static void FillRoundedRectangle(
            this Graphics graphics,
            Brush brush,
            Rectangle rectangle,
            int radius)
        {
            graphics.FillRoundedRectangle(
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleEdgeFilter.All);
        }

        public static void FillRoundedRectangle(
            this Graphics graphics,
            Brush brush,
            RectangleF rectangle,
            int radius,
            RectangleEdgeFilter filter)
        {
            graphics.FillRoundedRectangle(
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }

        public static void FillRoundedRectangle(
            this Graphics graphics,
            Brush brush,
            RectangleF rectangle,
            int radius)
        {
            graphics.FillRoundedRectangle(
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleEdgeFilter.All);
        }

        public static FontMetrics GetFontMetrics(this Graphics graphics, System.Drawing.Font font)
        {
            return FontMetricsImpl.GetFontMetrics(graphics, font);
        }

        private class FontMetricsImpl : FontMetrics
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct TEXTMETRIC
            {
                public int tmHeight;
                public int tmAscent;
                public int tmDescent;
                public int tmInternalLeading;
                public int tmExternalLeading;
                public int tmAveCharWidth;
                public int tmMaxCharWidth;
                public int tmWeight;
                public int tmOverhang;
                public int tmDigitizedAspectX;
                public int tmDigitizedAspectY;
                public char tmFirstChar;
                public char tmLastChar;
                public char tmDefaultChar;
                public char tmBreakChar;
                public byte tmItalic;
                public byte tmUnderlined;
                public byte tmStruckOut;
                public byte tmPitchAndFamily;
                public byte tmCharSet;
            }
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            public static extern bool GetTextMetrics(IntPtr hdc, out TEXTMETRIC lptm);
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            public static extern bool DeleteObject(IntPtr hdc);
            private TEXTMETRIC GenerateTextMetrics(
                Graphics graphics,
                System.Drawing.Font font)
            {
                IntPtr hDC = IntPtr.Zero;
                TEXTMETRIC textMetric;
                IntPtr hFont = IntPtr.Zero;
                try
                {
                    hDC = graphics.GetHdc();
                    hFont = font.ToHfont();
                    IntPtr hFontDefault = SelectObject(hDC, hFont);
                    bool result = GetTextMetrics(hDC, out textMetric);
                    SelectObject(hDC, hFontDefault);
                }
                finally
                {
                    if (hFont != IntPtr.Zero) DeleteObject(hFont);
                    if (hDC != IntPtr.Zero) graphics.ReleaseHdc(hDC);
                }
                return textMetric;
            }
            private TEXTMETRIC metrics;
            public override int Height { get { return this.metrics.tmHeight; } }
            public override int Ascent { get { return this.metrics.tmAscent; } }
            public override int Descent { get { return this.metrics.tmDescent; } }
            public override int InternalLeading { get { return this.metrics.tmInternalLeading; } }
            public override int ExternalLeading { get { return this.metrics.tmExternalLeading; } }
            public override int AverageCharacterWidth { get { return this.metrics.tmAveCharWidth; } }
            public override int MaximumCharacterWidth { get { return this.metrics.tmMaxCharWidth; } }
            public override int Weight { get { return this.metrics.tmWeight; } }
            public override int Overhang { get { return this.metrics.tmOverhang; } }
            public override int DigitizedAspectX { get { return this.metrics.tmDigitizedAspectX; } }
            public override int DigitizedAspectY { get { return this.metrics.tmDigitizedAspectY; } }
            private FontMetricsImpl(Graphics graphics, System.Drawing.Font font)
            {
                this.metrics = this.GenerateTextMetrics(graphics, font);
            }
            public static FontMetrics GetFontMetrics(
                Graphics graphics,
                System.Drawing.Font font)
            {
                return new FontMetricsImpl(graphics, font);
            }
        }

        public enum RectangleEdgeFilter
        {
            None = 0,
            TopLeft = 1,
            TopRight = 2,
            BottomLeft = 4,
            BottomRight = 8,
            All = TopLeft | TopRight | BottomLeft | BottomRight
        }

        public abstract class FontMetrics
        {
            public virtual int Height { get { return 0; } }
            public virtual int Ascent { get { return 0; } }
            public virtual int Descent { get { return 0; } }
            public virtual int InternalLeading { get { return 0; } }
            public virtual int ExternalLeading { get { return 0; } }
            public virtual int AverageCharacterWidth { get { return 0; } }
            public virtual int MaximumCharacterWidth { get { return 0; } }
            public virtual int Weight { get { return 0; } }
            public virtual int Overhang { get { return 0; } }
            public virtual int DigitizedAspectX { get { return 0; } }
            public virtual int DigitizedAspectY { get { return 0; } }
        }
    }
}

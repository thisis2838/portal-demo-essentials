using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static portal_demo_essentials.VTFLib;

namespace portal_demo_essentials.Source
{
    public class Texture
    {
        private static bool _init = false;
        private static void Init()
        {
            if (_init) return;

            _init = vlInitialize() == 1;
        }

        public int Width;
        public int Height;

        private List<Byte> _origData = new List<byte>();
        private List<Byte> _activeData = new List<byte>();

        private uint _handle;
        private SVTFCreateOptions _options;

        public Texture(string imagePath)
        {
            Init();

            if (vlCreateImage(ref _handle) != 1)
                throw new Exception("Can't create handle!");

            if (vlBindImage(_handle) != 1)
                throw new Exception("Can't bind image to handle!");

            Bitmap e = new Bitmap(imagePath);

            TextureUtils.ToRGBA8888(e).ToList().ForEach(x => _origData.Add(x));
            _origData.ForEach(x => _activeData.Add(x));

            Width = e.Width;
            Height = e.Height;

            unsafe
            {
                _options = new SVTFCreateOptions()
                {
                    ImageFormat = VTFImageFormat.IMAGE_FORMAT_RGBA8888,
                    uiFlags = 0x00002000 | 0x01000000,
                    ResizeMethod = VTFResizeMethod.RESIZE_NEAREST_POWER2,
                    uiResizeHeight = 2,
                    uiResizeWidth = 2,
                    bResize = 1
                };
                _options.uiVersion[0] = 7;
                _options.uiVersion[1] = 1;
            }
        }

        public void DrawText(string text, Font f, Color clr, float angle, int x, int y)
        {
            const int margin = 5;

            var size = TextRenderer.MeasureText(text, f);
            var actualSize = Utils.RotatedSize(size, angle);

            Bitmap b = new Bitmap(actualSize.Width, actualSize.Height);
            b.MakeTransparent();

            Graphics g = Graphics.FromImage(b);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;


            var rect = Utils.RotatedOriginAnchoredRect(size, angle);
            var points = new List<Point>() { rect.A, rect.B, rect.C, rect.D };

            g.TranslateTransform(-Math.Min(points.Min(X => X.X), 0), points.Max(X => X.Y));
            g.RotateTransform(-angle);


            g.DrawString(text, f, new SolidBrush(clr), 0,0);
            g.Flush();

            //b = Utils.RotateImage(b, (float)rotate);

            Insert(b, x, y);
        }

        public void Insert(Bitmap b, int x, int y)
        {
            if (x + b.Width > Width || y + b.Height > Height)
                throw new Exception("Bitmap too large!");

            _activeData = new List<byte>();
            _origData.ForEach(e => _activeData.Add(e));

            var newb = b.ToRGBA8888();
            for (int iy = 0; iy < b.Height; iy++)
                for (int ix = 0; ix < b.Width; ix++)
                {
                    var absCoord = ((x + ix) + (y + iy) * Width) * 4;
                    var absCoordB = (ix + iy * b.Width) * 4;

                    if (newb[absCoordB + 3] == 0)
                        continue;   
                    
                    _activeData[absCoord] = newb[absCoordB];
                    _activeData[absCoord + 1] = newb[absCoordB + 1];
                    _activeData[absCoord + 2] = newb[absCoordB + 2];
                    _activeData[absCoord + 3] = newb[absCoordB + 3];
                }
        }

        public bool SaveToFile(string vtfPath)
        {
            return
                vlImageCreateSingle((uint)Width, (uint)Height, _activeData.ToArray(), ref _options) == 1 &&
                vlImageIsLoaded() == 1 &&
                vlImageSave(vtfPath) == 1;
        }
    }
    public static class TextureUtils
    {
        public static byte[] ToRGBA8888(this Bitmap map)
        {
            List<byte> px = new List<byte>();
            for (int y = 0; y < map.Height; y++)
                for (int x = 0; x < map.Width; x++)
                {
                    Color c = map.GetPixel(x, y);
                    px.Add(c.R);
                    px.Add(c.G);
                    px.Add(c.B);
                    px.Add(c.A);
                }
            return px.ToArray();
        }
    }
}

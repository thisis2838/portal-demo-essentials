using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace portal_demo_essentials.Source
{
    public static class VTFLib
    {
        #region FUNCTIONS
        [DllImport(@"VTFLib.dll")]
        public static extern Byte vlInitialize();

        [DllImport(@"VTFLib.dll")]
        public static extern byte vlImageIsBound();

        [DllImport(@"VTFLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte vlCreateImage(ref uint uiImage);
        [DllImport(@"VTFLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte vlBindImage(uint uiImage);

        [DllImport(@"VTFLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern Byte vlImageSave(
            [MarshalAs(UnmanagedType.LPStr)] string cFileName);

        [DllImport(@"VTFLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte vlImageCreateSingle(
            uint uiWidth,
            uint uiHeight,
            [MarshalAs(UnmanagedType.LPArray)] byte[] lpImageDataRGBA8888,
            ref SVTFCreateOptions VTFCreateOptions);

        [DllImport(@"VTFLib.dll")]
        public static extern byte vlImageIsLoaded();
        #endregion

        #region MODELS
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SVTFCreateOptions
        {
            public fixed uint uiVersion[2];
            public VTFImageFormat ImageFormat;

            public uint uiFlags;
            public uint uiStartFrame;
            public float sBumpScale;
            public fixed float sReflectivity[3];

            public byte bMipmaps;
            public VTFMipmapFilter MipmapFilter;
            public VTFSharpenFilter MipmapSharpenFilter;

            public byte bThumbnail;
            public byte bReflectivity;

            public byte bResize;
            public VTFResizeMethod ResizeMethod;
            public VTFMipmapFilter ResizeFilter;
            public VTFSharpenFilter ResizeSharpenFilter;
            public uint uiResizeWidth;
            public uint uiResizeHeight;

            public byte bResizeClamp;
            public uint uiResizeClampWidth;
            public uint uiResizeClampHeight;

            public byte bGammaCorrection;
            public float sGammaCorrection;

            public byte bNormalMap;
            public VTFKernelFilter KernelFilter;
            public VTFHeightConversionMethod HeightConversionMethod;
            public VTFNormalAlphaResult NormalAlphaResult;
            public byte bNormalMinimumZ;
            public float sNormalScale;
            public byte bNormalWrap;
            public byte bNormalInvertX;
            public byte bNormalInvertY;
            public byte bNormalInvertZ;

            public byte bSphereMap;
        }

        public enum VTFImageFormat
        {
            IMAGE_FORMAT_RGBA8888 = 0,
            IMAGE_FORMAT_ABGR8888,
            IMAGE_FORMAT_RGB888,
            IMAGE_FORMAT_BGR888,
            IMAGE_FORMAT_RGB565,
            IMAGE_FORMAT_I8,
            IMAGE_FORMAT_IA88,
            IMAGE_FORMAT_P8,
            IMAGE_FORMAT_A8,
            IMAGE_FORMAT_RGB888_BLUESCREEN,
            IMAGE_FORMAT_BGR888_BLUESCREEN,
            IMAGE_FORMAT_ARGB8888,
            IMAGE_FORMAT_BGRA8888,
            IMAGE_FORMAT_DXT1,
            IMAGE_FORMAT_DXT3,
            IMAGE_FORMAT_DXT5,
            IMAGE_FORMAT_BGRX8888,
            IMAGE_FORMAT_BGR565,
            IMAGE_FORMAT_BGRX5551,
            IMAGE_FORMAT_BGRA4444,
            IMAGE_FORMAT_DXT1_ONEBITALPHA,
            IMAGE_FORMAT_BGRA5551,
            IMAGE_FORMAT_UV88,
            IMAGE_FORMAT_UVWQ8888,
            IMAGE_FORMAT_RGBA16161616F,
            IMAGE_FORMAT_RGBA16161616,
            IMAGE_FORMAT_UVLX8888,
            IMAGE_FORMAT_R32F,
            IMAGE_FORMAT_RGB323232F,
            IMAGE_FORMAT_RGBA32323232F,
            IMAGE_FORMAT_NV_DST16,
            IMAGE_FORMAT_NV_DST24,
            IMAGE_FORMAT_NV_INTZ,
            IMAGE_FORMAT_NV_RAWZ,
            IMAGE_FORMAT_ATI_DST16,
            IMAGE_FORMAT_ATI_DST24,
            IMAGE_FORMAT_NV_NULL,
            IMAGE_FORMAT_ATI2N,
            IMAGE_FORMAT_ATI1N,
            IMAGE_FORMAT_COUNT,
            IMAGE_FORMAT_NONE = -1
        }

        public enum VTFMipmapFilter
        {
            MIPMAP_FILTER_POINT = 0,
            MIPMAP_FILTER_BOX,
            MIPMAP_FILTER_TRIANGLE,
            MIPMAP_FILTER_QUADRATIC,
            MIPMAP_FILTER_CUBIC,
            MIPMAP_FILTER_CATROM,
            MIPMAP_FILTER_MITCHELL,
            MIPMAP_FILTER_GAUSSIAN,
            MIPMAP_FILTER_SINC,
            MIPMAP_FILTER_BESSEL,
            MIPMAP_FILTER_HANNING,
            MIPMAP_FILTER_HAMMING,
            MIPMAP_FILTER_BLACKMAN,
            MIPMAP_FILTER_KAISER,
            MIPMAP_FILTER_COUNT
        }

        public enum VTFSharpenFilter
        {
            SHARPEN_FILTER_NONE = 0,
            SHARPEN_FILTER_NEGATIVE,
            SHARPEN_FILTER_LIGHTER,
            SHARPEN_FILTER_DARKER,
            SHARPEN_FILTER_CONTRASTMORE,
            SHARPEN_FILTER_CONTRASTLESS,
            SHARPEN_FILTER_SMOOTHEN,
            SHARPEN_FILTER_SHARPENSOFT,
            SHARPEN_FILTER_SHARPENMEDIUM,
            SHARPEN_FILTER_SHARPENSTRONG,
            SHARPEN_FILTER_FINDEDGES,
            SHARPEN_FILTER_CONTOUR,
            SHARPEN_FILTER_EDGEDETECT,
            SHARPEN_FILTER_EDGEDETECTSOFT,
            SHARPEN_FILTER_EMBOSS,
            SHARPEN_FILTER_MEANREMOVAL,
            SHARPEN_FILTER_UNSHARP,
            SHARPEN_FILTER_XSHARPEN,
            SHARPEN_FILTER_WARPSHARP,
            SHARPEN_FILTER_COUNT
        }

        public enum VTFResizeMethod
        {
            RESIZE_NEAREST_POWER2 = 0,
            RESIZE_BIGGEST_POWER2,
            RESIZE_SMALLEST_POWER2,
            RESIZE_SET,
            RESIZE_COUNT
        }

        public enum VTFKernelFilter
        {
            KERNEL_FILTER_4X = 0,
            KERNEL_FILTER_3X3,
            KERNEL_FILTER_5X5,
            KERNEL_FILTER_7X7,
            KERNEL_FILTER_9X9,
            KERNEL_FILTER_DUDV,
            KERNEL_FILTER_COUNT
        }

        public enum VTFHeightConversionMethod
        {
            HEIGHT_CONVERSION_METHOD_ALPHA = 0,
            HEIGHT_CONVERSION_METHOD_AVERAGE_RGB,
            HEIGHT_CONVERSION_METHOD_BIASED_RGB,
            HEIGHT_CONVERSION_METHOD_RED,
            HEIGHT_CONVERSION_METHOD_GREEN,
            HEIGHT_CONVERSION_METHOD_BLUE,
            HEIGHT_CONVERSION_METHOD_MAX_RGB,
            HEIGHT_CONVERSION_METHOD_COLORSPACE,
            //HEIGHT_CONVERSION_METHOD_NORMALIZE,
            HEIGHT_CONVERSION_METHOD_COUNT
        }

        public enum VTFNormalAlphaResult
        {
            NORMAL_ALPHA_RESULT_NOCHANGE = 0,
            NORMAL_ALPHA_RESULT_HEIGHT,
            NORMAL_ALPHA_RESULT_BLACK,
            NORMAL_ALPHA_RESULT_WHITE,
            NORMAL_ALPHA_RESULT_COUNT
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RemoteScreen
{
    /// Note:
    /// This is the class that allow us to invoke Native API to capture Desktop Image

    /// <summary>
    /// This class shall keep the GDI32 APIs used in our program.
    /// </summary>
    public class PlatformInvokeGDI32
    {
        // SRCCOPY : Native Type = ENUM, thus set to original value, refer MSDN for more info
        #region Class Variables
        public const int SRCCOPY = 13369376;
        #endregion

        #region Class Functions<br>
        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        public static extern IntPtr DeleteDC(IntPtr hDc);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern IntPtr DeleteObject(IntPtr hDc);

        [DllImport("gdi32.dll", EntryPoint = "BitBlt")]
        public static extern bool BitBlt(IntPtr hdcDest, int xDest,
            int yDest, int wDest, int hDest, IntPtr hdcSource,
            int xSrc, int ySrc, int RasterOp);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc,
            int nWidth, int nHeight);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
        #endregion
    }

    /// <summary>
    /// This class shall keep the User32 APIs used in our program.
    /// </summary>
    public class PlatformInvokeUSER32
    {
        #region Class Structs
        public struct POINT
        {
            public int X, Y;
        };

        public struct CURSORINFO
        {
            public int cbSize;
            public int flags;
            public IntPtr hCursor;
            public POINT ptScreenPos;
        };

        public struct ICONINFO
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        };
        #endregion

        #region Class Variables
        public const int SM_CXSCREEN = 0;
        public const int SM_CYSCREEN = 1;
        #endregion

        #region Class Functions

        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr ptr);

        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int abc);

        [DllImport("user32.dll", EntryPoint = "GetWindowDC")]
        public static extern IntPtr GetWindowDC(Int32 ptr);

        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);

        [DllImport("user32.dll", EntryPoint = "GetCursorInfo")]
        public static extern bool GetCursorInfo(ref CURSORINFO pci);

        [DllImport("user32.dll", EntryPoint = "CopyIcon")]
        public static extern IntPtr CopyIcon(IntPtr IconHandle);
        
        [DllImport("user32.dll", EntryPoint = "GetIconInfo")]
        public static extern bool GetIconInfo(IntPtr hIcon,out PlatformInvokeUSER32.ICONINFO IconInfo);

        #endregion
    }

    /// <summary>
    /// This class shall keep all the functionality 
    /// for capturing the desktop.
    /// </summary>
    public class CaptureScreen
    {
        #region Class Variable Declaration
        protected static IntPtr m_HBitmap;
        #endregion

        ///
        /// This class shall keep all the functionality for capturing
        /// the desktop.
        ///
        #region Public Class Functions
        public static Bitmap GetDesktopImage()
        {
            //In size variable we shall keep the size of the screen.
            SIZE size;

            //Variable to keep the handle to bitmap.
            IntPtr hBitmap;

            //Here we get the handle to the desktop device context.
            IntPtr hDC = PlatformInvokeUSER32.GetDC
                          (PlatformInvokeUSER32.GetDesktopWindow());

            //Here we make a compatible device context in memory for screen
            //device context.
            IntPtr hMemDC = PlatformInvokeGDI32.CreateCompatibleDC(hDC);

            //We pass SM_CXSCREEN constant to GetSystemMetrics to get the
            //X coordinates of the screen.
            size.cx = PlatformInvokeUSER32.GetSystemMetrics
                      (PlatformInvokeUSER32.SM_CXSCREEN);

            //We pass SM_CYSCREEN constant to GetSystemMetrics to get the
            //Y coordinates of the screen.
            size.cy = PlatformInvokeUSER32.GetSystemMetrics
                      (PlatformInvokeUSER32.SM_CYSCREEN);

            //We create a compatible bitmap of the screen size and using
            //the screen device context.
            hBitmap = PlatformInvokeGDI32.CreateCompatibleBitmap
                        (hDC, size.cx, size.cy);

            //As hBitmap is IntPtr, we cannot check it against null.
            //For this purpose, IntPtr.Zero is used.
            if (hBitmap != IntPtr.Zero)
            {
                //Here we select the compatible bitmap in the memeory device
                //context and keep the refrence to the old bitmap.
                IntPtr hOld = (IntPtr)PlatformInvokeGDI32.SelectObject
                                       (hMemDC, hBitmap);
                //We copy the Bitmap to the memory device context.
                PlatformInvokeGDI32.BitBlt(hMemDC, 0, 0, size.cx, size.cy, hDC,
                                           0, 0, PlatformInvokeGDI32.SRCCOPY);
                //We select the old bitmap back to the memory device context.
                PlatformInvokeGDI32.SelectObject(hMemDC, hOld);
                //We delete the memory device context.
                PlatformInvokeGDI32.DeleteDC(hMemDC);
                //We release the screen device context.
                PlatformInvokeUSER32.ReleaseDC(PlatformInvokeUSER32.
                                               GetDesktopWindow(), hDC);
                //Image is created by Image bitmap handle and stored in
                //local variable.
                Bitmap bmp = System.Drawing.Image.FromHbitmap(hBitmap);
                //Release the memory to avoid memory leaks.
                PlatformInvokeGDI32.DeleteObject(hBitmap);
                //This statement runs the garbage collector manually.
                GC.Collect();
                //Return the bitmap 
                return bmp;
            }
            //If hBitmap is null, retun null.
            return null;
        }

        //Captures Cursor as a bitmap and returns out position of cursor
        public static Bitmap CaptureCursor(out Point Location)
        {
            Bitmap bmp;
            IntPtr hicon;
            PlatformInvokeUSER32.CURSORINFO CurInfo= new PlatformInvokeUSER32.CURSORINFO();
            PlatformInvokeUSER32.ICONINFO IconInfo;
            CurInfo.cbSize = Marshal.SizeOf(CurInfo);
            Location = new Point();
            if (PlatformInvokeUSER32.GetCursorInfo(ref CurInfo))
            {
                if (CurInfo.flags != 0) //The cursor is shown
                {
                    hicon = PlatformInvokeUSER32.CopyIcon(CurInfo.hCursor);
                    if (PlatformInvokeUSER32.GetIconInfo(hicon,out IconInfo))
                    {
                        Location.X = CurInfo.ptScreenPos.X - ((int)IconInfo.xHotspot);
                        Location.Y = CurInfo.ptScreenPos.Y - ((int)IconInfo.yHotspot);
                        Icon ic = Icon.FromHandle(hicon);
                        bmp = ic.ToBitmap();

                        return bmp;
                    }
                }
            }
            return null;
        }

        public static Bitmap CaptureDesktopWithCursor()
        {
            Point Location;
            Bitmap desktopBMP;
            Bitmap cursorBMP;
            Graphics g;
            Rectangle r;
            desktopBMP = GetDesktopImage();
            cursorBMP = CaptureCursor(out Location);
            if (desktopBMP != null)
            {
                if (cursorBMP != null)
                {
                    r = new Rectangle(Location.X, Location.Y,cursorBMP.Width, cursorBMP.Height);
                    g = Graphics.FromImage(desktopBMP);
                    g.DrawImage(cursorBMP, r);
                    g.Flush();
                    return desktopBMP;
                }
                else
                    return desktopBMP;
            }
            return null;
        }
        #endregion
    }

    //This structure shall be used to keep the size of the screen.
    public struct SIZE
    {
        public int cx;
        public int cy;
    }

}

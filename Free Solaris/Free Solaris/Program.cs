using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.Media;

namespace Free_Solaris
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("gdi32.dll", EntryPoint = "BitBlt")]
        static extern bool BitBlt(IntPtr hdc, int x, int y, int cx, int cy, IntPtr hdcSrc, int x1, int y1, uint rop);

        public const uint SRCCOPY = 0x00CC0020;
        public const uint SRCPAINT = 0x00EE0086;
        public const uint SRCAND = 0x008800C6;
        public const uint SRCINVERT = 0x00660046;
        public const uint SRCERASE = 0x00440328;
        public const uint NOTSRCCOPY = 0x00330008;
        public const uint NOTSRCERASE = 0x001100A6;
        public const uint MERGECOPY = 0x00C000CA;
        public const uint MERGEPAINT = 0x00BB0226;
        public const uint PATCOPY = 0x00F00021;
        public const uint PATPAINT = 0x00FB0A09;
        public const uint PATINVERT = 0x005A0049;
        public const uint DSTINVERT = 0x00550009;
        public const uint BLACKNESS = 0x00000042;
        public const uint WHITENESS = 0x00FF0062;
        public const uint CAPTUREBLT = 0x40000000;
        public const uint CUSTOM = 0x00100C85;

        [DllImport("user32.dll")]
        static extern bool DrawIconEx(IntPtr hdc, int xLeft, int yTop, IntPtr hIcon, int cxWidth, int cyHeight, 
            uint istepIfAniCur, IntPtr hbrFlickerFreeDraw, uint diFlags);
        const uint DI_COMPAT = 0x0004;
        const uint DI_DEFAULTSIZE = 0x0008;
        const uint DI_IMAGE = 0x0002;
        const uint DI_MASK = 0x0001;
        const uint DI_NOMIRROR = 0x0004;
        const uint DI_NORMAL = 0x0004;

        [DllImport("user32.dll")]
        static extern IntPtr LoadIconA(IntPtr hInstance, int lpIconName);

        static IntPtr IDI_APPLICATION = LoadIconA(IntPtr.Zero, 32512);
        static IntPtr IDI_ERROR = LoadIconA(IntPtr.Zero, 32513);
        static IntPtr IDI_QUESTION = LoadIconA(IntPtr.Zero, 32514);
        static IntPtr IDI_WARNING = LoadIconA(IntPtr.Zero, 32515);
        static IntPtr IDI_INFORMATION = LoadIconA(IntPtr.Zero, 32516);
        static IntPtr IDI_WINLOGO = LoadIconA(IntPtr.Zero, 32517);
        static IntPtr IDI_SHIELD = LoadIconA(IntPtr.Zero, 32518);

        [DllImport("gdi32.dll")]
        static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest,
            IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, uint rop);

        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        public static extern bool DeleteDC(IntPtr hdc);

        public static Random r = new Random();

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void invert()
        {
            while(true)
            {
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                IntPtr hdc = GetDC(IntPtr.Zero);

                BitBlt(hdc, 0, 0, x, y, hdc, 0, 0, NOTSRCCOPY);

                Thread.Sleep(40);

                DeleteDC(hdc);
            }
        }

        public static void icons()
        {
            while (true)
            {
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                IntPtr hdc = GetDC(IntPtr.Zero);

                IntPtr[] icon = { IDI_ERROR, IDI_WARNING };
                DrawIconEx(hdc, r.Next(x), r.Next(y), icon[r.Next(icon.Length)], r.Next(300), r.Next(300), 0, IntPtr.Zero, DI_IMAGE | DI_MASK);

                Thread.Sleep(10);

                DeleteDC(hdc);
            }
        }

        public static void tunnel()
        {
            while (true)
            {
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                IntPtr hdc = GetDC(IntPtr.Zero);

                StretchBlt(hdc, 40, 40, x - 80, y - 80, hdc, 0, 0, x, y, SRCCOPY);

                Thread.Sleep(100);

                DeleteDC(hdc);
            }
        }

        public static void sound()
        {
            while(true)
            {
                SystemSound[] sounds = { SystemSounds.Beep, SystemSounds.Hand, SystemSounds.Exclamation };
                sounds[r.Next(sounds.Length)].Play();
                Thread.Sleep(200);
            }
        }
    }
}

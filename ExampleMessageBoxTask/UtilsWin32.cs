// ReSharper disable InconsistentNaming
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ExampleMessageBoxTask
{
    public static class UtilsWin32
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr handle, ref Rect r);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        public static IntPtr MakeLParam(int x, int y)
        {
            return (IntPtr)((y << 16) | (x & 0xffff));
        }

        // https://msdn.microsoft.com/ru-ru/library/windows/desktop/ms633545(v=vs.85).aspx
        public static class SetWindowPosConst
        {
            public static IntPtr HWND_NOTOPMOST = new IntPtr(-2);
            public static IntPtr HWND_TOPMOST = new IntPtr(-1);
            public static IntPtr HWND_TOP = new IntPtr(0);
            public static IntPtr HWND_BOTTOM = new IntPtr(1);

            public const uint SWP_ASYNCWINDOWPOS = 0x4000;
            public const uint SWP_DEFERERASE = 0x2000;
            public const uint SWP_DRAWFRAME = 0x0020;
            public const uint SWP_FRAMECHANGED = 0x0020;
            public const uint SWP_HIDEWINDOW = 0x0080;
            public const uint SWP_NOACTIVATE = 0x0010;
            public const uint SWP_NOCOPYBITS = 0x0100;
            public const uint SWP_NOMOVE = 0x0002;
            public const uint SWP_NOOWNERZORDER = 0x0200;
            public const uint SWP_NOREDRAW = 0x0008;
            public const uint SWP_NOREPOSITION = 0x0200;
            public const uint SWP_NOSENDCHANGING = 0x0400;
            public const uint SWP_NOSIZE = 0x0001;
            public const uint SWP_NOZORDER = 0x0004;
            public const uint SWP_SHOWWINDOW = 0x0040;
        }

        // https://autohotkey.com/docs/misc/SendMessageList.htm
        public static class MsgConst
        {
                        public const uint WM_NULL                   = 0x0000;
            public const uint WM_CREATE                 = 0x0001;
            public const uint WM_DESTROY                = 0x0002;
            public const uint WM_MOVE                   = 0x0003;
            public const uint WM_SIZE                   = 0x0005;
            public const uint WM_ACTIVATE               = 0x0006;
            public const uint WM_SETFOCUS               = 0x0007;
            public const uint WM_KILLFOCUS              = 0x0008;
            public const uint WM_ENABLE                 = 0x000A;
            public const uint WM_SETREDRAW              = 0x000B;
            public const uint WM_SETTEXT                = 0x000C;
            public const uint WM_GETTEXT                = 0x000D;
            public const uint WM_GETTEXTLENGTH          = 0x000E;
            public const uint WM_PAINT                  = 0x000F;
            public const uint WM_CLOSE                  = 0x0010;
            public const uint WM_QUERYENDSESSION        = 0x0011;
            public const uint WM_QUIT                   = 0x0012;
            public const uint WM_QUERYOPEN              = 0x0013;
            public const uint WM_ERASEBKGND             = 0x0014;
            public const uint WM_SYSCOLORCHANGE         = 0x0015;
            public const uint WM_ENDSESSION             = 0x0016;
            public const uint WM_SYSTEMERROR            = 0x0017;
            public const uint WM_SHOWWINDOW             = 0x0018;
            public const uint WM_CTLCOLOR               = 0x0019;
            public const uint WM_WININICHANGE           = 0x001A;
            public const uint WM_SETTINGCHANGE          = 0x001A;
            public const uint WM_DEVMODECHANGE          = 0x001B;
            public const uint WM_ACTIVATEAPP            = 0x001C;
            public const uint WM_FONTCHANGE             = 0x001D;
            public const uint WM_TIMECHANGE             = 0x001E;
            public const uint WM_CANCELMODE             = 0x001F;
            public const uint WM_SETCURSOR              = 0x0020;
            public const uint WM_MOUSEACTIVATE          = 0x0021;
            public const uint WM_CHILDACTIVATE          = 0x0022;
            public const uint WM_QUEUESYNC              = 0x0023;
            public const uint WM_GETMINMAXINFO          = 0x0024;
            public const uint WM_PAINTICON              = 0x0026;
            public const uint WM_ICONERASEBKGND         = 0x0027;
            public const uint WM_NEXTDLGCTL             = 0x0028;
            public const uint WM_SPOOLERSTATUS          = 0x002A;
            public const uint WM_DRAWITEM               = 0x002B;
            public const uint WM_MEASUREITEM            = 0x002C;
            public const uint WM_DELETEITEM             = 0x002D;
            public const uint WM_VKEYTOITEM             = 0x002E;
            public const uint WM_CHARTOITEM             = 0x002F;
            public const uint WM_SETFONT                = 0x0030;
            public const uint WM_GETFONT                = 0x0031;
            public const uint WM_SETHOTKEY              = 0x0032;
            public const uint WM_GETHOTKEY              = 0x0033;
            public const uint WM_QUERYDRAGICON          = 0x0037;
            public const uint WM_COMPAREITEM            = 0x0039;
            public const uint WM_COMPACTING             = 0x0041;
            public const uint WM_WINDOWPOSCHANGING      = 0x0046;
            public const uint WM_WINDOWPOSCHANGED       = 0x0047;
            public const uint WM_POWER                  = 0x0048;
            public const uint WM_COPYDATA               = 0x004A;
            public const uint WM_CANCELJOURNAL          = 0x004B;
            public const uint WM_NOTIFY                 = 0x004E;
            public const uint WM_INPUTLANGCHANGEREQUEST = 0x0050;
            public const uint WM_INPUTLANGCHANGE        = 0x0051;
            public const uint WM_TCARD                  = 0x0052;
            public const uint WM_HELP                   = 0x0053;
            public const uint WM_USERCHANGED            = 0x0054;
            public const uint WM_NOTIFYFORMAT           = 0x0055;
            public const uint WM_CONTEXTMENU            = 0x007B;
            public const uint WM_STYLECHANGING          = 0x007C;
            public const uint WM_STYLECHANGED           = 0x007D;
            public const uint WM_DISPLAYCHANGE          = 0x007E;
            public const uint WM_GETICON                = 0x007F;
            public const uint WM_SETICON                = 0x0080;

            public const uint WM_NCCREATE = 0x81;
            public const uint WM_NCDESTROY = 0x82;
            public const uint WM_NCCALCSIZE = 0x83;
            public const uint WM_NCHITTEST = 0x84;
            public const uint WM_NCPAINT = 0x85;
            public const uint WM_NCACTIVATE = 0x86;
            public const uint WM_GETDLGCODE = 0x87;
            public const uint WM_NCMOUSEMOVE = 0xA0;
            public const uint WM_NCLBUTTONDOWN = 0xA1;
            public const uint WM_NCLBUTTONUP = 0xA2;
            public const uint WM_NCLBUTTONDBLCLK = 0xA3;
            public const uint WM_NCRBUTTONDOWN = 0xA4;
            public const uint WM_NCRBUTTONUP = 0xA5;
            public const uint WM_NCRBUTTONDBLCLK = 0xA6;
            public const uint WM_NCMBUTTONDOWN = 0xA7;
            public const uint WM_NCMBUTTONUP = 0xA8;
            public const uint WM_NCMBUTTONDBLCLK = 0xA9;

            public const uint WM_KEYFIRST = 0x100;
            public const uint WM_KEYDOWN = 0x100;
            public const uint WM_KEYUP = 0x101;
            public const uint WM_CHAR = 0x102;
            public const uint WM_DEADCHAR = 0x103;
            public const uint WM_SYSKEYDOWN = 0x104;
            public const uint WM_SYSKEYUP = 0x105;
            public const uint WM_SYSCHAR = 0x106;
            public const uint WM_SYSDEADCHAR = 0x107;
            public const uint WM_KEYLAST = 0x108;

            public const uint WM_IME_STARTCOMPOSITION = 0x10D;
            public const uint WM_IME_ENDCOMPOSITION = 0x10E;
            public const uint WM_IME_COMPOSITION = 0x10F;
            public const uint WM_IME_KEYLAST = 0x10F;

            public const uint WM_INITDIALOG = 0x110;
            public const uint WM_COMMAND = 0x111;
            public const uint WM_SYSCOMMAND = 0x112;
            public const uint WM_TIMER = 0x113;
            public const uint WM_HSCROLL = 0x114;
            public const uint WM_VSCROLL = 0x115;
            public const uint WM_INITMENU = 0x116;
            public const uint WM_INITMENUPOPUP = 0x117;
            public const uint WM_MENUSELECT = 0x11F;
            public const uint WM_MENUCHAR = 0x120;
            public const uint WM_ENTERIDLE = 0x121;

            public const uint WM_CTLCOLORMSGBOX = 0x132;
            public const uint WM_CTLCOLOREDIT = 0x133;
            public const uint WM_CTLCOLORLISTBOX = 0x134;
            public const uint WM_CTLCOLORBTN = 0x135;
            public const uint WM_CTLCOLORDLG = 0x136;
            public const uint WM_CTLCOLORSCROLLBAR = 0x137;
            public const uint WM_CTLCOLORSTATIC = 0x138;

            public const uint WM_MOUSEFIRST = 0x200;
            public const uint WM_MOUSEMOVE = 0x200;
            public const uint WM_LBUTTONDOWN = 0x201;
            public const uint WM_LBUTTONUP = 0x202;
            public const uint WM_LBUTTONDBLCLK = 0x203;
            public const uint WM_RBUTTONDOWN = 0x204;
            public const uint WM_RBUTTONUP = 0x205;
            public const uint WM_RBUTTONDBLCLK = 0x206;
            public const uint WM_MBUTTONDOWN = 0x207;
            public const uint WM_MBUTTONUP = 0x208;
            public const uint WM_MBUTTONDBLCLK = 0x209;
            public const uint WM_MOUSEWHEEL = 0x20A;
            public const uint WM_MOUSEHWHEEL = 0x20E;

            public const uint WM_PARENTNOTIFY = 0x210;
            public const uint WM_ENTERMENULOOP = 0x211;
            public const uint WM_EXITMENULOOP = 0x212;
            public const uint WM_NEXTMENU = 0x213;
            public const uint WM_SIZING = 0x214;
            public const uint WM_CAPTURECHANGED = 0x215;
            public const uint WM_MOVING = 0x216;
            public const uint WM_POWERBROADCAST = 0x218;
            public const uint WM_DEVICECHANGE = 0x219;

            public const uint WM_MDICREATE = 0x220;
            public const uint WM_MDIDESTROY = 0x221;
            public const uint WM_MDIACTIVATE = 0x222;
            public const uint WM_MDIRESTORE = 0x223;
            public const uint WM_MDINEXT = 0x224;
            public const uint WM_MDIMAXIMIZE = 0x225;
            public const uint WM_MDITILE = 0x226;
            public const uint WM_MDICASCADE = 0x227;
            public const uint WM_MDIICONARRANGE = 0x228;
            public const uint WM_MDIGETACTIVE = 0x229;
            public const uint WM_MDISETMENU = 0x230;
            public const uint WM_ENTERSIZEMOVE = 0x231;
            public const uint WM_EXITSIZEMOVE = 0x232;
            public const uint WM_DROPFILES = 0x233;
            public const uint WM_MDIREFRESHMENU = 0x234;

            public const uint WM_IME_SETCONTEXT = 0x281;
            public const uint WM_IME_NOTIFY = 0x282;
            public const uint WM_IME_CONTROL = 0x283;
            public const uint WM_IME_COMPOSITIONFULL = 0x284;
            public const uint WM_IME_SELECT = 0x285;
            public const uint WM_IME_CHAR = 0x286;
            public const uint WM_IME_KEYDOWN = 0x290;
            public const uint WM_IME_KEYUP = 0x291;

            public const uint WM_MOUSEHOVER = 0x2A1;
            public const uint WM_NCMOUSELEAVE = 0x2A2;
            public const uint WM_MOUSELEAVE = 0x2A3;

            public const uint WM_CUT = 0x300;
            public const uint WM_COPY = 0x301;
            public const uint WM_PASTE = 0x302;
            public const uint WM_CLEAR = 0x303;
            public const uint WM_UNDO = 0x304;

            public const uint WM_RENDERFORMAT = 0x305;
            public const uint WM_RENDERALLFORMATS = 0x306;
            public const uint WM_DESTROYCLIPBOARD = 0x307;
            public const uint WM_DRAWCLIPBOARD = 0x308;
            public const uint WM_PAINTCLIPBOARD = 0x309;
            public const uint WM_VSCROLLCLIPBOARD = 0x30A;
            public const uint WM_SIZECLIPBOARD = 0x30B;
            public const uint WM_ASKCBFORMATNAME = 0x30C;
            public const uint WM_CHANGECBCHAIN = 0x30D;
            public const uint WM_HSCROLLCLIPBOARD = 0x30E;
            public const uint WM_QUERYNEWPALETTE = 0x30F;
            public const uint WM_PALETTEISCHANGING = 0x310;
            public const uint WM_PALETTECHANGED = 0x311;

            public const uint WM_HOTKEY = 0x312;
            public const uint WM_PRINT = 0x317;
            public const uint WM_PRINTCLIENT = 0x318;

            public const uint WM_HANDHELDFIRST = 0x358;
            public const uint WM_HANDHELDLAST = 0x35F;
            public const uint WM_PENWINFIRST = 0x380;
            public const uint WM_PENWINLAST = 0x38F;
            public const uint WM_COALESCE_FIRST = 0x390;
            public const uint WM_COALESCE_LAST = 0x39F;
            public const uint WM_DDE_FIRST = 0x3E0;
            public const uint WM_DDE_INITIATE = 0x3E0;
            public const uint WM_DDE_TERMINATE = 0x3E1;
            public const uint WM_DDE_ADVISE = 0x3E2;
            public const uint WM_DDE_UNADVISE = 0x3E3;
            public const uint WM_DDE_ACK = 0x3E4;
            public const uint WM_DDE_DATA = 0x3E5;
            public const uint WM_DDE_REQUEST = 0x3E6;
            public const uint WM_DDE_POKE = 0x3E7;
            public const uint WM_DDE_EXECUTE = 0x3E8;
            public const uint WM_DDE_LAST = 0x3E8;

            public const uint WM_USER = 0x400;
            public const uint WM_APP = 0x8000;
        }

        /// <summary>
        /// Прямоуголная область
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

    }
}

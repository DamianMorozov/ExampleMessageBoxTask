// ReSharper disable InconsistentNaming
using System;
using System.Runtime.InteropServices;

namespace ExampleMessageBoxTask
{
    public static class UtilsWin32
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, string lParam);

        // https://autohotkey.com/docs/misc/SendMessageList.htm
        public static class MsgConst
        {
            public const uint WM_NULL = 0x00;
            public const uint WM_CREATE = 0x01;
            public const uint WM_DESTROY = 0x02;
            public const uint WM_MOVE = 0x03;
            public const uint WM_SIZE = 0x05;
            public const uint WM_ACTIVATE = 0x06;
            public const uint WM_SETFOCUS = 0x07;
            public const uint WM_KILLFOCUS = 0x08;
            public const uint WM_ENABLE = 0x0A;
            public const uint WM_SETREDRAW = 0x0B;
            public const uint WM_SETTEXT = 0x000C;
            public const uint WM_GETTEXT = 0x0D;
            public const uint WM_GETTEXTLENGTH = 0x0E;
            public const uint WM_PAINT = 0x0F;
            public const uint WM_CLOSE = 0x10;
            public const uint WM_QUERYENDSESSION = 0x11;
            public const uint WM_QUIT = 0x12;
            public const uint WM_QUERYOPEN = 0x13;
            public const uint WM_ERASEBKGND = 0x14;
            public const uint WM_SYSCOLORCHANGE = 0x15;
            public const uint WM_ENDSESSION = 0x16;
            public const uint WM_SYSTEMERROR = 0x17;
            public const uint WM_SHOWWINDOW = 0x18;
            public const uint WM_CTLCOLOR = 0x19;
            public const uint WM_WININICHANGE = 0x1A;
            public const uint WM_SETTINGCHANGE = 0x1A;
            public const uint WM_DEVMODECHANGE = 0x1B;
            public const uint WM_ACTIVATEAPP = 0x1C;
            public const uint WM_FONTCHANGE = 0x1D;
            public const uint WM_TIMECHANGE = 0x1E;
            public const uint WM_CANCELMODE = 0x1F;
            public const uint WM_SETCURSOR = 0x20;
            public const uint WM_MOUSEACTIVATE = 0x21;
            public const uint WM_CHILDACTIVATE = 0x22;
            public const uint WM_QUEUESYNC = 0x23;
            public const uint WM_GETMINMAXINFO = 0x24;
            public const uint WM_PAINTICON = 0x26;
            public const uint WM_ICONERASEBKGND = 0x27;
            public const uint WM_NEXTDLGCTL = 0x28;
            public const uint WM_SPOOLERSTATUS = 0x2A;
            public const uint WM_DRAWITEM = 0x2B;
            public const uint WM_MEASUREITEM = 0x2C;
            public const uint WM_DELETEITEM = 0x2D;
            public const uint WM_VKEYTOITEM = 0x2E;
            public const uint WM_CHARTOITEM = 0x2F;

            public const uint WM_SETFONT = 0x30;
            public const uint WM_GETFONT = 0x31;
            public const uint WM_SETHOTKEY = 0x32;
            public const uint WM_GETHOTKEY = 0x33;
            public const uint WM_QUERYDRAGICON = 0x37;
            public const uint WM_COMPAREITEM = 0x39;
            public const uint WM_COMPACTING = 0x41;
            public const uint WM_WINDOWPOSCHANGING = 0x46;
            public const uint WM_WINDOWPOSCHANGED = 0x47;
            public const uint WM_POWER = 0x48;
            public const uint WM_COPYDATA = 0x4A;
            public const uint WM_CANCELJOURNAL = 0x4B;
            public const uint WM_NOTIFY = 0x4E;
            public const uint WM_INPUTLANGCHANGEREQUEST = 0x50;
            public const uint WM_INPUTLANGCHANGE = 0x51;
            public const uint WM_TCARD = 0x52;
            public const uint WM_HELP = 0x53;
            public const uint WM_USERCHANGED = 0x54;
            public const uint WM_NOTIFYFORMAT = 0x55;
            public const uint WM_CONTEXTMENU = 0x7B;
            public const uint WM_STYLECHANGING = 0x7C;
            public const uint WM_STYLECHANGED = 0x7D;
            public const uint WM_DISPLAYCHANGE = 0x7E;
            public const uint WM_GETICON = 0x7F;
            public const uint WM_SETICON = 0x80;

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

    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper disable CheckNamespace

namespace UFFF.Win
{
    public class UtilsMessageBoxTask : IDisposable
    {
        private bool Disposed { get; set; }
        private string Text { get; set; }
        private string Caption { get; set; }
        private int Timeout { get; set; }
        private MessageBoxButtons Buttons { get; }
        private MessageBoxIcon MessageBoxIcon { get; }
        private MessageBoxDefaultButton DefaultButton { get; }
        private DateTime DtStart { get; }
        private DialogResult _result;

        public UtilsMessageBoxTask(string text, string caption,
            int timeout = 10,
            MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Information,
            MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
        {
            // Flag of dispose resources
            // Флаг высвобождения ресурсов
            Disposed = false;

            Text = text;
            Caption = caption;
            Timeout = timeout;
            Buttons = buttons;
            MessageBoxIcon = messageBoxIcon;
            DefaultButton = defaultButton;
            DtStart = DateTime.Now;
        }

        public DialogResult Show(IWin32Window owner)
        {
            CheckIfDisposed();

            var hOwner = IntPtr.Zero;
            if (owner != null) hOwner = owner.Handle;

            // Task for search MessageBox and timer change
            // Задача на отслеживание MessageBox и изменение таймера
            Task.Run(() =>
            {
                try
                {
                    IntPtr hWnd;

                    // Wait MessageBox, work go down
                    // Ждать окно сообщения. Работа перейдёт вниз по коду.
                    while ((hWnd = UtilsWin32.FindWindow("#32770", Caption)) == IntPtr.Zero)
                    {
                        Thread.Sleep(25);
                        // Exit by timer
                        // Выйти по таймеру
                        if (DateTime.Now - DtStart > TimeSpan.FromSeconds(Timeout))
                            break;
                    }

                    // Center window one time
                    // Отцентрировать один раз
                    if (hWnd != IntPtr.Zero)
                    {
                        CenterWindow(hOwner, hWnd);
                    }
                    // Resume thread
                    // Возобновить поток
                    while (hWnd != IntPtr.Zero)
                    {
                        // Change caption
                        // Изменить заголовок
                        UtilsWin32.SendMessage(hWnd, UtilsWin32.MsgConst.WM_SETTEXT, IntPtr.Zero, Caption + 
                            @"  [" + (DtStart - DateTime.Now.AddSeconds(-Timeout)).Seconds + @"]");
                        Thread.Sleep(100);
                        // Timer
                        // Таймер
                        if (DateTime.Now - DtStart > TimeSpan.FromSeconds(Timeout))
                        {
                            // Change caption
                            // Изменить заголовок
                            UtilsWin32.SendMessage(hWnd, UtilsWin32.MsgConst.WM_SETTEXT, IntPtr.Zero, Caption);
                            // Close MessageBox, if possible
                            // Закрыть окно, если возможно
                            UtilsWin32.SendMessage(hWnd, UtilsWin32.MsgConst.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                            // Wait MessageBox
                            // Подождать
                            Thread.Sleep(250);
                            // Press Enter on MessageBox there haven't close button
                            // Нажать Enter на окнах без кнопки закрытия
                            UtilsWin32.PostMessage(hWnd, UtilsWin32.MsgConst.WM_KEYDOWN, 0x0D, 0x0);
                            // Exit while
                            // Завершить цикл
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    //
                }
            });

            _result = owner == null 
                ? MessageBox.Show(Text, Caption, Buttons, MessageBoxIcon, DefaultButton) 
                : MessageBox.Show(owner, Text, Caption, Buttons, MessageBoxIcon, DefaultButton);

            return _result;
        }

        private static void CenterWindow(IntPtr hOwner, IntPtr hMessageBox)
        {
            try
            {
                // Size MessageBox
                // Размер MessageBox
                var rectChild = new UtilsWin32.Rect();
                var widthChild = 0;
                var heightChild = 0;
                if (hMessageBox != IntPtr.Zero)
                {
                    UtilsWin32.GetWindowRect(hMessageBox, ref rectChild);
                    widthChild = rectChild.right - rectChild.left;
                    heightChild = rectChild.bottom - rectChild.top;
                    
                }

                // Get size and location MessageBox
                // Получить размер и позицию формы
                var rectParent = new UtilsWin32.Rect();
                var widthParent = 0;
                var heightParent = 0;
                if (hOwner != IntPtr.Zero)
                {
                    UtilsWin32.GetWindowRect(hOwner, ref rectParent);
                    widthParent = rectParent.right - rectParent.left;
                    heightParent = rectParent.bottom - rectParent.top;
                }

                // Center MessageBox on parent form
                // Центровка MessageBox на форме
                var left = rectParent.left + (widthParent - widthChild) / 2;
                var top = rectParent.top + (heightParent - heightChild) / 2;
                UtilsWin32.SetWindowPos(hMessageBox, UtilsWin32.SetWindowPosConst.HWND_TOPMOST, left, top, 0, 0,
                    UtilsWin32.SetWindowPosConst.SWP_NOSIZE | 
                    UtilsWin32.SetWindowPosConst.SWP_NOOWNERZORDER | 
                    UtilsWin32.SetWindowPosConst.SWP_SHOWWINDOW);
            }
            catch (Exception)
            {
                //
            }
        }

        ~UtilsMessageBoxTask()
        {
            Dispose();
        }

        // Высвободить управляемые ресурсы
        private void DisposeManagedResources()
        {
            Text = null;
            Caption = null;
            Timeout = 0;
        }

        // Высвободить неуправляемые ресурсы
        private void DisposeUnmanagedResources()
        {
        }

        private void CheckIfDisposed()
        {
            if (Disposed)
            {
                throw new ObjectDisposedException(ToString() + @": объект уже высвобожден!");
            }
        }

        public virtual void Dispose()
        {
            lock (this)
            {
                if (!Disposed)
                {
                    // Высвободить управляемые ресурсы
                    DisposeManagedResources();

                    // Высвободить неуправляемые ресурсы
                    DisposeUnmanagedResources();

                    // Flag of dispose resources
                    // Флаг высвобождения ресурсов
                    Disposed = true;
                }

                // Deny GC call destructor
                // Запретить сборщику мусора вызывать деструктор
                GC.SuppressFinalize(this);
            }
        }
    }
}

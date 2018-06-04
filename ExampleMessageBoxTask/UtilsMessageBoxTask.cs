using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleMessageBoxTask
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

        public DialogResult Show()
        {
            CheckIfDisposed();

            // Задача на отслеживание MessageBox и изменение таймера
            Task.Run(() =>
            {
                try
                {
                    IntPtr hWnd;

                    // Ждать окно сообщения. Работа перейдёт вниз по коду.
                    while ((hWnd = UtilsWin32.FindWindow("#32770", Caption)) == IntPtr.Zero)
                    {
                        Thread.Sleep(25);
                        // Выйти по таймеру
                        if (DateTime.Now - DtStart > TimeSpan.FromSeconds(Timeout))
                            break;
                    }

                    // Возобновить поток
                    while (hWnd != IntPtr.Zero)
                    {
                        // Изменить заголовок
                        UtilsWin32.SendMessage(hWnd, UtilsWin32.MsgConst.WM_SETTEXT, IntPtr.Zero, Caption + @"  [" +
                            (DtStart - DateTime.Now.AddSeconds(-Timeout)).Seconds + @"]");
                        Thread.Sleep(100);
                        // Таймер
                        if (DateTime.Now - DtStart > TimeSpan.FromSeconds(Timeout))
                        {
                            // Закрыть окно
                            UtilsWin32.SendMessage(hWnd, UtilsWin32.MsgConst.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
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

            // Такой метод, иногда приводит к тому, что MessageBox не всегда отображается
            //var w = new Form() { Size = new System.Drawing.Size(0, 0) };
            //Task.Delay(TimeSpan.FromSeconds(Timeout))
            //    .ContinueWith(t => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());
            //_result = MessageBox.Show(w, Text, Caption, Buttons, MessageBoxIcon, DefaultButton);

            // Исправление
            _result = MessageBox.Show(Text, Caption, Buttons, MessageBoxIcon, DefaultButton);

            return _result;

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

                    // Флаг высвобождения ресурсов
                    Disposed = true;
                }

                // Запретить сборщику мусора вызывать деструктор
                GC.SuppressFinalize(this);
            }
        }
    }
}

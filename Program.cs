using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DoC.MapEditor
{
    class Program
    {
        private static Stopwatch stopWatch = new Stopwatch();

        /// <summary>
        /// The main entry point of the application
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            stopWatch.Start();

            using (UI.frmEditor editorUI = new UI.frmEditor())
                Application.Run(editorUI);
        }

        /// <summary>
        /// Gets the elapsed time in milliseconds
        /// </summary>
        /// <returns></returns>
        public static Int64 GetElapsedTime()
        {
            return stopWatch.ElapsedMilliseconds;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NzxtCamFixer
{
    class Program
    {
        static void ShowErrorMessage(string text)
        {
            System.Windows.Forms.MessageBox.Show(text, "NzxtCamFixer", System.Windows.Forms.MessageBoxButtons.OK);
            Environment.Exit(1);
        }

        static void Main(string[] args)
        {
            if(args.Length == 0) ShowErrorMessage("Error: path arg not found!");
            string path = args[0];
            if (!System.IO.File.Exists(path)) ShowErrorMessage("Error: app not found!");
            try
            {
                System.Diagnostics.Process app = new System.Diagnostics.Process();
                app.StartInfo.FileName = path;
                app.StartInfo.Arguments = "--startup";
                app.Start();
                System.Threading.Thread.Sleep(30000);
                app.Kill();
            } catch { ShowErrorMessage("Error: process error!"); }
        }
    }
}

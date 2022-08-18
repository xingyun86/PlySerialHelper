using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlyFramework
{
    public class WinMessageBox
    {
        public static void Show(string text)
        {
            MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string text)
        {
            MessageBox.Show(text, "预警", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string text)
        {
            MessageBox.Show(text, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Question(string text)
        {
            return MessageBox.Show(text, "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }
    }
}

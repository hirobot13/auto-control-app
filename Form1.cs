using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KAutoHelper;

namespace AutoControlApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("cmd.exe");
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("notepad");
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(textBox1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(RunCommand());
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
            
        }

        string RunCommand()
        {
            Process cmd = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            cmd.StartInfo = startInfo;
            cmd.Start();

            cmd.StandardInput.WriteLine(textBox2.Text);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            string result = "";
            return result = cmd.StandardOutput.ReadToEnd();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream file = new FileStream(Directory.GetCurrentDirectory() + "//" + textBox2.Text + ".txt", FileMode.Create);
                StreamWriter stream = new StreamWriter(file, Encoding.UTF8);
                stream.WriteLine(RunCommand());
                stream.Flush();
                stream.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int x = (int)numericUpDown1.Value;
                int y = (int)numericUpDown2.Value;

                Point pointToClick = new Point(x, y);

                EMouseKey key = EMouseKey.LEFT;
                IntPtr handle = IntPtr.Zero;
                if (textBox3.Text != null && textBox4.Text != null)
                {
                    handle = AutoControl.FindWindowHandle(textBox4.Text, textBox3.Text);
                    pointToClick = AutoControl.GetGlobalPoint(handle, x, y);
                }
                if (checkBox1.Checked)
                {
                    key = EMouseKey.RIGHT;
                }
                else
                {
                    key = EMouseKey.DOUBLE_RIGHT;
                }

                if (checkBox2.Checked)
                {
                    key = EMouseKey.LEFT;
                }
                else
                {
                    key = EMouseKey.DOUBLE_LEFT;
                }
                AutoControl.BringToFront(handle);
                AutoControl.MouseClick(pointToClick, key);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int x = (int)numericUpDown1.Value;
                int y = (int)numericUpDown2.Value;

                Cursor.Position = new Point(x, y);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }            
          
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                int x = (int)numericUpDown1.Value;
                int y = (int)numericUpDown2.Value;

                var handle = AutoControl.FindWindowHandle(textBox4.Text, textBox3.Text);

                EMouseKey key = EMouseKey.LEFT;
                var childhandle = IntPtr.Zero;
                childhandle = AutoControl.FindHandle(handle, textBox5.Text, textBox5.Text);
                var pointToClick = AutoControl.GetGlobalPoint(childhandle, x, y);
                if (checkBox1.Checked)
                {
                    key = EMouseKey.RIGHT;
                }
                else
                {
                    key = EMouseKey.DOUBLE_RIGHT;
                }

                if (checkBox2.Checked)
                {
                    key = EMouseKey.LEFT;
                }
                else
                {
                    key = EMouseKey.DOUBLE_LEFT;
                }
                AutoControl.BringToFront(childhandle);
                AutoControl.MouseClick(pointToClick, key);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                int x = (int)numericUpDown1.Value;
                int y = (int)numericUpDown2.Value;

                var handle = AutoControl.FindWindowHandle(textBox4.Text, textBox3.Text);
                AutoControl.BringToFront(handle);
                AutoControl.SendKeyFocus(KeyCode.ENTER);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                int x = (int)numericUpDown1.Value;
                int y = (int)numericUpDown2.Value;

                var handle = AutoControl.FindWindowHandle(textBox4.Text, textBox3.Text);
                AutoControl.BringToFront(handle);
                AutoControl.SendMultiKeysFocus(new KeyCode[] { KeyCode.CONTROL, KeyCode.KEY_Z });
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
            
        }
    }
}

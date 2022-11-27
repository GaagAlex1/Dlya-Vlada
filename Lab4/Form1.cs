using System;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private static int _menuItem = 2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArrayTasks.Arr = new int[0];
            richTextBox1.Text = "";
            textBox1.Visible = true;
            label1.Visible = true;
            richTextBox1.ReadOnly = true;
        }

        private void WriteArray()
        {
            if (ArrayTasks.Arr != null) richTextBox1.Text = "[" + string.Join(" ", ArrayTasks.Arr) + "]";
        }

        private void ChooseMethod()
        {
            if (radioButton1.Checked) ArrayTasks.DeleteHigherThanMid();
            else if (radioButton2.Checked) ArrayTasks.AddNumbersFromKeyboard(textBox2.Text);
            else if (radioButton3.Checked) ArrayTasks.SwapEvenOddItems();
            else if (radioButton4.Checked)
            {
                textBox3.Text = ArrayTasks.IndexOfFirstNegative(out int _amountIterations).ToString();
                label4.Text = _amountIterations.ToString();
            }
            else if (radioButton5.Checked) ArrayTasks.QuickSort(0, ArrayTasks.Arr.Length - 1);
            else if (radioButton6.Checked) 
            {
                textBox3.Text = ArrayTasks.ExponentialSearch(Convert.ToInt32(textBox4.Text),out int _amountIterations).ToString();
                label4.Text = _amountIterations.ToString();
            }
        }

        private bool IsNumbers(KeyPressEventArgs e, string input)
        {
            char symbol = e.KeyChar;
            if (input == "") return Char.IsDigit(symbol) || symbol == 8 || symbol == 45;
            else if (input[input.Length - 1] == '0') return symbol == 8 || symbol == 32;
            else if (input[input.Length - 1] == '-') return symbol == 8 || Char.IsDigit(symbol);
            return Char.IsDigit(symbol) || (symbol == 32 && input[input.Length - 1] != 32 && input[input.Length - 1] != 45)
                                || symbol == 8 || (symbol == 45 && !Char.IsDigit(input[input.Length - 1]));
        }

        private bool IsSingleNumber(KeyPressEventArgs e, string input)
        {
            char symbol = e.KeyChar;
            if (input == "0") return symbol == 8;
            return Char.IsDigit(symbol) || symbol == 8;
        }

        private bool IsNumber(KeyPressEventArgs e, string input)
        {
            char symbol = e.KeyChar;
            if (input == "") return Char.IsDigit(symbol) || symbol == 8 || symbol == 45;
            return Char.IsDigit(symbol) || symbol == 8 || (symbol == 45 && input[input.Length - 1] != 45 && !Char.IsDigit(input[input.Length - 1]));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_menuItem == 2)
            {
                if (textBox1.Text != "")
                {
                    ArrayTasks.Len = Convert.ToInt32(textBox1.Text);
                    ArrayTasks.Arr = new int[ArrayTasks.Len];
                    ArrayTasks.FillArrayRandom();
                }
            } 
            else
            {
                ArrayTasks.FillArrayManual(richTextBox1.Text);
            }
            WriteArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChooseMethod();
            WriteArray();
            textBox2.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsSingleNumber(e,textBox1.Text))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsNumbers(e,textBox2.Text))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsNumber(e, textBox4.Text))
            {
                e.Handled = true;
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsNumbers(e, richTextBox1.Text))
            {
                e.Handled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly = !textBox2.ReadOnly;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.ReadOnly = !textBox4.ReadOnly;
        }

        private void вручнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label1.Visible = false;
            richTextBox1.ReadOnly = false;
            _menuItem = 1;
        }

        private void случайноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            label1.Visible = true;
            richTextBox1.ReadOnly = true;
            _menuItem = 2;
        }
    }
}

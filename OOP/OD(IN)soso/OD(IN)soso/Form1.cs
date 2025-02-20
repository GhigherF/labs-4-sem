using System;
using System.Text.RegularExpressions;   
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OD_IN_soso
{
   
    public partial class Form1 : Form
    {
        bool isTextBox2Empty = true;
        bool isTextBox3Empty = true;
        public Form1()
        {
            InitializeComponent();

            

            button2.Enabled=false;
            button3.Enabled = false;
            numericUpDown1.Maximum = 0;

            button1.Click += new EventHandler(LabelCount);
            button2.Click += new EventHandler(TextBoxChange);
            button3.Click += new EventHandler(TextBoxDelete);


            textBox1.TextChanged += MaxChange;
            textBox1.TextChanged += Radio;
            radioButton1.CheckedChanged += Radio;
            radioButton2.CheckedChanged += Radio;
            radioButton3.CheckedChanged += Radio;
            radioButton4.CheckedChanged += Radio;
            numericUpDown1.ValueChanged+= GetByIndex;
            




            textBox2.TextChanged += Validate2;
            textBox3.TextChanged += Validate3;
            textBox4.TextChanged += Validate4;
        }

        private void LabelCount(object sender, EventArgs e)
        {
         label2.Text = Calculator.Length(textBox1.Text);
        }

        private void TextBoxChange(object sender, EventArgs e)
        {
            textBox1.Text = Calculator.Change(textBox1.Text, textBox2.Text, textBox3.Text);
        }
        private void TextBoxDelete(object sender,EventArgs e)
        {
            textBox1.Text = Calculator.Delete(textBox1.Text, textBox4.Text);
        }
        private void MaxChange(object sender,EventArgs e)
        {
            numericUpDown1.Maximum = textBox1.Text.Length;
        }

        private void GetByIndex(object sender,EventArgs e)
        {
            textBox5.Text = "";
            if ((int)numericUpDown1.Value - 1 == -1) textBox5.Text = "";
            else textBox5.Text+= textBox1.Text[(int)numericUpDown1.Value-1];
        }

        private void Radio(object sender, EventArgs e)
        {
            int check=0;
            if (radioButton1.Checked) check = 1;
            if (radioButton2.Checked) check = 2;
            if (radioButton3.Checked) check = 3;
            if (radioButton4.Checked) check = 4;

            List<char> glas = new List<char>() { 'a', 'e', 'u', 'y', 'i', 'o', 'е', 'ы', 'а', 'о', 'э', 'я', 'и', 'ю', 'A', 'E', 'U', 'Y', 'U', 'I', 'O', 'Е', 'Ы', 'А', 'О', 'Э', 'Я', 'И', 'Ю' };

            switch(check)
            {
                case 1:
                    {
                        int counter = 0;
                        foreach (var letter in textBox1.Text)
                        {
                              counter = glas.Contains(letter) ?counter+1:counter;
                        }
                        textBox6.Text = counter.ToString();
                        break;
                    }
                case 2:
                    {
                        int counter = 0;
                        foreach (var letter in textBox1.Text)
                        {
                            counter = glas.Contains(letter) ? counter : counter+1;
                        }
                        textBox6.Text = counter.ToString();
                        break;
                    }
                case 3:
                    {
                            string text = textBox1.Text.Trim();
                            int counter = Regex.Matches(text, @"(?<=[^.!?])[.!?](\s|$)").Count;
                            textBox6.Text = counter.ToString();
                              break;
                    }
                case 4:
                    {
                        string[] words = textBox1.Text.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
                        int counter = 0;
                        foreach (var word in words)
                        {
                            counter++;
                        }
                        textBox6.Text = counter.ToString();
                        break;
                    }
            }
        }





        private void Validate2(object sender, EventArgs e)
        {
            
           isTextBox2Empty = string.IsNullOrWhiteSpace(textBox2.Text);
            button2.Enabled = !isTextBox2Empty && !isTextBox3Empty;
        }

        private void Validate4(object sender, EventArgs e)
        {
           bool  isTextBoxEmpty = string.IsNullOrWhiteSpace(textBox4.Text);
            button3.Enabled = !isTextBoxEmpty;
        }

        private void Validate3(object sender, EventArgs e)
        {
            isTextBox3Empty = string.IsNullOrWhiteSpace(textBox3.Text);
            button2.Enabled = !isTextBox2Empty && !isTextBox3Empty;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        { 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        public static class Calculator
        {
            public static string Length(string text)
            {
                return text.Length.ToString();
            }

            public static string Change(string text, string sub1, string sub2)
            {
                return text.Replace(sub1, sub2);
            }
            public static string Delete(string text,string del)
            {
                return text.Replace(del, "");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Validate2(object sender, CancelEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.IO;
using System.Xml.Serialization;
using System.Text.RegularExpressions; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;
using static OD_IN_soso.Form1;
using System.Linq;
namespace OD_IN_soso
{
    public partial class Form1 : Form
    {
    
        List<Lector> lectors = new List<Lector>();
        Lector choice;
        public Form1()
        {
            File.Delete("C:\\Users\\ghigher\\Desktop\\labs-4-sem\\OOP\\3ooPorn\\test.xml");
            InitializeComponent();

            using (FileStream fileStream = new FileStream(
                "C:\\Users\\ghigher\\Desktop\\labs-4-sem\\OOP\\3ooPorn\\test.xml",
                FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Lector>));
                serializer.Serialize(fileStream, lectors);
            }
            button1.Enabled = false;
            button2.Enabled = false;
            comboBox1.Items.Clear();


            Lector lector = new Lector("Смелов Владимир Владиславович", "Смелов В.В.", "ПИ", "666-2");
            lectors.Add(lector);
            comboBox1.Items.Add(lector.shortName);

            lector = new Lector("Белодед Николай Иванович", "Белодед Н.И.", "ПИ", "666-1");
            lectors.Add(lector);
            comboBox1.Items.Add(lector.shortName);

            radioButton1.CheckedChanged += changeText;
            radioButton2.CheckedChanged += changeText;
            radioButton1.Checked = true;
            textBox1.BackColor = Color.MistyRose;
            textBox2.BackColor = Color.MistyRose;
            textBox3.BackColor = Color.MistyRose;
            textBox4.BackColor = Color.MistyRose;


            textBox1.TextChanged += Validate;
            textBox2.TextChanged += Validate;
            textBox3.TextChanged += Validate;
            textBox4.TextChanged += Validate;
            comboBox1.SelectedIndexChanged += Validate;
            comboBox1.SelectedIndexChanged += Choose;
            button2.Click += addLector;
            button1.Click += writeInFile;
            button3.Click += readFromFile;



            var gg = menuStrip1.Items[0];


            if (gg is ToolStripMenuItem menuItem)
            {
                var arr = menuItem.DropDownItems;
                arr[3].Click += ggg;
                arr[2].Click += save;


                if (arr[1] is ToolStripMenuItem newMenuItem)
                {
                    var newArr = newMenuItem.DropDownItems;
                    newArr[0].Click += nameSort;
                    newArr[1].Click += fioSort;
                }

                if (arr[0] is ToolStripMenuItem newNewMenuItem)
                {
                    var newArr = newNewMenuItem.DropDownItems;
                    newArr[0].Click += fullSearch;
                }
            }



        }



        [Serializable]
        public class Info
        {
            public string name { get; set; }
            public int age { get; set; }
            public float difficulty { get; set; }
            public int lectures { get; set; }
            public int labs { get; set; }
            public bool exam { get; set; }
            public string date { get; set; }
            public int price { get; set; }
            public Lector lector { get; set; }
        }


        private void ggg(object sender, EventArgs e)
        {
            MessageBox.Show("Дмитроченко К.Д    version 1.0\n           All rights reserved");
        }
        
        private void fullSearch(object sender,EventArgs e)
        {
            MessageBox.Show("HUI");
        }

        [Serializable]
        public class Lector
        {
            public Lector()
            {
            }

            public Lector(string name, string shortName, string cafedra, string kab)
            {
                this.shortName = shortName;
                this.name = name;
                this.cafedra = cafedra;
                this.kab = kab;
            }
            public string shortName { get; set; }
            public string cafedra { get; set; }
            public string name { get; set; }
            public string kab { get; set; }

        }

private void nameSort(object sender, EventArgs e)
    {
        string filePath = "C:\\Users\\ghigher\\Desktop\\labs-4-sem\\OOP\\3ooPorn\\test.xml";
        
        XmlSerializer serializer = new XmlSerializer(typeof(List<Info>));
        using (StreamReader reader = new StreamReader(filePath))
        {
            List<Info> obj = (List<Info>)serializer.Deserialize(reader) ?? new List<Info>();

            var sortedList = obj.OrderBy(info => info.name).ToList();

            richTextBox1.Text = "";
            foreach (var info in sortedList)
            {
                richTextBox1.Text += $"Name: {info.name}\nAge: {info.age}\nDifficulty: {info.difficulty}\nLectures: {info.lectures}\nLabs: {info.labs}\nExam: {info.exam}\nDate: {info.date}\nLector: {info.lector.name}\nPrice: {info.price}\n\n\n";
            }
        }
    }

    private void fioSort(object sender, EventArgs e)
    {
        string filePath = "C:\\Users\\ghigher\\Desktop\\labs-4-sem\\OOP\\3ooPorn\\test.xml";

        XmlSerializer serializer = new XmlSerializer(typeof(List<Info>));
        using (StreamReader reader = new StreamReader(filePath))
        {
            List<Info> obj = (List<Info>)serializer.Deserialize(reader) ?? new List<Info>();
            var sortedList = obj.OrderBy(info => info.lector != null ? info.lector.name : "").ToList();


            richTextBox1.Text = "";
            foreach (var info in sortedList)
            {
                richTextBox1.Text += $"Name: {info.name}\nAge: {info.age}\nDifficulty: {info.difficulty}\nLectures: {info.lectures}\nLabs: {info.labs}\nExam: {info.exam}\nDate: {info.date}\nLector: {info.lector.name}\nPrice: {info.price}\n\n\n";
            }
        }
    }



    public void save(object sender, EventArgs e)
        {
            string filePath = "C:\\Users\\ghigher\\Desktop\\labs-4-sem\\OOP\\3ooPorn\\TestIK.xml";

            List<Info> infoList = new List<Info>();

            string[] entries = richTextBox1.Text.Split(new string[] { "\n\n\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var entry in entries)
            {
                var lines = entry.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
    
                var info = new Info();
                foreach (var line in lines)
                {
                    var parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
 
                    switch (parts[0])
                    {
                        case "Name":
                            info.name = parts[1];
                            break;
                        case "Age":
                            if (int.TryParse(parts[1], out int age))
                                info.age = age;
                            break;
                        case "Difficulty":
                            if (int.TryParse(parts[1], out int difficulty))
                                info.difficulty = difficulty;
                            break;
                        case "Lectures":
                            if (int.TryParse(parts[1], out int lectures))
                                info.lectures = lectures;
                            break;
                        case "Labs":
                            if (int.TryParse(parts[1], out int labs))
                                info.labs = labs;
                            break;
                        case "Exam":
                            info.exam = parts[1].ToLower() == "true";
                            break;
                        case "Date":
                            info.date = parts[1];
                            break;
                        case "Lector":
                            info.lector = new Lector { name = parts[1] };
                            break;
                        case "Price":
                            if (int.TryParse(parts[1], out int price))
                                info.price = price;
                            break;
                    }
                }
                infoList.Add(info);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Info>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, infoList);
            }

            MessageBox.Show("Данные успешно сериализованы в файл.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Validate(object sender, EventArgs e)
        {
            bool isTextBox1Empty = true;
            bool isTextBox2Empty = true;
            bool isTextBox3Empty = true;
            bool isTextBox4Empty = true;


            isTextBox1Empty = string.IsNullOrWhiteSpace(textBox1.Text);
            isTextBox2Empty = string.IsNullOrWhiteSpace(textBox2.Text);
            isTextBox3Empty = string.IsNullOrWhiteSpace(textBox3.Text);
            isTextBox4Empty = string.IsNullOrWhiteSpace(textBox4.Text);


            if (CountWords(textBox3.Text) != 3) isTextBox3Empty = true;


            textBox1.BackColor = isTextBox1Empty ? Color.MistyRose : Color.White;
            textBox2.BackColor = isTextBox2Empty ? Color.MistyRose : Color.White;
            textBox3.BackColor = isTextBox3Empty ? Color.MistyRose : Color.White;
            textBox4.BackColor = isTextBox4Empty ? Color.MistyRose : Color.White;

            button2.Enabled = !isTextBox2Empty & !isTextBox3Empty & !isTextBox4Empty;
            if (textBox1.Text != "" && comboBox1.Text != "") button1.Enabled = true;
            else button1.Enabled = false;

        }

        private void changeText(object sender, EventArgs e)
        {
            label8.Text = radioButton1.Checked ? "Дата экзамена" : "Дата зачёта";
        }

        private int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;
            string[] words = text.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
        private void addLector(object sender, EventArgs e)
        {
            string[] parts = textBox3.Text.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string lastName = parts[0];
            string firstInitial = " " + parts[1][0] + ".";
            string middleInitial = parts.Length > 2 ? " " + parts[2][0] + "." : "";
            string shortName = lastName + firstInitial + middleInitial;
            Lector lector = new Lector(textBox3.Text, shortName, textBox2.Text, textBox4.Text);
            lectors.Add(lector);
            comboBox1.Items.Add(lector.shortName);
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void Choose(object sender, EventArgs e)
        {
            foreach (var a in lectors)
            {
                if (comboBox1.Text == a.shortName) choice = a;
            }
        }
        //private void Output(object sender, EventArgs e)
        //{
        //  if (choice!=null) richTextBox1.Text = "Fio:"+choice.name+"\nKafedra:"+choice.cafedra+"\nKabinet:"+choice.kab+"\n";
        //}
        private void writeInFile(object sender, EventArgs e)
        {
            string filePath = "C:\\Users\\ghigher\\Desktop\\labs-4-sem\\OOP\\3ooPorn\\test.xml";
            List<Info> infoList = new List<Info>();

            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Info>));
                using (StreamReader reader = new StreamReader(filePath))
                {
                    try
                    {
                        infoList = (List<Info>)serializer.Deserialize(reader) ?? new List<Info>();
                    }
                    catch
                    {
                        infoList = new List<Info>();
                    }
                }
            }

            Info info = new Info
            {
                name = textBox1.Text,
                age = (int)numericUpDown1.Value,
                difficulty = trackBar1.Value,
                lectures = (int)numericUpDown2.Value,
                labs = (int)numericUpDown3.Value,
                exam = radioButton1.Checked,
                price = ((int)numericUpDown2.Value *10+(int)numericUpDown3.Value*12)*(int)numericUpDown1.Value/10,
                date = monthCalendar1.SelectionStart.ToShortDateString(),
                lector = choice
            };

            infoList.Add(info);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Info>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(writer, infoList);
            }

            textBox1.Text = "";
            numericUpDown1.Value = 16;
            numericUpDown2.Value = 1;
            numericUpDown3.Value = 1;
            trackBar1.Value = 0;
            radioButton1.Checked = true;
            comboBox1.Text = "";
            monthCalendar1.SelectionStart = DateTime.Today;
            choice = null;
        }

        private void readFromFile(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            string filePath = "C:\\Users\\ghigher\\Desktop\\labs-4-sem\\OOP\\3ooPorn\\test.xml";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Info>));
                using (StreamReader reader = new StreamReader(filePath))
                {
                    List<Info> obj = (List<Info>)serializer.Deserialize(reader) ?? new List<Info>();
                    if (obj.Count == 0)
                    {
                        MessageBox.Show("Файл не содержит корректных данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (var a in obj)
                    {
                        richTextBox1.Text += $"Name: {a.name}\nAge: {a.age}\nDifficulty: {a.difficulty}\nLectures: {a.lectures}\nLabs: {a.labs}\nExam: {a.exam}\nDate: {a.date} \nLector: {(a.lector != null ? a.lector.name : "Unknown")}\nPrice: {a.price}\n\n\n";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



















        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ggToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void возрастаниюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void полныйToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

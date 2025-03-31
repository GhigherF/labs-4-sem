using System;
using System.Collections;
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
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using System.Diagnostics;
namespace OD_IN_soso
{
   

// Поля класса формы


    public partial class Form1 : Form
    {
        public class HistoryStack<T> : IEnumerable<T>
        {
            private LinkedList<T> list = new LinkedList<T>();
            public int MaxSize { get; } = 50;
            public int Count => list.Count;

            public HistoryStack(int maxSize = 50) => MaxSize = maxSize;

            public void Push(T item)
            {
                list.AddLast(item);
                if (list.Count > MaxSize)
                    list.RemoveFirst();
            }

            public T Pop()
            {
                var last = list.Last.Value;
                list.RemoveLast();
                return last;
            }

            public bool CanPop => list.Count > 0;
            public void Clear() => list.Clear();
            public IEnumerator<T> GetEnumerator() => list.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        private StatusStrip statusStrip;
        private ErrorProvider errorProvider;
        private ToolStripStatusLabel lblObjectCount;
        private ToolStripStatusLabel lblLastAction;
        private ToolStripStatusLabel lblDateTime;
        private Timer timer;
        private HistoryStack<string> backHistory = new HistoryStack<string>(100);
        private HistoryStack<string> forwardHistory = new HistoryStack<string>(100);
        private bool isNavigating = false;

        List<Lector> lectors = new List<Lector>();
        Lector choice;
        public Form1()
        {

            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

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
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            button2.Enabled = false;
            richTextBox1.TextChanged += (s, e) =>
            {
                if (!isNavigating)
                {
                    backHistory.Push(richTextBox1.Text);
                    forwardHistory.Clear();
                }
            };
            textBox1.TextChanged += (s, e) => Validate();
            numericUpDown1.ValueChanged += (s, e) => Validate();
            trackBar1.ValueChanged += (s, e) => Validate();
            numericUpDown2.ValueChanged += (s, e) => Validate();
            numericUpDown3.ValueChanged += (s, e) => Validate();
            monthCalendar1.DateChanged += (s, e) => Validate();
            comboBox1.SelectedIndexChanged += (s, e) => Validate();
            comboBox1.SelectedIndexChanged += Choose;
            button2.Click += addLector;
            button1.Click += writeInFile;
            button3.Click += readFromFile;
            button4.Click += ggg;
            button5.Click += save;
            button6.Click += fioSort;
            button7.Click += nameSort;
            button8.Click += searchToolStripMenuItem_Click;
            button9.Click += Clear;
            button10.Click += Delete;
            button11.Click += Forward;
            button12.Click += Backward;
            button13.Click += Hide;
            textBox2.TextChanged+= ladd;
            textBox3.TextChanged += ladd;
            textBox4.TextChanged+= ladd;


            var gg = menuStrip1.Items[0];


            if (gg is ToolStripMenuItem menuItem)
            {
                var arr = menuItem.DropDownItems;
                arr[0].Click += (object sender, EventArgs e) =>
                {
                    var test = new SearchForm();
                        test.ShowDialog();
                };
                arr[3].Click += ggg;
                arr[2].Click += save;


                if (arr[1] is ToolStripMenuItem newMenuItem)
                {
                    var newArr = newMenuItem.DropDownItems;
                    newArr[0].Click += nameSort;
                    newArr[1].Click += fioSort;
                }

                //if (arr[0] is ToolStripMenuItem newNewMenuItem)
                //{
                //    var newArr = newNewMenuItem.DropDownItems;
                //    var test = new SearchForm();
                //    newArr[1].Click += (object sender, EventArgs e) =>
                //    {
                //        test.ShowDialog();
                //    };
                //    //newArr[0].Click += fullSearch;
                //}

            }
            var searchButton = new System.Windows.Forms.Button
            {
                Text = "Поиск",
                Location = new Point(10, menuStrip1.Bottom + 10),
                Size = new Size(80, 30)
            };
            searchButton.Click += searchToolStripMenuItem_Click;
            Controls.Add(searchButton);
            InitializeStatusStrip();
            UpdateObjectCount();
            UpdateLastAction("Приложение запущено");
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Forward(object sender, EventArgs e)
        {
            if (forwardHistory.CanPop)
            {
                isNavigating = true;
                try
                {
                    backHistory.Push(richTextBox1.Text);
                    richTextBox1.Text = forwardHistory.Pop();
                }
                finally
                {
                    isNavigating = false;
                }
            }
        }

        private void Backward(object sender, EventArgs e)
        {
            if (backHistory.CanPop)
            {
                isNavigating = true;
                try
                {
                    forwardHistory.Push(richTextBox1.Text);
                    richTextBox1.Text = backHistory.Pop();
                }
                finally
                {
                    isNavigating = false;
                }
            }
        }
        private void UpdateNavigationButtons()
        {
            button11.Enabled = forwardHistory.CanPop;
            button12.Enabled = backHistory.CanPop;
        }

        // Подключение к событию TextChanged
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            richTextBox1.TextChanged += (s, ev) => UpdateNavigationButtons();
        }

        [Serializable]
        public class Info
        {
            [Required(ErrorMessage = "Название предмета обязательно")]
            [StringLength(100, MinimumLength = 3, ErrorMessage = "Длина названия от 3 до 100 символов")]
            public string name { get; set; }

            [Range(16, 100, ErrorMessage = "Возраст должен быть от 16 до 100")]
            public int age { get; set; }

            [Range(0.0f, 10.0f, ErrorMessage = "Сложность должна быть от 0.0 до 10.0")]
            public float difficulty { get; set; }

            [Range(1, 50, ErrorMessage = "Количество лекций от 1 до 50")]
            public int lectures { get; set; }

            [Range(1, 100, ErrorMessage = "Количество лабораторных от 1 до 100")]
            public int labs { get; set; }

            public bool exam { get; set; }

            [FutureDate(ErrorMessage = "Дата должна быть в будущем")]
            public string date { get; set; }

            public int price { get; set; }

            [RequiredLector(ErrorMessage = "Преподаватель обязателен")]
            public Lector lector { get; set; }
        }

        // Кастомный атрибут для проверки даты
        public class FutureDateAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value is string dateStr)
                {
                    if (DateTime.TryParse(dateStr, out DateTime date))
                    {
                        return date > DateTime.Today;
                    }
                }
                return false;
            }
        }

        // Кастомный атрибут для проверки преподавателя
        public class RequiredLectorAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                return value is Lector lector && !string.IsNullOrWhiteSpace(lector.name);
            }
        }

        private void ggg(object sender, EventArgs e)
        {
            MessageBox.Show("Дмитроченко К.Д    version 1.0\n           All rights reserved");
            UpdateLastAction("О программе");
            UpdateObjectCount();
        }
        bool flag = false;
        private void Hide(object sender,EventArgs e)
        {
           if (flag==false){
                button8.Hide();
                button7.Hide();
                button6.Hide();
                button5.Hide();
                button4.Hide();
                button9.Hide();
                button10.Hide();
                button11.Hide();
                button12.Hide();
                menuStrip1.Hide();
                flag = true;
                UpdateLastAction("Строка состояния скрыта");
                UpdateObjectCount();
            }
            else
           {
                button8.Show();
                button7.Show();
                button6.Show();
                button5.Show();
                button4.Show();
                button9.Show();
                button10.Show();
                button11.Show();
                button12.Show();
                menuStrip1.Show();
                flag = false;
                UpdateLastAction("Строка состояния показана");
                UpdateObjectCount();
            }
            ;

        }

        private void Delete (object sender,EventArgs e)
        {
            string filePath = "C:\\Users\\ghigher\\Desktop\\labs-4-sem\\OOP\\3ooPorn\\test.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Info>));

            using (StreamWriter reader = new StreamWriter(filePath))
            {
                List<Info> obj = null;
                try
                {
                  serializer.Serialize(reader,obj);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка при чтении файла.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            richTextBox1.Clear();
            UpdateLastAction("Удаление информацииы");
            UpdateObjectCount();
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
            public override string ToString() => shortName;
        }

        private void InitializeStatusStrip()
        {
            statusStrip = new StatusStrip();
            lblObjectCount = new ToolStripStatusLabel();
            lblLastAction = new ToolStripStatusLabel();
            lblDateTime = new ToolStripStatusLabel();

            // Настройка внешнего вида
            lblObjectCount.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Right;
            lblLastAction.BorderStyle = Border3DStyle.Etched;
            lblDateTime.Spring = true;

            // Добавление элементов
            statusStrip.Items.AddRange(new ToolStripItem[] {
            lblObjectCount,
            lblLastAction,
            lblDateTime
        });

            // Добавление таймера для обновления времени
            timer = new Timer { Interval = 1000 };
            timer.Tick += (s, e) => lblDateTime.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            timer.Start();

            // Размещение внизу формы
            Controls.Add(statusStrip);
        }

        // Метод для обновления счётчика объектов
        private void UpdateObjectCount()
        {
            lblObjectCount.Text = $"Объектов: {GetInfoCount()}";
        }

        private int GetInfoCount()
        {
            try
            {
                var filePath = "C:\\Users\\ghigher\\Desktop\\labs-4-sem\\OOP\\3ooPorn\\test.xml";
                if (File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Open))
                    {
                        var serializer = new XmlSerializer(typeof(List<Info>));
                        return ((List<Info>)serializer.Deserialize(stream))?.Count ?? 0;
                    }
                }
                return 0;
            }
            catch { return 0; }
        }

        public void UpdateLastAction(string action)
        {
            try
            {
         
                if (string.IsNullOrEmpty(action))
                    throw new ArgumentException("Не указано действие для логирования", nameof(action));

                lblLastAction.Text = $"Последнее действие: {action}";
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine($"Ошибка аргумента: {ex.Message}");
                lblLastAction.Text = "Ошибка: некорректные входные данные";
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine($"Ошибка ссылки: {ex.Message}");
                // Восстановление состояния
                lblLastAction = new ToolStripStatusLabel();
                statusStrip.Items.Add(lblLastAction);
            }
            catch (ObjectDisposedException ex)
            {
                Debug.WriteLine($"Объект был уничтожен: {ex.Message}");
                // Повторная инициализация
                InitializeStatusStrip();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Неожиданная ошибка: {ex.Message}");
                lblLastAction.Text = $"Ошибка: {ex.GetType().Name}";
            }
            finally
            {
                // Обновление времени в любом случае
                lblDateTime.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            }
        }


        private void nameSort(object sender, EventArgs e)
        {
            string filePath = "C:\\Users\\ghigher\\Desktop\\labs-4-sem\\OOP\\3ooPorn\\test.xml";

            if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
            {
                MessageBox.Show("Файл отсутствует или пуст.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Info>));
            using (StreamReader reader = new StreamReader(filePath))
            {
                List<Info> obj;
                try
                {
                    obj = (List<Info>)serializer.Deserialize(reader) ?? new List<Info>();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка при чтении файла.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var sortedList = obj.OrderBy(info => info.name).ToList();

                richTextBox1.Text = "";
                foreach (var info in sortedList)
                {
                    richTextBox1.Text += $"Name: {info.name}\nAge: {info.age}\nDifficulty: {info.difficulty}\nLectures: {info.lectures}\nLabs: {info.labs}\nExam: {info.exam}\nDate: {info.date}\nLector: {(info.lector != null ? info.lector.name : "Unknown")}\nPrice: {info.price}\n\n\n";
                }
            }
            UpdateLastAction("Сортировка по предмету");
            UpdateObjectCount();
        }

        private void fioSort(object sender, EventArgs e)
        {
            string filePath = "C:\\Users\\ghigher\\Desktop\\labs-4-sem\\OOP\\3ooPorn\\test.xml";

            if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
            {
                MessageBox.Show("Файл отсутствует или пуст.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Info>));
            using (StreamReader reader = new StreamReader(filePath))
            {
                List<Info> obj;
                try
                {
                    obj = (List<Info>)serializer.Deserialize(reader) ?? new List<Info>();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка при чтении файла.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var sortedList = obj.OrderBy(info => info.lector != null ? info.lector.name : "").ToList();

                richTextBox1.Text = "";
                foreach (var info in sortedList)
                {
                    richTextBox1.Text += $"Name: {info.name}\nAge: {info.age}\nDifficulty: {info.difficulty}\nLectures: {info.lectures}\nLabs: {info.labs}\nExam: {info.exam}\nDate: {info.date}\nLector: {(info.lector != null ? info.lector.name : "Unknown")}\nPrice: {info.price}\n\n\n";
                }
            }
            UpdateLastAction("Сортировка по ФИО");
            UpdateObjectCount();
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
            UpdateLastAction("Действие записано в файл");
            UpdateObjectCount();
        }

        private void Validate()
        {
            

            // Создаем временный объект для валидации
            var tempInfo = new Info
            {
                name = textBox1.Text,
                age = (int)numericUpDown1.Value,
                difficulty = trackBar1.Value,
                lectures = (int)numericUpDown2.Value,
                labs = (int)numericUpDown3.Value,
                date = monthCalendar1.SelectionStart.ToShortDateString(),
                price = ((int)numericUpDown2.Value * 10 + (int)numericUpDown3.Value * 12) * (int)numericUpDown1.Value / 10,
                lector = choice
            };
            var context = new ValidationContext(tempInfo);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(tempInfo, context, results, true);

            // Очистка предыдущих ошибок
            errorProvider.Clear();

            // Вывод ошибок
            foreach (var error in results)
            {
                switch (error.MemberNames.First())
                {
                    case "name":
                        errorProvider.SetError(textBox1, error.ErrorMessage);
                        break;
                    case "age":
                        errorProvider.SetError(numericUpDown1, error.ErrorMessage);
                        break;
                    case "difficulty":
                        errorProvider.SetError(trackBar1, error.ErrorMessage);
                        break;
                    case "lectures":
                        errorProvider.SetError(numericUpDown2, error.ErrorMessage);
                        break;
                    case "labs":
                        errorProvider.SetError(numericUpDown3, error.ErrorMessage);
                        break;
                    case "date":
                        errorProvider.SetError(monthCalendar1, error.ErrorMessage);
                        break;
                    case "lector":
                        errorProvider.SetError(comboBox1, error.ErrorMessage);
                        break;
                }
            }

            button1.Enabled = isValid;
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

        private void Clear(object sender,EventArgs e)
        {
            richTextBox1.Clear();
            UpdateLastAction("Очистка вывода");
            UpdateObjectCount();
        }
        private void ladd(object sender, EventArgs e)
        {
            button2.Enabled = !textBox2.Text.Equals("")
                   & !textBox3.Text.Equals("") &
                   !textBox4.Text.Equals("");
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
            UpdateLastAction("Добавление лектора");
            UpdateObjectCount();
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
            Info info = new Info
            {
                name = textBox1.Text,
                age = (int)numericUpDown1.Value,
                difficulty = trackBar1.Value,
                lectures = (int)numericUpDown2.Value,
                labs = (int)numericUpDown3.Value,
                exam = radioButton1.Checked,
                price = ((int)numericUpDown2.Value * 10 + (int)numericUpDown3.Value * 12) * (int)numericUpDown1.Value / 10,
                date = monthCalendar1.SelectionStart.ToShortDateString(),
                lector = choice
            };
            var context = new ValidationContext(info);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(info, context, results, true))
            {
                MessageBox.Show("Ошибки валидации:\n" +
                    string.Join("\n", results.Select(r => r.ErrorMessage)),
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
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
                UpdateLastAction("Сохранение данных");
                UpdateObjectCount();
            }

         

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
            UpdateLastAction("Загрузка данных");
            UpdateObjectCount();
        }
        private bool MatchCondition(string value, string pattern, bool useRegex)
        {
            if (string.IsNullOrEmpty(value)) return false;

            if (useRegex)
            {
                try { return Regex.IsMatch(value, pattern); }
                catch { return false; }
            }
            return value.Equals(pattern, StringComparison.OrdinalIgnoreCase);
        }

        
        private string GetPropertyValue(Info info, string propertyName)
        {
            switch (propertyName)
            {
                case "Name":
                    return info.name ?? string.Empty;

                case "Age":
                    return info.age.ToString();

                case "Lectures":
                    return info.lectures.ToString();

                case "Labs":
                    return info.labs.ToString();

                case "Date":
                    return info.date?.ToString() ?? string.Empty;

                case "Lector":
                    return info.lector?.name ?? string.Empty;

                case "Difficulty":
                    return info.difficulty.ToString("F1");

                case "Price":
                    return info.price.ToString("C0");

                case "Exam":
                    return info.exam ? "Экзамен" : "Зачёт";

                default:
                    return string.Empty;
            }
        }

        private List<Info> DeserializeFromFile(string path)
        {
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Info>));
                    return (List<Info>)serializer.Deserialize(stream) ?? new List<Info>();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ошибка чтения файла", ex);
            }
        }

        // Обработчик пункта меню для поиска
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = "C:\\Users\\ghigher\\Desktop\\labs-4-sem\\OOP\\3ooPorn\\test.xml";

            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Файл данных не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var allData = DeserializeFromFile(filePath);
                if (allData == null || allData.Count == 0)
                {
                    MessageBox.Show("Файл не содержит данных", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var searchForm = new SearchForm())
                {
                    if (searchForm.ShowDialog() == DialogResult.OK)
                    {
                        var results = PerformSearch(searchForm.Conditions, allData);
                        DisplaySearchResults(results);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateLastAction("Выполнение поиска");
        }
    
        private void DisplaySearchResults(List<Info> results)
        {
            richTextBox1.Clear();

            if (results == null || results.Count == 0)
            {
                richTextBox1.Text = "Поиск не дал результатов";
                return;
            }

            var sb = new StringBuilder();
            foreach (var info in results)
            {
                sb.AppendLine($"Name: {info.name}");
                sb.AppendLine($"Age: {info.age}");
                sb.AppendLine($"Difficulty: {info.difficulty}");
                sb.AppendLine($"Lectures: {info.lectures}");
                sb.AppendLine($"Labs: {info.labs}");
                sb.AppendLine($"Exam: {info.exam}");
                sb.AppendLine($"Date: {info.date}");
                sb.AppendLine($"Price: {info.price}");
                sb.AppendLine($"Lector: {info.lector?.name ?? "Не указан"}");
                sb.AppendLine(new string('-', 40));
            }

            richTextBox1.Text = sb.ToString();
            richTextBox1.SelectionStart = 0;
            richTextBox1.ScrollToCaret();
        }
       private List<Info> PerformSearch(List<SearchForm.SearchCondition> conditions, List<Info> allData)
{
    try
    {
        var filteredData = allData;
        
        foreach (var condition in conditions)
        {
            filteredData = filteredData.Where(info => 
            {
                var value = GetPropertyValue(info, condition.Field);
                return MatchCondition(value, condition.Pattern, condition.UseRegex);
            }).ToList();
        }
        return filteredData;
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Ошибка поиска: {ex.Message}");
        return null;
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}

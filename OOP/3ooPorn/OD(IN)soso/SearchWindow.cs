using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System;

namespace OD_IN_soso
{
    public partial class SearchForm : Form
    {
        public class SearchCondition
        {
            public string Field { get; set; }
            public string Pattern { get; set; }
            public bool UseRegex { get; set; }
        }

        public List<SearchCondition> Conditions { get; private set; } = new List<SearchCondition>();
        private Panel conditionsPanel;
        private FlowLayoutPanel flowLayoutPanel1;
        private int panelTop = 10;

        public SearchForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            AddConditionPanel();
        }

        private void InitializeCustomComponents()
        {
            // Основная панель для содержимого
            var mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            // Панель для условий с прокруткой
            conditionsPanel = new Panel
            {
                Location = new Point(120, 30),
                Size = new Size(400, 300),
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom,
                AutoScroll = true,
                BorderStyle = BorderStyle.Fixed3D
            };

            // Кнопка "Добавить параметр"
            var btnAdd = new Button
            {
                Text = "Добавить параметр",
                Location = new Point(10, 30),
                Size = new Size(100, 30),
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };
            btnAdd.Click += AddConditionPanel;

            // Кнопка "Поиск"
            var btnSearch = new Button
            {
                Text = "Поиск",
                Location = new Point(10, 70),
                Size = new Size(100, 30),
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };
            btnSearch.Click += btnSearch_Click;

            // Добавляем элементы на форму
            mainPanel.Controls.Add(btnAdd);
            mainPanel.Controls.Add(btnSearch);
            mainPanel.Controls.Add(conditionsPanel);
            Controls.Add(mainPanel);

            // Настройки формы
            Text = "Поиск";
            Size = new Size(550, 400);
            StartPosition = FormStartPosition.CenterParent;
        }

        private void AddConditionPanel(object sender = null, EventArgs e = null)
        {
            var panel = new Panel
            {
                Width = conditionsPanel.Width - 30,
                Height = 80,
                Location = new Point(5, panelTop),
                BorderStyle = BorderStyle.FixedSingle
            };

            var cbField = new ComboBox
            {
                Items = { "Name", "Age", "Lectures", "Labs", "Date", "Lector" },
                SelectedIndex = 0,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 150,
                Left = 5,
                Top = 27
            };

            var tbPattern = new TextBox
            {
                Width = 200,
                Left = 160,
                Top = 27
            };

            var rbExact = new RadioButton
            {
                Text = "Точное",
                Checked = true,
                Left = 5,
                Top = 50
            };

            var rbRegex = new RadioButton
            {
                Text = "Regex",
                Left = 120,
                Top = 50
            };

            var btnRemove = new Button
            {
                Text = "Удалить",
                Left = panel.Width - 80,
                Top = 50,
                Size = new Size(70, 25)
            };

            panel.Controls.Add(new Label { Text = "Поле:", Left = 5, Top = 5 });
            panel.Controls.Add(cbField);
            panel.Controls.Add(new Label { Text = "Значение:", Left = 160, Top = 5 });
            panel.Controls.Add(tbPattern);
            panel.Controls.Add(rbExact);
            panel.Controls.Add(rbRegex);
            panel.Controls.Add(btnRemove);

            btnRemove.Click += (s, args) =>
            {
                conditionsPanel.Controls.Remove(panel);
                UpdatePanelsPosition();
            };

            conditionsPanel.Controls.Add(panel);
            panelTop += 85;
            conditionsPanel.Invalidate();
        }

        private void UpdatePanelsPosition()
        {
            panelTop = 10;
            foreach (Control control in conditionsPanel.Controls)
            {
                if (control is Panel panel)
                {
                    panel.Top = panelTop;
                    panelTop += 85;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Conditions.Clear();
            foreach (Control control in conditionsPanel.Controls)
            {
                if (control is Panel panel)
                {
                    var cbField = panel.Controls.OfType<ComboBox>().First();
                    var tbPattern = panel.Controls.OfType<TextBox>().First();
                    var useRegex = panel.Controls.OfType<RadioButton>().Last().Checked;

                    if (!string.IsNullOrEmpty(tbPattern.Text))
                    {
                        Conditions.Add(new SearchCondition
                        {
                            Field = cbField.SelectedItem.ToString(),
                            Pattern = tbPattern.Text,
                            UseRegex = useRegex
                        });
                    }
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(524, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(406, 545);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // SearchForm
            // 
            this.ClientSize = new System.Drawing.Size(955, 569);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "SearchForm";
            this.ResumeLayout(false);

        }
    }
}
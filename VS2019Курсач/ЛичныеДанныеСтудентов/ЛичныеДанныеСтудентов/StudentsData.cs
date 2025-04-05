using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ЛичныеДанныеСтудентов.Controller;


namespace ЛичныеДанныеСтудентов
{
    public partial class StudentsData : Form
    {


        Query controller;
        public StudentsData()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.ConncectStr);
            dataGridView1.DataSource = controller.UpateStudent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            controller.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
            dataGridView1.DataSource = controller.UpateStudent();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            {
                DialogResult result = MessageBox.Show("Удалить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ///Создаем диалоговое окно для подтверждения удаления

                if (result == DialogResult.Yes)
                {
                    controller.Delete(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код"].Value.ToString())); /// Удаляем запись
                    MessageBox.Show("Запись удалена.", ""); /// Получаем сообщение об удалении записи
                    dataGridView1.DataSource = controller.UpateStudent();
                }
                else if (result == DialogResult.No)
                {

                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                DialogResult = MessageBox.Show("Вы вводите неверное значение.", "Пожалуйста, введите число.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                DialogResult = MessageBox.Show("Вы вводите неверное значение.", "Пожалуйста, введите число.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                DialogResult = MessageBox.Show("Вы вводите неверное значение.", "Пожалуйста, введите число.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
        
            


    


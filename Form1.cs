using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лабораторная_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1_Load(null, null);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Исходный массив: ";
            label2.Text = "Изменённый массив: ";
            label3.Text = "Введите количество цифр в массиве: ";
            button1.Text = "Создать массив";
            button1.Click += button1_Click;
            button2.Text = "Преобразовать";
            button2.Click += button2_Click;
            button3.Text = "Очистить";
            button3.Click += button3_Click;

        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // Глобальная переменная видна всем методам
        int[] massiv;
        private void button1_Click(object sender, EventArgs e)
        {
            // Очищаем элементы управления
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            // Проверяем, что пользователь ввел корректное значение
            if (!int.TryParse(textBox1.Text, out int size) || size <= 0)
            {
                MessageBox.Show("Введите корректное количество чисел в массиве.");
                return;
            }

            // Инициализируем класс случайных чисел
            Random rand = new Random();

            // Инициализируем массив с заданным размером
            massiv = new int[size];

            // Генерируем и выводим элементы массива
            for (int i = 0; i < size; i++)
            {
                massiv[i] = rand.Next(0, 100); // генерируем случайное число от 0 до 99
                listBox1.Items.Add("Mas[" + i.ToString() + "] = " + massiv[i].ToString());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Проверяем, что массив был инициализирован
            if (massiv == null)
            {
                MessageBox.Show("Сначала сгенерируйте массив.");
                return;
            }

            // Очищаем элемент управления
            listBox2.Items.Clear();

            int maxIndex = 0; // переменная для хранения индекса наибольшего элемента

            // Находим индекс наибольшего элемента в массиве
            for (int i = 1; i < massiv.Length; i++)
            {
                if (massiv[i] > massiv[maxIndex])
                {
                    maxIndex = i;
                }
            }

            // Меняем местами наибольший элемент и первый элемент массива
            int temp = massiv[0];
            massiv[0] = massiv[maxIndex];
            massiv[maxIndex] = temp;

            // Выводим измененный массив
            for (int i = 0; i < massiv.Length; i++)
            {
                listBox2.Items.Add("Mas[" + i.ToString() + "] = " + massiv[i].ToString());
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Text = "";
        }
    }
}
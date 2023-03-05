using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganography
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void download_Click(object sender, EventArgs e)
        {
            picture2.Image = null;
            if (src.Text.Equals(""))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Files (*.jpg, *.png)|*.jpg; *.png|Files (*.jpg)|*.jpg|Files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    src.Text = openFileDialog.FileName;
                }
            }
            if (!src.Text.Equals(""))
            {
                picture1.Image = Image.FromFile(src.Text);
            }
        }

        private void downloadDec_Click(object sender, EventArgs e)
        {
            picture1.Image = null;
            if (src.Text.Equals(""))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Files (*.jpg, *.png)|*.jpg; *.png|Files (*.jpg)|*.jpg|Files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    src.Text = openFileDialog.FileName;
                }
            }
            if (!src.Text.Equals(""))
            {
                picture2.Image = Image.FromFile(src.Text);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (picture2.Image != null) //если в pictureBox есть изображение
            {
                //создание диалогового окна "Сохранить как..", для сохранения изображения
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.InitialDirectory = "c:\\";
                savedialog.Title = "Сохранить картинку как...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                savedialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                savedialog.Filter = "Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                //отображается ли кнопка "Справка" в диалоговом окне
                savedialog.ShowHelp = true;
                savedialog.FileName = "Picture.png";
                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        picture2.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void coding_Click(object sender, EventArgs e)
        {
            if(picture1.Image == null) // Если изображение не было загружено
            {
                var location = Application.StartupPath;
                var path = Path.GetDirectoryName(location);
                picture1.Image = Image.FromFile(Path.GetDirectoryName(path) + "\\img\\ph.jpg"); // Загрузка стандартного изображения
            }

            Image img = picture1.Image;
            Bitmap bitmap = new Bitmap(img);

            int nBytes = (byte)text1.Text.Length * 2; // Кол-во байт в тексте
            byte[] bytesText = new byte[nBytes + 1]; // Создание масства байт
            bytesText[0] = (byte)nBytes; // 1 байт - длина кодируемого текста 
            Encoding.UTF8.GetBytes(text1.Text, 0, text1.Text.Length, bytesText, 1); // Кодирует набор символов из заданного объекта в указанный массив байтов
            //(Объект, Индекс первого кодируемого символа, Число кодируемых символов, Массив байтовИндекс, с которого начинается запись)

            int positionBytes = 0;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for(int j = 0; j < bitmap.Height; j++)
                {
                    if (bytesText.Length == positionBytes) // При достижении конца текста, вывод получившийся картинки
                    {
                        picture2.Image = Image.FromHbitmap(bitmap.GetHbitmap());
                        return;                        
                    }

                    Color pixelColor = bitmap.GetPixel(i, j); // Получение цвета пикселя

                    byte r = (byte)((pixelColor.R & 248) | (bytesText[positionBytes] >> 0) & 7); // Изменение 3 младших значимых битов в цвете R на 3 бита кодируемого текста
                    byte g = (byte)((pixelColor.G & 248) | (bytesText[positionBytes] >> 3) & 7); // Изменение 3 младших значимых битов в цвете G на 3 бита кодируемого текста
                    byte b = (byte)((pixelColor.B & 252) | (bytesText[positionBytes] >> 6) & 3); // Изменение 2 младших значимых битов в цвете B на 2 бита кодируемого текста
                    positionBytes++;

                    bitmap.SetPixel(i, j, Color.FromArgb(r, g, b)); // Замена оригинальных пикселей на изменённые
                }
            }
            MessageBox.Show("Длина строки слишком большая");
        }

        private void decoding_Click(object sender, EventArgs e)
        {
            if (picture2.Image != null) // Если изображение загружено
            {
                Image img = picture2.Image; // Получение изображение с зашифрованным текстом
                Bitmap bitmap = new Bitmap(img);

                Color pixel1 = bitmap.GetPixel(0, 0); // Получение первого пикселя, в котором зашифрована длина текста
                int length = (int)(((pixel1.B & 3) << 6) | ((pixel1.G & 7) << 3)| ((pixel1.R & 7) << 0)); // Получение длины

                byte[] bytesText = new byte[length]; // Создание массива битов для текста
                
                int positionBytes = 0; // Положение в тексе
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 1; j < bitmap.Height; j++)
                    {
                        if (bytesText.Length == positionBytes)
                        {
                            text2.Text = Encoding.UTF8.GetString(bytesText, 0, length); // Вывод полученного текста
                            return;
                        }                           

                        Color clrPixelModified = bitmap.GetPixel(i, j);
                        byte bitsR = (byte)((clrPixelModified.R & 7) << 0); // Получение бит из красного цвета
                        byte bitsG = (byte)((clrPixelModified.G & 7) << 3); // Получение бит из зелёного цвета
                        byte bitsB = (byte)((clrPixelModified.B & 3) << 6); // Получение бит из синего цвета

                        bytesText[positionBytes] = (byte)(bitsR | bitsG | bitsB); // Объединение бит в байт
                        positionBytes++;
                    }
                }
            }            
        }
    }
}

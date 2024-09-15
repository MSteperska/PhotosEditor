using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt1_testy
{
    public partial class Form1 : Form
    {
        //  variables for image cropping
        private Rectangle cropRectangle;
        private Point startPoint;
        private Point endPoint;
        private bool isDragging = false;
        private Image originalImage;

        //  variables for image scaling
        private float W_ratio;
        private float H_ratio;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  // loading image
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Obrazy (*.jpg;*.jpeg;*.png;*.bmp;*.jfif)|*.jpg;*.jpeg;*.png;*.bmp;*.jfif";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog () == DialogResult.OK)
            {
                try
                {
                    // Pobranie ścieżki do wybranego pliku
                    string selectedFilePath = ofd.FileName;

                    // Zwolnienie poprzedniego obrazka, jeśli istnieje
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }

                    // Wczytanie nowego obrazka i wyświetlenie go w PictureBox
                    originalImage = Image.FromFile(selectedFilePath);
                    pictureBox1.Image = new Bitmap(originalImage);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    //  wyświetlenie rozmiarów obrazka
                    update_ImageSizeLabel(pictureBox1.Image.Width, pictureBox1.Image.Height);

                }
                catch (OutOfMemoryException ex)
                {
                    MessageBox.Show("Błąd: Nie można załadować obrazka. Pamięć jest niewystarczająca.", "Błąd pamięci", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd: Nie można załadować obrazka. " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
        }

        private void button2_Click(object sender, EventArgs e)  //crop image
        {
            pictureBox1.Enabled = true;

            if (pictureBox1.Image == null || cropRectangle.Width == 0 || cropRectangle.Height == 0)
                return;


            if(pictureBox1.Image != null && cropRectangle != Rectangle.Empty)
            {
                Bitmap originalImage = new Bitmap(pictureBox1.Image);
                Bitmap croppedImage = originalImage.Clone(cropRectangle, originalImage.PixelFormat);

                pictureBox1.Image.Dispose();
                pictureBox1.Image = croppedImage;              

                cropRectangle = Rectangle.Empty;
                pictureBox1.Invalidate();

            }
           
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(pictureBox1 == null)
                return;

            isDragging = true;
            startPoint = e.Location;
            cropRectangle = new Rectangle(startPoint, new Size(0, 0));
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging)
                return;

            endPoint = e.Location;
            cropRectangle = new Rectangle(Math.Min(startPoint.X, endPoint.X),
                                     Math.Min(startPoint.Y, endPoint.Y),
                                     Math.Abs(startPoint.X - endPoint.X),
                                     Math.Abs(startPoint.Y - endPoint.Y));

            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;

            if (pictureBox1.Image == null || cropRectangle.Width == 0 || cropRectangle.Height == 0)
                return;

            // Przekształcenie cropRect do współrzędnych obrazu
            Rectangle imageRect = GetImageRectangleInPictureBox();
            cropRectangle = TransformRectangleToImageCoordinates(cropRectangle, imageRect, pictureBox1.Image.Size);

            // Przycięcie obrazka
            Bitmap originalBitmap = new Bitmap(pictureBox1.Image);
            Bitmap croppedImage = originalBitmap.Clone(cropRectangle, originalBitmap.PixelFormat);

            originalImage.Dispose();
            originalImage = croppedImage;

            pictureBox1.Image.Dispose();
            pictureBox1.Image = croppedImage;
            update_ImageSizeLabel(cropRectangle.Width, cropRectangle.Height);

            cropRectangle = Rectangle.Empty;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (cropRectangle != Rectangle.Empty)
            {
                using (Pen pen = new Pen(Color.Blue, 1))
                {
                    e.Graphics.DrawRectangle(pen, cropRectangle);
                }
            }
        }
        private Rectangle AdjustRectangleToBounds(Rectangle rect, Bitmap image)
        {
            int x = Math.Max(rect.X, 0);
            int y = Math.Max(rect.Y, 0);
            int width = Math.Min(rect.Width, image.Width - x);
            int height = Math.Min(rect.Height, image.Height - y);

            return new Rectangle(x, y, width, height);
        }


        private Rectangle GetImageRectangleInPictureBox()
        {
            if (pictureBox1.Image == null)
                return Rectangle.Empty;

            float imageAspectRatio = (float)pictureBox1.Image.Width / pictureBox1.Image.Height;
            float controlAspectRatio = (float)pictureBox1.Width / pictureBox1.Height;

            int imageWidth, imageHeight;

            if (imageAspectRatio > controlAspectRatio)
            {
                imageWidth = pictureBox1.Width;
                imageHeight = (int)(pictureBox1.Width / imageAspectRatio);
            }
            else
            {
                imageWidth = (int)(pictureBox1.Height * imageAspectRatio);
                imageHeight = pictureBox1.Height;
            }

            int x = (pictureBox1.Width - imageWidth) / 2;
            int y = (pictureBox1.Height - imageHeight) / 2;

            return new Rectangle(x, y, imageWidth, imageHeight);
        }


        private Rectangle TransformRectangleToImageCoordinates(Rectangle rect, Rectangle imageRect, Size imageSize)
        {
            // Przekształcenie współrzędnych z PictureBox do współrzędnych obrazu
            float xRatio = (float)imageSize.Width / imageRect.Width;
            float yRatio = (float)imageSize.Height / imageRect.Height;

            int x = (int)((rect.X - imageRect.X) * xRatio);
            int y = (int)((rect.Y - imageRect.Y) * yRatio);
            int width = (int)(rect.Width * xRatio);
            int height = (int)(rect.Height * yRatio);

            return new Rectangle(x, y, width, height);
        }

        private void SaveImageButton_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image == null)
                return;

            if (pictureBox1.Image != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    // Ustawienie właściwości dialogu zapisu pliku
                    saveFileDialog.Filter = "Obrazy (*.jpg;*.jpeg;*.png;*.bmp;*.jfif)|*.jpg;*.jpeg;*.png;*.bmp;*.jfif";
                    saveFileDialog.Title = "Wybierz lokalizację zapisu";
                    saveFileDialog.FileName = "saved_image.png"; // Domyślna nazwa pliku

                    // Jeśli użytkownik wybrał lokalizację i kliknął "OK"
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Utwórz obiekt Bitmap na podstawie obrazu z PictureBox
                        Bitmap imageToSave = new Bitmap(pictureBox1.Image);

                        // Zapisz obraz do wybranej lokalizacji z dialogu
                        imageToSave.Save(saveFileDialog.FileName);

                        MessageBox.Show($"Obraz został zapisany jako {Path.GetFileName(saveFileDialog.FileName)}", "Zapisano obraz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // SCALE IMAGE

        private void WidthInput_ValueChanged(object sender, EventArgs e)
        {
            W_ratio = (float)WidthInput.Value;
        }

        private void HeightInput_ValueChanged(object sender, EventArgs e)
        {
            H_ratio = (float)HeightInput.Value;
        }

        private void ScaleButton_Click(object sender, EventArgs e)
        {
            //skalowanie obrazu
            if ((W_ratio == 0 && H_ratio == 0) || pictureBox1 == null)
                return;
            else
            {
                // new image size
                int new_w = (int)(pictureBox1.Image.Width * W_ratio);
                int new_h = (int)(pictureBox1.Image.Height * H_ratio);

                Bitmap originalImage = new Bitmap(pictureBox1.Image);
                //originalImage.Height = H;
                Bitmap scaledBitmap = new Bitmap(new_w, new_h);

                // Utworzenie obiektu Graphics na podstawie nowej bitmapy
                using (Graphics g = Graphics.FromImage(scaledBitmap))
                {
                    // Ustawienie jakości skalowania
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                    // Skalowanie obrazu i rysowanie na nowej bitmapie
                    g.DrawImage(originalImage, 0, 0, new_w, new_h);
                }
                pictureBox1.Image.Dispose();
                pictureBox1.Image = scaledBitmap;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                update_ImageSizeLabel(new_w, new_h);
                pictureBox1.Invalidate();
            }
        }

        private void FlipButton_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Refresh();

                update_ImageSizeLabel(pictureBox1.Image.Width, pictureBox1.Image.Height);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;    // do wylaczenia przycinania
        }

        private void MirrorImageButton_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pictureBox1.Refresh();
                update_ImageSizeLabel(pictureBox1.Image.Width, pictureBox1.Image.Height);
            }
        }

        private void update_ImageSizeLabel(int w, int h)
        {
            ImageSizeLabel.Text = w + " x" + h;
        }
    }
}


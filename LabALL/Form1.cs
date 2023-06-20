using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap OriginalImage;
        Bitmap FiltedImage;
        int[,,] ImageAsATable;


        private void button1_Click(object sender, EventArgs e)
        {

            string ImageName = "";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImageName = openFileDialog1.FileName;
                button11.Enabled = false;
                button12.Enabled = false;
            }

            OriginalImage = new Bitmap(ImageName, true);
            FiltedImage = new Bitmap(ImageName, true);

            pictureBox1.Image = OriginalImage;

            textBox1.Text = ImageName;



            ImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height]; // 0 Red, 1 Green,2 Blue

            for (int i = 0; i < OriginalImage.Width; i++)
            {

                for (int j = 0; j < OriginalImage.Height; j++)
                {
                    ImageAsATable[0, i, j] = OriginalImage.GetPixel(i, j).R;
                    ImageAsATable[1, i, j] = OriginalImage.GetPixel(i, j).G;
                    ImageAsATable[2, i, j] = OriginalImage.GetPixel(i, j).B;
                }

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];

            for (int i = 0; i < OriginalImage.Width; i++)
            {

                for (int j = 0; j < OriginalImage.Height; j++)
                {

                    FiltedImageAsATable[0, i, j] = (int)((ImageAsATable[0, i, j] + ImageAsATable[1, i, j]) / 2);
                    FiltedImageAsATable[1, i, j] = (int)((ImageAsATable[0, i, j] + ImageAsATable[2, i, j]) / 2);
                    FiltedImageAsATable[2, i, j] = (int)((ImageAsATable[2, i, j] + ImageAsATable[1, i, j]) / 2);

                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATable[t, i, j] > 255) FiltedImageAsATable[t, i, j] = 255;
                        if (FiltedImageAsATable[t, i, j] < 0) FiltedImageAsATable[t, i, j] = 0;
                    }

                }
            }

            DesignImage(FiltedImageAsATable, pictureBox2);




        }

        private void DesignImage(int[,,] FiltedImageAsATable, PictureBox ToDispay)
        {
            Color Temp;
            FiltedImage = new Bitmap(OriginalImage.Width, OriginalImage.Height);

            for (int i = 0; i < FiltedImage.Width; i++)
            {
                for (int j = 0; j < FiltedImage.Height; j++)
                {
                    Temp = Color.FromArgb(FiltedImageAsATable[0, i, j], FiltedImageAsATable[1, i, j], FiltedImageAsATable[2, i, j]);
                    FiltedImage.SetPixel(i, j, Temp);

                }

            }

            ToDispay.Image = FiltedImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];

            for (int i = 0; i < OriginalImage.Width; i++)
            {

                for (int j = 0; j < OriginalImage.Height; j++)
                {

                    FiltedImageAsATable[0, i, j] = (int)ImageAsATable[1, i, j];
                    FiltedImageAsATable[1, i, j] = (int)ImageAsATable[2, i, j];
                    FiltedImageAsATable[2, i, j] = (int)ImageAsATable[0, i, j];

                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATable[t, i, j] > 255) FiltedImageAsATable[t, i, j] = 255;
                        if (FiltedImageAsATable[t, i, j] < 0) FiltedImageAsATable[t, i, j] = 0;
                    }

                }
            }

            DesignImage(FiltedImageAsATable, pictureBox2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];

            int Ch = comboBox1.SelectedIndex;

            for (int i = 0; i < OriginalImage.Width; i++)
            {

                for (int j = 0; j < OriginalImage.Height; j++)
                {

                    FiltedImageAsATable[0, i, j] = (int)ImageAsATable[Ch, i, j];
                    FiltedImageAsATable[1, i, j] = (int)ImageAsATable[Ch, i, j];
                    FiltedImageAsATable[2, i, j] = (int)ImageAsATable[Ch, i, j];

                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATable[t, i, j] > 255) FiltedImageAsATable[t, i, j] = 255;
                        if (FiltedImageAsATable[t, i, j] < 0) FiltedImageAsATable[t, i, j] = 0;
                    }

                }
            }

            DesignImage(FiltedImageAsATable, pictureBox2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];

            for (int i = 0; i < OriginalImage.Width; i++)
            {

                for (int j = 0; j < OriginalImage.Height; j++)
                {

                    FiltedImageAsATable[0, i, j] = ImageAsATable[1, i, j];
                    FiltedImageAsATable[1, i, j] = ImageAsATable[1, i, j];
                    FiltedImageAsATable[2, i, j] = ImageAsATable[1, i, j];

                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATable[t, i, j] > 255) FiltedImageAsATable[t, i, j] = 255;
                        if (FiltedImageAsATable[t, i, j] < 0) FiltedImageAsATable[t, i, j] = 0;
                    }

                }
            }

            DesignImage(FiltedImageAsATable, pictureBox2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];

            for (int i = 0; i < OriginalImage.Width; i++)
            {

                for (int j = 0; j < OriginalImage.Height; j++)
                {

                    FiltedImageAsATable[0, i, j] = (int)(ImageAsATable[0, i, j] + ImageAsATable[1, i, j] + ImageAsATable[2, i, j]) / 3;
                    FiltedImageAsATable[1, i, j] = (int)(ImageAsATable[0, i, j] + ImageAsATable[1, i, j] + ImageAsATable[2, i, j]) / 3;
                    FiltedImageAsATable[2, i, j] = (int)(ImageAsATable[0, i, j] + ImageAsATable[1, i, j] + ImageAsATable[2, i, j]) / 3;


                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATable[t, i, j] > 255) FiltedImageAsATable[t, i, j] = 255;
                        if (FiltedImageAsATable[t, i, j] < 0) FiltedImageAsATable[t, i, j] = 0;
                    }

                }
            }

            DesignImage(FiltedImageAsATable, pictureBox2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATableR = new int[3, OriginalImage.Width, OriginalImage.Height];
            int[,,] FiltedImageAsATableG = new int[3, OriginalImage.Width, OriginalImage.Height];
            int[,,] FiltedImageAsATableB = new int[3, OriginalImage.Width, OriginalImage.Height];


            for (int i = 0; i < OriginalImage.Width; i++)
            {

                for (int j = 0; j < OriginalImage.Height; j++)
                {

                    FiltedImageAsATableR[0, i, j] = ImageAsATable[0, i, j];
                    FiltedImageAsATableR[1, i, j] = ImageAsATable[0, i, j];
                    FiltedImageAsATableR[2, i, j] = ImageAsATable[0, i, j];

                    FiltedImageAsATableG[0, i, j] = ImageAsATable[1, i, j];
                    FiltedImageAsATableG[1, i, j] = ImageAsATable[1, i, j];
                    FiltedImageAsATableG[2, i, j] = ImageAsATable[1, i, j];

                    FiltedImageAsATableB[0, i, j] = ImageAsATable[2, i, j];
                    FiltedImageAsATableB[1, i, j] = ImageAsATable[2, i, j];
                    FiltedImageAsATableB[2, i, j] = ImageAsATable[2, i, j];



                }
            }

            DesignImage(FiltedImageAsATableR, pictureBox3);
            DesignImage(FiltedImageAsATableG, pictureBox4);
            DesignImage(FiltedImageAsATableB, pictureBox5);



        }

        private void button8_Click(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATableR = new int[3, OriginalImage.Width, OriginalImage.Height];
            int[,,] FiltedImageAsATableG = new int[3, OriginalImage.Width, OriginalImage.Height];
            int[,,] FiltedImageAsATableB = new int[3, OriginalImage.Width, OriginalImage.Height];


            for (int i = 0; i < OriginalImage.Width; i++)
            {

                for (int j = 0; j < OriginalImage.Height; j++)
                {

                    FiltedImageAsATableR[0, i, j] = ImageAsATable[0, i, j];
                    FiltedImageAsATableR[1, i, j] = 0;
                    FiltedImageAsATableR[2, i, j] = 0;

                    FiltedImageAsATableG[0, i, j] = 0;
                    FiltedImageAsATableG[1, i, j] = ImageAsATable[1, i, j];
                    FiltedImageAsATableG[2, i, j] = 0;

                    FiltedImageAsATableB[0, i, j] = 0;
                    FiltedImageAsATableB[1, i, j] = 0;
                    FiltedImageAsATableB[2, i, j] = ImageAsATable[2, i, j];



                }
            }

            DesignImage(FiltedImageAsATableR, pictureBox3);
            DesignImage(FiltedImageAsATableG, pictureBox4);
            DesignImage(FiltedImageAsATableB, pictureBox5);

        }

        private void button9_Click(object sender, EventArgs e)
        {

            int[,,] FiltedImageAsATableR = new int[3, OriginalImage.Width, OriginalImage.Height];
            int[,,] FiltedImageAsATableG = new int[3, OriginalImage.Width, OriginalImage.Height];
            int[,,] FiltedImageAsATableB = new int[3, OriginalImage.Width, OriginalImage.Height];


            for (int i = 0; i < OriginalImage.Width; i++)
            {

                for (int j = 0; j < OriginalImage.Height; j++)
                {

                    FiltedImageAsATableR[0, i, j] =   255-   ImageAsATable[0, i, j];
                    FiltedImageAsATableR[1, i, j] = 255 - ImageAsATable[0, i, j];
                    FiltedImageAsATableR[2, i, j] = 255 - ImageAsATable[0, i, j];

                    FiltedImageAsATableG[0, i, j] = 255 - ImageAsATable[1, i, j];
                    FiltedImageAsATableG[1, i, j] = 255 - ImageAsATable[1, i, j];
                    FiltedImageAsATableG[2, i, j] = 255 - ImageAsATable[1, i, j];

                    FiltedImageAsATableB[0, i, j] = 255 - ImageAsATable[2, i, j];
                    FiltedImageAsATableB[1, i, j] = 255 - ImageAsATable[2, i, j];
                    FiltedImageAsATableB[2, i, j] = 255 - ImageAsATable[2, i, j];



                }
            }

            DesignImage(FiltedImageAsATableR, pictureBox8);
            DesignImage(FiltedImageAsATableG, pictureBox7);
            DesignImage(FiltedImageAsATableB, pictureBox6);
        }

        double[] Lum1 = new double[256];

        private void button10_Click(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];

            CreateGrayscaleY(FiltedImageAsATable);
            DesignImage(FiltedImageAsATable, pictureBox2);
            button11.Enabled = true;
            button12.Enabled = true;
        }

        private void CreateGrayscaleY(int[,,] FiltedImageAsATable)
        {
           
            for (int i = 0; i < 255; i++)
            {

                Lum1[i] = 0;
            }


            for (int i = 0; i < OriginalImage.Width; i++)
            {

                for (int j = 0; j < OriginalImage.Height; j++)
                {
                    int Y = (int)(0.299 * ImageAsATable[0, i, j] + 0.587 * ImageAsATable[1, i, j] + 0.114 * ImageAsATable[2, i, j]);
                    FiltedImageAsATable[0, i, j] = Y;
                    FiltedImageAsATable[1, i, j] = Y;
                    FiltedImageAsATable[2, i, j] = Y;

                    Lum1[Y] += 1;

                }
            }

           
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATableR = new int[3, OriginalImage.Width, OriginalImage.Height];
            int[,,] FiltedImageAsATableG = new int[3, OriginalImage.Width, OriginalImage.Height];
            int[,,] FiltedImageAsATableB = new int[3, OriginalImage.Width, OriginalImage.Height];

            double Theta = 0;
            double S;
            double I;
            double Fmelos;
            double Smelos;
            int H;
            int s;
            int Ia;


            for (int i = 0; i < OriginalImage.Width; i++)
            {

                for (int j = 0; j < OriginalImage.Height; j++)
                {

                    Theta = Math.Acos((0.5 * ((ImageAsATable[0, i, j] - ImageAsATable[1, i, j]) + (ImageAsATable[0, i, j] - ImageAsATable[2, i, j]))) / (Math.Pow((Math.Pow((ImageAsATable[0, i, j] - ImageAsATable[1, i, j]), 2) + (ImageAsATable[0, i, j] - ImageAsATable[2, i, j]) * (ImageAsATable[1, i, j] - ImageAsATable[2, i, j])), 0.5)));


                    if (ImageAsATable[2, i, j] <= ImageAsATable[1, i, j])
                    {
                        Theta = Theta;
                    }
                    else if (ImageAsATable[2, i, j] > ImageAsATable[1, i, j])
                    {
                        Theta = 360.000 - Theta;
                    }


                    //S = 1 - ((3 / (ImageAsATable[0, i, j] + ImageAsATable[1, i, j] + ImageAsATable[2, i, j])) * Math.Min(ImageAsATable[0, i, j], Math.Min(ImageAsATable[1, i, j], ImageAsATable[2, i, j])));

                    Fmelos = (3 / (ImageAsATable[0, i, j] + ImageAsATable[1, i, j] + ImageAsATable[2, i, j] + 0.000001));
                    Smelos = Math.Min(ImageAsATable[0, i, j], Math.Min(ImageAsATable[1, i, j], ImageAsATable[2, i, j]));
                    S = 1 - (Fmelos * Smelos);


                    I = ((ImageAsATable[0, i, j] + ImageAsATable[1, i, j] + ImageAsATable[2, i, j]) / 3);



                    H = (int)(Theta * 255 / 360);
                    s = (int)(S * 255);
                    Ia = (int)I;



                    // ** Σε ορισμένες εικόνες εχώ πρόβλημα με το Η μου για αυτό το έχω σε σχόλεια γιατί τα άλλα μου δουλέυουν με χαρά **
                    FiltedImageAsATableR[0, i, j] = (int)(H);
                    FiltedImageAsATableR[1, i, j] = (int)(H);
                    FiltedImageAsATableR[2, i, j] = (int)(H);

                    FiltedImageAsATableG[0, i, j] = (int)(s);
                    FiltedImageAsATableG[1, i, j] = (int)(s);
                    FiltedImageAsATableG[2, i, j] = (int)(s);

                    FiltedImageAsATableB[0, i, j] = (int)(Ia);
                    FiltedImageAsATableB[1, i, j] = (int)(Ia);
                    FiltedImageAsATableB[2, i, j] = (int)(Ia);


                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATableR[t, i, j] > 255) FiltedImageAsATableR[t, i, j] = 255;
                        if (FiltedImageAsATableR[t, i, j] < 0) FiltedImageAsATableR[t, i, j] = 0;
                    }

                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATableG[t, i, j] > 255) FiltedImageAsATableG[t, i, j] = 255;
                        if (FiltedImageAsATableG[t, i, j] < 0) FiltedImageAsATableG[t, i, j] = 0;
                    }

                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATableB[t, i, j] > 255) FiltedImageAsATableB[t, i, j] = 255;
                        if (FiltedImageAsATableB[t, i, j] < 0) FiltedImageAsATableB[t, i, j] = 0;
                    }
                }
            }

            DesignImage(FiltedImageAsATableR, pictureBox11);
            DesignImage(FiltedImageAsATableG, pictureBox10);
            DesignImage(FiltedImageAsATableB, pictureBox9);
        }

        private void button11_Click(object sender, EventArgs e)
        {

            double[] CPLum = new double[256];

            for (int i = 0; i < 255; i++)
            {

                Lum1[i] = Lum1[i] / (OriginalImage.Width * OriginalImage.Height);

                if (i > 0)
                {
                    CPLum[i] = Lum1[i] + CPLum[i - 1];
                }
                else CPLum[0] = Lum1[0];



            }

            for (int i = 0; i < 255; i++)
            {

                CPLum[i] = 255 * CPLum[i];

            }


            // same shit

            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];

            for (int i = 0; i < OriginalImage.Width; i++)
            {

                for (int j = 0; j < OriginalImage.Height; j++)
                {

                    int Y = (int)(0.299 * ImageAsATable[0, i, j] + 0.587 * ImageAsATable[1, i, j] + 0.114 * ImageAsATable[2, i, j]);


                    FiltedImageAsATable[0, i, j] = (int)CPLum[Y];
                    FiltedImageAsATable[1, i, j] = (int)CPLum[Y];
                    FiltedImageAsATable[2, i, j] = (int)CPLum[Y];


                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATable[t, i, j] > 255) FiltedImageAsATable[t, i, j] = 255;
                        if (FiltedImageAsATable[t, i, j] < 0) FiltedImageAsATable[t, i, j] = 0;
                    }

                }
            }

            DesignImage(FiltedImageAsATable, pictureBox2);



        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];


            int Y;
            int Thre = trackBar1.Value;
            int Width = OriginalImage.Width;
            int Height = OriginalImage.Height;

            for (int i = 0; i < Width; i++)
            {

                for (int j = 0; j < Height; j++)
                {

                    Y = (int)(0.299 * ImageAsATable[0, i, j] + 0.587 * ImageAsATable[1, i, j] + 0.114 * ImageAsATable[2, i, j]);

                    if (Y > Thre)
                    {
                        FiltedImageAsATable[0, i, j] = 255;
                        FiltedImageAsATable[1, i, j] = 255;
                        FiltedImageAsATable[2, i, j] = 255;
                    }
                    else
                    {
                        FiltedImageAsATable[0, i, j] = 0;
                        FiltedImageAsATable[1, i, j] = 0;
                        FiltedImageAsATable[2, i, j] = 0;

                    }


                }
            }

            DesignImage(FiltedImageAsATable, pictureBox2);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];


            double Pixels = (OriginalImage.Width * OriginalImage.Height);
            double AverageLum = 0;
            for (int i = 0; i < 255; i++)
            {

                AverageLum += Lum1[i]*i/ Pixels;
            }



            //skata

            int Y;

            int Width = OriginalImage.Width;
            int Height = OriginalImage.Height;


            for (int i = 0; i < Width; i++)
            {

                for (int j = 0; j < Height; j++)
                {

                    Y = (int)(0.299 * ImageAsATable[0, i, j] + 0.587 * ImageAsATable[1, i, j] + 0.114 * ImageAsATable[2, i, j]);

                    if (Y > AverageLum)
                    {
                        FiltedImageAsATable[0, i, j] = 255;
                        FiltedImageAsATable[1, i, j] = 255;
                        FiltedImageAsATable[2, i, j] = 255;
                    }
                    else
                    {
                        FiltedImageAsATable[0, i, j] = 0;
                        FiltedImageAsATable[1, i, j] = 0;
                        FiltedImageAsATable[2, i, j] = 0;

                    }


                }
            }

            DesignImage(FiltedImageAsATable, pictureBox2);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int[,] M = new int[3, 3];

            M[0, 0] = 10;
            M[0, 1] = 10;
            M[0, 2] = 10;
            M[1, 0] = 10;
            M[1, 1] = 10;
            M[1, 2] = 10;
            M[2, 0] = 10;
            M[2, 1] = 10;
            M[2, 2] = 10;

            int SPrime = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    SPrime += M[i, j];

                }
            }


            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];

            for (int i = 1; i < OriginalImage.Width-1; i++)
            {

                for (int j = 1; j < OriginalImage.Height-1; j++)
                {

                    FiltedImageAsATable[0, i, j] =

                        (int)((ImageAsATable[0, i - 1, j - 1] * M[0, 0] +
                        ImageAsATable[0, i - 1, j] * M[0, 1] +
                        ImageAsATable[0, i - 1, j + 1] * M[0, 2] +

                        ImageAsATable[0, i, j - 1] * M[1, 0] +
                        ImageAsATable[0, i, j] * M[1, 1] +
                        ImageAsATable[0, i, j + 1] * M[1, 2] +

                        ImageAsATable[0, i + 1, j - 1] * M[2, 0] +
                        ImageAsATable[0, i + 1, j] * M[2, 1] +
                        ImageAsATable[0, i + 1, j + 1] * M[2, 2])/ SPrime);


                    FiltedImageAsATable[1, i, j] =

                        (int)((ImageAsATable[1, i - 1, j - 1] * M[0, 0] +
                        ImageAsATable[1, i - 1, j] * M[0, 1] +
                        ImageAsATable[1, i - 1, j + 1] * M[0, 2] +

                        ImageAsATable[1, i, j - 1] * M[1, 0] +
                        ImageAsATable[1, i, j] * M[1, 1] +
                        ImageAsATable[1, i, j + 1] * M[1, 2] +

                        ImageAsATable[1, i + 1, j - 1] * M[2, 0] +
                        ImageAsATable[1, i + 1, j] * M[2, 1] +
                        ImageAsATable[1, i + 1, j + 1] * M[2, 2]) / SPrime);



                    FiltedImageAsATable[2, i, j] =

                        (int)((ImageAsATable[2, i - 1, j - 1] * M[0, 0] +
                        ImageAsATable[2, i - 1, j] * M[0, 1] +
                        ImageAsATable[2, i - 1, j + 1] * M[0, 2] +

                        ImageAsATable[2, i, j - 1] * M[1, 0] +
                        ImageAsATable[2, i, j] * M[1, 1] +
                        ImageAsATable[2, i, j + 1] * M[1, 2] +

                        ImageAsATable[2, i + 1, j - 1] * M[2, 0] +
                        ImageAsATable[2, i + 1, j] * M[2, 1] +
                        ImageAsATable[2, i + 1, j + 1] * M[2, 2]) / SPrime);




                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATable[t, i, j] > 255) FiltedImageAsATable[t, i, j] = 255;
                        if (FiltedImageAsATable[t, i, j] < 0) FiltedImageAsATable[t, i, j] = 0;
                    }

                }
            }

            DesignImage(FiltedImageAsATable, pictureBox2);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int[,] M = new int[3, 3];

            M[0, 0] = Convert.ToInt32(textBox2.Text);
            M[0, 1] = Convert.ToInt32(textBox3.Text);
            M[0, 2] = Convert.ToInt32(textBox4.Text);
            M[1, 0] = Convert.ToInt32(textBox5.Text);
            M[1, 1] = Convert.ToInt32(textBox6.Text);
            M[1, 2] = Convert.ToInt32(textBox7.Text);
            M[2, 0] = Convert.ToInt32(textBox8.Text);
            M[2, 1] = Convert.ToInt32(textBox9.Text);
            M[2, 2] = Convert.ToInt32(textBox10.Text);

            int SPrime = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    SPrime += M[i, j];

                }
            }

            if (SPrime <= 0) SPrime = 1;

            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];

            for (int i = 1; i < OriginalImage.Width - 1; i++)
            {

                for (int j = 1; j < OriginalImage.Height - 1; j++)
                {

                    FiltedImageAsATable[0, i, j] =

                        (int)((ImageAsATable[0, i - 1, j - 1] * M[0, 0] +
                        ImageAsATable[0, i - 1, j] * M[0, 1] +
                        ImageAsATable[0, i - 1, j + 1] * M[0, 2] +

                        ImageAsATable[0, i, j - 1] * M[1, 0] +
                        ImageAsATable[0, i, j] * M[1, 1] +
                        ImageAsATable[0, i, j + 1] * M[1, 2] +

                        ImageAsATable[0, i + 1, j - 1] * M[2, 0] +
                        ImageAsATable[0, i + 1, j] * M[2, 1] +
                        ImageAsATable[0, i + 1, j + 1] * M[2, 2]) / SPrime);


                    FiltedImageAsATable[1, i, j] =

                        (int)((ImageAsATable[1, i - 1, j - 1] * M[0, 0] +
                        ImageAsATable[1, i - 1, j] * M[0, 1] +
                        ImageAsATable[1, i - 1, j + 1] * M[0, 2] +

                        ImageAsATable[1, i, j - 1] * M[1, 0] +
                        ImageAsATable[1, i, j] * M[1, 1] +
                        ImageAsATable[1, i, j + 1] * M[1, 2] +

                        ImageAsATable[1, i + 1, j - 1] * M[2, 0] +
                        ImageAsATable[1, i + 1, j] * M[2, 1] +
                        ImageAsATable[1, i + 1, j + 1] * M[2, 2]) / SPrime);



                    FiltedImageAsATable[2, i, j] =

                        (int)((ImageAsATable[2, i - 1, j - 1] * M[0, 0] +
                        ImageAsATable[2, i - 1, j] * M[0, 1] +
                        ImageAsATable[2, i - 1, j + 1] * M[0, 2] +

                        ImageAsATable[2, i, j - 1] * M[1, 0] +
                        ImageAsATable[2, i, j] * M[1, 1] +
                        ImageAsATable[2, i, j + 1] * M[1, 2] +

                        ImageAsATable[2, i + 1, j - 1] * M[2, 0] +
                        ImageAsATable[2, i + 1, j] * M[2, 1] +
                        ImageAsATable[2, i + 1, j + 1] * M[2, 2]) / SPrime);




                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATable[t, i, j] > 255) FiltedImageAsATable[t, i, j] = 255;
                        if (FiltedImageAsATable[t, i, j] < 0) FiltedImageAsATable[t, i, j] = 0;
                    }

                }
            }

            DesignImage(FiltedImageAsATable, pictureBox2);
        }

        private void button15_Click(object sender, EventArgs e)
        {
           

            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];

            int[] Temp = new int [9];

            for (int i = 1; i < OriginalImage.Width - 1; i++)
            {

                for (int j = 1; j < OriginalImage.Height - 1; j++)
                {

                    Temp[0] = ImageAsATable[0, i - 1, j - 1];
                    Temp[0] = ImageAsATable[0, i - 1, j - 1];
                    Temp[0] = ImageAsATable[0, i - 1, j - 1];
                    Temp[1] = ImageAsATable[0, i - 1, j ];
                    Temp[2] = ImageAsATable[0, i - 1, j + 1];

                    Temp[3] = ImageAsATable[0, i , j - 1];
                    Temp[4] = ImageAsATable[0, i , j];
                    Temp[5] = ImageAsATable[0, i , j + 1];


                    Temp[6] = ImageAsATable[0, i + 1, j - 1];
                    Temp[7] = ImageAsATable[0, i +1 , j];
                    Temp[8] = ImageAsATable[0, i + 1, j + 1];


                    Array.Sort(Temp);


                    FiltedImageAsATable[0, i, j] = Temp[5];


                    Temp[0] = ImageAsATable[1, i - 1, j - 1];
                    Temp[1] = ImageAsATable[1, i - 1, j];
                    Temp[2] = ImageAsATable[1, i - 1, j + 1];

                    Temp[3] = ImageAsATable[1, i, j - 1];
                    Temp[4] = ImageAsATable[1, i, j];
                    Temp[5] = ImageAsATable[1, i, j + 1];


                    Temp[6] = ImageAsATable[1, i + 1, j - 1];
                    Temp[7] = ImageAsATable[1, i + 1, j];
                    Temp[8] = ImageAsATable[1, i + 1, j + 1];


                    Array.Sort(Temp);


                    FiltedImageAsATable[1, i, j] = Temp[5];


                    Temp[0] = ImageAsATable[2, i - 1, j - 1];
                    Temp[1] = ImageAsATable[2, i - 1, j];
                    Temp[2] = ImageAsATable[2, i - 1, j + 1];

                    Temp[3] = ImageAsATable[2, i, j - 1];
                    Temp[4] = ImageAsATable[2, i, j];
                    Temp[5] = ImageAsATable[2, i, j + 1];


                    Temp[6] = ImageAsATable[2, i + 1, j - 1];
                    Temp[7] = ImageAsATable[2, i + 1, j];
                    Temp[8] = ImageAsATable[2, i + 1, j + 1];


                    Array.Sort(Temp);


                    FiltedImageAsATable[2, i, j] = Temp[5];

                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATable[t, i, j] > 255) FiltedImageAsATable[t, i, j] = 255;
                        if (FiltedImageAsATable[t, i, j] < 0) FiltedImageAsATable[t, i, j] = 0;
                    }

                }
            }

            DesignImage(FiltedImageAsATable, pictureBox2);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];

            CreateGrayscaleY(FiltedImageAsATable);


            int[,] M = new int[3, 3];

            int[,] M2 = new int[3, 3];

            M[0, 0] = -2;
            M[0, 1] = 0;
            M[0, 2] = 2;
            M[1, 0] = -1;
            M[1, 1] = 0;
            M[1, 2] = 1;
            M[2, 0] = -2;
            M[2, 1] = 0;
            M[2, 2] = 2;

            M2[0, 0] = -2;
              M2[0, 1] = -1;
              M2[0, 2] = -2;
              M2[1, 0] = 0;
              M2[1, 1] = 0;
              M2[1, 2] = 0;
              M2[2, 0] = 2;
              M2[2, 1] = 1;
              M2[2, 2] = 2;

            int SPrime = 1275;


            int[,,] FiltedImageAsATable2 = new int[3, OriginalImage.Width, OriginalImage.Height];



            for (int i = 1; i < OriginalImage.Width - 1; i++)
            {

                for (int j = 1; j < OriginalImage.Height - 1; j++)
                {

                   

                     double Dx=   (double)(((FiltedImageAsATable[0, i - 1, j - 1] * M[0, 0] +
                        FiltedImageAsATable[0, i - 1, j] * M[0, 1] +
                        FiltedImageAsATable[0, i - 1, j + 1] * M[0, 2] +

                        FiltedImageAsATable[0, i, j - 1] * M[1, 0] +
                        FiltedImageAsATable[0, i, j] * M[1, 1] +
                        FiltedImageAsATable[0, i, j + 1] * M[1, 2] +

                        FiltedImageAsATable[0, i + 1, j - 1] * M[2, 0] +
                        FiltedImageAsATable[0, i + 1, j] * M[2, 1] +
                        FiltedImageAsATable[0, i + 1, j + 1] * M[2, 2]) / (double)SPrime)+1)*127;


                    double Dy = (double)(((FiltedImageAsATable[0, i - 1, j - 1] * M2[0, 0] +
   FiltedImageAsATable[0, i - 1, j] * M2[0, 1] +
   FiltedImageAsATable[0, i - 1, j + 1] * M2[0, 2] +

   FiltedImageAsATable[0, i, j - 1] * M2[1, 0] +
   FiltedImageAsATable[0, i, j] * M2[1, 1] +
   FiltedImageAsATable[0, i, j + 1] * M2[1, 2] +

   FiltedImageAsATable[0, i + 1, j - 1] * M2[2, 0] +
   FiltedImageAsATable[0, i + 1, j] * M2[2, 1] +
 FiltedImageAsATable[0, i + 1, j + 1] * M2[2, 2]) / (double)SPrime) + 1) * 127;


                    if (comboBox2.Text=="dx")
                    {
                        FiltedImageAsATable2[0, i, j] = (int)(Dx);
                        FiltedImageAsATable2[1, i, j] = (int)(Dx);
                        FiltedImageAsATable2[2, i, j] = (int)(Dx);


                    }

                    if (comboBox2.Text == "dy")
                    {
                        FiltedImageAsATable2[0, i, j] = (int)(Dy);
                        FiltedImageAsATable2[1, i, j] = (int)(Dy);
                        FiltedImageAsATable2[2, i, j] = (int)(Dy);


                    }

                    if (comboBox2.Text == "All")
                    {
                        FiltedImageAsATable2[0, i, j] = (int)((Math.Sqrt(Math.Pow(Dx, 2) + Math.Pow(Dy, 2))) / 1.40);
                        FiltedImageAsATable2[1, i, j] = (int)((Math.Sqrt(Math.Pow(Dx, 2) + Math.Pow(Dy, 2))) / 1.40);
                        FiltedImageAsATable2[2, i, j] = (int)((Math.Sqrt(Math.Pow(Dx, 2) + Math.Pow(Dy, 2))) / 1.40);
                    }

                    //  FiltedImageAsATable2[0, i, j] = (int) A;
                    //  FiltedImageAsATable2[1, i, j] = (int)A;
                    //  FiltedImageAsATable2[2, i, j] = (int)A;



                }
            }

            DesignImage(FiltedImageAsATable2, pictureBox2);






        }

        private void button17_Click(object sender, EventArgs e)
        {
            FiltedImage = OriginalImage;
            pictureBox3.Image = FiltedImage;
            pictureBox4.Image = FiltedImage;
            pictureBox5.Image = FiltedImage;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            FiltedImage = OriginalImage;
            pictureBox8.Image = FiltedImage;
            pictureBox7.Image = FiltedImage;
            pictureBox6.Image = FiltedImage;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            FiltedImage = OriginalImage;
            pictureBox11.Image = FiltedImage;
            pictureBox10.Image = FiltedImage;
            pictureBox9.Image = FiltedImage;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            FiltedImage = OriginalImage;
            pictureBox2.Image = FiltedImage;
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATableR = new int[3, OriginalImage.Width, OriginalImage.Height];
            int[,,] FiltedImageAsATableG = new int[3, OriginalImage.Width, OriginalImage.Height];
            int[,,] FiltedImageAsATableB = new int[3, OriginalImage.Width, OriginalImage.Height];


            for (int i = 0; i < OriginalImage.Width; i++)
            {

                for (int j = 0; j < OriginalImage.Height; j++)
                {
                    int Y = (int)(0.299 * ImageAsATable[0, i, j] + 0.587 * ImageAsATable[1, i, j] + 0.114 * ImageAsATable[2, i, j]);
                    FiltedImageAsATableR[0, i, j] = Y;
                    FiltedImageAsATableR[1, i, j] = Y;
                    FiltedImageAsATableR[2, i, j] = Y;

                    int I = (int)(0.596 * ImageAsATable[0, i, j] + (-0.275) * ImageAsATable[1, i, j] + (-0.321) * ImageAsATable[2, i, j]);
                    FiltedImageAsATableG[0, i, j] = I;
                    FiltedImageAsATableG[1, i, j] = I;
                    FiltedImageAsATableG[2, i, j] = I;

                    int Q = (int)(0.212 * ImageAsATable[0, i, j] + (-0.587) * ImageAsATable[1, i, j] + 0.311 * ImageAsATable[2, i, j]);
                    FiltedImageAsATableB[0, i, j] = Q;
                    FiltedImageAsATableB[1, i, j] = Q;
                    FiltedImageAsATableB[2, i, j] = Q;


                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATableR[t, i, j] > 255) FiltedImageAsATableR[t, i, j] = 255;
                        if (FiltedImageAsATableR[t, i, j] < 0) FiltedImageAsATableR[t, i, j] = 0;
                    }

                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATableG[t, i, j] > 255) FiltedImageAsATableG[t, i, j] = 255;
                        if (FiltedImageAsATableG[t, i, j] < 0) FiltedImageAsATableG[t, i, j] = 0;
                    }

                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATableB[t, i, j] > 255) FiltedImageAsATableB[t, i, j] = 255;
                        if (FiltedImageAsATableB[t, i, j] < 0) FiltedImageAsATableB[t, i, j] = 0;
                    }
                }
            }

            DesignImage(FiltedImageAsATableR, pictureBox14);
            DesignImage(FiltedImageAsATableG, pictureBox13);
            DesignImage(FiltedImageAsATableB, pictureBox12);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            FiltedImage = OriginalImage;
            pictureBox14.Image = FiltedImage;
            pictureBox13.Image = FiltedImage;
            pictureBox12.Image = FiltedImage;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];

            for (int i = 0; i < 255; i++)
            {

                Lum1[i] = 0;
            }


            for (int i = 0; i < OriginalImage.Width; i++)
            {

                for (int j = 0; j < OriginalImage.Height; j++)
                {

                    int Y = (int)(0.299 * ImageAsATable[0, i, j] + 0.587 * ImageAsATable[1, i, j] + 0.114 * ImageAsATable[2, i, j]);
                    int I = (int)(0.596 * ImageAsATable[0, i, j] + (-0.275 * ImageAsATable[1, i, j]) + (-0.321 * ImageAsATable[2, i, j]));
                    int Q = (int)(0.212 * ImageAsATable[0, i, j] + (-0.587 * ImageAsATable[1, i, j]) + 0.311 * ImageAsATable[2, i, j]);


                    FiltedImageAsATable[0, i, j] = Y;
                    FiltedImageAsATable[1, i, j] = I;
                    FiltedImageAsATable[2, i, j] = Q;


                    for (int t = 0; t < 3; t++)
                    {
                        if (FiltedImageAsATable[t, i, j] > 255) FiltedImageAsATable[t, i, j] = 255;
                        if (FiltedImageAsATable[t, i, j] < 0) FiltedImageAsATable[t, i, j] = 0;
                    }

                }
            }

            DesignImage(FiltedImageAsATable, pictureBox2);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];


            double Pixels = (OriginalImage.Width * OriginalImage.Height);
            double AverageLum = 0;

            for (int i = 0; i < 255; i++)
            {

                AverageLum += Lum1[i] * i / Pixels;            // Mean
            }


            int Y;
            int Width = OriginalImage.Width;
            int Height = OriginalImage.Height;


            for (int i = 0; i < Width; i++)
            {

                for (int j = 0; j < Height; j++)
                {

                    Y = (int)(0.299 * ImageAsATable[0, i, j] + 0.587 * ImageAsATable[1, i, j] + 0.114 * ImageAsATable[2, i, j]);

                    if (Y > AverageLum)
                    {
                        FiltedImageAsATable[0, i, j] = 255;
                        FiltedImageAsATable[1, i, j] = 255;
                        FiltedImageAsATable[2, i, j] = 255;
                    }
                    else
                    {
                        FiltedImageAsATable[0, i, j] = 0;
                        FiltedImageAsATable[1, i, j] = 0;
                        FiltedImageAsATable[2, i, j] = 0;

                    }


                }
            }

            DesignImage(FiltedImageAsATable, pictureBox2);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            int[,,] FiltedImageAsATable = new int[3, OriginalImage.Width, OriginalImage.Height];


            double Pixels = (OriginalImage.Width * OriginalImage.Height);
            double medianLum = 0;
            double sum = 0;


            for (int i = 0; i < 255; i++)
            {
                sum += Lum1[i];

                if (sum > Pixels / 2)
                {
                    medianLum = i;
                    break;
                }

            }

            int Y;
            int Width = OriginalImage.Width;
            int Height = OriginalImage.Height;

            for (int i = 0; i < Width; i++)
            {

                for (int j = 0; j < Height; j++)
                {

                    Y = (int)(0.299 * ImageAsATable[0, i, j] + 0.587 * ImageAsATable[1, i, j] + 0.114 * ImageAsATable[2, i, j]);

                    if (Y > medianLum)
                    {
                        FiltedImageAsATable[0, i, j] = 255;
                        FiltedImageAsATable[1, i, j] = 255;
                        FiltedImageAsATable[2, i, j] = 255;
                    }
                    else
                    {
                        FiltedImageAsATable[0, i, j] = 0;
                        FiltedImageAsATable[1, i, j] = 0;
                        FiltedImageAsATable[2, i, j] = 0;

                    }

                }
            }

            DesignImage(FiltedImageAsATable, pictureBox2);

        }
    }
}

/*******************************************************************
*Colegio Técnico Antônio Teixeira Fernandes (Univap)
 *Curso Técnico em Informática - Data de Entrega: 07 / 09 / 2022
* Autores do Projeto: Lucas Castelani Gouveia
*                     Fábio Miguel de Andrade
* Turma: 3h
* Atividade Projeto 3 Bi
 * ******************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoICG3BI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void salvarImagem(Bitmap imagem, String caminho)
        {
            imagem.Save(caminho);
        }
        public Bitmap removerFundo(Bitmap imagem)
        {
            int r, g, b;
            Color cor = new Color();
            int coluna = imagem.Width;
            int linha = imagem.Height;
            Bitmap imagemMod = new Bitmap(coluna, linha);
            for (int i = 0; i < coluna; i++)
            {
                for (int j = 0; j < linha; j++)
                {
                    r = imagem.GetPixel(i, j).R;
                    g = imagem.GetPixel(i, j).G;
                    b = imagem.GetPixel(i, j).B;
                    
                    if (r - b > 50 && g - b > 50)
                    {
                        cor = corRGB(0, 0, 0, 0);
                        imagemMod.SetPixel(i, j, cor);
                    }
                    else
                    {
                        cor = corRGB(r, g, b);
                        imagemMod.SetPixel(i, j, cor);
                    }
                }
            }
            return imagemMod;
        }
        public Bitmap transcreverImagem(Bitmap imagem1, Bitmap imagem2)
        {
            int coluna1 = imagem1.Height;
            int linha1 = imagem1.Width;
            int colunaImg = 0,linhaImg = 0;
            Bitmap imagemMod = new Bitmap(linha1, coluna1);
            Color corPixel = new Color();
            for (int i = 0; i < linha1; i++)
            {
                for (int j = 0; j < coluna1; j++)
                {
                    if ((i > 145 && i < 382) && (j >5 && j < 242))
                    { 
                        corPixel = imagem2.GetPixel(colunaImg, linhaImg);
                        if (corPixel.R == 0 && corPixel.G == 0 && corPixel.B == 0)
                        {
                            corPixel = imagem1.GetPixel(i, j);
                            imagemMod.SetPixel(i, j, corPixel);
                        }
                        else
                        {
                            imagemMod.SetPixel(i, j, corPixel);
                        }
                        if (linhaImg == 236)
                        {
                            linhaImg = 1;
                            colunaImg++;
                        }
                        else
                            linhaImg++;
                    }
                    else
                    {
                        corPixel = imagem1.GetPixel(i, j);
                        imagemMod.SetPixel(i, j, corPixel);
                    }
                }
            }
            return imagemMod;
        }
        
        public Bitmap imagememCinza(Bitmap imagem)
        {
            Color cor = new Color();
            int coluna = imagem.Height;
            int linha = imagem.Width;
            Bitmap imagemMod = new Bitmap(linha, coluna);
            for (int i = 0; i < linha; i++)
            {
                for (int j = 0; j < coluna; j++)
                {
                    int r = imagem.GetPixel(i, j).R;
                    int g = imagem.GetPixel(i, j).G;
                    int b = imagem.GetPixel(i, j).B;
                    cor = cinza(corRGB(r, g, b));
                    imagemMod.SetPixel(i, j, cor);
                }
            }
            return imagemMod;
        }
        public Bitmap imagememBW(Bitmap imagem)
        {
            Color bw = new Color();
            int coluna = imagem.Height;
            int linha = imagem.Width;
            Bitmap imagemMod = new Bitmap(linha, coluna);
            for (int i = 0; i < linha; i++)
            {
                for (int j = 0; j < coluna; j++)
                {
                    int r = imagem.GetPixel(i, j).R;
                    int g = imagem.GetPixel(i, j).G;
                    int b = imagem.GetPixel(i, j).B;
                    int cor = cinza(corRGB(r, g, b)).R;
                    if (cor <= 126)
                        bw = Color.FromArgb(255, 0, 0, 0);
                    else if (cor > 126)
                        bw = Color.FromArgb(255, 255, 255, 255);
                    imagemMod.SetPixel(i, j, bw);
                }
            }
            return imagemMod;
        }
        public Color cinza(Color cor)
        {
            int cinza = (int)(cor.R * 0.3 + cor.G * 0.59 + cor.B * 0.11);
            return cor = corRGB(255, cinza, cinza, cinza);
        }
        public Color corRGB(int r, int g, int b)
        {
            Color cor = new Color();
            cor = Color.FromArgb(r, g, b);
            return cor;
        }
        public Color corRGB(int a, int r, int g, int b)
        {
            Color cor = new Color();
            cor = Color.FromArgb(a, r, g, b);
            return cor;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap imagem1 = new Bitmap("C:\\Imagens\\Imagem_A.jpg");
            Bitmap imagem2 = new Bitmap("C:\\Imagens\\Panela.jpg");

            imagem2 = removerFundo(imagem2);
            imagem1 = transcreverImagem(imagem1, imagem2);
            salvarImagem(imagem1, "C:\\Imagens\\Finalizado.jpg");
            imagem1 = imagememCinza(imagem1);
            salvarImagem(imagem1, "C:\\Imagens\\FinalizadoCinza.jpg");
            imagem1 = imagememBW(imagem1);
            salvarImagem(imagem1, "C:\\Imagens\\FinalizadoBW.jpg");

        }
    }
}

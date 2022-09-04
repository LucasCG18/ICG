public Bitmap transcreverImagem(Bitmap imagem1, Bitmap imagem2)
        {
            int coluna1 = imagem1.Height;
            int linha1 = imagem1.Width;
            int coluna2 = imagem2.Height;
            int linha2 = imagem2.Width;
            int colunaImg = 0,linhaImg = 0;
            Bitmap imagemMod = new Bitmap(linha1, coluna1);
            textBox2.Text = "PC1: " + coluna1.ToString() +" PL1: " + linha1.ToString() + " PC2: " + coluna2.ToString() + " PL2: " + linha2.ToString();
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
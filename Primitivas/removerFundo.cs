public Bitmap removerFundo(Bitmap imagem)
        {
            int r, g, b;
            int rD = 0, gD = 0, bD = 0;
            Color cor = new Color();
            int coluna = imagem.Width;
            int linha = imagem.Height;
            Bitmap imagemMod = new Bitmap(coluna, linha);
            for (int i = 0; i < coluna; i++)
            {
                for (int j = 0; j < linha; j++)
                {
                    if(i == 0 && j == 0)
                    {
                        rD = imagem.GetPixel(i, j).R;
                        gD = imagem.GetPixel(i, j).G;
                        bD = imagem.GetPixel(i, j).B;
                        
                    }
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
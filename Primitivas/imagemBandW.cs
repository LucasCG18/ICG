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
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
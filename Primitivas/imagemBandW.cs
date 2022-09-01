public Bitmap imagememcinza(Bitmap imagem){
    Color bw = new Color();
    int coluna = imagem.Width;
    int linha = imagem.Height;
    Bitmap imagemMod = new Bitmap(coluna,linha);
    for (int i = 0; i < colunas; i++)
    {
        for(int j = 0; j < altura; j++)
        {
        int r = imagem.GetPixel(i, j).R;
        int g = imagem.GetPixel(i, j).G;
        int b = imagem.GetPixel(i, j).B;
        int cor = cinza(corRGB(r, g, b)).R;
        if (cor <= 126)
            bw = Color.FromArgb(255,0,0,0);
        else if (cor > 126)
            bw = Color.FromArgb(255,255,255,255);
        imagemMod.SetPixel(i, j, cor);
        }
    }
    return imagemMod;
}
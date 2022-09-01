public Bitmap imagememcinza(Bitmap imagem){
    Color cor = new Color();
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
        cor = cinza(corRGB(r, g, b));
        imagemMod.SetPixel(i, j, cor);
        }
    }
    return imagemMod;
}
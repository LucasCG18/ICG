using System.Drawing;
public Color cinza(Color cor){
    int cinza = cor.R * 0.3 + cor.G * 0.59 + cor.B * 0.11;
    return cor = Color.FromArgb(255, cinza, cinza, cinza);
}
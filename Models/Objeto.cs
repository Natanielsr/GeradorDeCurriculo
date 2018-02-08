using System;

namespace GeradorDeCurriculo.Models
{
    public class Objeto
    {
        public string Chave { get; set; }
        public Object Conteudo { get; set; }

        public Objeto(string Chave, Object Conteudo) {
            this.Chave = Chave;
            this.Conteudo = Conteudo;
        }
    }
}

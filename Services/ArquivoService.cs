
using System.IO;

namespace GeradorDeCurriculo.Services
{
    public static class ArquivoService
    {
        static string path = @"./Curriculo.html";
        public static string salvar(string html) {
            
            File.WriteAllText(path, html);
            
            return Path.GetFullPath(path);
        }
    }
}

using DIO.Series.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Classes
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }


        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Gênero: {Genero} {Environment.NewLine}");
            sb.Append($"Titulo: {Titulo} {Environment.NewLine}");
            sb.Append($"Descrição: {Descricao} {Environment.NewLine}");
            sb.Append($"Ano de Inicio: {Ano} { Environment.NewLine}");
            sb.Append($"Excluido: {Excluido}");
            return sb.ToString();
        }

        public string RetornaTitulo()
        {
            return Titulo;
        }

        public int RetornaId()
        {
            return Id;
        }

        public void Excluir()
        {
            Excluido = true;
        }
    }
}

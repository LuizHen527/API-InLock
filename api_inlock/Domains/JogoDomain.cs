﻿namespace api_inlock.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        public int IdEstudio { get; set; }

        public string Name { get; set; }

        public string Descricao { get; set; }

        public DateTime DataLancamento { get; set; }

        public decimal Valor { get; set; }

        public EstudioDomain? Estudio { get; set; }
    }
}

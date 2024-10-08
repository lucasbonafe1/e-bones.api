﻿using E_Bones.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace E_Bones.Domain.Entities
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("fotos")]
        public IList<String> ImageUrl { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("preco")]
        public float Preco{ get; set; }

        [JsonIgnore]
        public DateTime? DeletedAt { get; set; }

        public Produto()
        {

        }

        public Produto(string nome, string descricao, IList<string> imageUrl, int quantidade, float preco)
        {
            Nome = nome;
            Descricao = descricao;
            ImageUrl = imageUrl;
            Quantidade = quantidade;
            Preco = preco;
        }
    }
}
﻿using Newtonsoft.Json;

namespace LocadoraDeVeiculos.Dominio
{
    public abstract class EntidadeBase<T>
    {
        [JsonProperty(Order = -4)]
        public int Id { get; set; }
        public abstract override bool Equals(object? obj);
    }
}

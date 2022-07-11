using Newtonsoft.Json;
using System;

namespace LocadoraDeVeiculos.Dominio
{
    public abstract class EntidadeBase<T>
    {
        [JsonProperty(Order = -6)]
        public Guid guid { get; set; }
        public abstract override bool Equals(object? obj);
    }
}

using Newtonsoft.Json;
using System;

namespace LocadoraDeVeiculos.Dominio
{
    public abstract class EntidadeBase<T>
    {
        protected EntidadeBase()
        {
            this.Id = Guid.Empty;
        }

        [JsonProperty(Order = -6)]
        public Guid Id { get; set; }
        public abstract override bool Equals(object? obj);
    }
}

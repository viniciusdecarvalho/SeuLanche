//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeuLanche.WebAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class PedidosSaldo
    {
        public int SequencialPedido { get; set; }
        public Nullable<int> SequencialLanche { get; set; }
        public Nullable<System.Guid> ItemId { get; set; }
        public int Nivel { get; set; }
        public Nullable<long> Ordem { get; set; }
        public string Descricao { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Nullable<decimal> Saldo { get; set; }
    }
}

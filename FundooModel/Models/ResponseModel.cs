// -----------------------------------------------------------------------------------------------------
// <copyright file="ResponseModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooModel.Models
{
    public class ResponseModel<T>
    {
        public bool Status { get; set; }

        public string Masseage { get; set; }

        public T Data { get; set; }
    }
}

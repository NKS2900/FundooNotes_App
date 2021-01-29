using System;
using System.Collections.Generic;
using System.Text;

namespace FundooModel.Models
{
    public class ResponseModel<T>
    {
        public bool Status { get; set; }

        public string Masseage { get; set; }

        public T Data { get; set; }
    }
}

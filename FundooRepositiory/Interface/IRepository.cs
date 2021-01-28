﻿// -----------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooRepositiory
{
    using FundooModel.Models;
    using System.Collections.Generic;

    public interface IRepository
    {
        public bool RegisterUser(FundooModels model);

        public bool LoginValidation(string Email, string Password);

        public string GenerateTokens(string email);

        public IEnumerable<FundooModels> GetAllRecords();
       
        public bool SendEmail(string email);

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SNOW.SHOP.MOBILE.Models.Orders;

namespace SNOW.SHOP.MOBILE.Models.User
{

    public class PaymentInfo
    {
        public Guid Id { get; set; }
        public string CardNumber { get; set; }
        public string SecurityNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public string CardHolderName { get; set; }
        //public CardType CardType { get; set; }
        public string Expiration { get; set; }
    }
}
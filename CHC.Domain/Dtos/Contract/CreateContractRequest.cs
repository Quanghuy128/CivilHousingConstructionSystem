﻿namespace CHC.Domain.Dtos.Contract
{
    public class CreateContractRequest
    {
        public string Content { get; set; } = string.Empty;
        public double FinalOffer { get; set; } = 0;
        public int Discount { get; set; } = 0;
    }
}

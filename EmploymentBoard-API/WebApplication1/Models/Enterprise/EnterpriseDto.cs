﻿using BolsaDeTrabajoAPI.Enums;

namespace BolsaDeTrabajoAPI.Models
{
    public class EnterpriseDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Cuit { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Field { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string ContactName { get; set; }
        public string ContactPosition { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public EnterpriseRelationTypes EnterpriseRelation { get; set; }
        public AccountStatusTypes AccountStatus { get; set; }
        //public ICollection<JobOfferDto> OfferedJobs { get; set; } = new List<JobOfferDto>();
    }
}

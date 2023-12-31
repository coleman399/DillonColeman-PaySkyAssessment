﻿using DillonColeman_PaySkyAssessment.Models.VacancyModel;

namespace DillonColeman_PaySkyAssessment.Dtos.VacancyDtos
{
    public class GetVacancyDto
    {
        public int Id { get; set; }
        public List<Applicant>? Applicates { get; set; }
        public int Volume { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}

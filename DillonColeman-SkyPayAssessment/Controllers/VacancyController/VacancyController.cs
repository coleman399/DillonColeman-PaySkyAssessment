﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DillonColeman_PaySkyAssessment.Controllers.VacancyController
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    public class VacancyController(IVacancyService vacancyService, ILogger<VacancyController> logger) : ControllerBase
    {
        private readonly IVacancyService _vacancyService = vacancyService;
        private readonly ILogger<VacancyController> _logger = logger;

        // GET api/Vacancy/getVacancies
        [HttpGet("getVacancies"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VacancyServiceResponse<List<GetVacancyDto>>>> GetVacancies()
        {
            VacancyServiceResponse<List<GetVacancyDto>> result = await _vacancyService.GetVacancies();
            if (result.Success) _logger.LogInformation($"GetVacancies() called: {result.Data}");
            if (!result.Success) _logger.LogInformation($"GetVacancies() called: {result.Message}");
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // POST api/Vacancy/createVacancy 
        [HttpPost("createVacancy"), Authorize(Roles = "Employer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VacancyServiceResponse<GetVacancyDto>>> CreateVacancy([FromBody] CreateVacancyDto newVacancy)
        {
            VacancyServiceResponse<GetVacancyDto> result = await _vacancyService.CreateVacancy(newVacancy);
            if (result.Success) _logger.LogInformation($"CreateVacancy() called: {result.Data}");
            if (!result.Success) _logger.LogInformation($"CreateVacancy() called: {result.Message}");
            if (!result.Success) return BadRequest(result);
            return Created("createVacancy", result);
        }

        // PUT api/Vacancy/updateVacancy?id={id}
        [HttpPut("updateVacancy"), Authorize(Roles = "Employer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VacancyServiceResponse<GetVacancyDto>>> UpdateVacancy([FromBody] UpdateVacancyDto vacancy, [FromQuery] int id)
        {
            VacancyServiceResponse<GetVacancyDto> result = await _vacancyService.UpdateVacancy(vacancy, id);
            if (result.Success) _logger.LogInformation($"UpdateVacancy() called: {result.Data}");
            if (!result.Success) _logger.LogInformation($"UpdateVacancy() called: {result.Message}");
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // DELETE api/Vacancy/deleteVacancy?id={id}
        [HttpDelete("deleteVacancy"), Authorize(Roles = "Employer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VacancyServiceResponse<List<GetVacancyDto>>>> DeleteVacancy([FromQuery] int id)
        {
            VacancyServiceResponse<DeleteVacancyDto> result = await _vacancyService.DeleteVacancy(id);
            if (result.Success) _logger.LogInformation($"DeleteVacancy() called: {result.Data}");
            if (!result.Success) _logger.LogInformation($"DeleteVacancy() called: {result.Message}");
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // POST api/Vacancy/applyForVacancy
        [HttpPost("applyForVacancy"), Authorize(Roles = "Applicant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VacancyServiceResponse<GetVacancyDto>>> ApplyForVacancy([FromQuery] int id)
        {
            VacancyServiceResponse<GetVacancyDto> result = await _vacancyService.ApplyForVacancy(id);
            if (result.Success) _logger.LogInformation($"ApplyForVacancy() called: {result.Data}");
            if (!result.Success) _logger.LogInformation($"ApplyForVacancy() called: {result.Message}");
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // POST api/Vacancy/getVacancy?id={id}
        [HttpGet("getVacancy"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VacancyServiceResponse<GetVacancyDto>>> GetVacancy([FromQuery] int id)
        {
            VacancyServiceResponse<GetVacancyDto> result = await _vacancyService.GetVacancy(id);
            if (result.Success) _logger.LogInformation($"GetVacancy() called: {result.Data}");
            if (!result.Success) _logger.LogInformation($"GetVacancy() called: {result.Message}");
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }
}

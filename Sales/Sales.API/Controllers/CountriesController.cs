﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController] //Data Annotation
    [Route("/api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        } 



    }
}

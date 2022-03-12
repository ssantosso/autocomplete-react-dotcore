using Autocomplete.API.ViewModel;
using Autocomplete.Business.Interface;
using Autocomplete.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autocomplete.Controllers
{
    [Route("api/v1/[controller]")]
    public class CityController : MainController
    {
        private readonly ICityRepository _repo;
        private readonly IMapper _mapper;

        public CityController(INotificador notificador, ICityRepository repo, IMapper mapper) : base(notificador)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = _mapper.Map<IEnumerable<CityViewModel>>(await _repo.ObterEnderecoPorCidadeAsync(new FiltroViewModel()));

            return CustomResponse(result);
        }

        [HttpGet("obterporfiltro")]
        public async Task<ActionResult> ObterPorFiltro([FromQuery] string filtro)
        {

            var citys = _mapper.Map<IEnumerable<CityViewModel>>(await _repo.ObterEnderecoPorCidadeAsync(new FiltroViewModel { Filtro= filtro }));
            var result = new DataViewModel
            {
                citys = citys,
                sugestions = citys.Select(x => x.Original)
            };
            return CustomResponse(result);
        }
    }
}

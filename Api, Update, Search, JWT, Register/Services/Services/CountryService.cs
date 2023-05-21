using AutoMapper;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Services.DTOs.Country;
using Services.DTOs.Employee;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository,
                              IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CountryCreateDto country) => await _countryRepository.CreateAsync(_mapper.Map<Country>(country));

        public async Task<IEnumerable<CountryDto>> GetAllAsync() => _mapper.Map<IEnumerable<CountryDto>>(await _countryRepository.GetAllAsync());

        public async Task<CountryDto> GetByIdAsync(int? id) => _mapper.Map<CountryDto>(await _countryRepository.GetByIdAsync(id));

        public async Task DeleteAsync(int? id) => await _countryRepository.DeleteAsync(await _countryRepository.GetByIdAsync(id));

        public async Task<IEnumerable<CountryDto>> SearchAsync(string name) => _mapper.Map<IEnumerable<CountryDto>>(await _countryRepository.CountrySearch(name));



    }
}

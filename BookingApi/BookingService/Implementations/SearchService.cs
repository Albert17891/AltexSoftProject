using Booking.Data;
using Booking.Domain.Booking;
using Booking.Services.Abstractions;
using Booking.Services.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Implementations
{
    public class SearchService : ISearchService
    {
        private readonly ISearchRepository _repository;
        private readonly IOrderRepository _orderRepository;

        public SearchService(ISearchRepository repository,IOrderRepository orderRepository)
        {
            _repository = repository;
            _orderRepository = orderRepository;
        }
        public async Task AddApartmentService(ApartmentServiceModel apartment)
        {
            await _repository.AddApartment(apartment.Adapt<Apartment>());
        }

        public async Task Booking(OrderServiceModel orderServiceModel)
        {
            await _orderRepository.Booking(orderServiceModel.Adapt<Order>());
        }

        public async Task<List<ApartmentServiceModel>> GetAllApartment(string city,DateTime From,DateTime To)
        {
            var result= await _repository.GetApartmentWithCity(city,From,To);
            return result.Adapt<List<ApartmentServiceModel>>();
        }
    }
}

using Booking.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Abstractions
{
    public interface ISearchService
    {
        Task<List<ApartmentServiceModel>> GetAllApartment(string city,DateTime From,DateTime To);
        Task AddApartmentService(ApartmentServiceModel apartment);

        Task Booking(OrderServiceModel orderServiceModel);
    }
}

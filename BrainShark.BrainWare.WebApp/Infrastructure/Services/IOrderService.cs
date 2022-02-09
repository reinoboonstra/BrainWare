using System.Collections.Generic;
using BrainShark.BrainWare.WebApp.Models;

namespace BrainShark.BrainWare.WebApp.Infrastructure.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetForCompany(int companyId = 1);
    }
}
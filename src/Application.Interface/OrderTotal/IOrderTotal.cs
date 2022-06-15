using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.OrderTotal
{
    public interface IOrderTotal
    {
        Task<bool> CreateAsync(Model.OrderTotal.OrderTotal OrderTotal);
        Task<bool> UpdateAsync(Model.OrderTotal.OrderTotal OrderTotal);
    }
}

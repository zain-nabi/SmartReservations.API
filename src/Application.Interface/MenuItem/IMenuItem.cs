using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.MenuItem
{
    public interface IMenuItem
    {
        Task<Model.MenuItem.MenuItem> CreateAsync(Model.MenuItem.MenuItem MenuItem);
        Task<bool> UpdateAsync(Model.MenuItem.MenuItem MenuItem);
        Task<Model.MenuItem.MenuItem> FindByIdAsync(int MenuItemID);
        Task<List<Model.MenuItem.MenuItem>> Items();
    }
}

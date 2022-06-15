using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.TableSettings
{
    public interface ITableSettings
    {
        Task<List<Model.TableSettings.TableSettings>> Tables(int RestaurantID);
        Task<Model.TableSettings.TableSettings> CreateAsync(Model.TableSettings.TableSettings TableSettings);
        Task<bool> UpdateAsync(Model.TableSettings.TableSettings TableSettings);
    }
}

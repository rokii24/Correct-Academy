using Contract.AddDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.IDataServices
{
    public interface ICategoreyservice
    {
        Task<Guid> Add(AddCategoryDto Dto);

    }
}

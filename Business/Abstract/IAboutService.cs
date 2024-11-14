using Business.Abstract.Generic;
using Entities.Concrete;

namespace Business.Abstract;

public interface IAboutService : IGenericService<About>
{
    About Get();
}
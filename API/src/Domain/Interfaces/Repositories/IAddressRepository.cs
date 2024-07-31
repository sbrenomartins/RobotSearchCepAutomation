using Domain.Entidades;

namespace Domain.Interfaces.Repositories;

public interface IAddressRepository
{
    Task Add(List<Address> addresses);
    Task UpdateData(Address address);
    Task<Address?> GetCepForProcessing(string robot);
    Task<Address?> Get(int id);
    Task<List<Address>> List();
}

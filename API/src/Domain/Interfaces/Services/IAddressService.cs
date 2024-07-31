using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IAddressService
{
    Task Add(List<AddressModel> addresses);
    Task UpdateData(AddressModel address);
    Task<AddressModel> GetCepForProcessing(string robot);
    Task<List<AddressModel>> List();
}

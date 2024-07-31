using Application.Adapters;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _repository;

    public AddressService(IAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task Add(List<AddressModel> addresses)
    {
        var domains = AddressAdapter.Map(addresses);
        await _repository.Add(domains);
    }

    public async Task<AddressModel> GetCepForProcessing(string robot)
    {
        var domain = await _repository.GetCepForProcessing(robot);

        if (domain == null) throw new Exception("Não existe nenhum CEP para processar.");

        domain.Status = EnumStatus.EmAndamento;
        domain.Robo = robot;

        await _repository.UpdateData(domain);

        return AddressAdapter.Map(domain);
    }

    public async Task<List<AddressModel>> List()
    {
        var domains = await _repository.List();
        return AddressAdapter.Map(domains);
    }

    public async Task UpdateData(AddressModel address)
    {
        var domain = await _repository.Get(address.Id);

        if (domain == null) throw new Exception("CEP não localizado.");

        domain.Logradouro = address.Logradouro;
        domain.Bairro = address.Bairro;
        domain.UF = address.UF;
        domain.Status = EnumStatus.Finalizado;

        await _repository.UpdateData(domain);
    }
}

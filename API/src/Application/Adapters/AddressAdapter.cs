using Domain.Entidades;
using Domain.Models;

namespace Application.Adapters;

public static class AddressAdapter
{
    public static AddressModel Map(Address address)
    {
        return new AddressModel
        {
            Bairro = address.Bairro,
            CEP = address.CEP,
            Id = address.Id,
            Logradouro = address.Logradouro,
            UF = address.UF,
        };
    }

    public static Address Map(AddressModel address)
    {
        return new Address
        {
            Bairro = address.Bairro,
            CEP = address.CEP,
            Id = address.Id,
            Logradouro = address.Logradouro,
            UF = address.UF,
        };
    }

    public static List<AddressModel> Map(List<Address> address)
    {
        return address.Select(Map).ToList();
    }

    public static List<Address> Map(List<AddressModel> address)
    {
        return address.Select(Map).ToList();
    }
}

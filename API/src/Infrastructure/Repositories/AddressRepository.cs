using Domain.Entidades;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly AppDbContext _context;

    public AddressRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(List<Address> addresses)
    {
        await _context.BulkInsertAsync(addresses);
    }

    public async Task<Address?> Get(int id)
    {
        return await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Address?> GetCepForProcessing(string robot)
    {
        var cepExisting = await _context.Addresses
            .FirstOrDefaultAsync(a => a.Status == EnumStatus.EmAndamento && a.Robo == robot);

        if (cepExisting != null) return cepExisting;

        var cep = await _context.Addresses
            .FirstOrDefaultAsync(a => a.Status == EnumStatus.Aberto && string.IsNullOrEmpty(a.Robo));

        return cep;
    }

    public async Task<List<Address>> List()
    {
        return await _context.Addresses.ToListAsync();
    }

    public async Task UpdateData(Address address)
    {
        _context.Addresses.Update(address);
        await _context.SaveChangesAsync();
    }
}

using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpPost]
    public async Task<IActionResult> Add(List<AddressModel> models)
    {
        await _addressService.Add(models);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update(AddressModel model)
    {
        await _addressService.UpdateData(model);
        return Ok();
    }

    [HttpGet("{robot}")]
    public async Task<IActionResult> GetCepForProcessing(string robot)
    {
        var cep = await _addressService.GetCepForProcessing(robot);
        return Ok(cep);
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _addressService.List());
    }
}

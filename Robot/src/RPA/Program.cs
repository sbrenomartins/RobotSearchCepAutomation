using RPA;
using RPA.Driver;
using RPA.Model;

const string BASE_URL = "http://localhost:5237/v1/address/";
var request = new RequestProvider();
var search = new SearchCepDriver();

var address = await request.GetAsync<AddressModel>(BASE_URL + "robot_1");

if (address != null)
{
    search.SearchCep(address);

    await request.PutAsync(BASE_URL, address);
}

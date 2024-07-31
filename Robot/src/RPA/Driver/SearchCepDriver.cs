using System.Data;
using EasyAutomationFramework;
using OpenQA.Selenium;
using RPA.Model;

namespace RPA.Driver;

public class SearchCepDriver : Web
{
    public SearchCepDriver()
    {
        StartBrowser();
    }

    public void SearchCep(AddressModel address)
    {
        Navigate("https://buscacepinter.correios.com.br/app/endereco/index.php");

        AssignValue(TypeElement.Id, "endereco", address.CEP)
            .element.SendKeys(Keys.Enter);

        var result = GetTableData(TypeElement.Id, "resultado-DNEC");

        foreach (DataRow row in result.table.Rows)
        {
            address.Logradouro = row[0].ToString();
            address.Bairro = row[1].ToString();
            address.UF = row[2].ToString();
        }
    }
}

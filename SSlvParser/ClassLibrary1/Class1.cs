using HtmlAgilityPack;

namespace ClassLibrary1;

class Program
{

    static void Main(string[] args)
    {
        getHtmlAsync();
        Console.ReadLine();
    }

    private static async void getHtmlAsync()
    {
        string url = "https://www.ss.lv/ru/transport/cars/audi/";
        HttpClient httpClient = new HttpClient();
        var html = await httpClient.GetStringAsync(url);

        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);

        var ProductList = htmlDocument.DocumentNode.Descendants("tr")
            .Where(node => node.GetAttributeValue("id", "")
            .Equals("tr_52357345")).ToList();

        Console.WriteLine(ProductList);

    }

}
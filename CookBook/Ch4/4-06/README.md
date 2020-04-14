#### Joined both LINQ to DataSet and LINQ to XML to access the multiple data
domains:
```csharp
Northwind dataContext =
    new Northwind(Settings.Default.NorthwindConnectionString);

ProductsTableAdapter adapter = new ProductsTableAdapter();

Products products = new Products();
adapter.Fill(products._Products);

XElement xmlCategories = XElement.Load("Categories.xml");

var expr = from product in products._Products
           where product.Units_In_Stock > 100
           join xc in xmlCategories.Elements("Category")
           on product.Category_ID equals int.Parse(xc.Attribute("CategoryID").Value)
           select new
           {
             ProductName = product.Product_Name,
             Category = xc.Attribute("CategoryName").Value,
             CategoryDescription = xc.Attribute("Description").Value
           };

foreach (var productInfo in expr)
{
    Console.WriteLine("ProductName: " + productInfo.ProductName +
                      " Category: " + productInfo.Category +
                      " Category Description: " + productInfo.CategoryDescription);
}
```
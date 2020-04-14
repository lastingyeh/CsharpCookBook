### Being Selective About Your Query Results

#### TakeWhile (> 3)
```csharp
NorthwindEntities dataContext = new NorthwindEntities();
// find the products for all suppliers
var query =
	dataContext.Suppliers.GroupJoin(dataContext.Products,
		s => s.SupplierID, p => p.SupplierID, (s, products) => new
		{
			s.CompanyName,
			s.ContactName,
			s.Phone,
			Products = products
		}).OrderByDescending(supplierData => supplierData.Products.Count());

var results = 
	query.AsEnumerable().TakeWhile(supplierData => supplierData.Products.Count() > 3);

Console.WriteLine($"Suppliers that provide more than three products: " +
				  $"{results.Count()}");

foreach (var supplierData in results)
{
	Console.WriteLine($" Company Name : {supplierData.CompanyName}");
	Console.WriteLine($" Contact Name : {supplierData.ContactName}");
	Console.WriteLine($" Contact Phone : {supplierData.Phone}");
	Console.WriteLine($" Products Supplied : {supplierData.Products.Count()}");
	
	foreach (var productData in supplierData.Products)
		Console.WriteLine($" Product: {productData.ProductName}");
}
```

#### SkipWhile (< 3)
```csharp
NorthwindEntities dataContext = new NorthwindEntities();
// find the products for all suppliers
var query =
	dataContext.Suppliers.GroupJoin(dataContext.Products,
		s => s.SupplierID, p => p.SupplierID, (s, products) => new
			{
				s.CompanyName,
				s.ContactName,
				s.Phone,
				Products = products
			}).OrderByDescending(supplierData => supplierData.Products.Count());

var results =
	query.AsEnumerable().SkipWhile(supplierData => supplierData.Products.Count() > 3);

Console.WriteLine($"Suppliers that provide more than three products: " +
				  $"{results.Count()}");

foreach (var supplierData in results)
{
	Console.WriteLine($" Company Name : {supplierData.CompanyName}");
	Console.WriteLine($" Contact Name : {supplierData.ContactName}");
	Console.WriteLine($" Contact Phone : {supplierData.Phone}");
	Console.WriteLine($" Products Supplied : {supplierData.Products.Count()}");
	
	foreach (var productData in supplierData.Products)
		Console.WriteLine($" Product: {productData.ProductName}");
}
```
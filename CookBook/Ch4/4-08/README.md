### Take a data set from a database and represent it as XML.

```csharp

NorthwindEntities dataContext = new NorthwindEntities();
// Log the generated SQL to the console
dataContext.Database.Log = Console.WriteLine;
// select the top 5 customers whose contact is the owner and
// those owners placed orders spending more than $10000 this year
var bigSpenders = new XElement("BigSpenders",
	from top5 in
	(
		(from customer in
			(from c in dataContext.Customers
			// get the customers where the contact is the
			// owner and they placed orders
			where c.ContactTitle.Contains("Owner") && c.Orders.Count > 0
			join orderData in
				(from c in dataContext.Customers
						// get the customers where the contact is the
						// owner and they placed orders
						where c.ContactTitle.Contains("Owner") && c.Orders.Count > 0
						from o in c.Orders
						// get the order details
						join od in dataContext.Order_Details
						on o.OrderID equals od.OrderID
						select new
						{
						c.CompanyName,
						c.CustomerID,
						o.OrderID,
						// have to calc order value from orderdetails
						//(UnitPrice*Quantity as Total)-
						// (Total*Discount) as NetOrderTotal
						NetOrderTotal = (
						(((double)od.UnitPrice) * od.Quantity) -
						((((double)od.UnitPrice) * od.Quantity) *
						od.Discount))
						}
				)
			on c.CustomerID equals orderData.CustomerID
			into customerOrders
		select new
		{
		c.CompanyName,
		c.ContactName,
		c.Phone,
		// Get the total amount spent by the customer
		TotalSpend = customerOrders.Sum(order =>
		order.NetOrderTotal)
		}
	)
	// only worry about customers that spent > 10000
	where customer.TotalSpend > 10000
	orderby customer.TotalSpend descending
	// only take the top 5 spenders
	select new
	{
		CompanyName = customer.CompanyName,
		ContactName = customer.ContactName,
		Phone = customer.Phone,
		TotalSpend = customer.TotalSpend
	}).Take(5)
	).ToList()
	// format the data as XML
	select new XElement("Customer",
		new XAttribute("companyName", top5.CompanyName),
		new XAttribute("contactName", top5.ContactName),
		new XAttribute("phoneNumber", top5.Phone),
		new XAttribute("amountSpent", top5.TotalSpend))
);

using (XmlWriter writer = XmlWriter.Create("BigSpenders.xml"))
{
	bigSpenders.WriteTo(writer);
}
```

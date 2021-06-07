use AdventureWorksLT2019
Select SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.Product.Color, SalesLT.Product.ProductNumber 
from SalesLT.Product

Select SalesLT.Customer.CustomerID,  SalesLT.Customer.FirstName,  SalesLT.Customer.MiddleName,  SalesLT.Customer.LastName,  SalesLT.Customer.EmailAddress,  SalesLT.Customer.Phone
from  SalesLT.Customer

Select SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.Product.ProductNumber 
from SalesLT.Product
Where SalesLT.Product.Color ='black' AND SalesLT.Product.Color ='Gray' OR SalesLT.Product.ColoR = 'Multi'

Select SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.Product.ProductNumber 
from SalesLT.Product
Where SalesLT.Product.Color ='black' OR SalesLT.Product.Color ='yellow' 

Select SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.Product.ProductNumber 
from SalesLT.Product
Where SalesLT.Product.Weight >1000

Select SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.Product.ProductNumber 
from SalesLT.Product
Where SalesLT.Product.Weight >6000

Select SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.Product.ProductNumber 
from SalesLT.Product
Where SalesLT.Product.Weight BETWEEN 2000 AND 5000

Select SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.Product.ProductNumber 
from SalesLT.Product
Where SalesLT.Product.ProductNumber LIKE 'B[K,B]%'

Select SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.Product.ProductNumber 
from SalesLT.Product
Where SalesLT.Product.SellEndDate < GETDATE()

Select SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.Product.ProductNumber 
from SalesLT.Product
Order by SalesLT.Product.Color

Select SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.Product.ProductNumber 
from SalesLT.Product
Order by SalesLT.Product.Color ASC, SalesLT.Product.Weight DESC

Select SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.Product.ProductNumber 
from SalesLT.Product
Order by SalesLT.Product.ProductNumber ASC, SalesLT.Product.Weight DESC

Select TOP 10 SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.Product.ProductNumber 
from SalesLT.Product

Select TOP 10 SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.Product.ProductNumber 
from SalesLT.Product
Order by SalesLT.Product.Weight ASC

Select TOP 10 SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.Product.ProductNumber 
from SalesLT.Product
Order by SalesLT.Product.Weight DESC

Select SalesLT.Product.ProductID, SalesLT.Product.Name, SalesLT.Product.ProductNumber 
from SalesLT.Product
Order by SalesLT.Product.Weight ASC 
OFFSET 10 ROWS
    FETCH NEXT 10 ROWS ONLY;

Select product.ProductID, product.Name, product.ProductNumber, product.Color, product.Weight, sail.UnitPrice, sail.UnitPriceDiscount
from 
SalesLT.Product as product JOIN SalesLT.SalesOrderDetail as sail ON product.ProductID = sail.ProductID 

Select customer.CustomerID, customer.FirstName, customer.MiddleName, customer.LastName, customer.EmailAddress, customer.Phone, customerAddress.AddressType, adress.CountryRegion, adress.City, adress.PostalCode, adress.AddressLine1, adress.AddressLine2
from 
SalesLT.Customer as customer JOIN SalesLT.CustomerAddress as customerAddress ON customer.CustomerID = customerAddress.CustomerID
JOIN SalesLT.Address as adress ON customerAddress.AddressID = adress.AddressID

Select product.ProductID, product.Name, product.ProductNumber, category.Name, category.ParentProductCategoryID
from 
SalesLT.Product as product JOIN SalesLT.ProductCategory as category ON product.ProductCategoryID = category.ProductCategoryID

Select COUNT(*) from SalesLT.Product

Select COUNT(*) from SalesLT.Product Where SalesLT.Product.SellEndDate < GETDATE()

Select COUNT(*) from SalesLT.Product Where SalesLT.Product.Weight IS NULL 

Select AVG(Weight) from SalesLT.Product Where SalesLT.Product.Weight IS NOT NULL 

Select AVG(Weight) from SalesLT.Product

Select Min(Weight) from SalesLT.Product

Select Max(Weight) from SalesLT.Product

Select product.ProductCategoryID, category.Name, COUNT(*) ProductsInCategory, SUM(Weight) SummaryWeight, MAX(Weight) MaxWeight, MIN(Weight) MinWeight, AVG(Weight) AvgWeight
from SalesLT.Product product 
JOIN SalesLT.ProductCategory category ON product.ProductCategoryID = category.ProductCategoryID
Group By product.ProductCategoryID, category.Name

Select product.ProductCategoryID, category.Name, COUNT(*) ProductsInCategory, SUM(Weight) SummaryWeight
from SalesLT.Product product
JOIN SalesLT.ProductCategory category ON product.ProductCategoryID = category.ProductCategoryID
Group By product.ProductCategoryID, category.Name

Select product.ProductCategoryID, category.Name, COUNT(*) ProductsInCategory, SUM(Weight) SummaryWeight, MAX(Weight) MaxWeight, MIN(Weight) MinWeight, AVG(Weight) AvgWeight
from SalesLT.Product product
JOIN SalesLT.ProductCategory category ON product.ProductCategoryID = category.ProductCategoryID 
Group By product.ProductCategoryID, category.Name
 Having MAX(Weight) Is not null AND Min(Weight) Is not null AND Min(Weight) Is not null

 Select product.ProductCategoryID, category.Name, COUNT(*) ProductsInCategory, SUM(Weight) SummaryWeight, MAX(Weight) MaxWeight, MIN(Weight) MinWeight, AVG(Weight) AvgWeight
from SalesLT.Product product
JOIN SalesLT.ProductCategory category ON product.ProductCategoryID = category.ProductCategoryID 
Group By product.ProductCategoryID, category.Name
Having MAX(Weight) Is not null AND AVG(Weight) Is not null AND Min(Weight) Is not null AND MAX(Weight)>10000


 Select product.ProductCategoryID, category.Name, SUM(sale.UnitPrice) SummaryPrice
from SalesLT.Product product
JOIN SalesLT.ProductCategory category ON product.ProductCategoryID = category.ProductCategoryID 
JOIN SalesLT.SalesOrderDetail sale ON product.ProductID = sale.ProductID
Where Product.SellEndDate < GETDATE()
Group By product.ProductCategoryID, category.Name

Select Customer.FirstName, Max(detail.UnitPriceDiscount) 
from SalesLT.Customer as customer
JOIN SalesLT.SalesOrderHeader as header on header.CustomerID = customer.CustomerID
JOIN SalesLT.SalesOrderDetail as detail on detail.SalesOrderID = header.SalesOrderID
WHERE detail.UnitPriceDiscount >= 0.40
GROUP BY customer.FirstName

SELECT Customer.CustomerID, Sum(salesHeader.TotalDue) from SalesLT.Customer 
JOIN SalesLT.SalesOrderHeader salesHeader ON salesHeader.CustomerID = customer.CustomerID
JOIN SalesLT.SalesOrderDetail salesDetail ON salesDetail.SalesOrderID  = salesHeader.SalesOrderID
GROUP BY customer.CustomerID
HAVING  SUM(salesDetail.LineTotal) > 15000





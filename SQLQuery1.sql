SELECT Customers.CustomerID, Customers.TypeID, Types.TypeDesc,
    Customers.FirstName, Customers.LastName, Customers.Email,
    Customers.Phone, Customers.Company
FROM Customers, Types
WHERE Customers.TypeID = Types.TypeID
ORDER BY Customers.CustomerID;

CREATE DATABASE max_store;






CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(255),
    StockQuantity INT,
    Price DECIMAL(10, 2)
);



INSERT INTO Products (ProductID, ProductName, StockQuantity, Price) VALUES
(1, 'Protein Powder', 50, 29.99),
(2, 'Multivitamin', 100, 14.99),
(3, 'Fish Oil', 75, 19.99),
(4, 'Creatine', 30, 9.99),
(5, 'BCAA', 40, 24.99),
(6, 'Pre-Workout', 25, 34.99),
(7, 'Glutamine', 60, 17.99),
(8, 'Whey Protein', 70, 39.99),
(9, 'Casein Protein', 55, 44.99),
(10, 'Fat Burner', 20, 27.99);

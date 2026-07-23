-- =============================================
-- Initial Data Seed Script for library
-- =============================================

USE [library];
GO

-- 1. Seed Admins
IF NOT EXISTS (SELECT 1 FROM dbo.AdminList)
BEGIN
    INSERT INTO dbo.AdminList (AdminID, Username, Password, RealName, Phone)
    VALUES 
        ('A001', 'admin', 'admin123', 'System Administrator', '123-456-7890'),
        ('A002', 'Keiji', '201124', 'Keiji', '987-654-3210');
END
GO

-- 2. Seed Book Categories
IF NOT EXISTS (SELECT 1 FROM dbo.BookCategory)
BEGIN
    INSERT INTO dbo.BookCategory (CategoryID, CategoryName, Description)
    VALUES 
        ('C001', 'Fiction', 'Fictional books and novels'),
        ('C002', 'Science & Technology', 'Science, engineering and tech books'),
        ('C003', 'History', 'Historical literature and biographies');
END
GO

-- 3. Seed Sample Readers
IF NOT EXISTS (SELECT 1 FROM dbo.ReaderInfo)
BEGIN
    INSERT INTO dbo.ReaderInfo (ReaderID, ReaderName, Gender, Phone, Address)
    VALUES 
        ('R001', 'John Doe', 'Male', '555-0101', '123 Main St'),
        ('R002', 'Jane Smith', 'Female', '555-0102', '456 Oak Ave');
END
GO

-- 4. Seed Sample Books
IF NOT EXISTS (SELECT 1 FROM dbo.BookInfo)
BEGIN
    INSERT INTO dbo.BookInfo (BookID, BookName, CategoryID, Publisher, Author, Price, PublishDate, Introduction)
    VALUES 
        ('B001', 'The Great Gatsby', 'C001', 'Scribner', 'F. Scott Fitzgerald', 15.99, '1925-04-10', 'A novel about the American Dream in the 1920s.'),
        ('B002', 'Clean Code', 'C002', 'Prentice Hall', 'Robert C. Martin', 45.00, '2008-08-01', 'A handbook of agile software craftsmanship.');
END
GO

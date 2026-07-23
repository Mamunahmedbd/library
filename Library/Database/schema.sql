-- =============================================
-- Database Schema for Library Management System
-- Initial Catalog: library
-- =============================================

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'library')
BEGIN
    CREATE DATABASE [library];
END
GO

USE [library];
GO

-- 1. Admin Table
IF OBJECT_ID(N'dbo.AdminList', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.AdminList (
        AdminID   NVARCHAR(50)  NOT NULL PRIMARY KEY,
        Username  NVARCHAR(50)  NOT NULL,
        Password  NVARCHAR(255) NOT NULL,
        RealName  NVARCHAR(100) NULL,
        Phone     NVARCHAR(20)  NULL
    );
END
GO

-- 2. Book Category Table
IF OBJECT_ID(N'dbo.BookCategory', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.BookCategory (
        CategoryID   NVARCHAR(50)  NOT NULL PRIMARY KEY,
        CategoryName NVARCHAR(100) NOT NULL,
        Description  NVARCHAR(255) NULL
    );
END
GO

-- 3. Book Info Table
IF OBJECT_ID(N'dbo.BookInfo', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.BookInfo (
        BookID       NVARCHAR(50)   NOT NULL PRIMARY KEY,
        BookName     NVARCHAR(100)  NOT NULL,
        CategoryID   NVARCHAR(50)   NULL,
        Publisher    NVARCHAR(100)  NULL,
        Author       NVARCHAR(100)  NULL,
        Price        DECIMAL(18, 2) NULL DEFAULT 0,
        PublishDate  DATETIME       NULL,
        Introduction NVARCHAR(MAX)  NULL,
        CONSTRAINT FK_BookInfo_BookCategory FOREIGN KEY (CategoryID) REFERENCES dbo.BookCategory(CategoryID) ON DELETE SET NULL
    );
END
GO

-- 4. Reader Info Table
IF OBJECT_ID(N'dbo.ReaderInfo', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ReaderInfo (
        ReaderID   NVARCHAR(50)  NOT NULL PRIMARY KEY,
        ReaderName NVARCHAR(100) NOT NULL,
        Gender     NVARCHAR(10)  NULL,
        Phone      NVARCHAR(20)  NULL,
        Address    NVARCHAR(255) NULL
    );
END
GO

-- 5. Borrow Record Table
IF OBJECT_ID(N'dbo.BorrowRecord', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.BorrowRecord (
        RecordID   NVARCHAR(50) NOT NULL PRIMARY KEY,
        BookID     NVARCHAR(50) NOT NULL,
        ReaderID   NVARCHAR(50) NOT NULL,
        BorrowDate DATETIME     NOT NULL,
        DueDate    DATETIME     NOT NULL,
        ReturnDate DATETIME     NULL,
        IsReturn   NVARCHAR(20) NOT NULL DEFAULT 'borrowed', -- 'borrowed' or 'returned'
        Remark     NVARCHAR(255) NULL,
        CONSTRAINT FK_BorrowRecord_BookInfo FOREIGN KEY (BookID) REFERENCES dbo.BookInfo(BookID) ON DELETE CASCADE,
        CONSTRAINT FK_BorrowRecord_ReaderInfo FOREIGN KEY (ReaderID) REFERENCES dbo.ReaderInfo(ReaderID) ON DELETE CASCADE
    );
END
GO

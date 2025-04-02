USE master;


---- Drop database if it already exists
--IF EXISTS (SELECT name FROM sys.databases WHERE name = 'AuctionDB')
--BEGIN
--    ALTER DATABASE AuctionDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
--    DROP DATABASE AuctionDB;
--END
--GO

---- Create a new database
--CREATE DATABASE AuctionDB;
--GO

USE AuctionDB;


-- Create the User table
CREATE TABLE [User] (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);

-- Insert sample users
INSERT INTO [User] (Username, Email) VALUES ('auction_master', 'master@auctionsite.com');
INSERT INTO [User] (Username, Email) VALUES ('bidder123', 'bidder123@example.com');
INSERT INTO [User] (Username, Email) VALUES ('shinyThingsLover', 'shiney@example.com');
INSERT INTO [User] (Username, Email) VALUES ('vintageHunter', 'vintage@example.com');
INSERT INTO [User] (Username, Email) VALUES ('quickSniper', 'snipe@fastmail.com');
INSERT INTO [User] (Username, Email) VALUES ('dailyBidder', 'daily@example.com');
INSERT INTO [User] (Username, Email) VALUES ('rareCollector', 'collector@example.com');
INSERT INTO [User] (Username, Email) VALUES ('antiqueFan', 'antique@example.com');
INSERT INTO [User] (Username, Email) VALUES ('dealSeeker', 'dealseek@example.com');
INSERT INTO [User] (Username, Email) VALUES ('randomUser', 'user@example.com');


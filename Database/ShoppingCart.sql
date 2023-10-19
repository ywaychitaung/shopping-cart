-- -------------------------------------------------------------
-- TablePlus 5.5.2(512)
--
-- https://tableplus.com/
--
-- Database: ShoppingCart
-- Generation Time: 2023-10-17 15:42:42.6700
-- -------------------------------------------------------------


DROP TABLE IF EXISTS [dbo].[ActivationCode];
-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[ActivationCode] (
    [OrderId] int,
    [ProductId] int,
    [Code] varchar(100),
    PRIMARY KEY ([OrderId],[ProductId],[Code])
);

DROP TABLE IF EXISTS [dbo].[Cart];
-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[Cart] (
    [CartId] int IDENTITY,
    [UserId] int,
    [ProductId] int,
    [Quantity] int,
    PRIMARY KEY ([CartId])
);

DROP TABLE IF EXISTS [dbo].[Order];
-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[Order] (
    [OrderId] int IDENTITY,
    [OrderDate] varchar(50),
    [UserId] int,
    PRIMARY KEY ([OrderId])
);

DROP TABLE IF EXISTS [dbo].[OrderDetails];
-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[OrderDetails] (
    [OrderId] int,
    [ProductId] int,
    [Quantity] int,
    PRIMARY KEY ([OrderId],[ProductId])
);

DROP TABLE IF EXISTS [dbo].[Product];
-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[Product] (
    [ProductId] int,
    [Name] varchar(50),
    [Description] varchar(100),
    [Price] int,
    [ImageUrl] varchar(300),
    PRIMARY KEY ([ProductId])
);

DROP TABLE IF EXISTS [dbo].[User];
-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[User] (
    [UserId] int,
    [Name] varchar(50),
    [Username] varchar(50),
    [Password] varchar(200),
    PRIMARY KEY ([UserId])
);

INSERT INTO [dbo].[Product] ([ProductId], [Name], [Description], [Price], [ImageUrl]) VALUES
('1', N'.NET Charts', N'Bring powerful charting capabilites to your .NET applications.', '99', N'/images/net-charts.png'),
('2', N'.NET PayPal', N'Integrate your .NET apps with PayPal the easy way!', '69', N'/images/net-paypal.png'),
('3', N'.NET ML', N'Supercharged .NET machine leraning libraries.', '299', N'/images/net-ml.png'),
('4', N'.NET Analytics', N'Performs data mining and analytics easily in .NET.', '299', N'/images/net-analytics.png'),
('5', N'.NET Logger', N'Logs and aggregates events easily in your .NET apps.', '49', N'/images/net-logger.png'),
('6', N'.NET Numerics', N'Powerful numberical methods for your .NET simulations.', '199', N'/images/net-numerics.png');

INSERT INTO [dbo].[User] ([UserId], [Name], [Username], [Password]) VALUES
('1', N'Li Chongyang', N'barry', N'$2y$10$KdEhvvj/ZaGxLq0VaorRCup6uIHmt43ZegAArIYXMzzYhOuQpn/6K'),
('2', N'Yway Chit Aung', N'cappy', N'$2y$10$KdEhvvj/ZaGxLq0VaorRCup6uIHmt43ZegAArIYXMzzYhOuQpn/6K'),
('3', N'Ge Hongrui', N'zoe', N'$2y$10$KdEhvvj/ZaGxLq0VaorRCup6uIHmt43ZegAArIYXMzzYhOuQpn/6K'),
('4', N'Bryan Yeo Wei Ren', N'bryan', N'$2y$10$KdEhvvj/ZaGxLq0VaorRCup6uIHmt43ZegAArIYXMzzYhOuQpn/6K'),
('5', N'Wang Jiaqi', N'cathia', N'$2y$10$KdEhvvj/ZaGxLq0VaorRCup6uIHmt43ZegAArIYXMzzYhOuQpn/6K'),
('6', N'Hu Ruoqing', N'flora', N'$2y$10$KdEhvvj/ZaGxLq0VaorRCup6uIHmt43ZegAArIYXMzzYhOuQpn/6K'),
('7', N'Zhao Chen', N'kim', N'$2y$10$KdEhvvj/ZaGxLq0VaorRCup6uIHmt43ZegAArIYXMzzYhOuQpn/6K');


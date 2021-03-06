CREATE TABLE [UnitOfMeasurement] (
  [ID] int NOT NULL  IDENTITY (1,1)
, [UnitName] nvarchar(30) NOT NULL
);
GO
CREATE TABLE [Items] (
  [ID] int NOT NULL  IDENTITY (1,1)
, [NAME] nvarchar(70) NOT NULL
, [UoMID] int NOT NULL
, [UnitPrice] money NOT NULL
);
GO
CREATE TABLE [FirmDetails] (
  [FirmName] nvarchar(70) NOT NULL
, [Address] nvarchar(100) NULL
, [PhoneNumbers] nvarchar(100) NULL
);
GO
CREATE TABLE [FinancialYear] (
  [StartYear] int NOT NULL
, [BooksStartDate] datetime NOT NULL
);
GO
CREATE TABLE [Customers] (
  [ID] int NOT NULL  IDENTITY (1,1)
, [Name] nvarchar(70) NOT NULL
, [PhoneNumbers] nvarchar(100) NULL
, [MobileNumbers] nvarchar(100) NULL
, [Address] nvarchar(80) NULL
, [City] nvarchar(25) NULL
, [OpeningBalance] money NOT NULL DEFAULT 0.0
, [BalanceType] nchar(1) NULL
, [Notes] nvarchar(200) NULL
);
GO
CREATE TABLE [Payments] (
  [ID] int NOT NULL  IDENTITY (1,1)
, [CustomerID] int NOT NULL
, [PaymentDate] datetime NOT NULL
, [Amount] money NOT NULL
, [PaymentMode] nchar(1) NOT NULL
, [InstrumentNumber] nvarchar(20) NULL
, [Notes] nvarchar(60) NULL
);
GO
CREATE TABLE [BillMaster] (
  [ID] int NOT NULL  IDENTITY (1,1)
, [BillDate] datetime NOT NULL
, [CustomerID] int NULL
, [DiscountAmount] money NULL DEFAULT 0.0
, [ExpenseAmount] money NULL DEFAULT 0.0
, [ExpenseText] nvarchar(50) NULL
);
GO
CREATE TABLE [BillDetails] (
  [BillID] int NOT NULL
, [ItemID] int NOT NULL
, [UoMID] int NOT NULL
, [Rate] money NOT NULL
, [quantity] money NOT NULL
);
GO
ALTER TABLE [UnitOfMeasurement] ADD CONSTRAINT [PK__UnitOfMeasurement__0000000000000006] PRIMARY KEY ([ID]);
GO
ALTER TABLE [Items] ADD CONSTRAINT [PK__Items__0000000000000046] PRIMARY KEY ([ID]);
GO
ALTER TABLE [Customers] ADD CONSTRAINT [PK__Customers__0000000000000066] PRIMARY KEY ([ID]);
GO
ALTER TABLE [Payments] ADD CONSTRAINT [PK__Payments__ID] PRIMARY KEY ([ID]);
GO
ALTER TABLE [BillMaster] ADD CONSTRAINT [PK__BillMaster__ID] PRIMARY KEY ([ID]);
GO
ALTER TABLE [BillDetails] ADD CONSTRAINT [PK__BillDetails__BillID_ItemID] PRIMARY KEY ([BillID],[ItemID]);
GO
CREATE UNIQUE INDEX [UQ__UnitOfMeasurement__0000000000000034] ON [UnitOfMeasurement] ([UnitName] ASC);
GO
CREATE INDEX [IDX_ITEMS_MEASUREMENT_UNIT_ID] ON [Items] ([UoMID] ASC);
GO
CREATE UNIQUE INDEX [UQ__Items__000000000000004B] ON [Items] ([NAME] ASC);
GO
CREATE INDEX [IDX_Customers_City] ON [Customers] ([City] ASC);
GO
CREATE UNIQUE INDEX [UQ__Customers__000000000000006B] ON [Customers] ([Name] ASC);
GO
CREATE INDEX [IDX_Payments_CustomerID] ON [Payments] ([CustomerID] ASC);
GO
CREATE INDEX [IDX_Payments_PaymentDate] ON [Payments] ([PaymentDate] ASC);
GO
CREATE INDEX [IDX_Payments_PaymentMode] ON [Payments] ([PaymentMode] ASC);
GO
CREATE INDEX [IDX_BillMaster_BillDate] ON [BillMaster] ([BillDate] ASC);
GO
CREATE INDEX [IDX_BillMaster_CustomerID] ON [BillMaster] ([CustomerID] ASC);
GO
CREATE INDEX [IDX_BillDetails_BillID] ON [BillDetails] ([BillID] ASC);
GO
CREATE INDEX [IDX_BillDetails_ItemID] ON [BillDetails] ([ItemID] ASC);
GO
CREATE INDEX [IDX_BillDetails_UomID] ON [BillDetails] ([UoMID] ASC);
GO
ALTER TABLE [Items] ADD CONSTRAINT [FK__Items__0000000000000050] FOREIGN KEY ([UoMID]) REFERENCES [UnitOfMeasurement]([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
ALTER TABLE [Payments] ADD CONSTRAINT [FK__Payments__CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customers]([ID]) ON DELETE NO ACTION ON UPDATE CASCADE;
GO
ALTER TABLE [BillMaster] ADD CONSTRAINT [FK__BillMaster__CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customers]([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
ALTER TABLE [BillDetails] ADD CONSTRAINT [FK__BillDetails__BillID] FOREIGN KEY ([BillID]) REFERENCES [BillMaster]([ID]) ON DELETE CASCADE ON UPDATE CASCADE;
GO
ALTER TABLE [BillDetails] ADD CONSTRAINT [FK__BillDetails__ItemID] FOREIGN KEY ([ItemID]) REFERENCES [Items]([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
ALTER TABLE [BillDetails] ADD CONSTRAINT [FK__BillDetails__UoMID] FOREIGN KEY ([UoMID]) REFERENCES [UnitOfMeasurement]([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
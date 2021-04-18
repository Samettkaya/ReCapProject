CREATE TABLE [dbo].[Cars] (
    [CarID]       INT           IDENTITY (1, 1) NOT NULL,
    [CarName]     NVARCHAR (50) NULL,
    [BrandID]     INT           NULL,
    [ColorID]     INT           NULL,
    [ModelYear]   INT           NULL,
    [DailyPrice]  DECIMAL (18)  NULL,
    [Description] VARCHAR (100) NULL,
    [FindexScore] INT           NULL,
    PRIMARY KEY CLUSTERED ([CarID] ASC),
    FOREIGN KEY ([ColorID]) REFERENCES [dbo].[Colors] ([ColorID]),
    FOREIGN KEY ([BrandID]) REFERENCES [dbo].[Brands] ([BrandID])
)

7
CREATE TABLE [dbo].[Colors] (
    [ColorID]   INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([ColorID] ASC)
);

CREATE TABLE [dbo].[Brands] (
    [BrandID]   INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([BrandID] ASC)
);


CREATE TABLE [dbo].[Customers] (
    [CustomerId]  INT           IDENTITY (1, 1) NOT NULL,
    [UserId]      INT           NOT NULL,
    [CompanyName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserID])
);


CREATE TABLE [dbo].[Users] (
    [UserID]       INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50)    NOT NULL,
    [LastName]     VARCHAR (50)    NOT NULL,
    [Email]        VARCHAR (50)    NOT NULL,
    [PasswordHash] VARBINARY (500) NOT NULL,
    [PasswordSalt] VARBINARY (500) NOT NULL,
    [Status]       BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

CREATE TABLE [dbo].[UserOperationClaims] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [UserId]           INT NOT NULL,
    [OperationClaimId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserOperationClaims_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserID]),
    FOREIGN KEY ([OperationClaimId]) REFERENCES [dbo].[OperationClaims] ([Id])
);


CREATE TABLE [dbo].[OperationClaims] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Payments] (
    [Id]          INT          NOT NULL,
    [PaymentDate] DATETIME     NULL,
    [Total]       DECIMAL (18) NULL,
    [CustomerId]  INT          NULL,
    [CardId]      INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Payments_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_Cars] FOREIGN KEY ([CardId]) REFERENCES [dbo].[Cars] ([CarID]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[CreditCards] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [UserId]         INT          NOT NULL,
    [CardName]       VARCHAR (50) NOT NULL,
    [CardNumber]     VARCHAR (50) NOT NULL,
    [CardCvc]        VARCHAR (50) NOT NULL,
    [CardExpiration] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CreditCards_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserID]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Findeks] (
    [FindexId]   INT IDENTITY (1, 1) NOT NULL,
    [CustomerId] INT NOT NULL,
    [Score]      INT NOT NULL,
    PRIMARY KEY CLUSTERED ([FindexId] ASC),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])
);


CREATE TABLE [dbo].[Rentals] (
    [RentalId]   INT      IDENTITY (1, 1) NOT NULL,
    [CarId]      INT      NULL,
    [CustomerId] INT      NULL,
    [RentDate]   DATETIME NULL,
    [ReturnDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([RentalId] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarID]),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])
);

CREATE TABLE [dbo].[CarImages] (
    [ImageId]   INT           IDENTITY (1, 1) NOT NULL,
    [CarId]     INT           NOT NULL,
    [ImagePath] VARCHAR (MAX) NOT NULL,
    [Date]      DATE          NOT NULL,
    CONSTRAINT [PK_CarImages] PRIMARY KEY CLUSTERED ([ImageId] ASC),
    CONSTRAINT [FK_CarImages_Cars] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarID]) ON DELETE CASCADE
);







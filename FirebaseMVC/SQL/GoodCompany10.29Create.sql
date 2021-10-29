CREATE TABLE [UserProfile] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [FirebaseUserId] nvarchar(28) NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Application] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserProfileId] int NOT NULL,
  [CompanyId] int NOT NULL,
  [PositionLevelId] int NOT NULL,
  [Title] varchar(100) NOT NULL,
  [DateApplied] datetime,
  [NextAction] varchar(500) NOT NULL,
  [NextActionDue] datetime NOT NULL,
  [DateListed] datetime NOT NULL,
  [SalaryRangeLow] int,
  [SalaryRangeHigh] int,
  [FullBenefits] bit
)
GO

CREATE TABLE [Company] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [CompanySize] nvarchar(255) NOT NULL,
  [CompanyUrl] nvarchar(255) NOT NULL,
  [HasMentor] bit,
  [HasProfDev] bit
)
GO

CREATE TABLE [Skill] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [ApplicationSkill] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [SkillId] int,
  [ApplicationId] int
)
GO

CREATE TABLE [PositionLevel] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Level] nvarchar(255)
)
GO

CREATE TABLE [ApplicationNote] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [ApplicationId] int,
  [Note] varchar(500) NOT NULL
)
GO

CREATE TABLE [CompanyNote] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [CompanyId] int,
  [Note] varchar(500) NOT NULL
)
GO

ALTER TABLE [Application] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [Application] ADD FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [Application] ADD FOREIGN KEY ([PositionLevelId]) REFERENCES [PositionLevel] ([Id])
GO

ALTER TABLE [CompanyNote] ADD FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id])
GO

ALTER TABLE [ApplicationNote] ADD FOREIGN KEY ([ApplicationId]) REFERENCES [Application] ([Id])
GO

ALTER TABLE [ApplicationSkill] ADD FOREIGN KEY ([ApplicationId]) REFERENCES [Application] ([Id])
GO

ALTER TABLE [ApplicationSkill] ADD FOREIGN KEY ([SkillId]) REFERENCES [Skill] ([Id])
GO

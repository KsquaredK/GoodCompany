CREATE TABLE [UserProfile] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [FirebaseUserId] nvarchar(28) NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [DateCreated] datetime NOT NULL Default SysDateTime(),
  [Email] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Position] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Title] nvarchar(255) NOT NULL,
  [CompanyId] int NOT NULL,
  [DateListed] datetime NOT NULL,
  [Notes] text,
  [SalaryRangeBottom] int,
  [SalaryRangeTop] int,
  [FullBenefits] bit,
)
GO

CREATE TABLE [Application] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [PositionId] int NOT NULL,
  [UserProfileId] int NOT NULL,
  [DateApplied] datetime,
  [NextAction] text NOT NULL,
  [NextActionDue] datetime NOT NULL,
  [RecommenderNotes] text
)
GO

CREATE TABLE [Company] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [CompanySize] nvarchar(255) NOT NULL,
  [CompanyUrl] nvarchar(255) NOT NULL,
  [ContactNotes] text,
  [HasMentor] bit,
  [HasProfDev] bit
)
GO

CREATE TABLE [Skill] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [Level] nvarchar(255)
)
GO

CREATE TABLE [PositionSkill] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [PositionId] int,
  [SkillId] int
)
GO

ALTER TABLE [Application] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [Application] ADD FOREIGN KEY ([PositionId]) REFERENCES [Position] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [Position] ADD FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [PositionSkill] ADD FOREIGN KEY ([PositionId]) REFERENCES [Position] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [PositionSkill] ADD FOREIGN KEY ([SkillId]) REFERENCES [Skill] ([Id]) ON DELETE CASCADE
GO

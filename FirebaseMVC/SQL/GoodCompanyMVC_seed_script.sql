IF db_id('GoodCompanyMVC') IS NULL
	CREATE DATABASE [GoodCompanyMVC]
GO

USE [GoodCompanyMVC]
GO

SET IDENTITY_INSERT [UserProfile] ON
INSERT INTO [UserProfile] ( [Id], FirebaseUserId, [Name], DateCreated, Email ) VALUES ( 1, 'Z5waIIg7OJX8YJWNgb11oH3qYbI3', 'Meghna Chakrabarti', '2020-06-15', 'meghna@chakrabarti.com' )
INSERT INTO [UserProfile] ( [Id], FirebaseUserId, [Name], DateCreated, Email ) VALUES ( 2, 'hVS9Pay6EHOKBW8UbCJAEfEpuIB3', 'Yamiche Alcindor', '2021-03-15', 'yamiche@alcindor.com' )
INSERT INTO [UserProfile] ( [Id], FirebaseUserId, [Name], DateCreated, Email ) VALUES ( 3, 'pTdAGSxGWOR4WLumlPwNgqlIp0X2', 'Andrei Cordrescu', '2021-10-01', 'andrei@cordrescu.com' )
SET IDENTITY_INSERT [UserProfile] OFF

SET IDENTITY_INSERT [Company] ON
INSERT INTO Company ( [Id], [Name], CompanySize, HasMentor,  HasProfDev, CompanyUrl, ContactNotes ) VALUES ( 1, 'HCA', 'large', 1, 1, 'https://HCA.com', 'Bill Jenkins, 615-555-5555, Hiring Manager, called me 2021-10-31' )
INSERT INTO Company ( [Id], [Name], CompanySize, HasMentor,  HasProfDev, CompanyUrl, ContactNotes ) VALUES ( 2, 'Accenture', 'large', 1, 1, 'https://accenture.com', 'Rita Tenuti, 615-444-4444, HR Specialist, emailed me 2021-11-01' )
INSERT INTO Company ( [Id], [Name], CompanySize, HasMentor,  HasProfDev, CompanyUrl, ContactNotes ) VALUES ( 3, '40AU', 'small', 1, 1, 'https://40au.com', 'Garland Rice, 615-333-3333, HR Manager, called me 2021-10-29' )
INSERT INTO Company ( [Id], [Name], CompanySize, HasMentor,  HasProfDev, CompanyUrl, ContactNotes ) VALUES ( 4, 'Alliance Bernstein', 'large', 1, 1, 'https://alliancebernstein.com', 'Akio Takamori, 615-777-7777, Team Lead, DMed me 2021-11-02' )
SET IDENTITY_INSERT [Company] OFF

SET IDENTITY_INSERT [Position] ON
INSERT INTO Position ( [Id], Title, CompanyId, DateListed, Notes, SalaryRangeTop, SalaryRangeBottom, FullBenefits) VALUES ( 3, 'junior developer', 1, '2021-10-11', 'requires Angular', 56000, 52500, 0 )
INSERT INTO Position ( [Id], Title, CompanyId, DateListed, Notes, SalaryRangeTop, SalaryRangeBottom, FullBenefits) VALUES  ( 1, 'entry-level developer', 4, '2021-08-22', 'remote work possible', 62500, 57500, 1 )
INSERT INTO Position ( [Id], Title, CompanyId, DateListed, Notes, SalaryRangeTop, SalaryRangeBottom, FullBenefits) VALUES ( 2, 'junior full-stack developer', 3, '2021-09-27', 'no network contacts', 63000, 58000, 1 )
INSERT INTO Position ( [Id], Title, CompanyId, DateListed, Notes, SalaryRangeTop, SalaryRangeBottom, FullBenefits) VALUES ( 4, 'junior software engineer', 2, '2021-10-15', 'long hiring process', 68000, 63500 , 1 )
SET IDENTITY_INSERT [Position] OFF

SET IDENTITY_INSERT [Application] ON
INSERT INTO [Application] ( [Id], PositionId, UserProfileId, DateApplied, NextAction, NextActionDue  ) VALUES ( 1, 1, 3, '2021-10-20', 'DM hiring mgr on LI', '2021-10-21' )
INSERT INTO [Application] ( [Id], PositionId, UserProfileId, DateApplied, NextAction, NextActionDue  ) VALUES ( 2, 2, 2, '2021-10-26', 'email recruiter', '2021-10-27' )
INSERT INTO [Application] ( [Id], PositionId, UserProfileId, DateApplied, NextAction, NextActionDue  ) VALUES ( 3, 4, 1, '2021-10-29', 'call HR', '2021-10-30' )
INSERT INTO [Application] ( [Id], PositionId, UserProfileId, DateApplied, NextAction, NextActionDue  ) VALUES ( 4, 1, 1, '2021-10-22', 'DM hiring mgr 0n LI', '2021-10-23' )
INSERT INTO [Application] ( [Id], PositionId, UserProfileId, DateApplied, NextAction, NextActionDue  ) VALUES ( 5, 3, 3, '2021-10-25', 'text recruiter', '2021-10-26' )
SET IDENTITY_INSERT [Application] OFF

SET IDENTITY_INSERT [Skill] ON
INSERT INTO Skill ( [Id], [Name], [Level] ) VALUES ( 1, 'Javascript', 'Entry-level' )
INSERT INTO Skill ( [Id], [Name], [Level] ) VALUES ( 2, 'React', 'Entry-level' )
INSERT INTO Skill ( [Id], [Name], [Level] ) VALUES ( 3, 'C#', 'Entry-level' )
INSERT INTO Skill ( [Id], [Name], [Level] ) VALUES ( 4, 'CSS', 'Entry-level' )
INSERT INTO Skill ( [Id], [Name], [Level] ) VALUES ( 5, '.NET', 'Entry-level' )
INSERT INTO Skill ( [Id], [Name], [Level] ) VALUES ( 6, 'Javascript', 'Junior' )
INSERT INTO Skill ( [Id], [Name], [Level] ) VALUES ( 7, 'React', 'Junior' )
INSERT INTO Skill ( [Id], [Name], [Level] ) VALUES ( 8, 'C#', 'Junior' )
INSERT INTO Skill ( [Id], [Name], [Level] ) VALUES ( 9, 'CSS', 'Junior' )
INSERT INTO Skill ( [Id], [Name], [Level] ) VALUES ( 10, '.NET', 'Junior' )
SET IDENTITY_INSERT [Skill] OFF

SET IDENTITY_INSERT [PositionSkill] ON
INSERT INTO PositionSkill ( [Id], PositionId, SkillId ) VALUES ( 1, 1, 4 )
INSERT INTO PositionSkill ( [Id], PositionId, SkillId ) VALUES ( 2, 3, 8 )
INSERT INTO PositionSkill ( [Id], PositionId, SkillId ) VALUES ( 3, 4, 10 )
INSERT INTO PositionSkill ( [Id], PositionId, SkillId ) VALUES ( 4, 2, 1 )
SET IDENTITY_INSERT [PositionSkill] OFF
USE [GoodCompany]
GO

SET IDENTITY_INSERT [UserProfile] ON
INSERT INTO [UserProfile] ( [Id], FirebaseUserId, [Name], Email ) VALUES ( 1, 'Z5waIIg7OJX8YJWNgb11oH3qYbI3', 'Meghna Chakrabarti', 'meghna@chakrabarti.com' )
INSERT INTO [UserProfile] ( [Id], FirebaseUserId, [Name], Email ) VALUES ( 2, 'hVS9Pay6EHOKBW8UbCJAEfEpuIB3', 'Yamiche Alcindor', 'yamiche@alcindor.com' )
INSERT INTO [UserProfile] ( [Id], FirebaseUserId, [Name], Email ) VALUES ( 3, 'pTdAGSxGWOR4WLumlPwNgqlIp0X2', 'Andrei Cordrescu', 'andrei@cordrescu.com' )
SET IDENTITY_INSERT [UserProfile] OFF

SET IDENTITY_INSERT [Company] ON
INSERT INTO Company ( [Id], [Name], CompanySize, HasMentor,  HasProfDev, CompanyUrl ) VALUES ( 1, 'HCA', 'large', 1, 1, 'https://HCA.com' )
INSERT INTO Company ( [Id], [Name], CompanySize, HasMentor,  HasProfDev, CompanyUrl ) VALUES ( 2, 'Accenture', 'large', 1, 1, 'https://accenture.com' )
INSERT INTO Company ( [Id], [Name], CompanySize, HasMentor,  HasProfDev, CompanyUrl ) VALUES ( 3, '40AU', 'small', 1, 1, 'https://40au.com' )
INSERT INTO Company ( [Id], [Name], CompanySize, HasMentor,  HasProfDev, CompanyUrl ) VALUES ( 4, 'Alliance Bernstein', 'large', 1, 1, 'https://alliancebernstein.com' )
SET IDENTITY_INSERT [Company] OFF

SET IDENTITY_INSERT [CompanyNote] ON
INSERT INTO CompanyNote ( [Id], CompanyId, Note )  VALUES ( 1, 4, 'Bill Jenkins, 615-555-5555, Hiring Manager, called me 2021-10-31' )
INSERT INTO CompanyNote ( [Id], CompanyId, Note )  VALUES ( 2, 1, 'Rita Tenuti, 615-444-4444, HR Specialist, emailed me 2021-11-01' )
INSERT INTO CompanyNote ( [Id], CompanyId, Note )  VALUES ( 3, 2, 'Andrew Kerr, 615-333-3333, HR Manager, met at Demo Day' )
INSERT INTO CompanyNote ( [Id], CompanyId, Note )  VALUES ( 4, 3, 'Akio Takamori, 615-777-7777, Team Lead, DMed me 2021-11-02' )
INSERT INTO CompanyNote ( [Id], CompanyId, Note )  VALUES ( 5, 2, 'Kerry Corcoran works in IT')
SET IDENTITY_INSERT [CompanyNote] OFF

SET IDENTITY_INSERT [PositionLevel] ON
INSERT INTO PositionLevel ( [Id], Level ) VALUES ( 1, 'Entry-level')
INSERT INTO PositionLevel ( [Id], Level ) VALUES ( 2, 'Junior' )
INSERT INTO PositionLevel ( [Id], Level ) VALUES ( 3, 'Intern' )
INSERT INTO PositionLevel ( [Id], Level ) VALUES ( 4, 'Apprentice' )
INSERT INTO PositionLevel ( [Id], Level ) VALUES ( 5, 'Developer' )
INSERT INTO PositionLevel ( [Id], Level ) VALUES ( 6, 'Senior' )
INSERT INTO PositionLevel ( [Id], Level ) VALUES ( 7, 'Team Lead' )
INSERT INTO PositionLevel ( [Id], Level ) VALUES ( 8, 'Project Manager' )
SET IDENTITY_INSERT [PositionLevel] OFF

SET IDENTITY_INSERT [Skill] ON
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 1, 'Javascript' )
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 2, 'React' )
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 3, 'C#' )
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 4, 'CSS' )
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 5, '.NET' )
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 6, 'Python' )
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 7, 'Ruby' )
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 8, 'SQL' )
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 9, 'Django' )
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 10, 'Go' )
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 11, 'Svelte' )
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 12, 'NodeJS' )
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 13, 'Vue' )
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 14, 'Java' )
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 15, 'Typescript' )
INSERT INTO Skill ( [Id], [Name] ) VALUES ( 16, 'AWS' )
SET IDENTITY_INSERT [Skill] OFF

SET IDENTITY_INSERT [Application] ON
INSERT INTO [Application] ( [Id], UserProfileId, CompanyId, PositionLevelId, Title, DateApplied, NextAction, NextActionDue, DateListed, SalaryRangeLow, SalaryRangeHigh, FullBenefits ) VALUES ( 1, 3, 4, 1, 'Junior Developer', '202-10-20', 'DM hiring mgr on LI', '2021-10-21', '2021-10-11', 68000, 63000 , 1  )
INSERT INTO [Application] ( [Id], UserProfileId, CompanyId, PositionLevelId, Title, DateApplied, NextAction, NextActionDue, DateListed, SalaryRangeLow, SalaryRangeHigh, FullBenefits ) VALUES ( 2, 2, 2, 2, 'Entry-Level Backend Developer', '2021-10-26', 'email recruiter', '2021-10-27', '2021-08-22', 56000, 52500, 0 )
INSERT INTO [Application] ( [Id], UserProfileId, CompanyId, PositionLevelId, Title, DateApplied, NextAction, NextActionDue, DateListed, SalaryRangeLow, SalaryRangeHigh, FullBenefits ) VALUES ( 3, 1, 1, 4, 'Apprentice FullStack Developer', '2021-10-29', 'call HR', '2021-10-30', '2021-09-27', 62500, 57500, 1  )
INSERT INTO [Application] ( [Id], UserProfileId, CompanyId, PositionLevelId, Title, DateApplied, NextAction, NextActionDue, DateListed, SalaryRangeLow, SalaryRangeHigh, FullBenefits ) VALUES ( 4, 2, 3, 1, 'Entry-Level JavaScript Dev', '2021-10-22', 'DM hiring mgr 0n LI', '2021-10-23', '2021-10-15', 63000, 58000, 1 )
INSERT INTO [Application] ( [Id], UserProfileId, CompanyId, PositionLevelId, Title, DateApplied, NextAction, NextActionDue, DateListed, SalaryRangeLow, SalaryRangeHigh, FullBenefits ) VALUES ( 5, 3, 4, 5, 'Junior Software Engineer', '2021-10-25', 'text recruiter', '2021-10-26', '2021-10-22', 68000, 63500 , 1 )
SET IDENTITY_INSERT [Application] OFF

SET IDENTITY_INSERT [ApplicationSkill] ON
INSERT INTO ApplicationSkill ( [Id], SkillID, ApplicationId ) VALUES ( 1, 8, 4 )
INSERT INTO ApplicationSkill ( [Id], SkillID, ApplicationId ) VALUES ( 2, 2, 2 )
INSERT INTO ApplicationSkill ( [Id], SkillID, ApplicationId ) VALUES ( 3, 4, 3 )
INSERT INTO ApplicationSkill ( [Id], SkillID, ApplicationId ) VALUES ( 4, 3, 1 )
INSERT INTO ApplicationSkill ( [Id], SkillID, ApplicationId ) VALUES ( 5, 12, 5 )
INSERT INTO ApplicationSkill ( [Id], SkillID, ApplicationId ) VALUES ( 6, 15, 3 )
SET IDENTITY_INSERT [ApplicationSkill] OFF

SET IDENTITY_INSERT [ApplicationNote] ON
INSERT INTO ApplicationNote ( [Id], ApplicationId, Note ) VALUES ( 1, 3, 'requires Angular' )
INSERT INTO ApplicationNote ( [Id], ApplicationId, Note ) VALUES ( 2, 1, 'remote work possible' )
INSERT INTO ApplicationNote ( [Id], ApplicationId, Note ) VALUES ( 3, 4, 'no network contacts' )
INSERT INTO ApplicationNote ( [Id], ApplicationId, Note ) VALUES ( 4, 1, 'long hiring process' )
INSERT INTO ApplicationNote ( [Id], ApplicationId, Note ) VALUES ( 5, 2, 'rec from Keisha Keynes' )
SET IDENTITY_INSERT [ApplicationNote] OFF




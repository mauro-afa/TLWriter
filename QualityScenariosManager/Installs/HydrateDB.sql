DELETE FROM St_Keywords;
DELETE FROM St_Networks;
DELETE FROM St_Versions;


--
-- Dumping data for table `St_Keywords`
--
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (1,'2 Wire Over IP');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (2,'7-ELEVEN');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (3,'7-ELEVEN-Conoco');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (4,'7ELEVEN-EXXON');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (5,'ADD2REGRESSION');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (6,'APPLAUSE');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (7,'BP');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (8,'CHEVRON');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (9,'CITGO');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (10,'CONCORD');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (11,'CONTROL CENTER');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (12,'CORE');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (13,'DASHBOARD');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (14,'DEFECT');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (15,'Dual Tank Monitor');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (16,'EMV');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (17,'EXCEPTION');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (18,'EXXON');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (19,'FDC');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (20,'FUNCTIONAL');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (21,'HPSC');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (22,'HPSD');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (23,'HPSD-Generic_brand');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (24,'Incomm');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (25,'IOL');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (26,'Kris Sprint 13 Test Cases');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (27,'MARATHON');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (28,'NBS');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (29,'P66');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (30,'PADSS');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (31,'PADSS-Lite');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (32,'REGRESSION');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (33,'SANITY CHECK');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (34,'SHELL');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (35,'SITE SERVER');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (36,'SMOKE TEST');
INSERT INTO [dbo].[St_Keywords] ([id],[KeywordName])
VALUES (37,'WORLDPAY');

--
-- Dumping data for table `St_Versions`
--

INSERT INTO [dbo].[St_Versions] ([id],[Version])
VALUES(1, 'v11.02');
INSERT INTO [dbo].[St_Versions] ([id],[Version])
VALUES(2, 'v99.99');

--
-- Dumping data for table `St_Networks`
--

INSERT INTO [dbo].[St_Networks] ([id],[NetworkName])
VALUES (1,'ADS Chicago');
INSERT INTO [dbo].[St_Networks] ([id],[NetworkName])
VALUES (2,'ADS Dallas');
INSERT INTO [dbo].[St_Networks] ([id],[NetworkName])
VALUES (3,'BP');
INSERT INTO [dbo].[St_Networks] ([id],[NetworkName])
VALUES (4,'Chevron');
INSERT INTO [dbo].[St_Networks] ([id],[NetworkName])
VALUES (5,'Concord');
INSERT INTO [dbo].[St_Networks] ([id],[NetworkName])
VALUES (6,'ExxonMobil');
INSERT INTO [dbo].[St_Networks] ([id],[NetworkName])
VALUES (7,'HPSChicago');
INSERT INTO [dbo].[St_Networks] ([id],[NetworkName])
VALUES (8,'IOL');
INSERT INTO [dbo].[St_Networks] ([id],[NetworkName])
VALUES (9,'NBS');
INSERT INTO [dbo].[St_Networks] ([id],[NetworkName])
VALUES (10,'RBS');
INSERT INTO [dbo].[St_Networks] ([id],[NetworkName])
VALUES (11,'Shell');
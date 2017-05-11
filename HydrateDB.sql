insert into TestSuites(Name, Jiralink, Brand, Version, UploadDate) values('DODO XXXX - Test suite', 'http://jirapos.gso.gilbarco.com:8080/browse/DODO-4743', 'Chevron', '11.02', GETDATE());
insert into TestSuites(Name, Jiralink, Brand, Version, UploadDate) values('DODO XXXX - Test suite2', 'http://jirapos.gso.gilbarco.com:8080/browse/DODO-4724', 'CONCORD', '11.02', GETDATE());

insert into TestCases(TCID, TSID, TestCaseID, TestObjective, Preconditions, Actions, Expec_res, Keyword, Exec_type, Importance, Stat)
values('1', '1', 'TestCase1', 'Objective1', 'Preconditions1', 'Actions1', 'Expected result 1', 'Keyword1;Keyword2;Keyword3;', '1', '2', '1');

insert into TestCases(TCID, TSID, TestCaseID, TestObjective, Preconditions, Actions, Expec_res, Keyword, Exec_type, Importance, Stat)
values('2', '1', 'TestCase2', 'Objective2', 'Preconditions2', 'Actions2', 'Expected result 2', 'Keyword1;Keyword2;Keyword3;', '1', '2', '1');

insert into TestCases(TCID, TSID, TestCaseID, TestObjective, Preconditions, Actions, Expec_res, Keyword, Exec_type, Importance, Stat)
values('1', '2', 'TestCase1', 'Objective1', 'Preconditions1', 'Actions1', 'Expected result 1', 'Keyword1;Keyword2;Keyword3;', '1', '2', '1');

insert into TestCases(TCID, TSID, TestCaseID, TestObjective, Preconditions, Actions, Expec_res, Keyword, Exec_type, Importance, Stat)
values('2', '2', 'TestCase2', 'Objective2', 'Preconditions2', 'Actions2', 'Expected result 2', 'Keyword1;Keyword2;Keyword3;', '1', '2', '1');

insert into TestCases(TCID, TSID, TestCaseID, TestObjective, Preconditions, Actions, Expec_res, Keyword, Exec_type, Importance, Stat)
values('3', '2', 'TestCase3', 'Objective3', 'Preconditions3', 'Actions3', 'Expected result 3', 'Keyword1;Keyword2;Keyword3;', '1', '2', '1');

select * from TestSuites
select * from TestCases
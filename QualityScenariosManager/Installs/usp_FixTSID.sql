CREATE PROCEDURE [dbo].[FixTSIDNumber]
	@TSID int
AS
	SET  @TSID = @TSID - 1
	UPDATE TestSuite set @TSID = TestSuiteID = @TSID + 1
RETURN 0
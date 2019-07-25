SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
GO
-- =============================================
-- Author:      Zachary Curry
-- Create date: 2019-01-01
-- Description: Retrieves values for a drop down
-- Revised:          
-- =============================================
ALTER PROCEDURE dbo.--ProcName
	@ApplicationUser	UNIQUEIDENTIFIER = NULL
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	--============================Debug
	DECLARE @Debug INT = 0;

	--DECLARE @ApplicationUser UNIQUEIDENTIFIER     = NULL

	--============================Audit Logging
	IF(@ApplicationUser IS NOT NULL)
	BEGIN
		DECLARE @ci VARBINARY (128) = CAST(CAST(LEFT(COALESCE(OBJECT_NAME(@@PROCID), ''), 90) AS VARCHAR (90)) + ';' + COALESCE(CAST(@ApplicationUser AS VARCHAR (38)), '') + SPACE(128) AS BINARY (128));
		SET CONTEXT_INFO @ci;
	END;

	--     ============================SP Body
	BEGIN TRY
		BEGIN TRANSACTION;

		

		IF @Debug = 1
			ROLLBACK TRANSACTION;
		ELSE
			COMMIT TRANSACTION;

	END TRY
	BEGIN CATCH

		IF(
		@@TRANCOUNT > 0
			OR XACT_STATE() <> 0
		)
			ROLLBACK TRANSACTION;

		--INCLUDE ALL INPUT PARAMETERS HERE FOR ERROR LOGGING
		DECLARE @Parameters XML =
					(
						SELECT	@ApplicationUser	AS ApplicationUser
						FOR XML PATH(N'Parameters'), ELEMENTS XSINIL
					);

		INSERT INTO dbo.DatabaseDiagnostics
			(
			ProcedureName
			,[Parameters]
			,TotalResultsReturned
			,ExecutedUser
			,ErrorNum
			,ErrorSeverity
			,ErrorState
			,ErrorLine
			,ErrorMessage
			)
					SELECT
						COALESCE(OBJECT_NAME(@@PROCID), 'Manually run code')
						,@Parameters
						,@@ROWCOUNT
						,SUSER_SNAME()
						,ERROR_NUMBER()
						,ERROR_SEVERITY()
						,ERROR_STATE()
						,ERROR_LINE()
						,ERROR_MESSAGE();

		RAISERROR('A stored procedure has encountered an error. Please refer to the database diagnostics.', 16, 1);

	END CATCH;

END;
GO
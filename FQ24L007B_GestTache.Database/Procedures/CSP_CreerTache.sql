CREATE PROCEDURE [dbo].[CSP_CreerTache]
	@Titre NVARCHAR(255)
AS
BEGIN
	IF @Titre IS NULL OR LEN(TRIM(@Titre)) = 0
	BEGIN
		RAISERROR (N'Titre invalide', 16, 1);
		RETURN -1;
	END

	INSERT INTO Tache (Titre) VALUES (TRIM(@Titre));
	RETURN 0;
END
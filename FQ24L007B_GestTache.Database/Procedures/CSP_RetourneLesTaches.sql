CREATE PROCEDURE [dbo].[CSP_RetourneLesTaches]
AS
BEGIN
	SELECT Id, Titre, Creation, Termine FROM Tache;
	RETURN 0
END
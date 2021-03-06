USE [hcm401koptimizer]
GO

alter PROCEDURE [dbo].[hcm401kGetUserTickersInfo] 
	
AS
BEGIN
	SET NOCOUNT ON;

    select u.Username,u.FirstName,u.LastName,u.Email, up.PropertyValue as [DefaultTicker]
from UserProfile up
inner join ProfilePropertyDefinition ppd on up.PropertyDefinitionID = ppd.PropertyDefinitionID
inner join Users u on u.UserID = up.UserID
where ppd.PropertyName = 'CompanyTicker'
END

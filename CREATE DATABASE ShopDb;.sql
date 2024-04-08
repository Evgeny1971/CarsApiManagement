CREATE PROCEDURE [dbo].[stp_CreateOrder]
    @CompanyName NVARCHAR(50),
    @CompanyHp NVARCHAR(10),
    @Date DATETIME2,
    @Comment NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @OrderId INT;

    -- Insert into Orders table
    INSERT INTO [dbo].[Orders] ([CompanyName], [CompanyHp], [Date], [Comment])
    VALUES (@CompanyName, @CompanyHp, @Date, @Comment);

    -- Get the newly inserted OrderId
    SET @OrderId = SCOPE_IDENTITY();
    SELECT @OrderId AS OrderId;
END;

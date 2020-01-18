CREATE PROCEDURE [dbo].[UpdateAction]
	@ID int, @Title nvarchar(50), @Source nvarchar(50), @Description nvarchar(50), @Priority int, @DeadLine1 nvarchar(50), @DeadLine2 nvarchar(50),
	@DeadLineFinal nvarchar(50), @ErrorMsg nvarchar(50),
    @AssignTeam nvarchar(50), @PatchDetails nvarchar(50), @IsResolved nvarchar(50), @Status nvarchar(50)
AS
	UPDATE BugRecords
	set Title=@Title, BugRecords.Source=@Source, Description=@Description, Priority=@Priority, DeadLine1 = @DeadLine1,
	DeadLine2=@DeadLine2, DeadLineFinal=@DeadLineFinal, ErrorMsg=@ErrorMsg,AssignTeam=@AssignTeam, PatchDetails=@PatchDetails,
	IsResolved=@IsResolved, Status = @Status where Id =@ID


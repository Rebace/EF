Use Todo
IF NOT EXISTS( SELECT TOP 1 1 FROM sys.tables WHERE [name] = 'Todo' )
BEGIN
	CREATE TABLE [Todo] (
		[Id] INT IDENTITY(1,1) CONSTRAINT PK_todo PRIMARY KEY,
		[Title] NVARCHAR(255) NOT NULL,
		[IsDone] BIT NOT NULL
	)
END
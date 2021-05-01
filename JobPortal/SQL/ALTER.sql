SELECT * from JobSeeker

ALTER TABLE JobSeeker ADD DOB DATE
GO
ALTER TABLE JobSeeker ALTER  COLUMN Country INT
GO
ALTER TABLE JobSeeker ADD FOREIGN KEY  (Country) REFERENCES  Countries(ID)
GO

EXEC sp_rename 'JobSeeker.IsMale', 'GENDER', 'COLUMN';
GO

ALTER TABLE JobSeeker ADD IsJava bit default 0
go 
ALTER TABLE JobSeeker ADD IsDotnet bit default 0
go
ALTER TABLE JobSeeker ADD IsSAP bit default 0
go



ALTER TABLE JobSeeker ALTER  COLUMN Mobile nvarchar(13)
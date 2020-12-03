USE BigMac 
GO 
ALTER DATABASE BigMac set TRUSTWORTHY ON; 
GO 
EXEC dbo.sp_changedbowner @loginame = N'sa', @map = false 
GO 
sp_configure 'show advanced options', 1; 
GO 
RECONFIGURE; 
GO 
sp_configure 'clr enabled', 1; 
GO 
RECONFIGURE; 
GO

create ASSEMBLY FuzzySharp from 'C:\Users\xxx\source\repos\FuzzySharp\FuzzySharp\bin\Debug\net46\FuzzySharp.dll' 
WITH PERMISSION_SET = SAFE  
GO 

create FUNCTION FuzzyMatch(@input1 NVARCHAR(MAX), @input2 NVARCHAR(MAX)) 
RETURNS float   
AS EXTERNAL NAME FuzzySharp.[FuzzySharp.FuzzyMatcher].FuzzyMatch; 
--           ASSEMBLY.CLASS___.METHOD
GO 

-- drop FUNCTION FuzzyMatch
-- drop ASSEMBLY FuzzySharp

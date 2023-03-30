CREATE DATABASE [TEST]

USE TEST
GO

CREATE TABLE [dbo].[tblCustomers](
	[idCustomer] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[LastName] [varchar](200) NOT NULL,
	[Birthdate] [datetime] NULL,
	[ProfilePicture] [varbinary](max) NULL,
	[CivilStatus] [int] NULL,
	[Brothers] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


INSERT INTO [dbo].[tblCustomers]
           ([Name]
           ,[LastName]
           ,[Birthdate]
           ,[ProfilePicture]
           ,[CivilStatus]
           ,[Brothers])
     VALUES
           ('Fernando'
           ,'Vargas'
           ,1985-05-25
           ,null>
           ,1
           ,true>);

SELECT * FROM [dbo].[tblCustomers]
        
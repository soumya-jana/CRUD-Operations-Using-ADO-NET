USE [ECOM]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 16-Mar-2022 05:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[CustomerEmail] [varchar](50) NOT NULL,
	[CustomerGender] [varchar](50) NULL,
	[CustomerDOB] [varchar](50) NULL,
	[CustomerPhone] [varchar](15) NOT NULL,
	[CustomerSurvey] [varchar](100) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_Add_Customer]    Script Date: 16-Mar-2022 05:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usp_Add_Customer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Usp_Add_Customer] AS' 
END
GO

ALTER PROCEDURE [dbo].[Usp_Add_Customer]
	@CustomerEmail VARCHAR(50),
	@CustomerGender VARCHAR(50) = NULL,
	@CustomerDOB VARCHAR(50) = NULL,
	@CustomerPhone VARCHAR(15),
	@CustomerSurvey VARCHAR(100) = NULL
           ([CustomerName]
           ,[CustomerEmail]
           ,[CustomerGender]
           ,[CustomerDOB]
           ,[CustomerPhone]
           ,[CustomerSurvey])
     VALUES
           (@CustomerName
           ,@CustomerEmail
           ,@CustomerGender
           ,@CustomerDOB
           ,@CustomerPhone
           ,@CustomerSurvey)
GO
/****** Object:  StoredProcedure [dbo].[Usp_Del_Customer]    Script Date: 16-Mar-2022 05:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usp_Del_Customer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Usp_Del_Customer] AS' 
END
GO

ALTER PROCEDURE [dbo].[Usp_Del_Customer]

END
GO
/****** Object:  StoredProcedure [dbo].[Usp_Get_Customers]    Script Date: 16-Mar-2022 05:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usp_Get_Customers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Usp_Get_Customers] AS' 
END
GO

ALTER PROCEDURE [dbo].[Usp_Get_Customers]
GO
/****** Object:  StoredProcedure [dbo].[Usp_Set_Customer]    Script Date: 16-Mar-2022 05:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usp_Set_Customer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Usp_Set_Customer] AS' 
END
GO

ALTER PROCEDURE [dbo].[Usp_Set_Customer]
	@CustomerName VARCHAR(50),
	@CustomerEmail VARCHAR(50),
	@CustomerGender VARCHAR(50) = NULL,
	@CustomerDOB VARCHAR(50) = NULL,
	@CustomerPhone VARCHAR(15),
	@CustomerSurvey VARCHAR(100) = NULL
	SET  [CustomerName] = @CustomerName
		,[CustomerEmail] = @CustomerEmail
		,[CustomerGender] = @CustomerGender
		,[CustomerDOB] = @CustomerDOB
		,[CustomerPhone] = @CustomerPhone
		,[CustomerSurvey] = @CustomerSurvey
	WHERE CustomerID = @CustomerID

END
GO
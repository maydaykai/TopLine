/****** Object:  UserDefinedFunction [dbo].[GetChildColumn]    Script Date: 12/15/2015 10:17:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetChildColumn]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetChildColumn]
GO
/****** Object:  StoredProcedure [dbo].[Proc_ColumnAdd]    Script Date: 12/15/2015 10:17:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proc_ColumnAdd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Proc_ColumnAdd]
GO
/****** Object:  StoredProcedure [dbo].[Proc_ColumnUpdate]    Script Date: 12/15/2015 10:17:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proc_ColumnUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Proc_ColumnUpdate]
GO
/****** Object:  StoredProcedure [dbo].[Proc_RoleAdd]    Script Date: 12/15/2015 10:17:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proc_RoleAdd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Proc_RoleAdd]
GO
/****** Object:  StoredProcedure [dbo].[Proc_RoleUpdate]    Script Date: 12/15/2015 10:17:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proc_RoleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Proc_RoleUpdate]
GO
/****** Object:  Table [dbo].[Right]    Script Date: 12/15/2015 10:17:36 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Right_Visible]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Right] DROP CONSTRAINT [DF_Right_Visible]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Right_CreateTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Right] DROP CONSTRAINT [DF_Right_CreateTime]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Right_UpdateTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Right] DROP CONSTRAINT [DF_Right_UpdateTime]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Right]') AND type in (N'U'))
DROP TABLE [dbo].[Right]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/15/2015 10:17:36 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Role_Status]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Role] DROP CONSTRAINT [DF_Role_Status]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Role_CreateTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Role] DROP CONSTRAINT [DF_Role_CreateTime]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Role_UpdateTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Role] DROP CONSTRAINT [DF_Role_UpdateTime]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
DROP TABLE [dbo].[Role]
GO
/****** Object:  Table [dbo].[RoleRight]    Script Date: 12/15/2015 10:17:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleRight]') AND type in (N'U'))
DROP TABLE [dbo].[RoleRight]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/15/2015 10:17:36 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_FcmsUser_ParentID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_FcmsUser_ParentID]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_FcmsUser_IsLock]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_FcmsUser_IsLock]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_FcmsUser_UpdateTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_FcmsUser_UpdateTime]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[Column]    Script Date: 12/15/2015 10:17:36 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Column_ParentID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Column] DROP CONSTRAINT [DF_Column_ParentID]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Column_Sort]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Column] DROP CONSTRAINT [DF_Column_Sort]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Column_Visible]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Column] DROP CONSTRAINT [DF_Column_Visible]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Column_CreateTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Column] DROP CONSTRAINT [DF_Column_CreateTime]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Column_UpdateTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Column] DROP CONSTRAINT [DF_Column_UpdateTime]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Column]') AND type in (N'U'))
DROP TABLE [dbo].[Column]
GO
/****** Object:  Table [dbo].[ColumnRight]    Script Date: 12/15/2015 10:17:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ColumnRight]') AND type in (N'U'))
DROP TABLE [dbo].[ColumnRight]
GO
/****** Object:  UserDefinedFunction [dbo].[fun_SplitToTable]    Script Date: 12/15/2015 10:17:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fun_SplitToTable]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fun_SplitToTable]
GO
/****** Object:  UserDefinedFunction [dbo].[Get_StrArrayLength]    Script Date: 12/15/2015 10:17:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Get_StrArrayLength]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Get_StrArrayLength]
GO
/****** Object:  UserDefinedFunction [dbo].[Get_StrArrayStrOfIndex]    Script Date: 12/15/2015 10:17:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Get_StrArrayStrOfIndex]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Get_StrArrayStrOfIndex]
GO
/****** Object:  UserDefinedFunction [dbo].[Get_StrArrayStrOfIndex]    Script Date: 12/15/2015 10:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Get_StrArrayStrOfIndex]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE function [dbo].[Get_StrArrayStrOfIndex]
(
  @str varchar(2000),  --要分割的字符串
  @split varchar(10),  --分隔符号
  @index int --取第几个元素
)
returns varchar(2000)
as
begin
  declare @location int
  declare @start int
  declare @next int
  declare @seed int

  set @str=ltrim(rtrim(@str))
  set @start=1
  set @next=1
  set @seed=len(@split)
  
  set @location=charindex(@split,@str)
  while @location<>0 and @index>@next
  begin
    set @start=@location+@seed
    set @location=charindex(@split,@str,@start)
    set @next=@next+1
  end
  if @location =0 select @location =len(@str)+1 
 --这儿存在两种情况：1、字符串不存在分隔符号 2、字符串中存在分隔符号，跳出while循环后，@location为0，那默认为字符串后边有一个分隔符号。
  
  return substring(@str,@start,@location-@start)
end

' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[Get_StrArrayLength]    Script Date: 12/15/2015 10:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Get_StrArrayLength]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE function [dbo].[Get_StrArrayLength]
(
  @str varchar(max),  --要分割的字符串
  @split varchar(10)  --分隔符号
)
returns int
as
begin
  declare @location int
  declare @start int
  declare @length int

  set @str=ltrim(rtrim(@str))
  set @location=charindex(@split,@str)
  set @length=1
  while @location<>0
  begin
    set @start=@location+1
    set @location=charindex(@split,@str,@start)
    set @length=@length+1
  end
  return @length
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fun_SplitToTable]    Script Date: 12/15/2015 10:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fun_SplitToTable]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'


CREATE FUNCTION [dbo].[fun_SplitToTable]
  (
      @SplitString nvarchar(max),
      @Separator nvarchar(10)='' ''
 )
  RETURNS @SplitStringsTable TABLE
  (
  [id] int identity(1,1),
  [value] nvarchar(max)
 ) AS
 BEGIN
     DECLARE @CurrentIndex int;
     DECLARE @NextIndex int;
     DECLARE @ReturnText nvarchar(max);
     SELECT @CurrentIndex=1;
     WHILE(@CurrentIndex<=len(@SplitString))
         BEGIN
             SELECT @NextIndex=charindex(@Separator,@SplitString,@CurrentIndex);
             IF(@NextIndex=0 OR @NextIndex IS NULL)
                 SELECT @NextIndex=len(@SplitString)+1;
                 SELECT @ReturnText=substring(@SplitString,@CurrentIndex,@NextIndex-@CurrentIndex);
                 INSERT INTO @SplitStringsTable([value]) VALUES(@ReturnText);
                SELECT @CurrentIndex=@NextIndex+1;
             END
     RETURN;
 END


' 
END
GO
/****** Object:  Table [dbo].[ColumnRight]    Script Date: 12/15/2015 10:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ColumnRight]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ColumnRight](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ColumnID] [int] NULL,
	[RightID] [int] NULL,
 CONSTRAINT [PK_ColumnRight] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ColumnRight', N'COLUMN',N'ColumnID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ColumnRight', @level2type=N'COLUMN',@level2name=N'ColumnID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ColumnRight', N'COLUMN',N'RightID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ColumnRight', @level2type=N'COLUMN',@level2name=N'RightID'
GO
/****** Object:  Table [dbo].[Column]    Script Date: 12/15/2015 10:17:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Column]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Column](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[LinkUrl] [nvarchar](200) NULL,
	[ICon] [nvarchar](100) NULL,
	[ParentID] [int] NOT NULL CONSTRAINT [DF_Column_ParentID]  DEFAULT ((0)),
	[Sort] [int] NOT NULL CONSTRAINT [DF_Column_Sort]  DEFAULT ((0)),
	[Visible] [bit] NOT NULL CONSTRAINT [DF_Column_Visible]  DEFAULT ((1)),
	[CreateTime] [datetime] NULL CONSTRAINT [DF_Column_CreateTime]  DEFAULT (getdate()),
	[UpdateTime] [datetime] NULL CONSTRAINT [DF_Column_UpdateTime]  DEFAULT (getdate()),
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Column] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Column', N'COLUMN',N'ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Column', @level2type=N'COLUMN',@level2name=N'ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Column', N'COLUMN',N'Name'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Column', @level2type=N'COLUMN',@level2name=N'Name'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Column', N'COLUMN',N'LinkUrl'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Column', @level2type=N'COLUMN',@level2name=N'LinkUrl'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Column', N'COLUMN',N'ICon'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Column', @level2type=N'COLUMN',@level2name=N'ICon'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Column', N'COLUMN',N'ParentID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Column', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Column', N'COLUMN',N'Sort'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Column', @level2type=N'COLUMN',@level2name=N'Sort'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Column', N'COLUMN',N'Visible'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Column', @level2type=N'COLUMN',@level2name=N'Visible'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Column', N'COLUMN',N'CreateTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Column', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Column', N'COLUMN',N'UpdateTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Column', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Column', N'COLUMN',N'Description'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Column', @level2type=N'COLUMN',@level2name=N'Description'
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/15/2015 10:17:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NOT NULL CONSTRAINT [DF_FcmsUser_ParentID]  DEFAULT ((0)),
	[UserName] [varchar](50) NULL,
	[PassWord] [varchar](50) NULL,
	[RealName] [nvarchar](50) NULL,
	[AnotherName] [nvarchar](50) NULL,
	[Sex] [int] NULL,
	[Phone] [varchar](20) NULL,
	[Mobile] [varchar](20) NULL,
	[Email] [nvarchar](200) NULL,
	[QQ] [varchar](20) NULL,
	[RegTime] [datetime] NULL,
	[LastLoginTime] [datetime] NULL,
	[LastIP] [varchar](50) NULL,
	[Times] [int] NULL,
	[IsLock] [bit] NULL CONSTRAINT [DF_FcmsUser_IsLock]  DEFAULT ((0)),
	[UpdateTime] [datetime] NULL CONSTRAINT [DF_FcmsUser_UpdateTime]  DEFAULT (getdate()),
	[RoleID] [varchar](100) NULL,
 CONSTRAINT [PK_FcmsUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'ParentID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上一级用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'UserName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'UserName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'PassWord'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'PassWord'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'RealName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RealName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'AnotherName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'别名（别称）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'AnotherName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'Sex'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别：0-女 1-男' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Sex'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'Phone'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'座机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Phone'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'Mobile'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'Email'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电子邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Email'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'RegTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RegTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'LastLoginTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'LastLoginTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'LastIP'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次登录IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'LastIP'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'Times'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Times'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'IsLock'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否禁用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'IsLock'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'UpdateTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'User', N'COLUMN',N'RoleID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
/****** Object:  Table [dbo].[RoleRight]    Script Date: 12/15/2015 10:17:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleRight]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RoleRight](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[ColumnID] [int] NOT NULL,
	[RightID] [int] NOT NULL,
 CONSTRAINT [PK_RoleRights] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'RoleRight', N'COLUMN',N'RoleID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleRight', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'RoleRight', N'COLUMN',N'ColumnID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleRight', @level2type=N'COLUMN',@level2name=N'ColumnID'
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/15/2015 10:17:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [int] NOT NULL CONSTRAINT [DF_Role_Status]  DEFAULT ((0)),
	[CreateTime] [datetime] NULL CONSTRAINT [DF_Role_CreateTime]  DEFAULT (getdate()),
	[Description] [nvarchar](500) NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF_Role_UpdateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Role', N'COLUMN',N'ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户组ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Role', N'COLUMN',N'Name'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Name'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Role', N'COLUMN',N'Status'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核状态：0-复审中，1-复审通过 2-复审不通过' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Status'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Role', N'COLUMN',N'CreateTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Role', N'COLUMN',N'Description'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Description'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Role', N'COLUMN',N'UpdateTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
/****** Object:  Table [dbo].[Right]    Script Date: 12/15/2015 10:17:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Right]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Right](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RightName] [nvarchar](50) NULL,
	[Visible] [bit] NULL CONSTRAINT [DF_Right_Visible]  DEFAULT ((1)),
	[CreateTime] [datetime] NULL CONSTRAINT [DF_Right_CreateTime]  DEFAULT (getdate()),
	[UpdateTime] [datetime] NULL CONSTRAINT [DF_Right_UpdateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Right] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Right', N'COLUMN',N'ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Right', @level2type=N'COLUMN',@level2name=N'ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Right', N'COLUMN',N'RightName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Right', @level2type=N'COLUMN',@level2name=N'RightName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Right', N'COLUMN',N'Visible'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Right', @level2type=N'COLUMN',@level2name=N'Visible'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Right', N'COLUMN',N'CreateTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Right', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Right', N'COLUMN',N'UpdateTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Right', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
/****** Object:  StoredProcedure [dbo].[Proc_RoleUpdate]    Script Date: 12/15/2015 10:17:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proc_RoleUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,>
-- Create date: <Create Date,2013-12-27>
-- Description:	<Description,修改角色及角色权限>
-- =============================================
Create PROCEDURE [dbo].[Proc_RoleUpdate]
	@ID INT,
	@Name NVARCHAR(50),
	@Status INT,
	@Description NVARCHAR(500),
	@UpdateTime DATETIME,
	@RoleRight VARCHAR(4000)
AS
BEGIN
	DECLARE @errorTal INT --错误统计
	SET @errorTal=0
	begin TRAN
		
	    DELETE  FROM dbo.RoleRight WHERE RoleID=@ID --先删除所有角色权限
	    SET @errorTal=@errorTal+@@ERROR
		UPDATE [dbo].[Role] SET Name=@Name,[Status]=@Status,[Description]=@Description,UpdateTime=@UpdateTime WHERE ID=@ID				
		SET @errorTal=@errorTal+@@ERROR	
		DECLARE @next INT,@RightStr VARCHAR(20)
		set @next=1				
		while (@next<=dbo.Get_StrArrayLength(@RoleRight,'',''))
		BEGIN									
			set @RightStr=dbo.Get_StrArrayStrOfIndex(@RoleRight,'','',@next)						
			INSERT INTO dbo.RoleRight(RoleID,ColumnID,RightID )
			VALUES (@ID,SUBSTRING(@RightStr,0,CHARINDEX(''|'',@RightStr,0)),SUBSTRING(@RightStr,CHARINDEX(''|'',@RightStr,0)+1,LEN(@RightStr)-CHARINDEX(''|'',@RightStr,0)))
			SET @errorTal=@errorTal+@@ERROR		
			set @next=@next+1
	    END
	    
		if(@errortal<>0) 
		BEGIN
			ROLLBACK TRAN
			RETURN 0;
		END
		else
		BEGIN
			COMMIT TRAN
			RETURN 1;
		END	
END


' 
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_RoleAdd]    Script Date: 12/15/2015 10:17:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proc_RoleAdd]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,>
-- Create date: <Create Date,2013-12-29>
-- Description:	<Description,添加角色及角色权限>
-- =============================================
CREATE PROCEDURE [dbo].[Proc_RoleAdd]
	@Name NVARCHAR(50),
	@Status INT,
	@Description NVARCHAR(500),
	@CreateTime DATETIME,
	@UpdateTime DATETIME,
	@RoleRight VARCHAR(4000)
AS
BEGIN
	DECLARE @errorTal INT --错误统计
	SET @errorTal=0
	begin TRAN
		--添加角色
		DECLARE @RoleId int
		insert into [dbo].[Role] (Name,[Status],[Description],CreateTime,UpdateTime)
		values(@Name,@Status,@Description,@CreateTime,@UpdateTime)			
		SET @errorTal=@errorTal+@@ERROR
		SELECT @RoleId=SCOPE_IDENTITY()	
		--分配的权限
		DECLARE @next INT,@RightStr VARCHAR(20)
		
		set @next=1				
		while (@next<=dbo.Get_StrArrayLength(@RoleRight,'',''))
		BEGIN									
			set @RightStr=dbo.Get_StrArrayStrOfIndex(@RoleRight,'','',@next)						
			INSERT INTO dbo.RoleRight(RoleID,ColumnID,RightID )
			VALUES (@RoleId,SUBSTRING(@RightStr,0,CHARINDEX(''|'',@RightStr,0)),SUBSTRING(@RightStr,CHARINDEX(''|'',@RightStr,0)+1,LEN(@RightStr)-CHARINDEX(''|'',@RightStr,0)))
			SET @errorTal=@errorTal+@@ERROR		
			set @next=@next+1
	    END
	    
		if(@errortal<>0) 
		BEGIN
			ROLLBACK TRAN
			RETURN 0;
		END
		else
		BEGIN
			COMMIT TRAN
			RETURN 1;
		END	
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_ColumnUpdate]    Script Date: 12/15/2015 10:17:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proc_ColumnUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,
-- Create date: <Create Date,2013-12-25>
-- Description:	<Description,修改栏目及栏目操作权限>
-- =============================================
CREATE PROCEDURE [dbo].[Proc_ColumnUpdate]
	@ID INT,
	@name NVARCHAR(50),
	@LinkUrl NVARCHAR(200),
	@ICon NVARCHAR(100),
	@Sort int,
	@Visible BIT,
	@Description NVARCHAR(200),
	@RightStr NVARCHAR(200)
AS
BEGIN
	DECLARE @errorTal INT --错误统计
	SET @errorTal=0
	begin TRAN
	    DECLARE @ColumnID INT	
	    DELETE  FROM dbo.[ColumnRight] WHERE ColumnID=@ID
	    SET @errorTal=@errorTal+@@ERROR
		UPDATE [dbo].[Column] SET name=@name,LinkUrl=@LinkUrl,ICon=@ICon,Sort=@Sort,[Description]=@Description
		WHERE ID=@ID				
		SET @errorTal=@errorTal+@@ERROR
		SELECT @ColumnID=@ID
		SET @errorTal=@errorTal+@@ERROR
		DECLARE @next INT,@RighrID INT
		set @next=1				
		while (@next<=dbo.Get_StrArrayLength(@RightStr,'',''))
		BEGIN							
			set @RighrID=dbo.Get_StrArrayStrOfIndex(@RightStr,'','',@next)	
			INSERT INTO dbo.ColumnRight( ColumnID, RightID )VALUES (@ColumnID,@RighrID)
			SET @errorTal=@errorTal+@@ERROR
			set @next=@next+1
	    END
	    
	    --如果父级栏目被修改是否显示 下面所有子栏目也修改是否显示
		declare @t table(id INT)
		insert @t select @ID --设置父ID
		while 1=1
		begin
		   insert @t select id from dbo.[Column] where ParentID in(select id from @t) and id not in(select id from @t)
		   --SET @errorTal=@errorTal+@@ERROR
		   if @@rowcount=0
			 break
		END		
		UPDATE dbo.[Column] SET Visible=@Visible WHERE ID IN(select id from @t)
	    
		if(@errortal<>0) 
		BEGIN
			ROLLBACK TRAN
			RETURN 0;
		END
		else
		BEGIN
			COMMIT TRAN
			RETURN 1;
		END	
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_ColumnAdd]    Script Date: 12/15/2015 10:17:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proc_ColumnAdd]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,>
-- Create date: <Create Date,2013-12-20>
-- Description:	<Description,添加栏目及栏目操作权限>
-- =============================================
CREATE PROCEDURE [dbo].[Proc_ColumnAdd]
	@name NVARCHAR(50),
	@LinkUrl NVARCHAR(200),
	@ICon NVARCHAR(100),
	@ParentID int,
	@Sort int,
	@Visible BIT,
	@Description NVARCHAR(200),
	@RightStr NVARCHAR(200)
AS
BEGIN
	DECLARE @errorTal INT --错误统计
	SET @errorTal=0
	begin TRAN
	    DECLARE @ColumnID INT	    
		INSERT INTO [Column](name,LinkUrl,ICon,ParentID,Sort,Visible,[Description])
		VALUES(@name,@LinkUrl,@ICon,@ParentID,@Sort,@Visible,@Description)
		SET @errorTal=@errorTal+@@ERROR
		SELECT @ColumnID=SCOPE_IDENTITY()
		DECLARE @next INT,@RighrID INT
		set @next=1				
		while (@next<=dbo.Get_StrArrayLength(@RightStr,'',''))
		BEGIN							
			set @RighrID=dbo.Get_StrArrayStrOfIndex(@RightStr,'','',@next)	
			INSERT INTO dbo.ColumnRight( ColumnID, RightID )VALUES (@ColumnID,@RighrID)
			SET @errorTal=@errorTal+@@ERROR
			set @next=@next+1
	    END
		if(@errortal<>0) 
		BEGIN
			ROLLBACK TRAN
			RETURN 0;
		END
		else
		BEGIN
			COMMIT TRAN
			RETURN 1;
		END	
END
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetChildColumn]    Script Date: 12/15/2015 10:17:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetChildColumn]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE function [dbo].[GetChildColumn](@ID int)
returns @t table(ID int,ParentID int,Level INT, Name nvarchar(50), Visible bit)
as
begin
    declare @i int,@ret varchar(8000)
    set @i = 1
    insert into @t select ID,ParentID, @i, Name, Visible from [Column] where ParentID = @ID
     
    while @@rowcount<>0
    begin
        set @i = @i + 1
         
        insert into @t 
        select 
            a.ID,a.ParentID,@i, a.Name, a.Visible 
        from 
            [Column] a,@t b 
        where 
            a.ParentID=b.ID and b.Level = @i-1
    end
    return
end

' 
END
GO

USE [TopLine]
GO

/****** Object:  Table [dbo].[Article]    Script Date: 12/22/2015 17:55:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Article](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OID] [varchar](50) NULL,
	[Title] [nvarchar](100) NULL,
	[Content] [nvarchar](max) NULL,
	[Imgs] [varchar](500) NULL,
	[IsHot] [bit] NULL,
	[IsBot] [bit] NULL,
	[Type] [varchar](50) NULL,
	[Status] [smallint] NULL,
	[AuditStatus] [smallint] NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_Article_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标识ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Article', @level2type=N'COLUMN',@level2name=N'OID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Article', @level2type=N'COLUMN',@level2name=N'Title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Article', @level2type=N'COLUMN',@level2name=N'Content'
GO	

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Article', @level2type=N'COLUMN',@level2name=N'Imgs'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否热门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Article', @level2type=N'COLUMN',@level2name=N'IsHot'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型：包括play、img、txt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Article', @level2type=N'COLUMN',@level2name=N'Type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态：1，添加成功；2，上传失败；3上传成功' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Article', @level2type=N'COLUMN',@level2name=N'Status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核状态：0，初审中；1，初审失败；2，复审中；3，复审失败；4，复审成功' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Article', @level2type=N'COLUMN',@level2name=N'AuditStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本地创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Article', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务器创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Article', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO



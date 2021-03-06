USE [ESMDB]
GO
/****** Object:  Table [dbo].[driver]    Script Date: 27.10.2020 17:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[driver](
	[driver_id] [bigint] NOT NULL,
	[driver_firstName] [nvarchar](50) NOT NULL,
	[driver_secondName] [nvarchar](50) NOT NULL,
	[home_depot] [bigint] NOT NULL,
	[home_esm] [bigint] NULL,
 CONSTRAINT [PK_driver] PRIMARY KEY CLUSTERED 
(
	[driver_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_2]    Script Date: 27.10.2020 17:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_2]
AS
SELECT        TOP (100) PERCENT driver_id, driver_firstName, driver_secondName, home_depot
FROM            dbo.driver
ORDER BY driver_secondName, driver_firstName, driver_id, home_depot
GO
/****** Object:  Table [dbo].[depot]    Script Date: 27.10.2020 17:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[depot](
	[depot_id] [bigint] NOT NULL,
	[depot_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_depot_1] PRIMARY KEY CLUSTERED 
(
	[depot_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_1]    Script Date: 27.10.2020 17:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_1]
AS
SELECT        TOP (100) PERCENT depot_id, depot_name
FROM            dbo.depot
ORDER BY depot_id, depot_name
GO
/****** Object:  Table [dbo].[esm]    Script Date: 27.10.2020 17:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[esm](
	[esm_id] [bigint] NOT NULL,
	[home_depot] [bigint] NOT NULL,
	[status] [tinyint] NOT NULL,
	[last_depot] [bigint] NULL,
	[last_driver] [bigint] NULL,
	[last_date_using] [date] NOT NULL,
 CONSTRAINT [PK_esm_1] PRIMARY KEY CLUSTERED 
(
	[esm_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_3]    Script Date: 27.10.2020 17:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_3]
AS
SELECT        TOP (100) PERCENT esm_id, home_depot, status, last_date_using
FROM            dbo.esm
ORDER BY last_date_using, status, esm_id, home_depot
GO
/****** Object:  Table [dbo].[role]    Script Date: 27.10.2020 17:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[role_id] [smallint] NOT NULL,
	[role_desc] [varchar](50) NOT NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[token]    Script Date: 27.10.2020 17:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[token](
	[token_id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_id] [bigint] NOT NULL,
	[token] [varchar](200) NOT NULL,
	[expire_date] [datetime] NOT NULL,
 CONSTRAINT [PK_token] PRIMARY KEY CLUSTERED 
(
	[token_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 27.10.2020 17:03:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[user_id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](50) NOT NULL,
	[user_password] [nvarchar](50) NOT NULL,
	[role_id] [smallint] NOT NULL,
	[hire_date] [datetime] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[depot] ([depot_id], [depot_name]) VALUES (1, N'Ярославль')
INSERT [dbo].[depot] ([depot_id], [depot_name]) VALUES (5, N'Иваново')
INSERT [dbo].[depot] ([depot_id], [depot_name]) VALUES (6, N'Буй')
INSERT [dbo].[depot] ([depot_id], [depot_name]) VALUES (10, N'Череповец')
INSERT [dbo].[depot] ([depot_id], [depot_name]) VALUES (11, N'Лоста')
INSERT [dbo].[depot] ([depot_id], [depot_name]) VALUES (13, N'Няндома')
INSERT [dbo].[depot] ([depot_id], [depot_name]) VALUES (15, N'Исакогорка')
INSERT [dbo].[depot] ([depot_id], [depot_name]) VALUES (19, N'Котлас')
INSERT [dbo].[depot] ([depot_id], [depot_name]) VALUES (21, N'Сосногорск')
INSERT [dbo].[depot] ([depot_id], [depot_name]) VALUES (22, N'Печора')
INSERT [dbo].[depot] ([depot_id], [depot_name]) VALUES (24, N'Воркута')
INSERT [dbo].[depot] ([depot_id], [depot_name]) VALUES (25, N'Челябинск')
INSERT [dbo].[driver] ([driver_id], [driver_firstName], [driver_secondName], [home_depot], [home_esm]) VALUES (12312312, N'Олег', N'Иванов', 1, NULL)
INSERT [dbo].[driver] ([driver_id], [driver_firstName], [driver_secondName], [home_depot], [home_esm]) VALUES (12312313, N'Игорь', N'Войтенко', 5, NULL)
INSERT [dbo].[driver] ([driver_id], [driver_firstName], [driver_secondName], [home_depot], [home_esm]) VALUES (12312314, N'Джейсон', N'Стетхем', 11, NULL)
INSERT [dbo].[driver] ([driver_id], [driver_firstName], [driver_secondName], [home_depot], [home_esm]) VALUES (12312315, N'Виктор', N'Ерохин', 24, NULL)
INSERT [dbo].[driver] ([driver_id], [driver_firstName], [driver_secondName], [home_depot], [home_esm]) VALUES (12312316, N'Ким', N'Рокин', 15, NULL)
INSERT [dbo].[esm] ([esm_id], [home_depot], [status], [last_depot], [last_driver], [last_date_using]) VALUES (1231231, 11, 1, 11, NULL, CAST(N'1999-11-12' AS Date))
INSERT [dbo].[esm] ([esm_id], [home_depot], [status], [last_depot], [last_driver], [last_date_using]) VALUES (1231232, 5, 2, 11, NULL, CAST(N'2001-11-13' AS Date))
INSERT [dbo].[esm] ([esm_id], [home_depot], [status], [last_depot], [last_driver], [last_date_using]) VALUES (1231233, 24, 3, 1, 12312312, CAST(N'2011-03-15' AS Date))
INSERT [dbo].[role] ([role_id], [role_desc]) VALUES (1, N'admin')
INSERT [dbo].[role] ([role_id], [role_desc]) VALUES (2, N'worker')
SET IDENTITY_INSERT [dbo].[token] ON 

INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (1, 1, N'GbOT9rOMIvbJMkdoDyUdwpb9nphODpJ0KfUAUJKNU1A=', CAST(N'2021-04-27T12:29:00.470' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (2, 1, N'2OIDpIEPaEWlt/+7Z0+03cDOFvYxgEZlqs44lImAG58=', CAST(N'2020-10-27T12:31:27.927' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (3, 1, N'x2nZRV+jw+KHdd3C5f7D4PtpdvoG65wVJBd3Ou3FkdU=', CAST(N'2020-10-27T12:33:18.623' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (4, 1, N'fAGYnNihUDyQDUOCPuwQyWDtZY5NFG/Z7Vwlmgth+Do=', CAST(N'2020-10-27T12:35:51.850' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (5, 1, N'0ukm7cl1aCZhGFH395dokiMZv8o9s8sXqzMOJy6HCNg=', CAST(N'2020-10-27T12:36:28.980' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (6, 1, N'QJzXXjA1Z3ifRuZORk0pbv8ZEpHdrVWrtuvoErWIxAo=', CAST(N'2020-10-27T12:38:29.233' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (7, 1, N'Ltl9dQ9d89iZmJOTOYfT+fypgoWkOsfnNHmX8kQ2rvU=', CAST(N'2020-10-27T12:38:37.863' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (8, 1, N'mFrpkgbQKfa+TXnna4CH5oVx4x70UZzrMpgOxukJcr0=', CAST(N'2020-10-27T12:38:38.857' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (9, 1, N'JqUIq0W+NqjMTg9yw6w/fk6Ucl8E1/n/++P6tLEh/uU=', CAST(N'2020-10-27T12:38:39.787' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (10, 1, N'Dd92JeUbpU3Xup7zuaPuRUY6OpRzHkS3KmH+LaqUVoI=', CAST(N'2020-10-27T12:38:40.647' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (11, 1, N'+4EcXjMht7/fJM/voEIoPuJ/kCffVxnztW46OzWu38U=', CAST(N'2020-10-27T12:38:41.403' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (12, 1, N'ztOKyf0JirpZBKySxQJl1iDknXGcA8utnvZb3EoMl4U=', CAST(N'2020-10-27T12:38:42.200' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (13, 1, N't+3tABmbjDJZXZe3KVDH0GnLwv4GKNODtII5+zX5HX4=', CAST(N'2020-10-27T12:38:43.070' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (14, 1, N'jusjqI8wt3OMHf8WMrdYNBzgxEHK69lEWujD5tAVl6M=', CAST(N'2020-10-27T12:38:43.937' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (15, 1, N'wK8w1LjwEnudCbiHkpgqQ/xMP1pw+TQjRr9OIlfhcfk=', CAST(N'2020-10-27T12:45:23.727' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (16, 1, N'Y2Bqac2Eu5oIlcnVLhKwqV7bj+fdL53xasobsyezs6k=', CAST(N'2020-10-27T12:45:37.923' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (17, 1, N'LS8ElcyAd08RNjXjZWNy6moWmEWVY2Nl7xJ2hKiHT4I=', CAST(N'2020-10-27T12:45:47.703' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (18, 2, N'sBxltxupcHYMrI1F7nBuKerpEKNwthBPj/liK6G+kZY=', CAST(N'2020-10-27T12:51:09.403' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (19, 2, N'pwNrCb07GSVV9qcZPVlYTKfUkL5bJwx2rDkCxKQLdq0=', CAST(N'2020-10-27T12:53:06.660' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (20, 3, N'ZhAbLg3YuEBlEO+3wXhb/DKK3T9LriNdOaRhTaZeVKs=', CAST(N'2020-10-27T13:27:34.093' AS DateTime))
INSERT [dbo].[token] ([token_id], [user_id], [token], [expire_date]) VALUES (21, 3, N'C+QPqV0dBWS/tt0aCoUoF7TseuDyZ0EWB3gk1GEme0U=', CAST(N'2020-10-27T13:28:05.573' AS DateTime))
SET IDENTITY_INSERT [dbo].[token] OFF
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([user_id], [user_name], [user_password], [role_id], [hire_date]) VALUES (1, N'1', N'123', 1, CAST(N'1999-11-11T00:00:00.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [user_name], [user_password], [role_id], [hire_date]) VALUES (2, N'2', N'123', 1, CAST(N'1999-11-11T00:00:00.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [user_name], [user_password], [role_id], [hire_date]) VALUES (3, N'3', N'123', 1, CAST(N'1999-11-11T00:00:00.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [user_name], [user_password], [role_id], [hire_date]) VALUES (4, N'4', N'123', 1, CAST(N'1999-11-11T00:00:00.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [user_name], [user_password], [role_id], [hire_date]) VALUES (5, N'5', N'123', 1, CAST(N'1999-11-11T00:00:00.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [user_name], [user_password], [role_id], [hire_date]) VALUES (6, N'6', N'123', 1, CAST(N'1999-11-11T00:00:00.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [user_name], [user_password], [role_id], [hire_date]) VALUES (7, N'7', N'123', 1, NULL)
SET IDENTITY_INSERT [dbo].[user] OFF
ALTER TABLE [dbo].[driver]  WITH CHECK ADD  CONSTRAINT [FK_driver_depot] FOREIGN KEY([home_depot])
REFERENCES [dbo].[depot] ([depot_id])
GO
ALTER TABLE [dbo].[driver] CHECK CONSTRAINT [FK_driver_depot]
GO
ALTER TABLE [dbo].[driver]  WITH CHECK ADD  CONSTRAINT [FK_driver_esm] FOREIGN KEY([home_esm])
REFERENCES [dbo].[esm] ([esm_id])
GO
ALTER TABLE [dbo].[driver] CHECK CONSTRAINT [FK_driver_esm]
GO
ALTER TABLE [dbo].[esm]  WITH CHECK ADD  CONSTRAINT [FK_esm_depot] FOREIGN KEY([home_depot])
REFERENCES [dbo].[depot] ([depot_id])
GO
ALTER TABLE [dbo].[esm] CHECK CONSTRAINT [FK_esm_depot]
GO
ALTER TABLE [dbo].[esm]  WITH CHECK ADD  CONSTRAINT [FK_esm_depot1] FOREIGN KEY([last_depot])
REFERENCES [dbo].[depot] ([depot_id])
GO
ALTER TABLE [dbo].[esm] CHECK CONSTRAINT [FK_esm_depot1]
GO
ALTER TABLE [dbo].[esm]  WITH CHECK ADD  CONSTRAINT [FK_esm_driver] FOREIGN KEY([last_driver])
REFERENCES [dbo].[driver] ([driver_id])
GO
ALTER TABLE [dbo].[esm] CHECK CONSTRAINT [FK_esm_driver]
GO
ALTER TABLE [dbo].[token]  WITH CHECK ADD  CONSTRAINT [FK_token_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([user_id])
GO
ALTER TABLE [dbo].[token] CHECK CONSTRAINT [FK_token_user]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[role] ([role_id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_role]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "depot"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "driver"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "esm"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_3'
GO

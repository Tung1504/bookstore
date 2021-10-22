USE [BookStore]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 10/22/2021 10:58:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[city] [nvarchar](max) NOT NULL,
	[district] [nvarchar](max) NOT NULL,
	[user_id] [int] NOT NULL,
	[postal_code] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Author]    Script Date: 10/22/2021 10:58:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[author_name] [nvarchar](255) NOT NULL,
	[description] [nvarchar](max) NULL,
	[birth_year] [nvarchar](50) NULL,
	[status] [nvarchar](50) NULL,
	[image] [nvarchar](50) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Book]    Script Date: 10/22/2021 10:58:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](max) NOT NULL,
	[price] [int] NOT NULL,
	[quantity_in_stock] [int] NOT NULL,
	[publisher_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
	[author_id] [int] NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[image] [nvarchar](max) NOT NULL,
	[public_date] [date] NULL,
	[edition] [nvarchar](max) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/22/2021 10:58:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 10/22/2021 10:58:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_number] [int] NOT NULL,
	[shipping_price] [int] NOT NULL,
	[status] [nvarchar](50) NOT NULL,
	[payment_status] [nvarchar](50) NOT NULL,
	[total_price] [float] NOT NULL,
	[user_id] [int] NOT NULL,
	[date] [date] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order_Detail]    Script Date: 10/22/2021 10:58:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Detail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[book_id] [int] NOT NULL,
	[order_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[total_price] [int] NOT NULL,
 CONSTRAINT [PK_Order_Detail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment_card]    Script Date: 10/22/2021 10:58:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_card](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[card_number] [int] NOT NULL,
	[from_date] [date] NOT NULL,
	[to_date] [date] NOT NULL,
	[user_id] [int] NOT NULL,
	[card_type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Payment_method] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 10/22/2021 10:58:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[publisher_name] [nvarchar](max) NOT NULL,
	[description] [nvarchar](max) NULL,
	[est_date] [nvarchar](10) NULL,
	[image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 10/22/2021 10:58:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[username] [nvarchar](255) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[role] [nvarchar](50) NOT NULL,
	[phone] [nvarchar](50) NULL,
	[email] [nvarchar](255) NULL,
	[dob] [date] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([id], [address], [city], [district], [user_id], [postal_code]) VALUES (2, N'address1', N'city1', N'district1', 1, 123456)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (1, N'Author1', N'abc', N'2000', N'active', N'1.jpg')
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (2, N'Author3', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (6, N'Nguyễn Thế Tùng', N'this a a author', N'2000', N'Active', NULL)
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (7, N'Nguyen Tung123', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (8, N'Tung Nguyen', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (9, N'Nguyen Tung123123123231', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum', N'2000', N'Active', N'1.jpg')
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (10, N'dsad1212', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (11, N'Nguyễn Thế Tùng', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (12, N'Tung Nguyen', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (14, N'Tung Nguyen', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (15, N'32', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (17, N'abc123412213', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (32, N'Author3', N'This is a author', N'1920', N'Active', NULL)
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (33, N'Author3', N'This is a author', N'1920', N'Active', N'1.jpg')
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (34, N'Author6', N'12', N'1920', N'Active', NULL)
SET IDENTITY_INSERT [dbo].[Author] OFF
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (1, N'Highest6', 1500, 5, 1, 1, 2, N'123456', N'book1.png', CAST(N'2021-10-28' AS Date), N'Vợ nuôi')
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (3, N'Book2', 1500, 3, 1, 2, 2, N'abc', N'product7.jpg', NULL, NULL)
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (4, N'Highest4', 1500, 5, 1, 2, 2, N'def', N'book4.jpg', CAST(N'2021-10-12' AS Date), N'abc')
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (5, N'Highest1', 1500, 15, 1, 2, 2, N'abc', N'product7.jpg', NULL, NULL)
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (6, N'Highest2', 1500, 12, 1, 2, 2, N'acs', N'product7.jpg', NULL, NULL)
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (7, N'Highest3', 1500, 10, 2, 1, 2, N'asd', N'product7.jpg', NULL, NULL)
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (8, N'asdd', 1500, 2, 1, 2, 2, N'asd', N'book8.jpg', CAST(N'2021-10-28' AS Date), N'123')
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (16, N'book9', 150, 2, 1, 2, 1, N'asa', N'product7.jpg', NULL, NULL)
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (17, N'234', 234, 1, 1, 1, 1, N'ádd', N'product7.jpg', NULL, NULL)
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (18, N'123', 123, 1, 1, 1, 1, N'123', N'product7.jpg', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [category_name]) VALUES (1, N'Trinh Thám')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (2, N'Adventure')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (9, N'Tung Nguyen')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (10, N'Tung Nguyen')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([id], [order_number], [shipping_price], [status], [payment_status], [total_price], [user_id], [date]) VALUES (1, 10001, 15000, N'Preparing', N'Paid', 18000, 1, CAST(N'2020-10-20' AS Date))
INSERT [dbo].[Order] ([id], [order_number], [shipping_price], [status], [payment_status], [total_price], [user_id], [date]) VALUES (2, 10002, 15000, N'Complete', N'Paid', 18000, 1, CAST(N'2020-12-21' AS Date))
INSERT [dbo].[Order] ([id], [order_number], [shipping_price], [status], [payment_status], [total_price], [user_id], [date]) VALUES (3, 10003, 15000, N'Shipping', N'Paid', 18000, 1, CAST(N'2020-12-30' AS Date))
INSERT [dbo].[Order] ([id], [order_number], [shipping_price], [status], [payment_status], [total_price], [user_id], [date]) VALUES (4, 10004, 15000, N'Preparing', N'Paid', 18000, 1, CAST(N'2021-12-20' AS Date))
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[Order_Detail] ON 

INSERT [dbo].[Order_Detail] ([id], [book_id], [order_id], [quantity], [total_price]) VALUES (1, 1, 1, 1, 1500)
INSERT [dbo].[Order_Detail] ([id], [book_id], [order_id], [quantity], [total_price]) VALUES (5, 4, 1, 1, 1500)
INSERT [dbo].[Order_Detail] ([id], [book_id], [order_id], [quantity], [total_price]) VALUES (6, 1, 2, 1, 1500)
INSERT [dbo].[Order_Detail] ([id], [book_id], [order_id], [quantity], [total_price]) VALUES (7, 4, 2, 1, 1500)
INSERT [dbo].[Order_Detail] ([id], [book_id], [order_id], [quantity], [total_price]) VALUES (9, 1, 3, 1, 1500)
INSERT [dbo].[Order_Detail] ([id], [book_id], [order_id], [quantity], [total_price]) VALUES (10, 4, 3, 1, 1500)
INSERT [dbo].[Order_Detail] ([id], [book_id], [order_id], [quantity], [total_price]) VALUES (11, 6, 4, 1, 1500)
INSERT [dbo].[Order_Detail] ([id], [book_id], [order_id], [quantity], [total_price]) VALUES (12, 5, 4, 1, 1500)
SET IDENTITY_INSERT [dbo].[Order_Detail] OFF
SET IDENTITY_INSERT [dbo].[Payment_card] ON 

INSERT [dbo].[Payment_card] ([id], [card_number], [from_date], [to_date], [user_id], [card_type]) VALUES (2, 123456789, CAST(N'2021-12-21' AS Date), CAST(N'2021-12-22' AS Date), 1, N'MasterCard')
SET IDENTITY_INSERT [dbo].[Payment_card] OFF
SET IDENTITY_INSERT [dbo].[Publisher] ON 

INSERT [dbo].[Publisher] ([id], [publisher_name], [description], [est_date], [image]) VALUES (1, N'P1', N'abc', N'21/10/2021', N'1.jpg')
INSERT [dbo].[Publisher] ([id], [publisher_name], [description], [est_date], [image]) VALUES (2, N'P2', N'abc', N'21/10/2021', N'1.jpg')
INSERT [dbo].[Publisher] ([id], [publisher_name], [description], [est_date], [image]) VALUES (3, N'P3', N'abc', N'21/10/2021', N'1.jpg')
INSERT [dbo].[Publisher] ([id], [publisher_name], [description], [est_date], [image]) VALUES (4, N'P3', N'abcs', N'21/10/2021', NULL)
SET IDENTITY_INSERT [dbo].[Publisher] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [name], [username], [password], [role], [phone], [email], [dob]) VALUES (1, N'Tung Nguyen', N'tungnt', N'12345678', N'user', N'0123456789', N'tungnt@gmail.com', CAST(N'2505-04-05' AS Date))
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_User]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Author] FOREIGN KEY([author_id])
REFERENCES [dbo].[Author] ([id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Author]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Category] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Category]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Publisher] FOREIGN KEY([publisher_id])
REFERENCES [dbo].[Publisher] ([id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Publisher]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Detail_Book] FOREIGN KEY([book_id])
REFERENCES [dbo].[Book] ([id])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Detail_Book]
GO
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Detail_Order1] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Detail_Order1]
GO
ALTER TABLE [dbo].[Payment_card]  WITH CHECK ADD  CONSTRAINT [FK_Payment_card_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Payment_card] CHECK CONSTRAINT [FK_Payment_card_User]
GO

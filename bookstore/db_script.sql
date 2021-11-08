USE [BookStore]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 11/8/2021 12:07:45 AM ******/
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
/****** Object:  Table [dbo].[Author]    Script Date: 11/8/2021 12:07:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[author_name] [nvarchar](255) NOT NULL,
	[description] [nvarchar](max) NULL,
	[birth_year] [int] NULL,
	[status] [nvarchar](50) NULL,
	[image] [nvarchar](50) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Book]    Script Date: 11/8/2021 12:07:46 AM ******/
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
	[description] [nvarchar](max) NULL,
	[image] [nvarchar](max) NULL,
	[public_date] [date] NULL,
	[edition] [nvarchar](max) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/8/2021 12:07:46 AM ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 11/8/2021 12:07:46 AM ******/
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
	[delivery_location] [nvarchar](500) NULL,
	[note] [nvarchar](500) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order_Detail]    Script Date: 11/8/2021 12:07:46 AM ******/
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
/****** Object:  Table [dbo].[Payment_card]    Script Date: 11/8/2021 12:07:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_card](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[card_number] [nvarchar](max) NOT NULL,
	[from_date] [date] NOT NULL,
	[to_date] [date] NOT NULL,
	[user_id] [int] NOT NULL,
	[card_type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Payment_method] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 11/8/2021 12:07:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[publisher_name] [nvarchar](max) NOT NULL,
	[description] [nvarchar](max) NULL,
	[est_date] [int] NULL,
	[image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 11/8/2021 12:07:46 AM ******/
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

INSERT [dbo].[Address] ([id], [address], [city], [district], [user_id], [postal_code]) VALUES (5, N'Apartment A-32A3, Sunsqua', N'Sydney', N'nam tu liem', 12, 3000)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (35, N'Jojo Moyes', N'Pauline Sara Jo Moyes, known professionally as Jojo Moyes, is an English journalist and, since 2002, a romance novelist and screenwriter. She is one of only a few authors to have twice won the Romantic Novel of the Year Award by the Romantic Novelists'' Association and has been translated into twenty-eight languages.', 1969, N'yes', N'author35.jpg')
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (36, N'Jack London', N'John Griffith London (born John Griffith Chaney;January 12, 1876 – November 22, 1916) was an American novelist, journalist, and social activist. A pioneer of commercial fiction and American magazines, he was one of the first American authors to become an international celebrity and earn a large fortune from writing.[citation needed] He was also an innovator in the genre that would later become known as science fiction.', 1876, N'yes', N'author35.jpg')
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (37, N'Thomas Harris', N'William Thomas Harris III[1] (born September 22, 1940) is an American writer, best known for a series of suspense novels about his most famous character, Hannibal Lecter. The majority of his works have been adapted into films and television, the most notable being The Silence of the Lambs, which became only the third film in Academy Awards history to sweep the Oscars in major categories.[2]', 1940, N'yes', NULL)
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (38, N'Dan Brown', N'Daniel Gerhard Brown (born June 22, 1964) is an American author best known for his thriller novels, including the Robert Langdon novels Angels & Demons (2000), The Da Vinci Code (2003), The Lost Symbol (2009), Inferno (2013), and Origin (2017). His novels are treasure hunts which usually take place over a period of 24 hours.[3] They feature recurring themes of cryptography, art, and conspiracy theories. His books have been translated into 57 languages and, as of 2012, have sold over 200 million copies. Three of them, Angels & Demons, The Da Vinci Code, and Inferno, have been adapted into films.', 1964, N'yes', N'author37.jpg')
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (39, N'Jane Austen', N'Jane Austen (/ˈɒstɪn, ˈɔːs-/; 16 December 1775 – 18 July 1817) was an English novelist known primarily for her six major novels, which interpret, critique and comment upon the British landed gentry at the end of the 18th century. Austen''s plots often explore the dependence of women on marriage in the pursuit of favourable social standing and economic security. Her works critique the novels of sensibility of the second half of the 18th century and are part of the transition to 19th-century literary realism', 1775, N'yes', N'author38.1810)_hires.jpg')
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (40, N'Walter Isaacson', N'Walter Isaacson, University Professor of History at Tulane, has been CEO of the Aspen Institute, chairman of CNN, and editor of Time magazine. He is the author of Leonardo da Vinci; Steve Jobs; Einstein: His Life and Universe;', 1952, N'yes', N'author39.jpg')
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (41, N'Stephen Hawking', N'Stephen William Hawking CH CBE FRS FRSA was an English theoretical physicist, cosmologist, and author who was director of research at the Centre for Theoretical Cosmology at the University of Cambridge at the time of his death', 1942, N'yes', N'author40.jpeg')
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (42, N'Edward Said', N'Edward Wadie Said was a professor of literature at Columbia University, a public intellectual, and a founder of the academic field of postcolonial studies.', 1935, N'yes', NULL)
INSERT [dbo].[Author] ([id], [author_name], [description], [birth_year], [status], [image]) VALUES (43, N'Marian Keyes', N'Marian Keyes is an Irish writer of popular fiction. As well as her novels, she produces non-fiction and is best known for her work in women''s literature.', 1963, N'yes', NULL)
SET IDENTITY_INSERT [dbo].[Author] OFF
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (1, N'Me Before You', 16, 17, 5, 1020, 35, N'Me Before You is a romance novel written by Jojo Moyes. The book was first published on 5 January 2012 in the United Kingdom. A sequel titled After You was released on 24 September 2015 through Pamela Dorman Books. A second sequel, Still Me, was published in January 2018', NULL, NULL, N'2')
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (2, N' The Call Of The Wild', 10, 7, 5, 1025, 36, N'The Call of the Wild is a short adventure novel by Jack London, published in 1903 and set in Yukon, Canada, during the 1890s Klondike Gold Rush, ...', N'book27.jpg', CAST(N'1903-01-01' AS Date), N'2')
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (3, N'The Silence of the Lambs', 20, 19, 5, 1028, 37, N'The Silence of the Lambs is a psychological horror novel by Thomas Harris. First published in 1988, it is the sequel to Harris''s 1981 novel Red Dragon. Both novels feature the cannibalistic serial killer Dr. Hannibal Lecter, this time pitted against FBI Special Agent Clarice Starling. ', N'book27.png', CAST(N'1988-12-02' AS Date), N'3')
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (4, N'The Da Vinci Code', 8, 15, 6, 1025, 38, N'The Da Vinci Code is a 2003 mystery thriller novel by Dan Brown. It is Brown''s second novel to include the character Robert Langdon: the first was his 2000 novel Angels & Demons. The Da Vinci Code follows "symbologist" Robert Langdon and cryptologist Sophie Neveu after a murder in the Louvre Museum in Paris causes them to become involved in a battle between the Priory of Sion and Opus Dei over the possibility of Jesus Christ and Mary Magdalene having had a child together.', N'book28.jpg', CAST(N'2003-01-04' AS Date), N'1')
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (5, N'Pride and Prejudice', 20, 5, 7, 1020, 39, N'Pride and Prejudice is an 1813 novel of manners written by Jane Austen. Though it is mostly called a romantic novel, it is also a satire. The novel follows the character development of Elizabeth Bennet, the dynamic protagonist of the book who learns about the repercussions of hasty judgments and comes to appreciate the difference between superficial goodness and actual goodness.', N'book29.jpeg', CAST(N'1813-01-28' AS Date), N'7')
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (6, N'Steve Jobs: The Exclusive Biography', 10, 20, 8, 1022, 40, N'Based on more than forty interviews with Steve Jobs conducted over two years—as well as interviews with more than 100 family members, friends, adversaries, competitors, and colleagues—Walter Isaacson has written a riveting story of the roller-coaster life and searingly intense personality of a creative entrepreneur whose for perfection and ferocious drive revolutionized six industries', N'book31.jpg', NULL, N'1')
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (7, N'Leonardo da Vinci', 15, 16, 8, 1022, 40, N'The #1 New York Times bestseller from Walter Isaacson brings Leonardo da Vinci to life in this exciting new biography that is “a study in creativity: how to define it, how to achieve it…Most important, it is a powerful story of an exhilarating mind and life” (The New Yorker).', N'book33.jpg', NULL, N'1')
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (34, N'God Created the Integers', 25, 3, 9, 1029, 41, N'God Created the Integers: The Mathematical Breakthroughs That Changed History is a 2005 anthology, edited by Stephen Hawking, of "excerpts from thirty-one of the most important works in the history of mathematics."', N'book7.jpeg', CAST(N'2005-10-04' AS Date), N'2')
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (35, N'Orientalism', 12, 3, 9, 1032, 42, N'Orientalism is a 1978 book by Edward W. Said, in which the author establishes the eponymous term "Orientalism" as a critical concept to describe the West''s commonly contemptuous depiction and portrayal of "The East," i.e. the Orient.', N'book34.jpeg', CAST(N'1978-01-01' AS Date), N'5')
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (36, N'Origin', 20, 3, 9, 1025, 38, N' Robert Langdon, Harvard professor of symbology and religious iconology, arrives at the Guggenheim Museum Bilbao to attend the unveiling of an astonishing scientific breakthrough. The evening’s host is billionaire Edmond Kirsch, a futurist whose dazzling high-tech inventions and audacious predictions have made him a controversial figure around the world.', N'book35.jpg', CAST(N'2018-07-12' AS Date), N'1')
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (37, N'Dan Brown’s Robert Langdon Series', 15, 1, 9, 1025, 38, N'A famous scientist is found dead, a mysterious symbol burned into his skin. Many miles away in Rome, the world’s cardinals gather to elect a new pope. Little do they know that beneath their feet, a vast bomb has started to tick. Professor Robert Langdon must work out the link between these two seemingly unconnected events if he is stop the Vatican being blown sky high.', N'book36.jpg', CAST(N'2017-12-01' AS Date), N'2')
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (38, N'Angels And Demons', 23, 2, 9, 1034, 38, N'The Vatican, Rome: the College of Cardinals assembles to elect a new pope. Somewhere beneath them, an unstoppable bomb of terrifying power relentlessly counts down to oblivion.  In a breathtaking race against time, Harvard professor Robert Langdon must decipher a labyrinthine trail of ancient symbols if he is to defeat those responsible - the Illuminati, a secret brotherhood presumed extinct for nearly four hundred years, reborn to continue their deadly vendetta against their most hated enemy, the Catholic Church.', N'book37.jpg', CAST(N'2009-08-28' AS Date), N'3')
INSERT [dbo].[Book] ([id], [title], [price], [quantity_in_stock], [publisher_id], [category_id], [author_id], [description], [image], [public_date], [edition]) VALUES (39, N'Rachel''s Holiday', 10, 3, 9, 1020, 43, N'''How did it end up like this? Twenty-seven, unemployed, mistaken for a drug addict, in a treatment centre in the back arse of nowhere with an empty Valium bottle in my knickers . . .''', N'book38.jpg', CAST(N'2012-08-02' AS Date), N'1')
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [category_name]) VALUES (1018, N'Nguyen Tung')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (1020, N'Romance')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (1022, N'Technology')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (1025, N'Action and Adventure')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (1028, N'Horror')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (1029, N'Science')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (1031, N'Cookbooks')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (1032, N'History')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (1033, N'Mathematics')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (1034, N'Thriller')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (1035, N'Nguyen Tung12')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (1039, N'sad')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (1040, N'sad')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (1041, N'22')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (1043, N'22')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (1044, N'Nguyen Tungưq')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([id], [order_number], [shipping_price], [status], [payment_status], [total_price], [user_id], [date], [delivery_location], [note]) VALUES (1, 10001, 2, N'Cancel', N'Unpaid', 12, 12, CAST(N'2021-11-03' AS Date), N'abc', NULL)
INSERT [dbo].[Order] ([id], [order_number], [shipping_price], [status], [payment_status], [total_price], [user_id], [date], [delivery_location], [note]) VALUES (2, 10002, 2, N'Pending', N'Unpaid', 2, 12, CAST(N'2021-11-03' AS Date), N'123 abc ', NULL)
INSERT [dbo].[Order] ([id], [order_number], [shipping_price], [status], [payment_status], [total_price], [user_id], [date], [delivery_location], [note]) VALUES (3, 10003, 2, N'Shipping', N'Unpaid', 18, 12, CAST(N'2021-11-03' AS Date), N'Apartment A-32A3, Sunsqua Sydney nam tu liem 3000', NULL)
INSERT [dbo].[Order] ([id], [order_number], [shipping_price], [status], [payment_status], [total_price], [user_id], [date], [delivery_location], [note]) VALUES (4, 10004, 2, N'Cancel', N'Unpaid', 12, 12, CAST(N'2021-11-04' AS Date), N'Apartment A-32A3, Sunsqua Sydney nam tu liem 3000', NULL)
INSERT [dbo].[Order] ([id], [order_number], [shipping_price], [status], [payment_status], [total_price], [user_id], [date], [delivery_location], [note]) VALUES (5, 10005, 2, N'Cancel', N'Unpaid', 12, 12, CAST(N'2021-11-04' AS Date), N'Apartment A-32A3, Sunsqua Sydney nam tu liem 3000', NULL)
INSERT [dbo].[Order] ([id], [order_number], [shipping_price], [status], [payment_status], [total_price], [user_id], [date], [delivery_location], [note]) VALUES (6, 10006, 2, N'Pending', N'Unpaid', 12, 12, CAST(N'2021-11-05' AS Date), N'Apartment A-32A3, Sunsqua Sydney nam tu liem 3000', NULL)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[Order_Detail] ON 

INSERT [dbo].[Order_Detail] ([id], [book_id], [order_id], [quantity], [total_price]) VALUES (1, 2, 1, 8, 10)
INSERT [dbo].[Order_Detail] ([id], [book_id], [order_id], [quantity], [total_price]) VALUES (2, 1, 3, 1, 16)
INSERT [dbo].[Order_Detail] ([id], [book_id], [order_id], [quantity], [total_price]) VALUES (3, 37, 2, 3, 45)
INSERT [dbo].[Order_Detail] ([id], [book_id], [order_id], [quantity], [total_price]) VALUES (4, 2, 4, 1, 10)
INSERT [dbo].[Order_Detail] ([id], [book_id], [order_id], [quantity], [total_price]) VALUES (5, 2, 5, 1, 10)
INSERT [dbo].[Order_Detail] ([id], [book_id], [order_id], [quantity], [total_price]) VALUES (6, 2, 6, 1, 10)
SET IDENTITY_INSERT [dbo].[Order_Detail] OFF
SET IDENTITY_INSERT [dbo].[Payment_card] ON 

INSERT [dbo].[Payment_card] ([id], [card_number], [from_date], [to_date], [user_id], [card_type]) VALUES (4, N'123546', CAST(N'2021-11-09' AS Date), CAST(N'2021-11-30' AS Date), 12, N'Master')
SET IDENTITY_INSERT [dbo].[Payment_card] OFF
SET IDENTITY_INSERT [dbo].[Publisher] ON 

INSERT [dbo].[Publisher] ([id], [publisher_name], [description], [est_date], [image]) VALUES (4, N'test', N'no', 2000, N'no.ipg')
INSERT [dbo].[Publisher] ([id], [publisher_name], [description], [est_date], [image]) VALUES (5, N'macmillan', N'Macmillan Publishers Ltd is a British publishing company traditionally considered to be one of the ''Big Five'' English language publishers.', 1843, N'publisher4.jpg')
INSERT [dbo].[Publisher] ([id], [publisher_name], [description], [est_date], [image]) VALUES (6, N'Doubleday', N'Doubleday is an American publishing company. It was founded as the Doubleday & McClure Company in 1897 and was the largest in the United States by 1947. It published the work of mostly U.S. authors under a number of imprints and distributed them through its own stores. In 2009 Doubleday merged with Knopf Publishing Group to form the Knopf Doubleday Publishing Group, which is now part of Penguin Random House. In 2019, the official website presents Doubleday as an imprint, not a publisher.', 1897, N'publisher5.png')
INSERT [dbo].[Publisher] ([id], [publisher_name], [description], [est_date], [image]) VALUES (7, N'Thomas Egerton', N'Thomas Egerton was a bookseller and publisher in Whitehall, London ca.1784–1830.[1] With business partner John Egerton he took over the enterprise established by John Millan.[2] For some years Egerton''s office stood on Charing Cross.[3] Books published included works by Jane Austen.[4]', 1820, N'publisher6.jpeg')
INSERT [dbo].[Publisher] ([id], [publisher_name], [description], [est_date], [image]) VALUES (8, N'Simon & Schuster', N'Simon & Schuster (U.S.) 656 pp. Steve Jobs is the authorized self-titled biography of American business magnate and Apple co-founder Steve Jobs.', 2000, NULL)
INSERT [dbo].[Publisher] ([id], [publisher_name], [description], [est_date], [image]) VALUES (9, N'Penguin Books', N'Penguin Books is a British publishing house. It was co-founded in 1935 by Sir Allen Lane with his brothers Richard and John, as a line of the publishers The Bodley Head, only becoming a separate company the following year.', 1935, N'publisher8.png')
INSERT [dbo].[Publisher] ([id], [publisher_name], [description], [est_date], [image]) VALUES (11, N'Publisher Name', N'dmeo', 1234, NULL)
SET IDENTITY_INSERT [dbo].[Publisher] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [name], [username], [password], [role], [phone], [email], [dob]) VALUES (1, N'Tung Nguyen', N'tungnt', N'12345678', N'Admin', N'0123456789', N'tungnt@gmail.com', CAST(N'2505-04-05' AS Date))
INSERT [dbo].[User] ([id], [name], [username], [password], [role], [phone], [email], [dob]) VALUES (12, N'Nguyen Tung', N'tung', N'Abcd1234.', N'Customer', N'+84969821227', N'natsu1504@gmail.com', CAST(N'2021-11-18' AS Date))
INSERT [dbo].[User] ([id], [name], [username], [password], [role], [phone], [email], [dob]) VALUES (14, N'admin', N'admin', N'123456', N'Admin', N'0988765645', N'tungadmin@gmail', CAST(N'2000-01-01' AS Date))
INSERT [dbo].[User] ([id], [name], [username], [password], [role], [phone], [email], [dob]) VALUES (15, N'Nguyen Tung', N'sadasd', N'Abcd12345.', N'Customer', N'+84969821227', N'natsu1504@gmail.com', CAST(N'2021-11-16' AS Date))
INSERT [dbo].[User] ([id], [name], [username], [password], [role], [phone], [email], [dob]) VALUES (16, N'Nguyen Tung', N'sadasd1', N'Abcd12345.', N'Admin', N'+84969821227', N'natsu1504@gmail.com', CAST(N'2021-11-16' AS Date))
INSERT [dbo].[User] ([id], [name], [username], [password], [role], [phone], [email], [dob]) VALUES (19, N'Nguyen Tung', N'tungnt12', N'Abcd1234.', N'Customer', N'+84123456789', N'natsu1504@gmail.com', CAST(N'2021-11-01' AS Date))
INSERT [dbo].[User] ([id], [name], [username], [password], [role], [phone], [email], [dob]) VALUES (20, N'Nguyen Tung', N'tungnt123', N'Abcd1234.', N'Admin', N'+84969821227', N'natsu1504@gmail.com', CAST(N'2021-12-08' AS Date))
INSERT [dbo].[User] ([id], [name], [username], [password], [role], [phone], [email], [dob]) VALUES (21, N'Nguyen Tung', N'test12345', N'Abcd1234.', N'Customer', N'+84969821227', N'natsu1504gmail.com', CAST(N'2021-11-09' AS Date))
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

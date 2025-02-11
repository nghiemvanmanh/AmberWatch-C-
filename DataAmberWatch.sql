use AmberWatch

Create table tbl_Account(
	Id INT Primary key identity(1,1),
	UserName NVARCHAR(255) Not null unique,
	PassWord NVARCHAR(255),
	SDT Varchar(10) CHECK (SDT LIKE '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	FullName Nvarchar(max) not null ,
	Address Nvarchar(max) not null ,
)


Insert into tbl_Account(UserName,PassWord,SDT,FullName, Address) values ('admin','2003','0999999999',N'Nghiêm Văn Mạnh',N'Hà Nội')

Create table tbl_Watch(
	id_watch INT Primary key identity(1,1),
	model nvarchar(255)  ,
	brand nvarchar(255)  ,
	name nvarchar(max)  ,
	collection nvarchar(max)  ,
	insurance nvarchar(max)  ,
	dialcolor nvarchar(255)  ,
	wirecolor nvarchar(255)  ,
	shellcolor nvarchar(255)  ,
	waterresistant nvarchar(255)  ,
	dialtype nvarchar(255)  ,
	wiretype nvarchar(255)  ,
	grasstype nvarchar(255)  ,
	machinetype nvarchar(255)    ,
	shellmaterial nvarchar(255),
	sex nvarchar(10)  ,
	dialsize nvarchar(255)  ,
	dialthickness nvarchar(255),
	img nvarchar(max)  ,
	price float,
	description nvarchar(max)  ,
)

drop table tbl_Watch

insert into tbl_Watch values(N'Citizen', N'Nhật Bản',N'Đồng Hồ Citizen C7 NH8391-51X Nam','AUTOMATIC',N'Quốc Tế 1 Năm',N'Xanh lá', N'Trắng',N'Trắng', '5 ATM (50m)',
N'Tròn',N'Dây Inox (Thép Không Gỉ)', N'Mineral Crystal (Kính Cứng)', N'Cơ Tự động (Automatic)', N'Thép không gỉ 304', 'Nam', '40.2 mm','13.1 mm', 'https://image.donghohaitrieu.com/wp-content/uploads/2023/09/NH8391-51X.jpg', 9285000,
N'Citizen C7 Automatic NH8391-51X phiên bản remake của dòng Crystal Seven năm 1965 của hãng. Giữ nguyên DNA thiết kế, nâng kích thước mặt số lên 40mm, bộ máy cơ in-house trữ cót 40 giờ, hoạt động ở 21.600vph có thể ngắm nhìn qua nắp đáy trong suốt.')


insert into tbl_Watch values(N'Casio', N'Nhật Bản',N'Đồng Hồ Casio Nam Edifice EFR-526L-1AVUDF','QUARTZ',N'Quốc Tế 1 Năm',N'Đen', N'Đen',N'Trắng', '10 ATM (100m)',
N'Tròn',N'Dây Da', N'Mineral Crystal (Kính Cứng)', N'Pin (Quartz)', N'Thép không gỉ 304', 'Nam', '48,5 mm x 43,8 mm','10,5 mm', 'https://lzd-img-global.slatic.net/g/ff/kf/Sc35b3b00fcab4969b571f8736c95f6982.jpg_720x720q80.jpg_.webp', 3426000,
N'Casio EFR-526L-1AVUDF là một thiết kế dành tặng riêng cho các quý ông của thương hiệu hàng đầu Nhật Bản, thương hiệu Casio. Với 100% linh kiện tốt nhất, công nghệ lắp ráp tiên tiến nhất, các nhà chế tác hàng đầu đến từ xứ sở hoa Anh Đào luôn muốn mang đến cho người tiêu dùng một sản phẩm mới với mẫu mã đẹp, tốt về chất lượng. Đồng hồ Casio EFR-526L-1AVUDF ra đời dựa trên nền tảng đó nhằm phục vụ nhu cầu thị hiếu ngày càng tăng cao của khách hàng. Hãy cùng nhau tìm hiểu vẻ đẹp tinh tế và chức năng vượt trội của sản phẩm này nhé!')


insert into tbl_Watch values(N'Casio', N'Nhật Bản',N'Đồng Hồ Casio Nữ LTP-V300L-4AUDF','QUARTZ',N'Quốc Tế 1 Năm',N'Be', N'Hồng',N'Trắng', '3 ATM (30m)',
N'Tròn',N'Dây Da', N'Mineral Crystal (Kính Cứng)', N'Pin (Quartz)', N'Thép không gỉ 304', N'Nữ', '34 mm','8 mm', 'https://www.watchstore.vn/images/products/others/2024/large/1-khung-sp-1386070660-857174691-1712568156.jpg', 1752000,
N'Đồng hồ Casio LTP-V300L-4AUDF là mẫu đồng hồ mới được trình làng tại thị trường Việt Nam trong thời gian gần đây. Chiếc đồng hồ này nổi bật với phong cách thiết kế đậm chất thể thao. Trong những năm gần đây,
nó nổi lên như một hiện tượng cuốn hút tất cả mọi đối tượng khách hàng. Hãy cùng SHOPDONGHO.com giải mã cơn sốt bí ẩn này!')


insert into tbl_Watch values(N'Pierre Lannier', N'Pháp',N'Đồng Hồ Pierre Lannier CITYLINE 209F438 Nam','QUARTZ',N'Quốc Tế 1 Năm',N'Đen', N'Trắng',N'Đen', '5 ATM (50m)',
N'Tròn',N'Dây Lưới', N'Mineral Crystal (Kính Cứng)', N'Pin (Quartz)', N'Thép không gỉ 304', 'Nam', '39 mm','7.8 mm', 'https://cdn.vuahanghieu.com/unsafe/0x900/left/top/smart/filters:quality(90)/https://admin.vuahanghieu.com/upload/product/2023/01/dong-ho-nam-pierre-lannier-252c138-mau-bac-63bb7aade4470-09012023092341.jpg', 5170000,
N'Hợp thời trang, nguyên bản và trên hết là rất thanh lịch, đồng hồ nam automatic 318B468 bằng thép Milanese màu xanh lam là một viên ngọc thực sự của ngành đồng hồ. Nó mang lại phong cách, cá tính và sự hiện diện. Mặt số lộ cơ khiến chiếc đồng hồ trở nên khá quyến rũ.

Thuộc bộ sưu tập AUTOMATIC, mẫu đồng hồ nam này có một vỏ tròn màu xanh bằng thép không gỉ với đường kính 42mm. Trong lòng vỏ đồng hồ này là cơ chế tự động với những bánh răng của chuyển động được hiển thị rõ ràng. Mặt số xuyên thấu của đồng hồ nam 318B468 được viền bằng màu xanh lam, tạo nên tính năng động của mẫu đồng hồ này. Các số La Mã màu vàng tạo nên tính xác thực cho mẫu đồng hồ này, cũng như kim giờ và phút được tách rời từ chuyển động.

Với dây đeo milanese bằng thép mạ xanh, bạn có thể dễ dàng điều chỉnh và đeo hàng ngày. Và bạn có thể thay đổi kiểu dáng đồng hồ nam của mình thường xuyên nhờ vào hệ thống dây đeo có thể thay thế của chúng tôi: hãy chọn một dây đeo da màu nâu chẳng hạn!

Đồng hồ nam dây thép Milanese tự động màu xanh 318B468 có mặt kính khoáng và có khả năng chống nước ở độ sâu 50 mét. 
Do đó, bạn có thể mang nó đi tắm hoặc đi biển mà không gặp rủi ro. Đồng hồ nam tự động 318B468 của bạn sẽ được gửi đến bạn trong hộp có chữ ký của thương hiệu và kèm theo bảo hành quốc tế 2 năm.')


insert into tbl_Watch values(N'Pierre Lannier', N'Pháp',N'Đồng Hồ Pierre Lannier LECARÉ 008F928 Nữ','QUARTZ',N'Quốc Tế 1 Năm',N'Trắng', N'Vàng Hồng',N'Vàng Hồng', '3 ATM (30m)',
N'Vuông',N'Dây Lưới', N'Mineral Crystal (Kính Cứng)', N'Pin (Quartz)', N'Thép không gỉ 304', N'Nữ', '30 mm','6,1 mm', 'https://cdn.cleor.com/i/default/77241/montre-pierre-lannier-acier-maille-milanaise-008f928.jpg', 4840000,
N'Hãy để bản thân bị quyến rũ bởi thiết kế cổ điển và vượt thời gian của một trong những mẫu đồng hồ hàng đầu trong bộ sưu tập Lecaré của chúng tôi, Đồng hồ nữ 008F928 trong Rose Gold Steel.

Được trang bị dây đeo bằng thép Milanese màu vàng hồng rộng 14mm và vỏ hình vuông 30 mm * 30 mm trong cùng một tông màu, đồng hồ nữ 008F928 là sự kết hợp chắc chắn và sang trọng. Dây đeo thiết thực của nó sẽ dễ dàng điều chỉnh theo mọi kích thước cổ tay. Sự hài hòa giữa nền mặt số màu trắng và sắc vàng hồng của kim, cọc số chỉ giờ và chữ ký Pierre Lannier là tuyệt vời.

Đồng hồ nữ dây thép vàng hồng 008F928 không thấm nước: nó có thể chịu được áp lực do nước tác động ở độ sâu 30 mét.
Đồng hồ nữ bằng thép không gỉ Pierre Lannier của bạn sẽ được gửi đến bạn trong hộp có chữ ký của thương hiệu kèm theo bảo hành quốc tế 2 năm.')


insert into tbl_Watch values(N'Seiko', N'Nhật Bản',N'Đồng Hồ Seiko Presage Cocktail SSA459J1 Nam','AUTOMATIC',N'Quốc Tế 1 Năm',N'Xanh ngọc bích', N'Đen',N'Trắng', '5 ATM (50m)',
N'Tròn',N'Dây Inox (Thép Không Gỉ)', N'Hardlex Crystal (Kính Cứng)', N'Cơ Tự động (Automatic)', N'Thép không gỉ 304', 'Nam', '40.5 mm','14,4 mm', 'https://image.donghohaitrieu.com/wp-content/uploads/2023/09/SSA459J1.jpg', 18270000,
N'Đồng hồ Seiko Presage Cocktail SSA459J1 lấy cảm hứng từ món Cocktail Mockingbird tuyệt đẹp. Với thiết kế dây da lịch lãm, mặt số kích thước 40mm phối màu xanh ngọc bích trên nền họa tiết chải tia độc đáo.')


insert into tbl_Watch values(N'Orient', N'Nhật bản',N'Đồng Hồ Orient Star Semi Skeleton RE-AV0114E00B Nam','AUTOMATIC',N'Quốc Tế 1 Năm',N'Xanh lá', N'Trắng',N'Trắng', '10 ATM (100m)',
N'Tròn',N'Dây Inox (Thép Không Gỉ)', N'Sapphire (Kính chống trầy)', N'Cơ Tự động (Automatic)', N'Thép không gỉ 304', 'Nam', '41 mm','12 mm', 'https://image.donghohaitrieu.com/wp-content/uploads/2023/09/RE-AV0114E00B.jpg', 24880000,
N'Orient Star RE-AV0114E00B mặt số xanh ngọc lục bảo độc đáo, thiết kế Skeleton để lộ một phần chuyển động tinh xảo. Trang bị chức năng Power Reserve cho phép người đeo biết được thời gian trữ cót còn lại.')


insert into tbl_Watch values(N'Orient', N'Nhật bản',N'Đồng Hồ Orient Star RE-AV0B03B00B Nam','AUTOMATIC',N'Quốc Tế 1 Năm',N'Xanh dương', N'Trắng',N'Trắng', '10 ATM (100m)',
N'Tròn',N'Dây Inox (Thép Không Gỉ)', N'Sapphire (Kính chống trầy)', N'Cơ Tự động (Automatic)', N'Thép không gỉ 304', 'Nam', '41 mm','13.6 mm', 'https://image.donghohaitrieu.com/wp-content/uploads/2023/09/RE-AV0B03B00B.jpg', 26840000,
N'Đồng hồ cơ nam Orient Star Layered Skeleton 41mm RE-AV0B03B00B trang bị bộ máy In-House F6F44 với khả năng trữ cót lên đến 50 giờ. Thiết kế mặt số xếp lớp kết hợp cửa sổ Open Heart tạo nên vẻ độc đáo và tinh xảo.')

insert into tbl_Watch values(N'KOI', N'Việt Nam',N'Đồng Hồ 
KOI Noble K002.103.641.03.13.04 Nữ','QUARTZ',N'Quốc Tế 3 Năm',N'Xà Cừ', N'Trắng',N'Trắng', '5 ATM (50m)',
N'Tròn',N'Dây Inox (Thép Không Gỉ)', N'Sapphire (Kính chống trầy)', N'Pin(Quartz)', N'Thép không gỉ 304', N'Nữ', '29 mm','7 mm', 'https://image.donghohaitrieu.com/wp-content/uploads/2024/01/2-1.jpg', 5480000,
N'Phiên bản đồng hồ KOI K002.103.641.03.13.04 được trang bị lớp nền xà cừ tinh xảo, kết hợp cùng viền đá quyến rũ, phù hợp với phụ nữ Á Đông.')

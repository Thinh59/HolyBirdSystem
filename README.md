# 🏨 HOLYBIRD RESORT - Quản Lý Đặt Phòng Khách Sạn

**Đồ án thực hành môn:** Hệ Quản trị Cơ sở Dữ liệu
[cite_start]**Giảng viên hướng dẫn:** Tuấn Nguyên Hoài Đức [cite: 3, 165]
[cite_start]**Nhóm thực hiện:** Nhóm 2 [cite: 4, 163]

---

## 📝 Giới thiệu
[cite_start]Hệ thống HolyBird Resort được thiết kế để tối ưu hóa quy trình đặt phòng đoàn, quản lý dịch vụ và vận hành khách sạn[cite: 172, 178]. [cite_start]Dự án tập trung giải quyết các bài toán thực tế về tính nhất quán dữ liệu khi có nhiều người dùng truy cập đồng thời[cite: 300, 1077].

## 👥 Thành viên và Đóng góp
| MSSV | Họ tên | Công việc chính |
| :--- | :--- | :--- |
| 23122015 | Nguyễn Gia Bảo | [cite_start]Thiết kế ER (Phòng), Xử lý tranh chấp TH 5, 6 [cite: 5, 1264] |
| 23122018 | Lại Nguyễn Hồng Thanh | [cite_start]Thiết kế ER (Khách hàng), Xử lý tranh chấp TH 7, 8 [cite: 5, 1264] |
| 23122019 | Phan Huỳnh Châu Thịnh | [cite_start]Thiết kế ER (Đại lý, Hóa đơn), Xử lý tranh chấp TH 1, 2 [cite: 5, 1264] |
| 23120079 | Phạm Thúy Quy | [cite_start]Thiết kế ER (Giao dịch), Xử lý tranh chấp TH 9, 10 [cite: 5, 1264] |
| 23120080 | Nguyễn Ngọc Như Quỳnh | [cite_start]Thiết kế ER (Phí phát sinh), Xử lý tranh chấp TH 3, 4 [cite: 5, 1264] |

## 🛠 Công nghệ sử dụng
* [cite_start]**Ngôn ngữ:** C# WinForms [cite: 167]
* [cite_start]**Hệ quản trị CSDL:** SQL Server [cite: 1070]
* [cite_start]**Công cụ báo cáo:** LaTeX [cite: 1069]

## ⚡ Các tình huống tranh chấp đã giải quyết
[cite_start]Hệ thống đã cài đặt và xử lý thành công 10 tình huống tranh chấp dữ liệu (Concurrency Control):
* [cite_start]**Lost Update:** Cập nhật mức giá phòng đồng thời[cite: 1078, 1270].
* [cite_start]**Unrepeatable Read:** Đọc giá dịch vụ/phòng khi đang cập nhật[cite: 1092, 1413].
* [cite_start]**Dirty Read:** Xem hóa đơn khi chưa commit hoặc bị rollback[cite: 1113, 1351].
* [cite_start]**Phantom:** Thay đổi danh sách phòng trống/giao dịch khi đang thống kê[cite: 1128, 1471].
* [cite_start]**Deadlock Conversion:** Xung đột khi nâng cấp khóa từ S sang X[cite: 1307, 1315].

## 📸 Giao diện ứng dụng
* [cite_start]**Dùng chung:** Đăng nhập, Xem thông tin cá nhân, Danh sách phòng[cite: 175, 320].
* [cite_start]**Tiếp tân:** Đăng ký giao dịch, Cấp thẻ từ, Lập hóa đơn[cite: 184, 523].
* [cite_start]**Quản lý:** Quản lý phòng, Phí phát sinh, Nhân viên[cite: 190, 731].
* [cite_start]**Admin:** Phân quyền, Nhật ký hệ thống, Sao lưu & Phục hồi[cite: 194, 881].

## 🔗 Tài nguyên
* [cite_start][Video Demo](https://drive.google.com/drive/folders/1nohAJC9tyxan08zWeC0kav01_ZqPKtg4) [cite: 1506]
* [cite_start][Source Code Database](https://drive.google.com/drive/folders/1Sp3vv6SlzyrlLzxx1GlvtlwVjv5bWDWi) [cite: 1508]

# 🏨 HOLYBIRD RESORT - Quản Lý Đặt Phòng Khách Sạn

  **Đồ án thực hành môn:** Hệ Quản trị Cơ sở Dữ liệu
  **Giảng viên hướng dẫn:** Tuấn Nguyên Hoài Đức 
  **Nhóm thực hiện:** Nhóm 2

---

## 📝 Giới thiệu
Hệ thống HolyBird Resort được thiết kế để tối ưu hóa quy trình đặt phòng đoàn, quản lý dịch vụ và vận hành khách sạn[cite: 172, 178]. [cite_start]Dự án tập trung giải quyết các bài toán thực tế về tính nhất quán dữ liệu khi có nhiều người dùng truy cập đồng thời

## 👥 Thành viên và Đóng góp
| MSSV | Họ tên | Công việc chính |
| :--- | :--- | :--- |
| 23122015 | Nguyễn Gia Bảo | Thiết kế ER (Phòng), Xử lý tranh chấp TH 5, 6 
| 23122018 | Lại Nguyễn Hồng Thanh | Thiết kế ER (Khách hàng), Xử lý tranh chấp TH 7, 8 
| 23122019 | Phan Huỳnh Châu Thịnh | Thiết kế ER (Đại lý, Hóa đơn), Xử lý tranh chấp TH 1, 2
| 23120079 | Phạm Thúy Quy | Thiết kế ER (Giao dịch), Xử lý tranh chấp TH 9, 10 
| 23120080 | Nguyễn Ngọc Như Quỳnh | Thiết kế ER (Phí phát sinh), Xử lý tranh chấp TH 3, 4

## 🛠 Công nghệ sử dụng
* **Ngôn ngữ:** C# WinForms 
* **Hệ quản trị CSDL:** SQL Server
* **Công cụ báo cáo:** LaTeX 

## ⚡ Các tình huống tranh chấp đã giải quyết
Hệ thống đã cài đặt và xử lý thành công 10 tình huống tranh chấp dữ liệu (Concurrency Control):
**Lost Update:** Cập nhật mức giá phòng đồng thời
* **Unrepeatable Read:** Đọc giá dịch vụ/phòng khi đang cập nhật
* **Dirty Read:** Xem hóa đơn khi chưa commit hoặc bị rollback
* **Phantom:** Thay đổi danh sách phòng trống/giao dịch khi đang thống kê
* **Deadlock Conversion:** Xung đột khi nâng cấp khóa từ S sang X.

## 📸 Giao diện ứng dụng
* **Dùng chung:** Đăng nhập, Xem thông tin cá nhân, Danh sách phòng
* **Tiếp tân:** Đăng ký giao dịch, Cấp thẻ từ, Lập hóa đơn
* **Quản lý:** Quản lý phòng, Phí phát sinh, Nhân viên
* **Admin:** Phân quyền, Nhật ký hệ thống, Sao lưu & Phục hồi

## 🔗 Tài nguyên
* [Video Demo](https://drive.google.com/drive/folders/1nohAJC9tyxan08zWeC0kav0l_ZqPKtg4?usp=sharing) 
* [Source Code Database](https://drive.google.com/drive/folders/1Sp3vv6SlzyrlLzxx1GlvtlwVjv5bWDWi)

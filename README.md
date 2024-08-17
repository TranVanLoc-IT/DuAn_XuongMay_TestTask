# DuAn_XuongMay_TestTask
<center style="height: 100px;width: 100px">![.NET](https://github.com/user-attachments/assets/4ddea864-215b-4bb9-8055-0202d9c05eed)</center>
Amazing project 🥇
## Folder structure
<h3>4 thư mục, các thư mục con là các file project .csproj net8 framework</h3>
1.*SERVER*: file project webapi, cấu hình chạy server
  > Controllers: API, chổ này viết api
  > Middleware: xử lý request/response, chuyển tiếp cho các MW theo pipeline xử lý.
  > DI: tiêm phụ thuộc, Authen, Author
2. *REPOSITORY*: kho chứa
  > Entity: model scaffold từ database
  > ModelView: trang giao diện ?
  > UOW: Unit Of Work, Pattern OOP quản lý các thay đổi, transaction với DB
  > IUOW: IUnit of Work, nhìn chung là interface quy định các method mà UOW phải làm 🤠
4. *SERVICES*: lớp dịch vụ
5. *CORE*: item, helper
  > Base: abtract/interface class
  > Store: lớp truy cập csdl, CRUD
  > Utils: xử lý dữ liệu

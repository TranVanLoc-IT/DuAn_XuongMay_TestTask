# DuAn_XuongMay_TestTask 
<hr>
<p align="center"><img src="https://github.com/user-attachments/assets/4ddea864-215b-4bb9-8055-0202d9c05eed"/></p>
<br>
Amazing project 🥇
<br>
<h2 color="orange">Folder structure</h2>
<br>
<h3>4 thư mục, các thư mục con là các file project .csproj net8 framework</h3><br>
1. <span style="color: red;">oko</span>SERVER: file project webapi, cấu hình chạy server<br>
  > Controllers: API, chổ này viết api<br>
  > Middleware: xử lý request/response, chuyển tiếp cho các MW theo pipeline xử lý.<br>
  > DI: tiêm phụ thuộc, Authen, Author<br>
2. *REPOSITORY*: kho chứa<br>
  > Entity: model scaffold từ database<br>
  > ModelView: trang giao diện ?<br>
  > UOW: Unit Of Work, Pattern OOP quản lý các thay đổi, transaction với DB<br>
  > IUOW: IUnit of Work, nhìn chung là interface quy định các method mà UOW phải làm 🤠<br>
4. *SERVICES*: lớp dịch vụ<br>
5. *CORE*: item, helper<br>
  > Base: abtract/interface class<br>
  > Store: lớp truy cập csdl, CRUD<br>
  > Utils: xử lý dữ liệu

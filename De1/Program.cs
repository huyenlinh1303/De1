// See https://aka.ms/new-console-template for more information


using System.IO;
using System.Text.Json;
using De1;

Menu:
Console.WriteLine("Chọn tính năng: ");
Console.WriteLine("1. Nhập danh sách nhân vật");
Console.WriteLine("2. Hiển thị toàn bộ danh sach ");
Console.WriteLine("3. Tim nhân vật theo mã");
Console.WriteLine("4. Tìm nhân vật có sức tấn công lớn nhất");
Console.WriteLine("5. Sắp xếp nhân vật giảm dần theo cấp độ");
Console.WriteLine("6. Xóa nhân vật theo mã");
Console.WriteLine("7. Thống kê số lượng nhân vật theo từng loại");
Console.WriteLine("8. Tính chỉ số sức mạnh");
Console.WriteLine("9. Hiển thị các nhân vật có chỉ số sức mạnh lớn hơn giá trị người dùng nhập");
Console.WriteLine("10. Thoát.");
int chonTinhNang = int.Parse(Console.ReadLine());

TinhNang tinhNang = new TinhNang();

while (chonTinhNang != 10)
{
    switch (chonTinhNang)
    {
        //1. Nhập danh sách nhân vật -> cho người chơi nhập -> lưu thành file -> serialize 
        case 1: 
            tinhNang.NhapDanhSach();
            break;
        
        //2. Hiển thị toàn bộ danh sach -> Đoc file Json
        case 2: 
            tinhNang.HienThiDanhSach();
            break;
        
        //3. Tim nhân vật theo mã -> .find() trong file json từ mã người chơi nhập vaào -> in nhóm thong tin ra màn hình
        case 3: 
            tinhNang.TimTheoMa();
            break;
        
        //4. Tìm nhân vật có sức mạnh lớn nhất
        case 4: 
            tinhNang.TimNhanVatManhNhat();
            break;
        
        //5. Sắp xêp nhân vật giảm dần theo cấp độ 
        case 5: 
            tinhNang.SapXepNhanVat();
            break;
        
        //6. Xóa nhân vật theo mã -> .find() trong file json từ mã người chơi nhập vaào -> xoóa nhóm thong tin -> gu thong bao xac nhan
        case 6: 
            tinhNang.XoaTheoMa();
            break;
        
        //7. Thống kê số lượng nhân vật theo từng loại -> nguoi choi chon 7 trong menu -> hien danh sach ten cac loai -> nguoi choi chon theo so -> hien so luong nhan vạt trong loại đó
        case 7: 
            tinhNang.ThongKe();
            break;
        
        //8. Tính chỉ số sức mạnh: Power = Health + Attack * 2 + Defense
        case 8:
            tinhNang.TinhSucManh();
            break;
        
        //9. Hiển thị các nhân vật có chỉ số sức mạnh lớn hơn giá trị người dùng nhập -> người dùng nhập chỉ số sức mạnh nhân vật muốn tìm -> so sánh voi chỉ số cua các nhân vật ->...
        case 9:
            tinhNang.HienThiNhanVatDuaTrenPower();
            break;
    }
    goto Menu;
}


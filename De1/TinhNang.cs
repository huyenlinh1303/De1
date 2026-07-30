using System.IO;
using System.Text.Json;

namespace De1;

public class TinhNang
{
    private List<NhanVat> players = new List<NhanVat>();

    public TinhNang()
    {
        if (File.Exists("data1.json"))
        {
            string json = File.ReadAllText("data1.json");
            players = JsonSerializer.Deserialize<List<NhanVat>>(json);
        }
    }

    public void NhapDanhSach()
    {
        Console.WriteLine("So nhan vat muon nhap: ");
        int soNhanVat = int.Parse(Console.ReadLine());

        for (int i = 0; i < soNhanVat; i++)
        {
            NhanVat nhanVat = new NhanVat();
            nhanVat.MaNhanVat = $"P{players.Count + 1}";

            Console.WriteLine("Nhap ten nhan vat: ");
            string tenNv1 = Console.ReadLine();
            nhanVat.TenNhanVat = tenNv1;

            while (true)
            {
                try
                {
                    Console.WriteLine("Chọn loại nhan vat: ");
                    Console.WriteLine("1. Dũng sĩ");
                    Console.WriteLine("2. Phù Thủy");
                    Console.WriteLine("3. Vú em");
                    int chonLoaiNhanVat = int.Parse(Console.ReadLine());

                    nhanVat.SucTanCong = 0;
                    nhanVat.PhongThu = 0;

                    if (chonLoaiNhanVat == 1)
                    {
                        nhanVat.LoaiNhanVat = "Dũng sĩ";
                        nhanVat.SucTanCong = 200;
                        nhanVat.PhongThu = 150;
                    }
                    else if (chonLoaiNhanVat == 2)
                    {
                        nhanVat.LoaiNhanVat = "Phù Thủy";
                        nhanVat.SucTanCong = 150;
                        nhanVat.PhongThu = 200;
                    }
                    else if (chonLoaiNhanVat == 3)
                    {
                        nhanVat.LoaiNhanVat = "Vú em";
                        nhanVat.SucTanCong = 100;
                        nhanVat.PhongThu = 250;
                    }
                    else
                    {
                        throw new Exception("Chỉ được chọn từ 1 đến 3.");
                    }

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            //Ban dau em muon để set cấp độ tự động là 1,
            //nhưng ở phía sau có tính năng 'Sắp xếp nhân vật giảm dần
            //theo cấp độ.' nên em nghĩ để người chơi tự set cấp độ ạ.
            while (true)
            {
                try
                {
                    Console.WriteLine("Nhập cấp độ nhân vật");
                    int nhapCapDo = int.Parse(Console.ReadLine());
                    nhanVat.CapDo = nhapCapDo;
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Vui lòng nhập so nguyên!");
                }
            }
            
            nhanVat.Mau = 100;

            players.Add(nhanVat);
            string json = JsonSerializer.Serialize(players);
            File.WriteAllText("data1.json", json);
        }
    }
    
    public void HienThiDanhSach()
    {
        foreach (NhanVat nhanVat in players)
        {
            Console.WriteLine($"Mã nhân vật: {nhanVat.MaNhanVat}");
            Console.WriteLine($"Tên nhân vật: {nhanVat.TenNhanVat}");
            Console.WriteLine($"Loại nhân vật: {nhanVat.LoaiNhanVat}");
            Console.WriteLine($"Cấp độ nhân vật: {nhanVat.CapDo}");
            Console.WriteLine($"Máu nhân vật: {nhanVat.Mau}");
            Console.WriteLine($"Sức tấn công của nhân vật: {nhanVat.SucTanCong}");
            Console.WriteLine($"Sức phòng thủ của nhân vật: {nhanVat.PhongThu}");
            Console.WriteLine($"Chỉ số sức mạnh: {nhanVat.Power}");
            Console.WriteLine("-----------------------------------------------"); 
        }
    }
    
    public void TimTheoMa()
    {
        Console.WriteLine("Nhập mã nhân vật muốn tìm theo cu phap 'P + thứ tự': ");
        string timMaNhanVat = Console.ReadLine().ToUpper();

        NhanVat ketQuaTimKiem = players.Find(x => x.MaNhanVat == timMaNhanVat);
        foreach (NhanVat nhanVat in players)
        {
            if (nhanVat == ketQuaTimKiem)
            {
                Console.WriteLine($"Mã nhân vật: {nhanVat.MaNhanVat}");
                Console.WriteLine($"Tên nhân vật: {nhanVat.TenNhanVat}");
                Console.WriteLine($"Loại nhân vật: {nhanVat.LoaiNhanVat}");
                Console.WriteLine($"Cấp độ nhân vật: {nhanVat.CapDo}");
                Console.WriteLine($"Máu nhân vật: {nhanVat.Mau}");
                Console.WriteLine($"Sức tấn công của nhân vật: {nhanVat.SucTanCong}");
                Console.WriteLine($"Sức phòng thủ của nhân vật: {nhanVat.PhongThu}");
                Console.WriteLine($"Chỉ số sức mạnh: {nhanVat.Power}");
                Console.WriteLine("-----------------------------------------------"); 
            }
            else
            {
                continue;
            }
        }
    }
    
    public void TimNhanVatManhNhat()
    {
        int max = players[0].SucTanCong;

        foreach (NhanVat nhanVat in players)
        {
            if (nhanVat.SucTanCong > max)
            {
                max = nhanVat.SucTanCong;
            }
        }

        foreach (NhanVat nhanVat in players)
        {
            if (nhanVat.SucTanCong == max)
            {
                Console.WriteLine($"Mã nhân vật: {nhanVat.MaNhanVat}");
                Console.WriteLine($"Tên nhân vật: {nhanVat.TenNhanVat}");
                Console.WriteLine($"Loại nhân vật: {nhanVat.LoaiNhanVat}");
                Console.WriteLine($"Cấp độ nhân vật: {nhanVat.CapDo}");
                Console.WriteLine($"Máu nhân vật: {nhanVat.Mau}");
                Console.WriteLine($"Sức tấn công của nhân vật: {nhanVat.SucTanCong}");
                Console.WriteLine($"Sức phòng thủ của nhân vật: {nhanVat.PhongThu}");
                Console.WriteLine($"Chỉ số sức mạnh: {nhanVat.Power}");
                Console.WriteLine("-----------------------------------------------"); 
            }
        }
    }
    
    public void SapXepNhanVat()
    {
        for (int i = 0; i < players.Count-1; i++)
        {
            int max = i;
            for (int j = i + 1; j < players.Count; j++)
            {
                if (players[j].CapDo > players[max].CapDo)
                {
                    max = j;
                }
            }
            NhanVat temp = players[i];
            players[i] = players[max];
            players[max] = temp;
        }
        
        foreach (NhanVat nhanVat in players)
        {
            Console.WriteLine($"Mã nhân vật: {nhanVat.MaNhanVat}");
            Console.WriteLine($"Tên nhân vật: {nhanVat.TenNhanVat}");
            Console.WriteLine($"Loại nhân vật: {nhanVat.LoaiNhanVat}");
            Console.WriteLine($"Cấp độ nhân vật: {nhanVat.CapDo}");
            Console.WriteLine($"Máu nhân vật: {nhanVat.Mau}");
            Console.WriteLine($"Sức tấn công của nhân vật: {nhanVat.SucTanCong}");
            Console.WriteLine($"Sức phòng thủ của nhân vật: {nhanVat.PhongThu}");
            Console.WriteLine($"Chỉ số sức mạnh: {nhanVat.Power}");
            Console.WriteLine("-----------------------------------------------"); 
        }
    }
    
    public void XoaTheoMa()
    {
        Console.WriteLine("Nhập mã nhân vật muôn xóa: ");
        string xoaNhanVat = Console.ReadLine().ToUpper();

        for (int i = players.Count - 1; i >= 0; i--)
        {
            if (players[i].MaNhanVat == xoaNhanVat)
            {
                players.Remove(players[i]);
            }
        }

        string json = JsonSerializer.Serialize(players);
        File.WriteAllText("data1.json", json);
        Console.WriteLine("Xóa thành công!");
    }
    
    public void ThongKe()
    {
        int tongSoNhanVat1 = 0;
        int tongSoNhanVat2 = 0;
        int tongSoNhanVat3 = 0;
        for(int i = 0; i < players.Count; i++)
        {
            if (players[i].LoaiNhanVat == "Dũng sĩ")
            {
                tongSoNhanVat1++;
            }else if (players[i].LoaiNhanVat == "Phù Thủy")
            {
                tongSoNhanVat2++;
            }else if (players[i].LoaiNhanVat == "Vú em")
            {
                tongSoNhanVat3++;
            }
        }
        Console.WriteLine("Số lượng Dũng sĩ: " + tongSoNhanVat1);
        Console.WriteLine("Số lượng Phù Thủy: " + tongSoNhanVat2);
        Console.WriteLine("Số lượng Vú em: " + tongSoNhanVat3);

    }
    
    public void TinhSucManh()
    {
        int power = 0;
        for (int i = 0; i < players.Count; i++)
        {
            power = players[i].Mau + players[i].SucTanCong * 2 + players[i].PhongThu;
            players[i].Power = power;
            Console.WriteLine($"Nhân vật mã {players[i].MaNhanVat} có chỉ số sức mạnh là: {power}");
        }
        string json = JsonSerializer.Serialize(players);
        File.WriteAllText("data1.json", json);
    }

    public void HienThiNhanVatDuaTrenPower()
    {
        Console.WriteLine("Nhập chỉ số sức mạnh của nhân vật muốn tìm: ");
        int chiSoPower = int.Parse(Console.ReadLine());

        foreach (NhanVat nhanVat in players)
        {
            if (nhanVat.Power > chiSoPower)
            {
                Console.WriteLine($"Mã nhân vật: {nhanVat.MaNhanVat}");
                Console.WriteLine($"Tên nhân vật: {nhanVat.TenNhanVat}");
                Console.WriteLine($"Loại nhân vật: {nhanVat.LoaiNhanVat}");
                Console.WriteLine($"Cấp độ nhân vật: {nhanVat.CapDo}");
                Console.WriteLine($"Máu nhân vật: {nhanVat.Mau}");
                Console.WriteLine($"Sức tấn công của nhân vật: {nhanVat.SucTanCong}");
                Console.WriteLine($"Sức phòng thủ của nhân vật: {nhanVat.PhongThu}");
                Console.WriteLine($"Chỉ số sức mạnh: {nhanVat.Power}");
                Console.WriteLine("-----------------------------------------------"); 
            }
        }
    }
    

}

    
    
    
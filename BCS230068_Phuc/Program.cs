using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        double radius = -1;

        // Lặp để nhập đúng giá trị bán kính
        while (true)
        {
            Console.Write("Nhap bán kính hình tròn (r > 0): ");
            string input = Console.ReadLine();

            // Kiểm tra nếu nhập đúng số thực và lớn hơn 0
            if (double.TryParse(input, out radius) && radius > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
            }
        }

        // Gọi hàm tính toán và hiển thị kết quả
        string resultJson = CalculateCircleProperties(radius);
        Console.WriteLine("Ket qua: " + resultJson);
    }

    /// <summary>
    /// Hàm tính toán diện tích, chu vi và đường kính của hình tròn.
    /// </summary>
    /// <param name="r">Bán kính hình tròn</param>
    /// <returns>Chuỗi JSON chứa diện tích, chu vi và đường kính</returns>
    static string CalculateCircleProperties(double r)
    {
        double area = Math.PI * r * r; // Diện tích
        double circumference = 2 * Math.PI * r; // Chu vi
        double diameter = 2 * r; // Đường kính

        // Tạo đối tượng ẩn danh để serialize thành JSON
        var result = new
        {
            dien_tich = Math.Round(area, 2),
            chu_vi = Math.Round(circumference, 2),
            duong_kinh = Math.Round(diameter, 2)
        };

        // Serialize đối tượng thành JSON string
        return JsonSerializer.Serialize(result);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        // a) Tính bình phương các số lớn hơn 4
        List<int> nums = new List<int>() { 1, 3, 4, 5, 8, 9 };
        var squares = nums.Where(num => num > 4)
           .Select(num => num * num);

        Console.WriteLine("Tính bình phương các số lớn hơn 4:");
        foreach (var square in squares)
        {
            Console.WriteLine(square);
        }

        // b) Đếm số lần xuất hiện của từng chữ
        string str = "chao mung den voi binh nguyen vo tan";
        var counts = str.Where(char.IsLetter)
           .GroupBy(c => c)
           .Select(group => new { Char = group.Key, Count = group.Count() });

        Console.WriteLine("\nĐếm số lần xuất hiện của từng chữ:");
        foreach (var count in counts)
        {
            Console.WriteLine($"Chữ '{count.Char}' xuất hiện {count.Count} lần.");
        }

        // c) Xuất ra các chuỗi viết hoa toàn bộ
        str = "CHAO mung DEN Voi binh nguyen vo tan";
        var uppercaseWords = str.Split(' ')
           .Where(word => word.Equals(word.ToUpper()))
           .Select(word => word);

        Console.WriteLine("\nXuất ra các chuỗi viết hoa toàn bộ:");
        foreach (var word in uppercaseWords)
        {
            Console.WriteLine(word);
        }
    }
}
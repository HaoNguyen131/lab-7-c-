using System;
using System.Linq;

namespace Northwind.LinqToSql
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dataContext = new NorthwindDataContext())
            {
                try
                {
                    // a/ Xuất ra màn hình các thông tin Name trong table Customers và Name trong bảng Orders
                    var query = from order in dataContext.Orders
                                join customer in dataContext.Customers on order.CustomerID equals customer.CustomerID
                                select new
                                {
                                    NameOrder = order.OrderID,
                                    NameCustomer = customer.CompanyName
                                };

                    Console.WriteLine("Danh sách Name trong table Customers và Orders:");
                    foreach (var result in query)
                    {
                        Console.WriteLine($"OrderID: {result.NameOrder}, CustomerName: {result.NameCustomer}");
                    }

                    // b/ Thêm một dòng dữ liệu vào bảng Customers với dữ liệu CustomerID=”2024” và CompanyName = “Độ tộc”
                    var newCustomer = new Customer
                    {
                        CustomerID = "2024",
                        CompanyName = "Độ tộc"
                    };
                    dataContext.Customers.InsertOnSubmit(newCustomer);
                    dataContext.SubmitChanges();
                    Console.WriteLine("Đã thêm dòng dữ liệu mới vào bảng Customers.");

                    // c/ Cập nhật CompanyName = “Bộ tộc gaming” tại CustomerID=”2024”
                    var customerToUpdate = dataContext.Customers.SingleOrDefault(c => c.CustomerID == "2024");
                    if (customerToUpdate != null)
                    {
                        customerToUpdate.CompanyName = "Bộ tộc gaming";
                        dataContext.SubmitChanges();
                        Console.WriteLine("Đã cập nhật CompanyName cho CustomerID = 2024.");
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy CustomerID = 2024 để cập nhật.");
                    }

                    // d/ Xóa dòng có CustumerID=”2024”
                    var customerToDelete = dataContext.Customers.SingleOrDefault(c => c.CustomerID == "2024");
                    if (customerToDelete != null)
                    {
                        dataContext.Customers.DeleteOnSubmit(customerToDelete);
                        dataContext.SubmitChanges();
                        Console.WriteLine("Đã xóa dòng dữ liệu có CustomerID = 2024.");
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy CustomerID = 2024 để xóa.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi: {ex.Message}");
                }
            }
        }
    }
}
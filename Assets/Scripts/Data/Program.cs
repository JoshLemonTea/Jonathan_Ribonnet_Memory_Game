//using System;
//using System.Data.SqlClient;
//using System.Data.Common;
//using System.IO;
//using System.Data;
//using System.Security.Cryptography;
//using Microsoft.AspNetCore.Mvc;

//internal class Program
//{
//    private static string connectionString = "Server=localHost;Database=Memory; Trusted_Connection=True;TrustServerCertificate=True";

//    static void Main(string[] args)
//    {
//        foreach (string arg in args)
//        {
//            if (arg.StartsWith("/images:"))
//            {
//                LoadImagesFrom(arg["/images:".Length..]);
//            }
//        }
//    }

//    private static void LoadImagesFrom(string imgDir)
//    {
//        using (SqlConnection sqlCon = new SqlConnection(connectionString))
//        {
//            sqlCon.Open();
//            using (SqlCommand sqlInsert = new SqlCommand("insert into dbo.image (name,image) values(@name,@image)", sqlCon))
//            {
//                SqlParameter prmName = sqlInsert.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.NVarChar, 60));
//                SqlParameter prmImage = sqlInsert.Parameters.Add(new SqlParameter("@image", System.Data.SqlDbType.VarBinary, -1));

//                foreach (string completeFileName in Directory.GetFiles(imgDir, "*.png"))
//                {
//                    byte[] fileBytes = File.ReadAllBytes(completeFileName);
//                    string fileName = Path.GetFileName(completeFileName);

//                    prmName.Value = fileName;
//                    prmImage.Value = fileBytes;

//                    sqlInsert.ExecuteNonQuery();
//                }
//            }
//        }
//    }

//    [HttpGet("{id}")]
//    public IActionResult Get(int id)
//    {
//        using (SqlConnection sqlCon = new SqlConnection(connectionString))
//        {
//            sqlCon.Open();
//            using (SqlCommand sqlSelect = new SqlCommand("select image from dbo.image where id=@id", sqlCon))
//            {
//                sqlSelect.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
//                using (SqlDataReader rdr = sqlSelect.ExecuteReader())
//                {
//                    while (rdr.Read())
//                    {
//                        byte[] data = (byte[])rdr["image"];
//                        return File(data, "image/png");
//                    }
//                }
//            }
//        }

//        return null;
//    }


//    [HttpGet("{id}")]
//    public IActionResult Get(int id)

//    {



//        memoryContext ctx = new memoryContext();
//        Image img = ctx.Images.Where(i => i.Id == id).First();
//        Response.ContentType = "image/png";
//        byte[] data = img.Image1;
//        return File(data, "image/png");

//    }
//}

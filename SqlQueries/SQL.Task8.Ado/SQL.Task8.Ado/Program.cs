using System;

namespace SQL.Task8.Ado
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server =DESKTOP-DKVRESV;Database=BooksDb;Trusted_Connection=True;";

            CRUD operation = new CRUD(connectionString);

            //operation.DeleteTableRow("Authors", "Name", "Author 5");
            //operation.InsertTableData("Authors", "Name", "Author 5");
            //operation.UpdateTableData("Authors", "Name", "AuthorNew", "Name", "Author 5");
            operation.SelectTableData("Authors", "Name");
        }
    }
}

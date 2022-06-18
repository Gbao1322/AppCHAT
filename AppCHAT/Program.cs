using Ganss.Excel;

namespace AppCHAT
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //create app's folder for saving files
            string pathString = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Chat App");
            System.IO.Directory.CreateDirectory(pathString);

            ReadData();

            Application.Run(new main());

            WriteData();
        }
        static void ReadData()
        {
            listData.Instance.List = new ExcelMapper(Application.StartupPath + @"\data.xlsx").Fetch<data>().ToList();
        }
        public static void WriteData()
        {
            var excel = new ExcelMapper();
            excel.Save(Application.StartupPath + @"\data.xlsx", listData.Instance.List);
        }
    }
}
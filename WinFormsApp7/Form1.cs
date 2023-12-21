using Dapper;
using Microsoft.Data.Sqlite;

namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        private string? ConnString = "Data Source=:memory:";
        private List<Buyer> buyers;
        private List<Sector> sectors;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buyers = new List<Buyer>();

            using (var connection = new SqliteConnection(ConnString))
            {
                connection.Open();
                CreateTable(connection);
                buyers = connection.Query<Buyer>("select * from Buyers").ToList();
                sectors = connection.Query<Sector>("select * from Sectors").ToList();
                dataGridView1.DataSource = buyers;
                /*Я не зрозумів як імплементувати пункт про акційні товари тому його тут нема*/
            }
        }
        public void CreateTable(SqliteConnection connection)
        {

            SqliteCommand c = new SqliteCommand("CREATE TABLE Buyers (\r\n    BuyerId INTEGER PRIMARY KEY AUTOINCREMENT,\r\n    PIB TEXT NOT NULL,\r\n    BirthDate TEXT NOT NULL,\r\n    Sex TEXT NOT NULL,\r\n    Email TEXT NOT NULL,\r\n    Country TEXT NOT NULL,\r\n    City TEXT NOT NULL,\r\n   SectionsOfInterest TEXT NOT NULL\r\n);", connection);
            c.ExecuteNonQuery();

            SqliteCommand ce = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Sullivan Flores', '20/12/1983','Чоловік',  'sullres@gmail.com',  'Франція',  'Париж', 'a');", connection);
            ce.ExecuteNonQuery();
            SqliteCommand ce1 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Vera White', '12/11/2001', 'Жінка',  'verawhite@gmail.com',  'США',  'Вашингтон', 'b');", connection);
            ce1.ExecuteNonQuery();
            SqliteCommand ce2 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Ezekiel Clark', '30/10/2003', 'Чоловік',  'ezeclark@gmail.com',  'Франція',  'Париж', 'c');", connection);
            ce2.ExecuteNonQuery();
            SqliteCommand ce3 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Олена Василівна Гуцуляк', '14/01/1992', 'Жінка',  'innabob@gmail.com',  'Україна',  'Київ', 'd' );", connection);
            ce3.ExecuteNonQuery();
            SqliteCommand ce4 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Яйцеслав Жидіславович Жидко','16/05/2000',  'Чоловік',  'suhfedbasch@gmail.com',  'Україна', 'Чернівці', 'e');", connection);
            ce4.ExecuteNonQuery();
            SqliteCommand ce5 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Дроздюк Орися Степанівна', '13/08/1963/', 'Жінка', 'drozdaorisa@gmail.com', 'Україна', 'Житомир', 'e');", connection);
            ce5.ExecuteNonQuery();
            SqliteCommand ce6 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Маркевич Оксана Іванівна', '2/09/1995', 'Жінка', 'markevichsana@gmail.com', 'Канада', 'Торонто', 'f');", connection);
            ce6.ExecuteNonQuery();
            SqliteCommand ce7 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Ластівка Андрій Юрійович', '12/12/1987', 'Чоловік', 'ptichkandrey33@gmail.com', 'Німеччина', 'Берлін', 'g');", connection);
            ce7.ExecuteNonQuery();
            SqliteCommand ce8 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Піта Михайло Михайлович', '23/07/1991', 'pitamishanya234@gmail.com', 'Швейцарія', 'Берн', 'h');", connection);
            SqliteCommand c1 = new SqliteCommand("CREATE TABLE Sectors (SectorId INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL);", connection);
            c1.ExecuteNonQuery();

            SqliteCommand c1e = new SqliteCommand("INSERT INTO Sectors(SectorId, Name) VALUES(NULL, 'кухонна техніка')", connection);
            SqliteCommand c2e = new SqliteCommand("INSERT INTO Sectors(SectorId, Name) VALUES(NULL, 'комп`ютери')", connection);
            SqliteCommand c3e = new SqliteCommand("INSERT INTO Sectors(SectorId, Name) VALUES(NULL, 'планшети')", connection);
            SqliteCommand c4e = new SqliteCommand("INSERT INTO Sectors(SectorId, Name) VALUES(NULL, 'ноутбуки')", connection);
            SqliteCommand c5e = new SqliteCommand("INSERT INTO Sectors(SectorId, Name) VALUES(NULL, 'телефони')", connection);
            SqliteCommand c6e = new SqliteCommand("INSERT INTO Sectors(SectorId, Name) VALUES(NULL, 'перефирічні пристрої')", connection);
            c1e.ExecuteNonQuery();
            c2e.ExecuteNonQuery();
            c3e.ExecuteNonQuery();
            c4e.ExecuteNonQuery();
            c5e.ExecuteNonQuery();
            c6e.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(ConnString))
            {
                connection.Open();
                CreateTable(connection);
                dataGridView1.DataSource = buyers;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(ConnString))
            {
                connection.Open();
                CreateTable(connection);
                dataGridView1.DataSource = connection.Query<Buyer>("select Email from Buyers").ToList();
            }
            Buyer.StaticId = buyers.Last().Id;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(ConnString))
            {
                connection.Open();
                CreateTable(connection);
                dataGridView1.DataSource = connection.Query<Buyer>("select City from Buyers").ToList();
            }
            Buyer.StaticId = buyers.Last().Id;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(ConnString))
            {
                connection.Open();
                CreateTable(connection);
                dataGridView1.DataSource = connection.Query<Buyer>("select Country from Buyers").ToList();
            }
            Buyer.StaticId = buyers.Last().Id;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(ConnString))
            {
                connection.Open();
                CreateTable(connection);
                dataGridView1.DataSource = sectors;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(ConnString))
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Введіть назву міста.", "Ввід даних", "Київ", -1, -1);
                connection.Open();
                CreateTable(connection);
                dataGridView1.DataSource = connection.Query<Buyer>($"select * from Buyers where City == '{input}' ").ToList();
            }
            Buyer.StaticId = buyers.Last().Id;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(ConnString))
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Введіть назву країни.", "Ввід даних", "Україна", -1, -1);
                connection.Open();
                CreateTable(connection);
                dataGridView1.DataSource = connection.Query<Buyer>($"select * from Buyers where Country == '{input}'").ToList();
            }
            Buyer.StaticId = buyers.Last().Id;

        }
    }
}

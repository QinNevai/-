using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb; ///Включаем библиотеку работы с базами данных
using System.Data; /// Включаем библиотеку для работы с данными

namespace ЛичныеДанныеСтудентов.Controller
{
    
        internal class Query
        {
            OleDbConnection connection; ///создание подключения между текущим проекто и нужной базой данных
            OleDbCommand command; ///Определяем команды для использования их в будущем
            OleDbDataAdapter dataAdapter; ///Получение набора данных из используемой базы данных
            DataTable bufferTable; ///Создание таблицы чтобы управлять данными в ней

            public Query(string Conn) ///Инициализируем объект класса OleDbConnection
            {
                connection = new OleDbConnection(Conn); ///Конструктор в качестве параметра принимает строку подключения
                bufferTable = new DataTable(); ///Инициалзируем объект класса DataTable
            }
            public DataTable UpateStudent() ///Метод обновления данных в таблице, не принимает параметров
            {
                connection.Open(); ///Открываем соединение
                dataAdapter = new OleDbDataAdapter("SELECT * FROM Student", connection);
                ///Инциализируем объект класса OleDbDataAdapter, как параметр прнимает запрос и объект
                bufferTable.Clear(); ///Очищение буферной таблицы для предупреждения возникновения некорректного отображения
                dataAdapter.Fill(bufferTable); ///После выполнения запроса заполнит таблицу набором данных
                connection.Close(); ///Закрываем соединение
                return bufferTable; ///Возвращаем результат
            }
            public void Add(string Имя, string Фамилия, string Отчество, string Возраст, string Курс, string Группа, string ПаспортныеДанные)
            ///Метод добавления данных в базу данных, в качестве параметров прописываем необходимые нам данные студентов
            {
                connection.Open(); ///Открываем соединение
                command = new OleDbCommand($"INSERT INTO Student(Имя, Фамилия, Отчество, Возраст, Курс, Группа, ПаспортныеДанные) VALUES (@Имя, @Фамилия, @Отчество, @Возраст, @Курс, @Группа, @ПаспортныеДанные)", connection);
                /// Загружаем данные в текущую базу данных
                command.Parameters.AddWithValue("Имя", Имя);    
                command.Parameters.AddWithValue("Фамилия", Фамилия);
                command.Parameters.AddWithValue("Отчество", Отчество);
                command.Parameters.AddWithValue("Возраст", Возраст);
                command.Parameters.AddWithValue("Курс", Курс);
                command.Parameters.AddWithValue("Группа", Группа);
                command.Parameters.AddWithValue("ПаспортныеДанные", ПаспортныеДанные); ///Значения, вносмые в базу данных
                command.ExecuteNonQuery();
                connection.Close(); ///Закрытие соединения
            }
            public void Delete(int ID) ///Удалене записи
            {
                connection.Open();///Открываем соединение
                command = new OleDbCommand($"DELETE FROM Student WHERE Код={ID}", connection); ///Программа удаления
                command.ExecuteNonQuery();
                connection.Close(); ///Закрываем соединение
            }
        }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; ///Дописываем использование библиотеки конфигураций

namespace ЛичныеДанныеСтудентов.Controller
{
    class ConnectionString
    {
            public static string ConncectStr
            ///Определяем статическое поле
            {
                get ///Определяем аксессор
                {
                    return ConfigurationManager.ConnectionStrings["ЛичныеДанныеСтудентов.Properties.Settings.Параметр"].ConnectionString;
                }
            }
        }
    }




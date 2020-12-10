using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace OlympList
{
    class Globals
    {
        //class is used to store global values used in entire app and text for some pages

        //used in case of internet connection problems
        public static Label connection_lost_l = new Label()
        {
            Text = "Возникли проблемы с доступом к Интернету. Попробуйте подключиться к сети и перезапустить приложение",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center,
            FontSize = 20,
            TextColor = Color.Black,
            FontFamily = "RoRe"
        };


        //olympiads grouped by subject
        public static Dictionary<string, List<Olympiad>> Subj_olympiads = new Dictionary<string, List<Olympiad>>();

        //all olympiads in one list
        public static List<Olympiad> all_olympiads = new List<Olympiad>();

        //list of subjects
        public static List<string> Subjects_List = new List<string>();


        //special elements for calendar page
        public static List<Label> dayLabels = new List<Label>();
        public static List<DateTime> dayDate = new List<DateTime>();

        public static string[] month_names = new string[] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        public static string[] month_names_rod = new string[] { "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };
        public static int[] num_days = new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };


        //grouped subjects
        public static Dictionary<string, List<string>> SpheresSubj = new Dictionary<string, List<string>>()
        {
            {"Естесственные науки",new List<string>(){ "Астрономия", "Биология","География","Геология","Физика","Химия","Естественные науки" } },
            {"Гуманитарные науки",new List<string>(){ "Гуманитарные и социальные науки", "История", "Лингвистика", "Литература", "Обществознание", "Право","Психология","Русский язык","Журналистика","Политология","Социология","Филология","Философия","Финансовая грамотность" }  },
            {"Точные науки",new List<string>(){ "Информатика", "Математика","Экономика","Инженерные науки", "Программирование" } },
            {"Творчество",new List<string>(){ "Рисунок","Теория и история музыки" } },
            {"Иностранные языки",new List<string>(){ "Иностранный язык", "Лингвистика" } },
            {"Профессиональные направления", new List<string>(){ "Остальные", "Робототехника","Техника и технологии"}  }
        };


        //personal info for recommendations page
        public static List<string> PersonalUnis = new List<string>();
        public static List<string> PersonalInfo = new List<string>() { "", "", "" };

        public static bool rec_done = false;
        public static List<Olympiad> to_recom1 = new List<Olympiad>();
        public static List<Olympiad> to_recom2 = new List<Olympiad>();


        //article for preparation page
        public static List<string> prep_article = new List<string>()
        {
            "Изучите задания прошедших олимпиад.Это полезная тренировка, а начинающие олимпиадники поймут, с чем им предстоит столкнуться.Разберите задания сами или с преподавателем",
            "Пользуйтесь материалами для подготовки: готовиться можно и по видеоурокам, включающим лекции, разборы заданий, семинарские занятия для школьников и учителей",
            "Не стоит ограничиваться только самоподготовкой, хотя и нельзя недооценивать ее значение. Занятия с опытными преподавателями все-таки остаются одним из лучших способов подготовки к олимпиадам",
            "Участвуйте в разных олимпиадах. Даже выбрав главной целью одну олимпиаду, не стоит отказываться от других",
            "Привлекайте друзей. Совместная подготовка проходит продуктивнее и веселее. А олимпиадное движение — одно из самых дружных в школьном мире",
            "Спросите совета у других участников олимпиад. Участвуйте и добивайтесь успехов вместе"
        };

        //special elements for preparation page
        public static string mathus_info = "На сайте собран основной теоретический материал, а также примеры задач для подготовки к ЕГЭ по физике и математике";
        public static string olimpru_info = "Содержит материалы для подготовки к различным олимпиадам школьников, а также актуальную информацию по каждой олимпиаде";
        public static string post_info = "Содержит общую информацию по олимпиадам, советы по подготовке, а также задачи прошлых лет и актуальный календарь олимпиад";
        public static string mathus_link = "https://mathus.ru/";
        public static string olimpru_link = "https://olimpiada.ru/";
        public static string post_link = "https://postypashki.ru/";


        //article for home page
        public static List<string> main_article = new List<string>() {
            "Перечневые олимпиады - это соревнования в разных предметных областях, перечень которых утверждён Министерством образования. Но раз ты открыл это приложение, то скорее всего отлично знаешь что это такое и зачем это нужно, но всё таки напомним это ещё раз",
            "Многие олимпиады дают льготы при поступлении в вуз, причем они могут быть разными:",
            "баллы за индивидуальные достижения",
            "100 баллов за ЕГЭ по профилю олимпиады(необходимо подтвердить 75 баллами за ЕГЭ по соответствующему предмету)",
            "100 баллов за дополнительные вступительные испытания(актуально для поступающих в МГУ)",
            "Право поступить в вуз без вступительных испытаний(необходимо подтверждать 75 баллами за ЕГЭ, если это не льгота по Всероссийской олимпиаде школьников)",
            "С каждым годом число поступающих в вузы по олимпиадам растёт. График демонстрирует процент поступивших по БВИ в вузы топ-15 по среднему баллу за последние годы. Информация взята с сайта https://ege.hse.ru",
            "В \"Олимпиадах\" можно найти исчерпывающую информацию по всем олимпиадам из перечня РСОШ\nВ \"Подготовке\" можно найти советы и материалы, по которым можно готовиться к олимпиадам\nВ \"Календаре\" можно найти систематизированную информацию о том, что будет проведено и в какие сроки\nВ \"Рекомендациях\" можно получить совет, о том в каких олимпиадах стоит поучаствовать\nВ \"Университетах\" представлена информация по поступлению в некоторые вузы\nЖелаем удачи!\n"
        };


        public static List<Unis> UnisList = new List<Unis>()
        {
            Unis.MSU,
            Unis.SPBGU,
            Unis.MEPHI,
            Unis.MIPT,
            Unis.HSE,
            Unis.RAN,
            Unis.MGIMO,
            Unis.MGTU,
            Unis.ITMO,
            Unis.NGU
        };

        public static Dictionary<string, Unis> UnisDict = new Dictionary<string, Unis>()
        {
            { "МГУ",Unis.MSU },
            { "СПбГУ",Unis.SPBGU },
            { "МФТИ",Unis.MIPT },
            {"МИФИ",Unis.MEPHI },
            {"ВШЭ", Unis.HSE },
            {"РАНХиГС", Unis.RAN },
            {"МГИМО", Unis.MGIMO },
            {"ИТМО",Unis.ITMO },
            {"МГТУ", Unis.MGTU },
            {"НГУ",Unis.NGU }
        };

        //olympDates for calendar page
        public static Dictionary<DateTime, List<Olympiad>> DateOlympList = new Dictionary<DateTime, List<Olympiad>>();
        public static void DateOlympListInit()
        {
            DateOlympList = new Dictionary<DateTime, List<Olympiad>>()
            {

                { new DateTime(2020,10,15),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада школьников «Ломоносов»", ""  }, new List<string>(){ "Олимпиада СПбГУ", "" } })},
                { new DateTime(2020,11,2),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада «Надежда энергетики» по комплексу предметов (физика, информатика, математика)", ""  }, new List<string>(){ "Олимпиада «Газпром»", "" } })},
                { new DateTime(2020,11,3),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада школьников «Надежда энергетики» по физике", ""  } })},
                { new DateTime(2020,11,5),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада школьников «Надежда энергетики» по информатике", ""  }, new List<string>(){ "Олимпиада «Росатом» по математике", "" }, new List<string>(){ "Олимпиада «Росатом» по физике", "" }, new List<string>(){ "Олимпиада школьников «Ломоносов» по информатике", "" } })},
                { new DateTime(2020,11,6),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада «Надежда энергетики» по комплексу предметов (физика, информатика, математика)", ""  }, new List<string>() { "Олимпиада «Шаг в будущее» по математике", ""  } })},
                { new DateTime(2020,11,8),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада «Высшая проба» по физике", ""  },new List<string>() { "Всесибирская олимпиада школьников по физике", ""  } })},
                { new DateTime(2020,11,9),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада Университета Иннополис «Innopolis Open» по математике", ""  } })},
                { new DateTime(2020,11,11),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада «Высшая проба» по информатике", ""  } })},
                { new DateTime(2020,11,13),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада «Шаг в будущее» по физике", ""  } })},
                { new DateTime(2020,11,14),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Межрегиональная олимпиада школьников по математике «САММАТ»", ""  }, new List<string>() { "Олимпиада «Высшая проба» по информатике", ""  } })},
                { new DateTime(2020,11,15),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада Университета Иннополис «Innopolis Open» по математике", ""  } })},
                { new DateTime(2020,11,16),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада «Высшая проба» по математике", ""  }, new List<string>() { "Олимпиада Университета Иннополис «Innopolis Open» по информатике", ""  }, new List<string>() { "Олимпиада «Формула Единства»/«Третье тысячелетие» по физике", ""  }, new List<string>() { "Олимпиада Национальной технологической инициативы", ""  }, new List<string>() { "Межрегиональная олимпиада школьников по математике «САММАТ»", ""  } })},
                { new DateTime(2020,11,19),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада «Высшая проба» по физике", ""  } })},
                { new DateTime(2020,11,20),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада «Шаг в будущее» по программированию", ""  } })},
                { new DateTime(2020,11,22),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада Университета Иннополис «Innopolis Open» по информатике", ""  }, new List<string>() { "Олимпиада «Высшая проба» по математике", ""  } })},
                { new DateTime(2020,11,24),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада «Надежда энергетики» по комплексу предметов (физика, информатика, математика)", ""  } })},
                { new DateTime(2020,11,25),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада школьников «Надежда энергетики» по информатике", ""  } })},
                { new DateTime(2020,11,26),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада школьников «Надежда энергетики» по физике", ""  } })},
                { new DateTime(2020,11,27),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада по программированию «ТехноКубок»", ""  } })},
                { new DateTime(2020,11,29),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада по программированию «ТехноКубок»", ""  } })},
                { new DateTime(2020,11,30),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада Университета Иннополис «Innopolis Open» по информатике", ""  } })},
                { new DateTime(2020,12,1),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Инженерная олимпиада «Звезда» по технике и технологии", ""  }, new List<string>() { "Всероссийская олимпиада школьников «Нанотехнологии — прорыв в будущее!»", ""  } })},
                { new DateTime(2020,12,4),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Московская олимпиада по физике", ""  }, new List<string>() { "Олимпиада «Шаг в будущее» по математике", ""  } })},
                { new DateTime(2020,12,6),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада Университета Иннополис «Innopolis Open» по математике", ""  } })},
                { new DateTime(2020,12,7),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада Университета Иннополис «Innopolis Open» по информатике", ""  } })},
                { new DateTime(2020,12,11),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада «Миссия выполнима. Твое призвание - финансист!» по математике", ""  }, new List<string>() { "Олимпиада «Шаг в будущее» по физике", ""  } })},
                { new DateTime(2020,12,13),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада Университета Иннополис «Innopolis Open» по информатике", ""  } })},
                { new DateTime(2020,12,18),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада «Шаг в будущее» по программированию", ""  }, new List<string>() { "Олимпиада по программированию «ТехноКубок»", ""  } })},
                { new DateTime(2020,12,20),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Открытая олимпиада по программированию", ""  }, new List<string>() { "Олимпиада по программированию «ТехноКубок»", ""  } })},
                { new DateTime(2021,1,9),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Московская астрономическая олимпиада", ""  } })},
                { new DateTime(2021,1,15),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Московская олимпиада по физике", ""  } })},
                { new DateTime(2021,1,28),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада «Миссия выполнима. Твое призвание - финансист!» по математике", ""  } })},
                { new DateTime(2021,2,7),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада школьников «Надежда энергетики» по физике", ""  } })},
                { new DateTime(2021,2,13),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада «Надежда энергетики» по комплексу предметов (физика, информатика, математика)", ""  } })},
                { new DateTime(2021,2,14),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада школьников «Надежда энергетики» по информатике", ""  } })},
                { new DateTime(2021,2,20),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада школьников «Физтех» по математике", ""  } })},
                { new DateTime(2021,2,21),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада школьников «Физтех» по физике", ""  } })},
                { new DateTime(2021,2,28),GlobalFunctions.GetOlympByName(new List<List<string>>() { new List<string>() { "Олимпиада «Формула Единства»/«Третье тысячелетие» по физике", ""  } })}

            };
        }

    
    }
}

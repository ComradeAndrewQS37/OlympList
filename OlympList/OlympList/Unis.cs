using System;
using System.Collections.Generic;
using System.Text;

namespace OlympList
{
    //this class contains description for all Unis objects(universities)
    public class Unis
    {
        public string name { get; set; }
        public string logo_src { get; set; }
        public string alink { get; set; }
        public string llink { get; set; }
        public int abs_bvi { get; set; }
        public int per_bvi { get; set; }
        public int all_adm { get; set; }
        public bool no_ol_rate { get; set; }
        public Dictionary<string, List<double>> ol_rate { get; set; }


        public static Unis MSU = new Unis()
        {
            name = "Московский государственный университет имени М.В.Ломоносова",
            logo_src = "msu.png",
            alink = "https://www.msu.ru/",
            llink = "http://www.cpk.msu.ru/files/2020/olymp_benefits.pdf",
            abs_bvi = 668,
            per_bvi = 21,
            all_adm = 3232,
            no_ol_rate = false,
            ol_rate = new Dictionary<string, List<double>>()
            {
                {" Всероссийская олимпиада ", new List<double>(){ 313.0 ,  9.7 ,  46.9 }},
                {" Олимпиада школьников «Физтех» ", new List<double>(){ 171.0 ,  5.3 ,  25.6 }},
                {" Олимпиада школьников «Ломоносов» ", new List<double>(){ 124.0 ,  3.8 ,  18.6 }},
                {" Олимпиада СПбГУ ", new List<double>(){ 23.0 ,  0.7 ,  3.4 }},
                {" Всесибирская олимпиада школьников ", new List<double>(){ 20.0 ,  0.6 ,  3.0 }},
                {" Олимпиада «Росатом» ", new List<double>(){ 19.0 ,  0.6 ,  2.8 }},
                {" Московская олимпиада школьников ", new List<double>(){ 17.0 ,  0.5 ,  2.5 }},
                {" Олимпиада «Покори Воробьевы горы!» ", new List<double>(){ 15.0 ,  0.5 ,  2.2 }}
            }
        };

        public static Unis SPBGU = new Unis()
        {
            name = "Санкт - Петербургский государственный университет",
            logo_src = "SPbGU.png",
            alink = "https://spbu.ru/",
            llink = "https://abiturient.spbu.ru/files/2020/bak/bac_spec_olymp_3_2020.pdf",
            abs_bvi = 456,
            per_bvi = 19,
            all_adm = 2418,
            no_ol_rate = false,
            ol_rate = new Dictionary<string, List<double>>()
            {
                {" Всероссийская олимпиада ", new List<double>(){ 176.0 ,  7.2 ,  38.6 }},
                {" Олимпиада СПбГУ", new List<double>(){ 76.0 ,  3.1 ,  16.7 }},
                {" Олимпиада школьников «Физтех» ", new List<double>(){ 34.0 ,  1.4 ,  7.5 }},
                {" Олимпиада школьников «Ломоносов» ", new List<double>(){ 23.0 ,  0.9 ,  5.0 }},
                {" Всесибирская олимпиада школьников ", new List<double>(){ 15.0 ,  0.6 ,  3.2 }}
            }
        };

        public static Unis MIPT = new Unis()
        {
            name = "Московский физико-технический институт",
            logo_src = "mipt.png",
            alink = "https://mipt.ru/",
            llink = "https://pk.mipt.ru/bachelor/2020_olympiads/",
            abs_bvi = 422,
            per_bvi = 30,
            all_adm = 1390,
            no_ol_rate = false,
            ol_rate = new Dictionary<string, List<double>>()
            {
                {" Всероссийская олимпиада ", new List<double>(){ 162.0 ,  11.7 ,  38.4 }}
            }
        };

        public static Unis MEPHI = new Unis()
        {
            name = "Национальный исследовательский ядерный университет «МИФИ»",
            logo_src = "mephi.png",
            alink = "https://mephi.ru/",
            llink = "https://admission.mephi.ru/admission/baccalaureate-and-specialty/specials/winners",

            no_ol_rate = true,

        };

        public static Unis HSE = new Unis()
        {
            name = "Национальный исследовательский университет \"Высшая школа экономики\"",
            logo_src = "hse.png",
            alink = "https://www.hse.ru/",
            llink = "https://ba.hse.ru/bolimp",

            no_ol_rate = true,

        };

        public static Unis RAN = new Unis()
        {
            name = "Российская академия народного хозяйства и государственной службы при Президенте Российской Федерации",
            logo_src = "ran.png",
            alink = "https://www.ranepa.ru/",
            llink = "https://www.ranepa.ru/pk/olimpiady/",

            no_ol_rate = true,

        };

        public static Unis MGIMO = new Unis()
        {
            name = "Московский Государственный Институт Международных Отношений",
            logo_src = "mgimo.png",
            alink = "https://mgimo.ru/",
            llink = "https://abiturient.mgimo.ru/bakalavriat/lgoty",

            no_ol_rate = true,

        };

        public static Unis ITMO = new Unis()
        {
            name = "Санкт-Петербургский национальный исследовательский университет информационных технологий, механики и оптики",
            logo_src = "itmo.png",
            alink = "https://itmo.ru/ru/",
            llink = "https://abit.itmo.ru/page/59/",

            no_ol_rate = true,

        };

        public static Unis MGTU = new Unis()
        {
            name = "Московский государственный технический университет им. Н. Э. Баумана",
            logo_src = "mgtu.png",
            alink = "https://bmstu.ru/",
            llink = "https://bmstu.ru/content/image/files/PK/Docs/Rules/Rules-p1_10.pdf",

            no_ol_rate = true,

        };
        
        public static Unis NGU = new Unis()
        {
            name = "Новосибирский Государственный Университет",
            logo_src = "ngu.png",
            alink = "https://www.nsu.ru/n/",
            llink = "https://www.nsu.ru/n/education/apply-info/olimpiady11/",

            no_ol_rate = true,

        };


    }
}

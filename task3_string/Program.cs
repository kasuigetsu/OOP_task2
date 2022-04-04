using System;
using System.IO;
using System.Collections.Generic;


namespace task3_string
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //task 3.2
                Console.WriteLine("Введите строку:");
                string str = Console.ReadLine();
                inversion(ref str);
                Console.WriteLine($"Измененная строка:\n{str}");

                //task3.3 
                string filename = "myList.txt";
                List<string> people = new List<string>()
                {
                "Семенова Татьяна Анатольевна & tati@mail.ru",
                "Истратова Елизавета Ильинична & cringemaster@bk.ru",
                "Аминова Диана Александровна & anonimys@mail.ru",
                "Вагапова Рената Рустамовна & savemaster@yandex.com",
                "Бадаев Ислям Ильясович & deadinside@google.com"
                };
                Console.WriteLine($"Начальная информация о людях, помещенная в файл {filename}:\n");
                File.WriteAllLines(filename, people);
                ToReadFromFile(filename);

                Program pg = new Program();
                for(int i=0; i<people.Count;i++)
                {
                    string str2 = people[i];
                    pg.SearchMail(ref str2);
                    people[i] = str2;               
                }

                string filename2 = "mail.txt";
                File.WriteAllLines(filename2, people);
                Console.WriteLine($"\nПочты людей были помещены в файл {filename2}.");
                ToReadFromFile(filename2);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void ToReadFromFile(string filename)
        {
            Console.WriteLine($"Содержимое файла {filename}:");
            using (StreamReader rd = File.OpenText(filename))
            {
                while (rd.Peek() >= 0)
                {
                    Console.WriteLine((string)rd.ReadLine());
                }
            }
        }
        static void inversion(ref string str)
        {
            char[] chars = str.ToCharArray();
            char[] inverse = new char[chars.Length];
            int j = 0;
            for(int i=chars.Length-1;i>=0;i--)
            {
                inverse.SetValue(chars[i],j);
                j++;
            }
            str = new string(inverse);
        }

        public void SearchMail(ref string str)
        {
            char[] chars = str.ToCharArray();
            for(int i=0;i<chars.Length;i++)
            {
                if(chars[i]=='&')
                {
                    str = str.Remove(0,i+1);
                }
            }
        }
    }
}

using CollectionLibrary;
using CustomLibrary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace lab14
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            //Авторы
            List<Pack> packs = new List<Pack>();
            
            //стек чатов
            Stack<Dictionary<string, Emoji>> chat1 = new Stack<Dictionary<string, Emoji>>();

            //сообщения
            Dictionary<string, Emoji> mesage1 = new Dictionary<string, Emoji>();
            Dictionary<string, Emoji> mesage2 = new Dictionary<string, Emoji>();
            Dictionary<string, Emoji> mesage3 = new Dictionary<string, Emoji>();

            //заполнение словарей
            for (int i = 0; i < 5; i++)
            {
                Emoji emoji = new Emoji();
                emoji.RandomInit();
                try
                {
                    mesage1.Add(emoji.Name, emoji);
                }
                catch (Exception ex)
                {
                    i--;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                SmileEmoji smileEmoji = new SmileEmoji();
                smileEmoji.RandomInit();
                Pack pack = new Pack(smileEmoji.Name);
                try
                {
                    mesage1.Add(smileEmoji.Name, smileEmoji);
                    packs.Add(pack);
                }
                catch (Exception ex)
                {
                    i--;
                }

            }
            chat1.Push(mesage1);

            for (int i = 0; i < 5; i++)
            {
                AnimalEmoji emoji = new AnimalEmoji();
                emoji.RandomInit();
                Pack pack = new Pack(emoji.Name);
                try
                {
                    mesage2.Add(emoji.Name, emoji);
                    packs.Add(pack);
                }
                catch (Exception ex)
                {
                    i--;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                FaceEmoji faceEmoji = new FaceEmoji();
                faceEmoji.RandomInit();
                Pack pack = new Pack(faceEmoji.Name);
                try
                {
                    mesage2.Add(faceEmoji.Name, faceEmoji);
                    packs.Add(pack);
                }
                catch (Exception ex)
                {
                    i--;
                }

            }
            chat1.Push(mesage2);

            for (int i = 0; i < 5; i++)
            {
                Emoji emoji = new Emoji();
                emoji.RandomInit();
                try
                {
                    mesage3.Add(emoji.Name, emoji);
                }
                catch (Exception ex)
                {
                    i--;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                FaceEmoji faceEmoji = new FaceEmoji();
                faceEmoji.RandomInit();
                try
                {
                    mesage3.Add(faceEmoji.Name, faceEmoji);
                }
                catch (Exception ex)
                {
                    i--;
                }

            }
            chat1.Push(mesage3);

            //коллекции для первой части

            //стек чатов
            Stack<Dictionary<string, Emoji>> chat = new Stack<Dictionary<string, Emoji>>();

            //сообщения
            Dictionary<string, Emoji> message1 = new Dictionary<string, Emoji>();
            Dictionary<string, Emoji> message2 = new Dictionary<string, Emoji>();
            Dictionary<string, Emoji> message3 = new Dictionary<string, Emoji>();

            //заполнение словарей
            for (int i = 0; i < 5; i++)
            {
                Emoji emoji = new Emoji();
                emoji.RandomInit();
                try
                {
                    message1.Add(emoji.Name, emoji);
                }
                catch (Exception ex)
                {
                    i--;
                }
            }
            for (int i = 0;i < 5; i++)
            {
                SmileEmoji smileEmoji = new SmileEmoji();
                smileEmoji.RandomInit();
                try
                {
                    message1.Add(smileEmoji.Name, smileEmoji);
                }
                catch (Exception ex)
                {
                    i--;
                }

            }
            chat.Push(message1);

            for (int i = 0; i < 5; i++)
            {
                AnimalEmoji emoji = new AnimalEmoji();
                emoji.RandomInit();
                try
                {
                    message2.Add(emoji.Name, emoji);
                }
                catch (Exception ex)
                {
                    i--;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                FaceEmoji faceEmoji = new FaceEmoji();
                faceEmoji.RandomInit();
                try
                {
                    message2.Add(faceEmoji.Name, faceEmoji);
                }
                catch (Exception ex)
                {
                    i--;
                }

            }
            chat.Push(message2);

            for (int i = 0; i < 5; i++)
            {
                Emoji emoji = new Emoji();
                emoji.RandomInit();
                try
                {
                    message3.Add(emoji.Name, emoji);
                }
                catch (Exception ex)
                {
                    i--;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                FaceEmoji faceEmoji = new FaceEmoji();
                faceEmoji.RandomInit();
                try
                {
                    message3.Add(faceEmoji.Name, faceEmoji);
                }
                catch (Exception ex)
                {
                    i--;
                }

            }
            chat.Push(message3);


            int answer = 0;
            string menu = "Выберете запрос:\n1) Вывод всех SmileEmoji в формате ИМЯ и Степень\n2) Найти среднюю степень улыыбки SmileEmoji\n3)Сгруппировать по степеням улыбки\n4) Найти объекты с одинаковыми именами в разных чатах\n5)Объединить с коллекцие стикер паков(даст информацию об авторе)\n6) Завершить работу";
            bool start = true;
            while (start)
            {
                Console.WriteLine("Данная программа выполняет запросы к коллекциям с помощью LINQ и методов расширения. Коллекции уже сгенерированы. ");
                Console.WriteLine(menu);

                answer = ChooseAnswer(1, 6);

                switch (answer)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Выберете способ получения информации\n1) LINQ запрос\n2) Методом расширения");
                        answer = ChooseAnswer(1, 2);
                        Console.Clear();
                        Console.WriteLine("Исходная коллекция:");
                        foreach (var item in chat)
                        {
                            foreach (var item1 in item)
                            {
                                Console.WriteLine(item1);
                            }
                        }
                        if (answer == 1)
                        {
                            var result = Collection.GetNamesAndGradesOfSmile(chat);
                            Collection.PrintNamesAndGrades(result);
                        }
                        else
                        {
                            var result = Collection.GetNamesAndGradesOfSmileExt(chat);
                            Collection.PrintNamesAndGrades(result);
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Выберете способ получения информации\n1) LINQ запрос\n2) Методом расширения");
                        answer = ChooseAnswer(1, 2);
                        Console.Clear();
                        Console.WriteLine("Исходная коллекция:");
                        foreach (var item in chat)
                        {
                            foreach (var item1 in item)
                            {
                                Console.WriteLine(item1);
                            }
                        }
                        if (answer == 1)
                        {
                            var result = Collection.GetAverage(chat);
                            Console.WriteLine(result);
                        }
                        else
                        {
                            var result = Collection.GetAverageExt(chat);
                            Console.WriteLine(result);
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Выберете способ получения информации\n1) LINQ запрос\n2) Методом расширения");
                        answer = ChooseAnswer(1, 2);
                        if (answer == 1)
                        {
                            var res = Collection.GroupByGrade(chat);
                            foreach (var item in res)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            var res = Collection.GroupByGradeExt(chat);
                            foreach (var item in res)
                            {
                                Console.WriteLine(item);
                            }
                        }

                        break; 

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Выберете способ получения информации\n1) LINQ запрос\n2) Методом расширения");
                        answer = ChooseAnswer(1, 2);
                        if (answer == 1)
                        {
                            var res = Collection.MergeCollections(chat, chat1);
                            foreach (var mes in res)
                            {
                                foreach (var item in mes)
                                {
                                    Console.WriteLine(item);
                                }
                            }
                        }
                        else
                        {
                            var res = Collection.MergeCollectionsExt(chat, chat1);
                            foreach (var mes in res)
                            {
                                foreach (var item in mes)
                                {
                                    Console.WriteLine(item);
                                }
                            }
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Выберете способ получения информации\n1) LINQ запрос\n2) Методом расширения");
                        answer = ChooseAnswer(1, 2);
                        if (answer == 1)
                        {
                            var res = Collection.MergeWithPack(chat1, packs);
                            foreach (var item in res)
                            {
                                Console.WriteLine($"Название стикера: {item.Key} Автор коллекции: {item.PackAuthor}");                              
                            }
                        }
                        else
                        {
                            var res = Collection.MergeWithPackExt(chat1, packs);
                            foreach (var item in res)
                            {
                                Console.WriteLine($"Название стикера: {item.Key} Автор коллекции: {item.PackAuthor}");
                            }
                        }
                        break;
                    case 6:
                        start = false;
                        break;
                }
            }

        }

        //обработка ввода чисел
        static int ChooseAnswer(int a, int b)   //выбор действия из целых
        {
            int answer = 0;
            bool checkAnswer;
            do
            {
                checkAnswer = int.TryParse(Console.ReadLine(), out answer);
                if ((answer > b || answer < a) || (!checkAnswer))
                {
                    Console.WriteLine("Вы некорректно ввели число, повторите ввод еще раз. Обратите внимание на то, что именно нужно ввести.");
                }
            } while ((answer > b || answer < a) || (!checkAnswer));

            return answer;
        }

        
    }
}



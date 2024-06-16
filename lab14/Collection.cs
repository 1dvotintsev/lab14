using CollectionLibrary;
using CustomLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{
    public class Collection
    {
        //Вывод всех SmileEmoji в формате ИМЯ и Степень


        public static IEnumerable<(string Name, int Grade)> GetNamesAndGradesOfSmile(Stack<Dictionary<string, Emoji>> chat)
        {
            var result = from dict in chat
                         from kvp in dict
                         let smile = kvp.Value as SmileEmoji
                         where smile != null
                         let upperName = smile.Name.ToUpper()
                         select (Name: upperName, Grade: smile.Grade);

            return result;
        }
        public static IEnumerable<(string Name, int Grade)> GetNamesAndGradesOfSmileExt(Stack<Dictionary<string, Emoji>> chat)
        {
            return chat.SelectMany(dict => dict.Values)
                       .OfType<SmileEmoji>()
                       .Select(smile => (Name: smile.Name.ToUpper(), Grade: smile.Grade));
        }

        //вывод рещультата первого запроса
        public static void PrintNamesAndGrades(IEnumerable<(string Name, int Grade)> result)
        {
            foreach (var item in result)
            {
                Console.WriteLine($"Name: {item.Name}, Grade: {item.Grade}");
            }
        }

        //нахождение среднего у всех улыбающихся
        public static double GetAverage(Stack<Dictionary<string, Emoji>> chat)
        {
            var result = (from dict in chat
                          from kvp in dict
                          let smile = kvp.Value as SmileEmoji
                          where smile != null
                          select smile.Grade).Average();
            return result;
        }

        public static double GetAverageExt(Stack<Dictionary<string, Emoji>> chat)
        {
            var result = chat
                .SelectMany(dict => dict.Values)
                .OfType<SmileEmoji>()
                .Select(smile => smile.Grade)
                .Average();

            return result;
        }

       

        //группировка по grade LINQ
        public static IEnumerable<(int Grade, int Count)> GroupByGrade(Stack<Dictionary<string, Emoji>> chat)
        {
            var result = from dict in chat
                         from kvp in dict
                         let smile = kvp.Value as SmileEmoji
                         where smile != null
                         group smile by smile.Grade into smileGroup
                         select (Grade: smileGroup.Key, Count: smileGroup.Count());

            return result;
        }
        //группировка по grade ext
        public static IEnumerable<(int Grade, int Count)> GroupByGradeExt(Stack<Dictionary<string, Emoji>> chat)
        {
            var result = chat.SelectMany(dict => dict.Values)
                             .OfType<SmileEmoji>()
                             .GroupBy(smile => smile.Grade)
                             .Select(group => (Grade: group.Key, Count: group.Count()));

            return result;
        }

        //коллекция, включающая в себя только уникальные элементы
        public static IEnumerable<Dictionary<string, Emoji>> MergeCollectionsExt(Stack<Dictionary<string, Emoji>> collection1, Stack<Dictionary<string, Emoji>> collection2)
        {
            var mergedCollection = collection1.Union(collection2);
            return mergedCollection;
        }

        public static IEnumerable<Dictionary<string, Emoji>> MergeCollections(Stack<Dictionary<string, Emoji>> collection1, Stack<Dictionary<string, Emoji>> collection2)
        {
            var mergedCollection = collection1.Concat(collection2)
                                      .GroupBy(dict => dict)
                                      .Select(group => group.First());
            return mergedCollection;
        }

        public static IEnumerable<dynamic> MergeWithPackExt(Stack<Dictionary<string, Emoji>> chatStack, List<Pack> packsList)
        {
            var chatMessages = chatStack.SelectMany(dict => dict);

            var query = chatMessages.Join(
                packsList,
                chat => chat.Key, // ключ из словаря
                pack => pack.Smile, // ключ из Pack
                (chat, pack) => new
                {
                    Key = chat.Key,
                    Emoji = chat.Value,
                    PackAuthor = pack.Author
                });

            return query;
        }

        public static IEnumerable<dynamic> MergeWithPack(Stack<Dictionary<string, Emoji>> chatStack, List<Pack> packsList)
        {
            var query = from dict in chatStack.SelectMany(stack => stack)
                        join pack in packsList on dict.Key equals pack.Smile
                        select new
                        {
                            Key = dict.Key,
                            Emoji = dict.Value,
                            PackAuthor = pack.Author
                        };

            return query;
        }

    }



}

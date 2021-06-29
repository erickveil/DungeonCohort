using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darkmoor;

namespace DungeonCohort
{
    class Books
    {
        public static string getBook()
        {
            var dataSource = DataSourceLoader.Instance;
            var bookSource = dataSource.BookSource;
            string jsonBook = bookSource.GetBookSubject();
            string specialBook = CrawlRooms.SpecialBook();
            string furnishBook = DungeonFurnishings.Book();

            var table = new RandomTable<string>();


            table.AddItem(jsonBook);
            table.AddItem(specialBook);
            table.AddItem(furnishBook);

            return table.GetResult();
        }
    }
}

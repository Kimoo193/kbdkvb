using LINQtoObject;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinqTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //using for Each do Disply method
            // •	Display book title and its ISBN.
            //var q = SampleData.Books.Select(s => (s.Title, s.Isbn));

            //---------------------------------------

            // •	Display the first 3 books with price more than 25.
            // var q = SampleData.Books.Where(e => e.Price > 25).Select(e => e.Title).Take(3);

            //--------------------------------------
            //•	Display Book title along with its publisher name. (Using 2 methods).
            //var q = SampleData.Books.Select(s => (s.Title, s.Publisher));
            //var q = from e in SampleData.Books
            //        select (e.Title, e.Publisher);
            //-------------------------------------
            //•	Find the number of books which cost more than 20.
            //var q =from e in SampleData.Books
            //       where (e.Price>20)
            //       select ;
            //var q = SampleData.Books.Count(e => e.Price > 20);
            //Console.WriteLine(q);
            //------------------------------------
            //•	Display book title, price and subject name sorted by its subject 
            //var sortedBooks = SampleData.Books.OrderBy(book => book.Subject)
            //.ThenBy(book => book.Price);

            //foreach (var book in sortedBooks)
            //{
            //    Console.WriteLine(book);
            //}


            //var q = SampleData.Books
            //    .GroupBy(book => book.Subject).Select(g => new { SubjectName = g.Key, Books = g.ToList() });
            //foreach (var item in q)
            //{
            //    Console.WriteLine(item.SubjectName);
            //    foreach (var book in item.Books)
            //    {
            //        Console.WriteLine(book.Title);
            //    }
            //}
            //-----------------------------------------


            //•	Try to display book title & price(from book objects) returned from GetBooks Function.

            //var q =SampleData.GetBooks();
            //foreach (var item in q)
            //{
            //    Console.WriteLine(item);
            //}

            //----------------------------------------

            //•	Display books grouped by publisher & Subject.


            //  var q  = SampleData.Books.GroupBy(e => new { e.Publisher, e.Subject }).Select(g => new
            //  {
            //      g.Key.Publisher,
            //      g.Key.Subject,
            //      Books = g.ToList()
            //  }); ;
            //foreach (var item in q)
            //{
            //    foreach (var item2 in item.Books)
            //    {
            //        Console.WriteLine(item2.Title);
            //    }
            //}

            FindBooksSorted();

        }

        /// <Bouns>
        /// 
        /// </Bouns>

        public static void FindBooksSorted()
        {
            Console.WriteLine("Enter the publisher's name:");
            string publisherName = Console.ReadLine();

            
            Console.WriteLine("Enter the sorting criteria (Title, Price, PageCount, PublicationDate):");
            string sortingCriteria = Console.ReadLine();

            
            Console.WriteLine("Enter the sorting order (ASC or DESC):");
            string sortingOrder = Console.ReadLine().ToUpper();

      
            var filteredBooks = SampleData.Books
                .Where(b => b.Publisher.Name.Equals(publisherName, StringComparison.OrdinalIgnoreCase));

            IEnumerable<Book> sortedBooks = filteredBooks;
            switch (sortingCriteria.ToLower())
            {
                case "title":
                    sortedBooks = sortingOrder == "ASC" ?
                        filteredBooks.OrderBy(b => b.Title) :
                        filteredBooks.OrderByDescending(b => b.Title);
                    break;
                case "price":
                    sortedBooks = sortingOrder == "ASC" ?
                        filteredBooks.OrderBy(b => b.Price) :
                        filteredBooks.OrderByDescending(b => b.Price);
                    break;
                case "pagecount":
                    sortedBooks = sortingOrder == "ASC" ?
                        filteredBooks.OrderBy(b => b.PageCount) :
                        filteredBooks.OrderByDescending(b => b.PageCount);
                    break;
                case "publicationdate":
                    sortedBooks = sortingOrder == "ASC" ?
                        filteredBooks.OrderBy(b => b.PublicationDate) :
                        filteredBooks.OrderByDescending(b => b.PublicationDate);
                    break;
                default:
                    Console.WriteLine("Invalid sorting criteria.");
                    return;
            }

             // Display the sorted books
            Console.WriteLine("\nSorted books:");
            foreach (var book in sortedBooks)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}
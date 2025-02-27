namespace Task6
{
    public record Book(string Title, string Author, string ISBN);

    class Program
    {
        static void Main(string[] args)
        {
            var book1 = new Book("1984", "George Orwell", "1234567890");
            var book2 = new Book("To Kill a Mockingbird", "Harper Lee", "0987654321");
            var book3 = new Book("1984", "George Orwell", "1234567890");

            Console.WriteLine("Book 1: " + book1);
            Console.WriteLine("Book 2: " + book2);
            Console.WriteLine("Book 3: " + book3);

            bool areEqual = book1 == book3;
            Console.WriteLine($"\nAre Book 1 and Book 3 equal? {areEqual}");

            var book4 = book1 with { Title = "Animal Farm" };

            Console.WriteLine($"\nOriginal Book 1: {book1}");
            Console.WriteLine($"New Book 4: {book4}");

            DisplayBook(book1);
            DisplayBook(book4);

            Console.ReadLine();
        }

        static void DisplayBook(Book book)
        {
            var (title, author, isbn) = book;
            Console.WriteLine($"\nDeconstructed Book - Title: {title}, Author: {author}, ISBN: {isbn}");
        }
    }
}
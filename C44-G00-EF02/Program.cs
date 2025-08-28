using C44_G00_EF02;
using C44_G00_EF02.DbContexts;

namespace C44_G00_EF02
{
    internal class Program
    {
        static void Main(string[] args)
        {
           using ITIDbContext context = new ITIDbContext();
            ITIDataSeeding.DataSeeding(context);
        }
    }
}

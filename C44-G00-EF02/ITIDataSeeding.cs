using C44_G00_EF02.DbContexts;
using C44_G00_EF02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C44_G00_EF02
{
    public static  class ITIDataSeeding
    {
        public static bool DataSeeding(ITIDbContext dbContext)
        {
			try
			{
				if (!dbContext.Topics.Any())
				{
					var TopicsData = File.ReadAllText("DataSeeding\\Topics.json");
					var Topics = JsonSerializer.Deserialize<List<Topic>>(TopicsData);
					if(Topics?.Count > 0)
					{
						dbContext.AddRange(Topics);
						dbContext.SaveChanges();
					}
					return true;
				}
				return false;
			}
			catch (Exception ex) 
			{
                Console.WriteLine($" Seeding failed: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
				return false;
            }
        }
    }
}

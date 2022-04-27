using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public static class UpdateValues
    {
        public static void IncreaseQualityIfPossible(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }
        public static void ShouldDecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.Quality = item.Quality - 1;
                }
            }
        }

        public static bool IsBackstage(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }
        // Add the same thing for the other items ...
    }
}

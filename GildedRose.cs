using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && !UpdateValues.IsBackstage(Items[i]))
                {
                    UpdateValues.ShouldDecreaseQuality(Items[i]);
                }
                else
                {
                    UpdateValues.IncreaseQualityIfPossible(Items[i]);
                    if (UpdateValues.IsBackstage(Items[i]))
                    {
                        if (Items[i].SellIn < 11)
                        {
                            UpdateValues.IncreaseQualityIfPossible(Items[i]);
                        }

                        if (Items[i].SellIn < 6)
                        {
                            UpdateValues.IncreaseQualityIfPossible(Items[i]);
                        }

                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (!UpdateValues.IsBackstage(Items[i]))
                        {
                            UpdateValues.ShouldDecreaseQuality(Items[i]);
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        UpdateValues.IncreaseQualityIfPossible(Items[i]);
                    }
                }
            }
        }
    }
}

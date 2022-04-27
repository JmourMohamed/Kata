using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }
        [Test]
        public void AgedBrieUpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            //First update Quality
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(11, Items[0].Quality);
            Assert.AreEqual(1, Items[0].SellIn);

            //Second update Quality
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(12, Items[0].Quality);
            Assert.AreEqual(0, Items[0].SellIn);

            //After finishing sellin update Quality
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(14, Items[0].Quality);
            Assert.AreEqual(-1, Items[0].SellIn);

            //After finishing sellin update Quality
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(16, Items[0].Quality);
            Assert.AreEqual(-2, Items[0].SellIn);
        }
        [Test]
        public void AgedBrieTestQualityLimit()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 49 } };
            GildedRose app = new GildedRose(Items);

            //First update Quality
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(50, Items[0].Quality);
            Assert.AreEqual(1, Items[0].SellIn);

            //Second update Quality
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(50, Items[0].Quality);
            Assert.AreEqual(0, Items[0].SellIn);
        }
        [Test]
        public void SulfurasUpdateQuality()
        {
            // “Sulfuras”, being a legendary item, never has to be sold or decreases in Quality

            string itemName = "Sulfuras, Hand of Ragnaros";
            IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = 2, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            //First update Quality
            app.UpdateQuality();
            Assert.AreEqual(itemName, Items[0].Name);
            Assert.AreEqual(10, Items[0].Quality);
            Assert.AreEqual(2, Items[0].SellIn);

            //Second update Quality
            app.UpdateQuality();
            Assert.AreEqual(itemName, Items[0].Name);
            Assert.AreEqual(10, Items[0].Quality);
            Assert.AreEqual(2, Items[0].SellIn);
        }

        [Test]
        public void BackstageUpdateQuality()
        {
            //1- Quality update if sellin > 10
            //2- Quality update if sellin <= 10
            //3- Quality update if sellin <= 5

            //1- Quality update if sellin > 10
            string itemName = "Backstage passes to a TAFKAL80ETC concert";
            IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = 12, Quality = 20 } };
            GildedRose app = new GildedRose(Items);

            //First update Quality
            app.UpdateQuality();
            Assert.AreEqual(itemName, Items[0].Name);
            Assert.AreEqual(21, Items[0].Quality);
            Assert.AreEqual(11, Items[0].SellIn);

            //Second update Quality
            app.UpdateQuality();
            Assert.AreEqual(itemName, Items[0].Name);
            Assert.AreEqual(22, Items[0].Quality);
            Assert.AreEqual(10, Items[0].SellIn);

            //2- Quality update if sellin <= 10

            //First update Quality
            app.UpdateQuality();
            Assert.AreEqual(itemName, Items[0].Name);
            Assert.AreEqual(24, Items[0].Quality);
            Assert.AreEqual(9, Items[0].SellIn);

            //3- Quality update if sellin <= 5
            Items = new List<Item> { new Item { Name = itemName, SellIn = 2, Quality = 20 } };
            app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(itemName, Items[0].Name);
            Assert.AreEqual(23, Items[0].Quality);
            Assert.AreEqual(1, Items[0].SellIn);
        }

    }
}

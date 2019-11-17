using System.Collections.Generic;

namespace GildedRose
{
    class Inventory
    {
        private readonly IEnumerable<Item> items;

        public Inventory(IEnumerable<Item> items)
        {
            this.items = items;
        }

        /// <summary>
        /// Items:
        /// "+5 Dexterity Vest"
        /// "Aged Brie"
        /// "Elixir of the Mongoose"
        /// "Sulfuras, Hand of Ragnaros"
        /// "Backstage passes to a TAFKAL80ETC concert"
        /// "Conjured Mana Cake"
        /// </summary>
        public void UpdateQuality()
        {
            foreach (var item in items)
            {
                var qualilityChangeVal = 1;
                if (item.SellIn <= 0) qualilityChangeVal = 2;

                if (item.Name == "+5 Dexterity Vest")
                    item.Quality -= qualilityChangeVal;

                else if (item.Name == "Aged Brie")
                    item.Quality += qualilityChangeVal;

                else if (item.Name == "Elixir of the Mongoose")
                {

                    item.Quality -= qualilityChangeVal;
                }

                else if (item.Name == "Sulfuras, Hand of Ragnaros")
                    continue;

                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn <= 0) item.Quality = 0;
                    else if (item.SellIn < 6) item.Quality += 3;
                    else if (item.SellIn < 11) item.Quality += 2;
                    else item.Quality += 1;
                }

                else if (item.Name == "Conjured Mana Cake")
                    item.Quality -= qualilityChangeVal * 2;

                if (item.Quality < 0) item.Quality = 0;
                if (item.Quality > 50) item.Quality = 50;
                item.SellIn--;
            }
        }
    }
}

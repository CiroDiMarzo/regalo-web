using System.Collections.Generic;
using regalo_web.ViewModels;
using regalo_web.Constants;
using System;

namespace regalo_web.Repositories
{
    public interface IGiftRepository
    {
        List<GiftModel> GetGift(string key);
    }

    public class GiftRepository : IGiftRepository
    {
        private readonly Dictionary<string, List<GiftModel>> _data;

        public GiftRepository()
        {
            this._data = new Dictionary<string, List<GiftModel>> {
                { GlobalConstants.Daniela, new List<GiftModel> {
                    new GiftModel {
                        Title = "Omkara & Gotama, Amen - Audio CD",
                        Description = "Prayerful Songs Inspired by The Mala of God by Mooji",
                        ContentUrl = "https://www.google.com",
                        PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f6/Bright_green_tree_-_Waikato.jpg/1024px-Bright_green_tree_-_Waikato.jpg"
                    },
                    new GiftModel {
                        Title = "Omkara & Gotama, Amen - Booklet",
                        Description = "Prayerful Songs Inspired by The Mala of God by Mooji",
                        ContentUrl = "https://www.google.com",
                        PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Poplar_Trees_of_Hunza_Valley.jpg/1024px-Poplar_Trees_of_Hunza_Valley.jpg"
                    },
                    new GiftModel {
                        Title = "Omkara & Gotama, Amen - Booklet",
                        Description = "Prayerful Songs Inspired by The Mala of God by Mooji",
                        ContentUrl = "https://www.google.com",
                        PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Poplar_Trees_of_Hunza_Valley.jpg/1024px-Poplar_Trees_of_Hunza_Valley.jpg"
                    },
                    new GiftModel {
                        Title = "Omkara & Gotama, Amen - Booklet",
                        Description = "Prayerful Songs Inspired by The Mala of God by Mooji",
                        ContentUrl = "https://www.google.com",
                        PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Poplar_Trees_of_Hunza_Valley.jpg/1024px-Poplar_Trees_of_Hunza_Valley.jpg"
                    }
                } },
                { GlobalConstants.Mirella, new List<GiftModel> {
                    new GiftModel {
                        Title = "Jai-Jagdeesh",
                        Description = "Jai-Jagdeesh Description",
                        ContentUrl = "https://www.google.com",
                        PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/5/5e/Rugged_Split_Seaside.jpg"
                    }
                } }
            };
        }

        public List<GiftModel> GetGift(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException(nameof(key));
            }

            if (!this._data.ContainsKey(key))
            {
                throw new ArgumentException($"The key is not present in the data dictionary {key}");
            }

            return this._data[key];
        }
    }
}
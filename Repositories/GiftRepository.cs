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
                        ContentUrl = "https://shop.mooji.org/?download_file=12756&order=wc_order_dIYE642opbTug&uid=a6611ec54deeb80eadc1fbe60896c5ca7869676fecfb6bdca3915b7d6bfc7220&key=b9060d8b-9459-437e-9e57-b1ebd557c9a7",
                        PictureUrl = $"/assets/{GlobalConstants.Daniela}/cover.jpg"
                    },
                    new GiftModel {
                        Title = "Omkara & Gotama, Amen - Booklet",
                        Description = "Prayerful Songs Inspired by The Mala of God by Mooji",
                        ContentUrl = "https://shop.mooji.org/?download_file=12756&order=wc_order_dIYE642opbTug&uid=a6611ec54deeb80eadc1fbe60896c5ca7869676fecfb6bdca3915b7d6bfc7220&key=c11fded6-9333-4f96-8d58-ab603aca3b37",
                        PictureUrl = $"/assets/{GlobalConstants.Daniela}/booklet.jpg"
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overdrop.Code.Data.Api.Moralis
{
    public class MoralisNftSearchResponseMetadata
    {
        public int id { get; set; }
        public string name { get; set; }
        public int generation { get; set; }
        public DateTime created_at { get; set; }
        public DateTime birthday { get; set; }
        public string image_url { get; set; }
        public string image_url_cdn { get; set; }
        public string color { get; set; }
        public object kitty_type { get; set; }
        public bool is_fancy { get; set; }
        public bool is_exclusive { get; set; }
        public bool is_special_edition { get; set; }
        public object fancy_type { get; set; }
        public string language { get; set; }
        public bool is_prestige { get; set; }
        public object prestige_type { get; set; }
        public object prestige_ranking { get; set; }
        public object prestige_time_limit { get; set; }
        public Status status { get; set; }
        public Purrs purrs { get; set; }
        public Watchlist watchlist { get; set; }
        public Hatcher hatcher { get; set; }
        public Auction auction { get; set; }
        public Offer offer { get; set; }
        public Owner owner { get; set; }
        public Matron matron { get; set; }
        public Sire sire { get; set; }
        public Child[] children { get; set; }
        public bool hatched { get; set; }
        public bool wrapped { get; set; }
        public object variation { get; set; }
        public object variation_ranking { get; set; }
        public string image_url_png { get; set; }
        public string image_url_kitty_items { get; set; }
        public object[] items { get; set; }
        public string description { get; set; }
        //public Attribute[] attributes { get; set; }
    }

    public class Status
    {
        public bool is_ready { get; set; }
        public bool is_gestating { get; set; }
        public long cooldown { get; set; }
        public long dynamic_cooldown { get; set; }
        public int cooldown_index { get; set; }
        public int cooldown_end_block { get; set; }
        public object pending_tx_type { get; set; }
        public object pending_tx_since { get; set; }
    }

    public class Purrs
    {
        public int count { get; set; }
        public bool is_purred { get; set; }
    }

    public class Watchlist
    {
        public int count { get; set; }
        public bool is_watchlisted { get; set; }
    }

    public class Hatcher
    {
        public string address { get; set; }
        public string image { get; set; }
        public string nickname { get; set; }
        public bool hasDapper { get; set; }
        public object twitter_id { get; set; }
        public object twitter_image_url { get; set; }
        public object twitter_handle { get; set; }
    }

    public class Auction
    {
        public int id { get; set; }
        public string type { get; set; }
        public string start_price { get; set; }
        public string end_price { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string current_price { get; set; }
        public string duration { get; set; }
        public string status { get; set; }
        public Seller seller { get; set; }
    }

    public class Seller
    {
        public string address { get; set; }
        public bool hasDapper { get; set; }
        public string nickname { get; set; }
        public string image { get; set; }
    }

    public class Offer
    {
    }

    public class Owner
    {
        public string address { get; set; }
        public bool hasDapper { get; set; }
        public object twitter_id { get; set; }
        public object twitter_image_url { get; set; }
        public object twitter_handle { get; set; }
        public string image { get; set; }
        public string nickname { get; set; }
    }

    public class Matron
    {
        public int id { get; set; }
        public string name { get; set; }
        public int generation { get; set; }
        public Enhanced_Cattributes[] enhanced_cattributes { get; set; }
        public string owner_wallet_address { get; set; }
        public Owner1 owner { get; set; }
        public DateTime created_at { get; set; }
        public string image_url { get; set; }
        public string image_url_cdn { get; set; }
        public string color { get; set; }
        public bool is_fancy { get; set; }
        public object kitty_type { get; set; }
        public bool is_exclusive { get; set; }
        public bool is_special_edition { get; set; }
        public object fancy_type { get; set; }
        public Status1 status { get; set; }
        public bool hatched { get; set; }
        public bool wrapped { get; set; }
        public string image_url_png { get; set; }
        public string image_url_kitty_items { get; set; }
    }

    public class Owner1
    {
        public string address { get; set; }
    }

    public class Status1
    {
        public bool is_ready { get; set; }
        public bool is_gestating { get; set; }
        public long cooldown { get; set; }
    }

    public class Enhanced_Cattributes
    {
        public string type { get; set; }
        public int kittyId { get; set; }
        public int position { get; set; }
        public string description { get; set; }
    }

    public class Sire
    {
        public int id { get; set; }
        public string name { get; set; }
        public int generation { get; set; }
        public Enhanced_Cattributes1[] enhanced_cattributes { get; set; }
        public string owner_wallet_address { get; set; }
        public Owner2 owner { get; set; }
        public DateTime created_at { get; set; }
        public string image_url { get; set; }
        public string image_url_cdn { get; set; }
        public string color { get; set; }
        public bool is_fancy { get; set; }
        public bool is_exclusive { get; set; }
        public bool is_special_edition { get; set; }
        public object fancy_type { get; set; }
        public Status2 status { get; set; }
        public object kitty_type { get; set; }
        public bool hatched { get; set; }
        public bool wrapped { get; set; }
        public string image_url_png { get; set; }
        public string image_url_kitty_items { get; set; }
    }

    public class Owner2
    {
        public string address { get; set; }
    }

    public class Status2
    {
        public bool is_ready { get; set; }
        public bool is_gestating { get; set; }
        public long cooldown { get; set; }
    }

    public class Enhanced_Cattributes1
    {
        public string type { get; set; }
        public int kittyId { get; set; }
        public int position { get; set; }
        public string description { get; set; }
    }

    public class Child
    {
        public int id { get; set; }
        public string name { get; set; }
        public int generation { get; set; }
        public Enhanced_Cattributes2[] enhanced_cattributes { get; set; }
        public string owner_wallet_address { get; set; }
        public Owner3 owner { get; set; }
        public DateTime created_at { get; set; }
        public string image_url { get; set; }
        public string image_url_cdn { get; set; }
        public string color { get; set; }
        public bool is_fancy { get; set; }
        public bool is_exclusive { get; set; }
        public bool is_special_edition { get; set; }
        public object kitty_type { get; set; }
        public object fancy_type { get; set; }
        public Status3 status { get; set; }
        public bool hatched { get; set; }
        public bool wrapped { get; set; }
        public string image_url_png { get; set; }
        public string image_url_kitty_items { get; set; }
    }

    public class Owner3
    {
        public string address { get; set; }
    }

    public class Status3
    {
        public bool is_ready { get; set; }
        public bool is_gestating { get; set; }
        public long cooldown { get; set; }
    }

    public class Enhanced_Cattributes2
    {
        public string type { get; set; }
        public int kittyId { get; set; }
        public int position { get; set; }
        public string description { get; set; }
    }

    public class Attribute
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public int? Position { get; set; }
        public int KittyId { get; set; }
    }

}

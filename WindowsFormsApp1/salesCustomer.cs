using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WindowsFormsApp1
{
    public partial class MainWindow
    {
        class salesCustomer
        {
            [BsonId]
            public ObjectId Id { get; set; }
            [BsonElement("name")]
            public String Name { get; set; }
            [BsonElement("price")]
            public String Price { get; set; }
            [BsonElement("quantity")]
            public String Quantity { get; set; }
            [BsonElement("amount")]
            public String Amount { get; set; }

        }
    }
}




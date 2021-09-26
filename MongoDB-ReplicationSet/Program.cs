using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBRep
{
    class Program
    {

        private static MongoClient mongoClient = new MongoClient("mongodb://localhost:30001/?readPreference=primary&ssl=false"); 
        static void Main(string[] args)
        {




            // GetDBList ------------------------------------------------------------------------
            var dbList = mongoClient.ListDatabases().ToList();
            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }


            //Use the MongoClient to access the server
            var database = mongoClient.GetDatabase("Microsoft");
            // get mongodb collection
            var collection = database.GetCollection<Personnel>("Personnel");
            
            
            
            // Get All Doc
            var getAllDocument = GetAll<Personnel>(collection);
            
            // insert Doc             
            // Insert<Personnel>(collection , new Personnel("Fiest Name 1" , "Last Name 1"));

        }

        public static List<BsonDocument> getDBlist()
        {
            return mongoClient.ListDatabases().ToList();
        }


        public static void Insert<T>(IMongoCollection<T> mongoCollection , T entity)
        {
               mongoCollection.InsertOne(entity);
        }

        public static List<T> GetAll<T>(IMongoCollection<T> mongoCollection)
        {
            return mongoCollection.Find<T>(_ => true).ToList();
        }

    }


    public class Personnel
    {
        public Personnel(string fname, string lname)
        {
            this.fname = fname;
            this.lname = lname;
        }

        public ObjectId _id { get; set; }

        public string fname {get; set;}

        public string lname {get; set;}
    }
}

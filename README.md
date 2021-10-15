https://docs.mongodb.com/manual/replication/


1 . First go to Mongo-Cli in Primary bash

2 .  exec   config = 
            { 
              "_id" : "comments" ,
               "members" :[
                {
                  "_id" : 0 ,
                  "host" : "node1:27017"
                } , 
                {
                  "_id" : 1 ,
                  "host" : "node2:27017"
                } , 
                {
                  "_id" : 2 ,
                  "host" : "node3:27017"
                } 
                 ]
            }
            
            
3 . exec rs.initiate(config) 

4 . Now you are a database with 1 Primary and 2 Replica 

5 . insert to primary DB 

6 . go to secondary DB and exec db.setSlaveOk()

7 . finally exec db.YOURDBNAME.find()

#---------------------------------------------------------------------------------
#EXAMPLE : 
comments:PRIMARY> use Microsoft
switched to db Microsoft
comments:PRIMARY> db.MicrosoftCollection.insert({ "Name" : "Fazel Saeedi"})
WriteResult({ "nInserted" : 1 })
comments:PRIMARY> db.MicrosoftCollection.find()
{ "_id" : ObjectId("614ff931efca18b10ef57515"), "Name" : "Fazel Saeedi" }
comments:PRIMARY> 



-------------------------------------------------------------------------------


db.setSlaveOk()
db.MicrosoftCollection.find()

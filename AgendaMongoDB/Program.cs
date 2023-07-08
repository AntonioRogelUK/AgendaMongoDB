using AgendaMongoDB;
using MongoDB.Driver;

MongoClient client = new MongoClient("mongodb://localhost:27017");
IMongoDatabase database = client.GetDatabase("agenda");
IMongoCollection<Contacto> collection = database.GetCollection<Contacto>("contactos");

Contacto contacto= new Contacto();
contacto.Name = "Putter";
contacto.Address = "9 3/4";
contacto.Phone= "1234567890";

Insert(contacto);


Contacto contacto2 = new Contacto();
contacto2.Name = "Sasuke";
contacto2.Address = "Konoha";
contacto2.Phone= "1234567890";

Insert(contacto2);

Contacto contactoEncontrado = FindByName("Putter");
Console.WriteLine(contactoEncontrado.Id);


foreach(Contacto c in Get())
{
    Console.WriteLine(c.Name);
}

void Insert(Contacto contacto)
{
    collection.InsertOne(contacto);
}

Contacto FindByName(string name)
{
    return collection.Find(c => c.Name == name)
        .FirstOrDefault<Contacto>();
}

List<Contacto> Get()
{
    return collection.Find(c => true).ToList();
}

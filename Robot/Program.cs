

using MongoDB.Bson;
using MongoDB.Driver;
using NSubstitute.Core;
using Robot.BodyParts;
using Robots;

var client = new MongoClient("mongodb+srv://EmilijaSliburiene:Vytis2020@cluster0.emno8.mongodb.net/?retryWrites=true&w=majority");
var robotStructure = client.GetDatabase("Robot").GetCollection<FullRobot>("UsersRobots");

//GetRobotById("62b0a516ac0895e79f7787cf");
//DeleteRobotById("62b0a516ac0895e79f7787cf");
UpdateRobot("62b0a6f40b566f6825e60123");
Console.WriteLine("Robot is done");
Console.ReadLine();

void AddRobot(string name)
{
    var robot = new FullRobot(name);
    var arm = new List<Arm>
    {
        new Arm
        {
            Material = "Metal",
            NumberOfJoints = 6,
            NumberOfFingers = 20

        }
    };
    robot.Arms = arm;
    var leg = new List<Leg>
    {
    new Leg
    {
            Material = "Metal",
            NumberOfJoints = 6,
            SizeOfFoot = 42
    }
    };
    robot.Leg = leg;
    var torso = new List<Torso>
    {
        new Torso
        {
            ChestMesurements = 89.9M,
            WaistMesurements = 78.8M

        }
    };
    robot.Torso= torso;
    var head = new List<Head>
    {
    new Head
    {
        HeadType = "Round"
    }
    };
    robot.Head= head;

    robotStructure.InsertOne(robot);
}
void AddRobotToDb(string robot)
{
    var client = new MongoClient("mongodb+srv://EmilijaSliburiene:Vytis2020@cluster0.emno8.mongodb.net/?retryWrites=true&w=majority");
    var robotStructure = client.GetDatabase("Robot").GetCollection<FullRobot>("UsersRobots");
    robotStructure.InsertOne(robot);
}
//public static void SaveRobotIntoDb(List<Robot> robots) cia pvz kaip lista pridet, esminis skirtumas yra add many
//{
//    var client = new MongoClient("mongodb+srv://LinKru95:Kompiuteris.1@cluster0.8l9v5zd.mongodb.net/?retryWrites=true&w=majority");
//    var robotCollection = client.GetDatabase("Robots").GetCollection<Robot>("Robots");

//    robotCollection.InsertMany(robots);
//}

void GetRobotById(string id)

{
    var filter_id = Builders<FullRobot>.Filter.Eq("_id", ObjectId.Parse(id));
    var entity = robotStructure.Find(filter_id).FirstOrDefault();
    var result = entity.ToString();
    Console.WriteLine(result);

    //var searchFilter = Builders<Robot>.Filter.Eq("_id", new ObjectId(id)); Lpvz
    //var results = robotCollection.Find(searchFilter).ToList();

    //var robot = new FullRobot(name);
    //var query_id = robot.Find(x=>x.id== "62b0a516ac0895e79f7787cf").FirstOrDefault();
    //return query_id.ToString();

}
void GetByHeadForm()
{
    //var searchFilter = Builders<Robot>.Filter.Eq("Head", headform);
    //var results = robotCollection.Find(searchFilter).ToList();

    //Console.WriteLine(results.Count);
}
void DeleteRobotById(string id)
{
    var filter_id = Builders<FullRobot>.Filter.Eq("_id", ObjectId.Parse(id));
    robotStructure.DeleteOne(filter_id);
}
void UpdateRobot(string id)
{
    var filter_id = Builders<FullRobot>.Filter.Eq("_id", ObjectId.Parse(id));
    var update = Builders<FullRobot>.Update.AddToSet<HeadType>("Square");
    robotStructure.UpdateMany(filter_id, update);

    //var client = new MongoClient("mongodb+srv://LinKru95:Kompiuteris.1@cluster0.8l9v5zd.mongodb.net/?retryWrites=true&w=majority");
    //var robotCollection = client.GetDatabase("Robots").GetCollection<Robot>("Robots");

    //var searchFilter = Builders<Robot>.Filter.Eq("_id", new ObjectId(id));
    //var results = robotCollection.Find(searchFilter).ToList();

    //foreach (var item in results)
    //{
    //    item.Head = (Head)headform;
    //}

    //var update = Builders<Robot>.Update.Set("Head", headform);
}

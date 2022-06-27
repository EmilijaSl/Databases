using MongoDB.Bson;
using Robot.BodyParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class FullRobot
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public List<Arm> Arms { get; set; }
        public List<Leg> Leg { get; set; }
        public List<Torso> Torso { get; set; }
        public List<Head> Head { get; set; }
        public FullRobot(string name)
        {

            Arms = new List<Arm>();
            Leg = new List<Leg>();
            Torso = new List<Torso>();
            Head = new List<Head>();
            Name = name;
        }
    }
}

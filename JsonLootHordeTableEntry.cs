using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCohort
{
    class JsonLootHordeTableEntryStuff
    {
        public string type;
        public string amount;
    }

    class JsonLootHordeTableEntry
    {
        public int min;
        public int max;
        public JsonLootHordeTableEntryStuff gems;
        public JsonLootHordeTableEntryStuff artobjects;
        public JsonLootHordeTableEntryStuff magicitems;
    }
}

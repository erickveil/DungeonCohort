using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCohort.JsonLoading;

namespace DungeonCohort
{
    /// <summary>
    /// This singleton will hold all loaded data so that it doesn't get loaded
    /// multiple times and all the many sources don't all have to be passed
    /// around to every class.
    ///
    /// It's the configuration use case of the singleton.
    ///
    /// TODO: Move all other loaders into this class and follow the pattern of 
    /// JsonSpellLoader.
    ///
    /// Member classes have to be private because we want to make sure _init
    /// is run before we obtain the value (which is static and might
    /// otherwise return null if accessed in a publicly static way instead of
    /// through the Instance).
    /// </summary>
    class DataSourceLoader
    {
        private static DataSourceLoader _instance = null;

        private static JsonSpellLoader _spellSource;

        private DataSourceLoader()
        {
            _spellSource = new JsonSpellLoader();
        }

        private static void _init()
        {
            _spellSource.LoadAllSpells();

        }

        public static DataSourceLoader Instance
        {
            get
            {
                if (_instance is null) 
                { 
                    _instance = new DataSourceLoader();
                    _init();
                }
                return _instance;
            }
        }

        public JsonSpellLoader SpellSource
        {
            get { return  _spellSource; }
        }


    }
}

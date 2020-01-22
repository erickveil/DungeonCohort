using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCohort.JsonLoading;
using System.IO;
using Newtonsoft.Json;

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
        private static JsonBookLoader _bookSource;
        private static JsonContainerContents _containerContentsSource;
        private static JsonMageFurnishings _mageFurnishingsSource;

        private DataSourceLoader()
        {
            _spellSource = new JsonSpellLoader();
            _bookSource = new JsonBookLoader();
            _containerContentsSource = new JsonContainerContents();
            _mageFurnishingsSource = new JsonMageFurnishings();
        }

        private static void _init()
        {
            _spellSource.LoadAllSpells();
            _bookSource.LoadBookFile();
            _containerContentsSource.Init();
            _mageFurnishingsSource.LoadFile();
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

        public static string LoadFile(string filename)
        {
            string jsonData;
            try { jsonData = File.ReadAllText(filename); }
            catch (Exception)
            {
                Console.WriteLine("Could not load file: " + filename);
                return "";
            }

            return jsonData;
        }

        public JsonSpellLoader SpellSource
        {
            get { return  _spellSource; }
        }

        public JsonBookLoader BookSource
        {
            get { return _bookSource; }
        }

        public JsonContainerContents ContainerContentsSource
        {
            get { return _containerContentsSource; }
        }

        public JsonMageFurnishings MageFurnishingsSource
        {
            get { return _mageFurnishingsSource; }
        }



    }
}

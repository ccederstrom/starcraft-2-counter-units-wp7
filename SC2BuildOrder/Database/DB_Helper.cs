using System;
using System.Net;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace SC2BuildOrder
{
    public class DB_Helper
    {
        public const int UNIT = 0;
        public const int BUILDING = 1;
        public const int UPGRADE = 2;
        // Data context for the local database
        //private static Row.GPSDataContext DB;
        private static Index.DataContext_Index DB_Index;
        private static Build_Order.DataContext_Build_Order DB_Build_Order;
        private static Object_SC.DataContext_Object_SC DB_Object_SC;

        // Connect to the database and instantiate data context.
        public static void connect()
        {
            //DB = new Row.GPSDataContext(Row.GPSDataContext.DBConnectionString);
            DB_Index = new Index.DataContext_Index(Index.DataContext_Index.DBConnectionString);
            DB_Build_Order = new Build_Order.DataContext_Build_Order(Build_Order.DataContext_Build_Order.DBConnectionString);
            DB_Object_SC = new Object_SC.DataContext_Object_SC(Object_SC.DataContext_Object_SC.DBConnectionString);
        }

        //public static ObservableCollection<Row> getAllRows()
        //{
        //    var InDB = from Row todo in DB.Rows select todo;
        //    return (new ObservableCollection<Row>(InDB));
        //}
        //public static ObservableCollection<Row> getRowsbyTitle(String title)
        //{
        //    var edit_query = from Row todo in DB.Rows where todo.Title == title select todo;
        //    return (new ObservableCollection<Row>(edit_query));
        //}
        //public static void deleteRow(Row temp)
        //{
        //    DB.Rows.DeleteOnSubmit(temp);
        //    DB.SubmitChanges();
        //}
        //public static void insertRow(Row temp)
        //{
        //    DB.Rows.InsertOnSubmit(temp);
        //    DB.SubmitChanges();
        //}

        /////////////OBJECT_SC TABLE//////////////////////
        public static void insertObject(string name, string race, int type, int food, int mineral, int gas, int time, String path, String strong1, String strong2, String strong3, String weak1, String weak2, String weak3)
        {
            Object_SC obj = new Object_SC(name, race, type, food, mineral, gas, time, path, strong1, strong2, strong3,  weak1, weak2, weak3);
            DB_Object_SC.Object_SC_Table.InsertOnSubmit(obj);
            DB_Object_SC.SubmitChanges();
        }
        public static ObservableCollection<Object_SC> get_Object_SC_by_Type_and_Race(String race, int type)
        {
            var InDB = from Object_SC obj in DB_Object_SC.Object_SC_Table where obj.Type == type && obj.Race == race select obj;
            return (new ObservableCollection<Object_SC>(InDB));
        }
        public static ObservableCollection<Object_SC> get_Object_SC_by_Race(String race)
        {
            var InDB = from Object_SC obj in DB_Object_SC.Object_SC_Table where obj.Race == race select obj;
            return (new ObservableCollection<Object_SC>(InDB));
        }
        public static ObservableCollection<Object_SC> get_Object_SC_by_Obj_Id(int obj_id)
        {
            var InDB = from Object_SC obj in DB_Object_SC.Object_SC_Table where obj.Obj_Id == obj_id select obj;
            return (new ObservableCollection<Object_SC>(InDB));
        }
        ////////////BUILD_ORDERS TABLE//////////////////////
        public static void insertBuild(int index_id, int order, int obj_id)
        {
            Build_Order obj = new Build_Order(index_id, order, obj_id);
            DB_Build_Order.Build_Order_Table.InsertOnSubmit(obj);
            DB_Build_Order.SubmitChanges();
        }
        ////////////INDEX TABLE//////////////////////////////////
        public static void createIndex(String name, String des,String race, String author)
        {
            Index ind = new Index(name, des, race, author);
            DB_Index.Index_Table.InsertOnSubmit(ind);
            DB_Index.SubmitChanges();
        }

        public static ObservableCollection<Index> get_Index_By_Name(String name)
        {
            var InDB = from Index ind in DB_Index.Index_Table where ind.Name == name select ind;
            return (new ObservableCollection<Index>(InDB));
        }

        public static ObservableCollection<Index> get_Index_By_Author(String author, String race)
        {
            var InDB = from Index ind in DB_Index.Index_Table where ind.Author == author && ind.Race==race select ind;
            return (new ObservableCollection<Index>(InDB));
        }

        public static ObservableCollection<Index> get_Index_Built_In(String race)
        {
            var InDB = from Index ind in DB_Index.Index_Table where ind.Author != "Custom" && ind.Race==race select ind;
            return (new ObservableCollection<Index>(InDB));
        }
        //////////////BUILD ORDER TABLE/////////////////////////////
        public static ObservableCollection<Build_Order> get_Build_Order_By_Index_Id(int index_id)
        {
            var InDB = from Build_Order ind in DB_Build_Order.Build_Order_Table where ind.Index_Id == index_id orderby ind.Order select ind;
            return (new ObservableCollection<Build_Order>(InDB));
        }
        //////////////////////////////////////////////////
        //Enter all Units, Buildings, and Upgrades to Database
        public static void enterObjectSC_Information()
        {
            DB_Helper.connect();


            string zerg_unit_path = "/SC2BuildOrder;component/Images/Zerg/Units/";
            string protoss_units_path = "/SC2BuildOrder;component/Images/Protoss/Units/";
            string terran_unit_path = "/SC2BuildOrder;component/Images/Terran/Units/";

            #region Zerg

            #region Zerg Units
            // ZERG Units
            insertObject("Drone", "Zerg", DB_Helper.UNIT, 1, 50, 0, 17, zerg_unit_path + "Unofficial/drone.jpg", terran_unit_path + "", protoss_units_path +"", zerg_unit_path + "", terran_unit_path+"reaper.png", protoss_units_path+"dark_templar.png", zerg_unit_path+"baneling.png");
            insertObject("Queen", "Zerg", DB_Helper.UNIT, 2, 150, 0, 50, zerg_unit_path + "Unofficial/queen.jpg", terran_unit_path + "hellion.png", protoss_units_path + "void_ray.png", zerg_unit_path + "mutalisk.png", terran_unit_path + "marine.png", protoss_units_path + "zealot.png", zerg_unit_path + "zergling.png");
            insertObject("Zergling", "Zerg", DB_Helper.UNIT, 1, 50, 0, 24, zerg_unit_path + "Unofficial/zergling.jpg", terran_unit_path + "marauder.png", protoss_units_path + "stalker.png", zerg_unit_path + "hydralisk.png", terran_unit_path + "hellion.png", protoss_units_path + "colossus.png", zerg_unit_path + "baneling.png");
            insertObject("Baneling", "Zerg", DB_Helper.UNIT, 0, 25, 25, 20, zerg_unit_path + "Unofficial/baneling.jpg", terran_unit_path + "marine.png", protoss_units_path + "zealot.png", zerg_unit_path + "zergling.png", terran_unit_path + "marauder.png", protoss_units_path + "stalker.png", zerg_unit_path + "roach.png");
            insertObject("Roach", "Zerg", DB_Helper.UNIT, 2, 75, 25, 27, zerg_unit_path + "Unofficial/roach.jpg", terran_unit_path + "hellion.png", protoss_units_path + "zealot.png", zerg_unit_path + "zergling.png", terran_unit_path + "marauder.png", protoss_units_path + "immortal.png", zerg_unit_path + "ultralisk.png");
            insertObject("Hydralisk", "Zerg", DB_Helper.UNIT, 2, 100, 50, 33, zerg_unit_path + "Unofficial/hydralisk.jpg", terran_unit_path + "banshee.png", protoss_units_path + "void_ray.png", zerg_unit_path + "mutalisk.png", terran_unit_path + "siegetank.png", protoss_units_path + "colossus.png", zerg_unit_path + "zergling.png");
            insertObject("Mutalisk", "Zerg", DB_Helper.UNIT, 2, 100, 100, 33, zerg_unit_path + "Unofficial/mutalisk.jpg", terran_unit_path + "viking.png", protoss_units_path + "void_ray.png", zerg_unit_path + "broodlord.png", terran_unit_path + "thor.png", protoss_units_path + "phoenix.png", zerg_unit_path + "corruptor.png");
            insertObject("Corruptor", "Zerg", DB_Helper.UNIT, 2, 150, 100, 40, zerg_unit_path + "Unofficial/corruptor.jpg", terran_unit_path + "battlecruiser.png", protoss_units_path + "phoenix.png", zerg_unit_path + "mutalisk.png", terran_unit_path + "viking.png", protoss_units_path + "void_ray.png", zerg_unit_path + "hydralisk.png");
            insertObject("Infestor", "Zerg", DB_Helper.UNIT, 2, 100, 150, 50, zerg_unit_path + "Unofficial/infestor.jpg", terran_unit_path + "marine.png", protoss_units_path + "immortal.png", zerg_unit_path + "mutalisk.png", terran_unit_path + "ghost.png", protoss_units_path + "high_templar.png", zerg_unit_path + "ultralisk.png");
            insertObject("Ultralisk", "Zerg", DB_Helper.UNIT, 6, 300, 200, 70, zerg_unit_path + "Unofficial/ultralisk.jpg", terran_unit_path + "marauder.png", protoss_units_path + "stalker.png", zerg_unit_path + "roach.png", terran_unit_path + "banshee.png", protoss_units_path + "void_ray.png", zerg_unit_path + "mutalisk.png");
            insertObject("Brood Lord", "Zerg", DB_Helper.UNIT, 2, 150, 150, 34, zerg_unit_path + "Unofficial/brood_lord.jpg", terran_unit_path + "marine.png", protoss_units_path + "stalker.png", zerg_unit_path + "hydralisk.png", terran_unit_path + "viking.png", protoss_units_path + "void_ray.png", zerg_unit_path + "corruptor.png");
            insertObject("Overlord", "Zerg", DB_Helper.UNIT, 0, 100, 0, 25, zerg_unit_path + "Unofficial/overlord.jpg", terran_unit_path + "", protoss_units_path + "", zerg_unit_path + "", terran_unit_path + "viking.png", protoss_units_path + "phoenix.png", zerg_unit_path + "corruptor.png");
            insertObject("Overseer", "Zerg", DB_Helper.UNIT, 0, 50, 100, 17, zerg_unit_path + "Unofficial/overseer.jpg", terran_unit_path + "banshee.png", protoss_units_path + "dark_templar.png", zerg_unit_path + "roach.png", terran_unit_path + "viking.png", protoss_units_path + "stalker.png", zerg_unit_path + "mutalisk.png");
            #endregion

            #region Zerg Buildings
            //ZERG Builings
            string ZERG = "Zerg";
            insertObject("Hatchery", ZERG, DB_Helper.BUILDING, 0, 300, 0, 100,"","","","","","","");
            insertObject("Lair", ZERG, DB_Helper.BUILDING, 0, 150, 150, 80,"","","","","","","");
            insertObject("Hive", ZERG, DB_Helper.BUILDING, 0, 200, 150, 100,"","","","","","","");
            insertObject("Extractor", ZERG, DB_Helper.BUILDING, 1, 25, 0, 30,"","","","","","","");
            insertObject("Spawning Pool", ZERG, DB_Helper.BUILDING, 1, 200, 0, 65,"","","","","","","");
            insertObject("Nydus Network", ZERG, DB_Helper.BUILDING, 1, 150, 200, 50,"","","","","","","");
            insertObject("Spine Crawler", ZERG, DB_Helper.BUILDING, 1, 100, 0, 50,"","","","","","","");
            insertObject("Spore Crawler", ZERG, DB_Helper.BUILDING, 1, 75, 0, 30,"","","","","","","");
            insertObject("Evolution Chamber", ZERG, DB_Helper.BUILDING, 1, 75, 0, 35,"","","","","","","");
            insertObject("Hydralisk Den", ZERG, DB_Helper.BUILDING, 1, 100, 100, 40,"","","","","","","");
            insertObject("Infestation Pit", ZERG, DB_Helper.BUILDING, 1, 100, 100, 50,"","","","","","","");
            insertObject("Ultralisk Cavern", ZERG, DB_Helper.BUILDING, 1, 150, 200, 65,"","","","","","","");
            insertObject("Creep Tumor", ZERG, DB_Helper.BUILDING, 1, 0, 0, 15,"","","","","","","");
            insertObject("Nydus Worm", "Zerg", DB_Helper.BUILDING, 0, 100, 100, 20, terran_unit_path + "", protoss_units_path + "", zerg_unit_path + "", terran_unit_path + "", protoss_units_path + "", zerg_unit_path + "", "");


            insertObject("Baneling Nest", ZERG, DB_Helper.BUILDING, 1, 100, 50, 60,"","","","","","","");
            insertObject("Roach Warren", ZERG, DB_Helper.BUILDING, 1, 150, 0, 55,"","","","","","","");
            insertObject("Spire", ZERG, DB_Helper.BUILDING, 1, 200, 150, 120,"","","","","","","");
            insertObject("Greater Spire", ZERG, DB_Helper.BUILDING, 0, 100, 150, 100,"","","","","","",""); // depends on spire
            #endregion

            #region Zerg Upgrades
            //Zerg Upgrades
            insertObject("Melee Attacks Level 1", "Zerg", DB_Helper.UPGRADE, 0, 100, 100, 160,"","","","","","","");
            insertObject("Centrifugal Hooks", ZERG, DB_Helper.UPGRADE, 0, 150, 150, 110,"","","","","","","");
            insertObject("Glial Reconstitution", ZERG, DB_Helper.UPGRADE, 0, 100, 100, 110,"","","","","","",""); // roach warren
            insertObject("Tunneling Claws", ZERG, DB_Helper.UPGRADE, 0, 150, 150, 110,"","","","","","",""); // roach warren
            insertObject("Flyer Attacks Level 1", "Zerg", DB_Helper.UPGRADE, 0, 100, 100, 160,"","","","","","",""); // Spire
            insertObject("Flyer Attacks Level 2", "Zerg", DB_Helper.UPGRADE, 0, 175, 175, 190,"","","","","","",""); // Spire
            insertObject("Flyer Attacks Level 3", "Zerg", DB_Helper.UPGRADE, 0, 250, 250, 220,"","","","","","",""); // Spire
            insertObject("Flyer Carapace Level 1", "Zerg", DB_Helper.UPGRADE, 0, 150, 150, 160,"","","","","","",""); // Spire
            insertObject("Flyer Carapace Level 2", "Zerg", DB_Helper.UPGRADE, 0, 225, 225, 190,"","","","","","",""); // Spire
            insertObject("Flyer Carapace Level 3", "Zerg", DB_Helper.UPGRADE, 0, 300, 300, 220,"","","","","","",""); // Spire
            #endregion
            #endregion

            #region Protoss
            #region Protoss Units
            // PROTOSS Units
            string PROTOSS = "Protoss";
            //http://wiki.teamliquid.net/starcraft2/Units

            insertObject("Probe", PROTOSS, DB_Helper.UNIT, 1, 50, 0, 17, protoss_units_path + "Unofficial/probe.jpg", terran_unit_path + "", protoss_units_path + "", zerg_unit_path + "", terran_unit_path + "reaper.png", protoss_units_path + "dark_templar.png", zerg_unit_path + "baneling.png");
            insertObject("Zealot", PROTOSS, DB_Helper.UNIT, 2, 100, 0, 38, protoss_units_path + "Unofficial/zealot.jpg", terran_unit_path + "marauder.png", protoss_units_path + "immortal.png", zerg_unit_path + "zergling.png", terran_unit_path + "hellion.png", protoss_units_path + "colossus.png", zerg_unit_path + "roach.png");
            insertObject("Stalker", PROTOSS, DB_Helper.UNIT, 2, 125, 50, 42, protoss_units_path + "Unofficial/stalker.jpg", terran_unit_path + "reaper.png", protoss_units_path + "void_ray.png", zerg_unit_path + "mutalisk.png", terran_unit_path + "marauder.png", protoss_units_path + "immortal.png", zerg_unit_path + "zergling.png");
            insertObject("Sentry", PROTOSS, DB_Helper.UNIT, 2, 50, 100, 37, protoss_units_path + "Unofficial/sentry.jpg", terran_unit_path + "", protoss_units_path + "zealot.png", zerg_unit_path + "zergling.png", terran_unit_path + "reaper.png", protoss_units_path + "stalker.png", zerg_unit_path + "hydralisk.png");
            insertObject("High Templar", PROTOSS, DB_Helper.UNIT, 2, 50, 150, 55, protoss_units_path + "Unofficial/high_templar.jpg", terran_unit_path + "marine.png", protoss_units_path + "sentry.png", zerg_unit_path + "hydralisk.png", terran_unit_path + "ghost.png", protoss_units_path + "colossus.png", zerg_unit_path + "roach.png");
            insertObject("Dark Templar", PROTOSS, DB_Helper.UNIT, 2, 125, 125, 55, protoss_units_path + "Unofficial/dark_templar.jpg", terran_unit_path + "scv.png", protoss_units_path + "probe.png", zerg_unit_path + "drone.png", terran_unit_path + "raven.png", protoss_units_path + "observer.png", zerg_unit_path + "overseer.png");
            insertObject("Archon", PROTOSS, DB_Helper.UNIT, 0, 0, 0, 12, protoss_units_path + "Unofficial/archon.jpg", terran_unit_path + "", protoss_units_path + "", zerg_unit_path + "mutalisk.png", terran_unit_path + "thor.png", protoss_units_path + "immortal.png", zerg_unit_path + "ultralisk.png"); // depends on two high templars, enable if two hight templars in queue
            insertObject("Immortal", PROTOSS, DB_Helper.UNIT, 4, 250, 100, 55, protoss_units_path + "Unofficial/immortal.jpg", terran_unit_path + "seigetank.png", protoss_units_path + "stalker.png", zerg_unit_path + "roach.png", terran_unit_path + "marine.png", protoss_units_path + "zealot.png", zerg_unit_path + "zergling.png");
            insertObject("Colossus", PROTOSS, DB_Helper.UNIT, 6, 300, 200, 75, protoss_units_path + "Unofficial/colossus.jpg", terran_unit_path + "marine.png", protoss_units_path + "zealot.png", zerg_unit_path + "zergling.png", terran_unit_path + "viking.png", protoss_units_path + "immortal.png", zerg_unit_path + "corruptor.png");
            insertObject("Observer", PROTOSS, DB_Helper.UNIT, 1, 25, 75, 40, protoss_units_path + "observer.png", terran_unit_path + "banshee.png", protoss_units_path + "dark_templar.png", zerg_unit_path + "roach.png", terran_unit_path + "raven.png", protoss_units_path + "observer.png", zerg_unit_path + "overseer.png");
            insertObject("Warp Prism", PROTOSS, DB_Helper.UNIT, 2, 200, 0, 50, protoss_units_path + "Unofficial/warp_prism.jpg", terran_unit_path + "", protoss_units_path + "", zerg_unit_path + "", terran_unit_path + "viking.png", protoss_units_path + "phoenix.png", zerg_unit_path + "corruptor.png");
            insertObject("Phoenix", PROTOSS, DB_Helper.UNIT, 2, 150, 100, 35, protoss_units_path + "Unofficial/phoenix.jpg", terran_unit_path + "banshee.png", protoss_units_path + "void_ray.png", zerg_unit_path + "mutalisk.png", terran_unit_path + "battlecruiser.png", protoss_units_path + "carrier.png", zerg_unit_path + "corruptor.png");
            insertObject("Void Ray", PROTOSS, DB_Helper.UNIT, 3, 250, 150, 60, protoss_units_path + "Unofficial/void_ray.jpg", terran_unit_path + "battlecruiser.png", protoss_units_path + "carrier.png", zerg_unit_path + "corruptor.png", terran_unit_path + "viking.png", protoss_units_path + "phoenix.png", zerg_unit_path + "mutalisk.png");
            insertObject("Carrier", PROTOSS, DB_Helper.UNIT, 6, 350, 250, 120, protoss_units_path + "Unofficial/carrier.jpg", terran_unit_path + "thor.png", protoss_units_path + "phoenix.png", zerg_unit_path + "mutalisk.png", terran_unit_path + "viking.png", protoss_units_path + "void_ray.png", zerg_unit_path + "corruptor.png");
            insertObject("Mothership", PROTOSS, DB_Helper.UNIT, 8, 400, 400, 160, protoss_units_path + "Unofficial/mothership.jpg", terran_unit_path + "", protoss_units_path + "", zerg_unit_path + "", terran_unit_path + "viking.png", protoss_units_path + "void_ray.png", zerg_unit_path + "corruptor.png");
            #endregion

            #region Protoss Buildings
            // Protoss building

            insertObject("Assimilator", PROTOSS, DB_Helper.BUILDING, 0, 75, 0, 30,"","","","","","","");
            insertObject("Cybernetics Core", PROTOSS, DB_Helper.BUILDING, 0, 150, 0, 50,"","","","","","","");
            insertObject("Dark Shrine", PROTOSS, DB_Helper.BUILDING, 0, 100, 250, 100,"","","","","","","");
            insertObject("Fleet Beacon", PROTOSS, DB_Helper.BUILDING, 0, 300, 200, 60,"","","","","","","");
            insertObject("Forge", PROTOSS, DB_Helper.BUILDING, 0, 150, 0, 45,"","","","","","","");
            insertObject("Gateway", PROTOSS, DB_Helper.BUILDING, 0, 150, 0, 65,"","","","","","","");
            insertObject("Nexus", PROTOSS, DB_Helper.BUILDING, 0, 400, 0, 100,"","","","","","","");
            insertObject("Photon Cannon", PROTOSS, DB_Helper.BUILDING, 0, 150, 0, 40,"","","","","","","");
            insertObject("Pylon", PROTOSS, DB_Helper.BUILDING, 0, 100, 0, 25,"","","","","","","");
            insertObject("Robotics Bay", PROTOSS, DB_Helper.BUILDING, 0, 200, 200, 65,"","","","","","","");
            insertObject("Robotics Facility", PROTOSS, DB_Helper.BUILDING, 0, 200, 100, 65,"","","","","","","");
            insertObject("Stargate", PROTOSS, DB_Helper.BUILDING, 0, 150, 150, 60,"","","","","","","");
            insertObject("Templar Archives", PROTOSS, DB_Helper.BUILDING, 0, 150, 200, 50,"","","","","","","");
            insertObject("Twilight Council", PROTOSS, DB_Helper.BUILDING, 0, 150, 100, 50,"","","","","","","");
            insertObject("Warp Gate", PROTOSS, DB_Helper.BUILDING, 0, 0, 0, 10,"","","","","","","");
            #endregion

            #region Protoss Upgrades
            // Protoss upgrades
            insertObject("Level 1", PROTOSS, DB_Helper.UPGRADE, 0, 0, 0, 0,"","","","","","","");
            #endregion
            #endregion

            #region Terran
            // Terran Units
            string TERRAN = "Terran";
            #region Terran Units
            insertObject("SCV", TERRAN, DB_Helper.UNIT, 1, 50, 0, 17, terran_unit_path + "Unofficial/scv.jpg", terran_unit_path + "", protoss_units_path + "", zerg_unit_path + "", terran_unit_path + "reaper.png", protoss_units_path + "dark_templar.png", zerg_unit_path + "baneling.png");
      //      insertObject("Mule", TERRAN, DB_Helper.UNIT, 0, 0, 0, 0, terran_unit_path + "mule.png", terran_unit_path + "", protoss_units_path + "", zerg_unit_path + "", terran_unit_path + "", protoss_units_path + "", zerg_unit_path + "");
            insertObject("Marine", TERRAN, DB_Helper.UNIT, 1, 50, 0, 25, terran_unit_path + "Unofficial/marine.jpg", terran_unit_path + "marauder.png", protoss_units_path + "immortal.png", zerg_unit_path + "hydralisk.png", terran_unit_path + "siegetank.png", protoss_units_path + "colossus.png", zerg_unit_path + "baneling.png");
            insertObject("Marauder", TERRAN, DB_Helper.UNIT, 2, 100, 25, 30, terran_unit_path + "Unofficial/marauder.jpg", terran_unit_path + "thor.png", protoss_units_path + "stalker.png", zerg_unit_path + "roach.png", terran_unit_path + "marine.png", protoss_units_path + "zealot.png", zerg_unit_path + "zergling.png");
            insertObject("Reaper", TERRAN, DB_Helper.UNIT, 1, 50, 50, 45, terran_unit_path + "Unofficial/reaper.jpg", terran_unit_path + "scv.png", protoss_units_path + "probe.png", zerg_unit_path + "drone.png", terran_unit_path + "marauder.png", protoss_units_path + "stalker.png", zerg_unit_path + "roach.png");
            insertObject("Ghost", TERRAN, DB_Helper.UNIT, 2, 200, 100, 40, terran_unit_path + "Unofficial/ghost.jpg", terran_unit_path + "raven.png", protoss_units_path + "high_templar.png", zerg_unit_path + "infestor.png", terran_unit_path + "marauder.png", protoss_units_path + "stalker.png", zerg_unit_path + "zergling.png");
            insertObject("Hellion", TERRAN, DB_Helper.UNIT, 2, 100, 0, 30, terran_unit_path + "Unofficial/hellion.jpg", terran_unit_path + "marine.png", protoss_units_path + "zealot.png", zerg_unit_path + "zergling.png", terran_unit_path + "marauder.png", protoss_units_path + "stalker.png", zerg_unit_path + "roach.png");
            insertObject("Siege Tank", TERRAN, DB_Helper.UNIT, 3, 150, 125, 45, terran_unit_path + "Unofficial/siege_tank.jpg", terran_unit_path + "marine.png", protoss_units_path + "stalker.png", zerg_unit_path + "hydralisk.png", terran_unit_path + "banshee.png", protoss_units_path + "immortal.png", zerg_unit_path + "mutalisk.png");
            insertObject("Thor", TERRAN, DB_Helper.UNIT, 6, 300, 200, 60, terran_unit_path + "Unofficial/thor.jpg", terran_unit_path + "marine.png", protoss_units_path + "stalker.png", zerg_unit_path + "mutalisk.png", terran_unit_path + "marauder.png", protoss_units_path + "immortal.png", zerg_unit_path + "zergling.png");
            insertObject("Viking", TERRAN, DB_Helper.UNIT, 2, 150, 75, 42, terran_unit_path + "Unofficial/viking.jpg", terran_unit_path + "battlecruiser.png", protoss_units_path + "void_ray.png", zerg_unit_path + "corruptor.png", terran_unit_path + "marine.png", protoss_units_path + "stalker.png", zerg_unit_path + "mutalisk.png");
            insertObject("Medivac", TERRAN, DB_Helper.UNIT, 2, 100, 100, 42, terran_unit_path + "Unofficial/medivac.jpg", terran_unit_path + "", protoss_units_path + "", zerg_unit_path + "", terran_unit_path + "viking.png", protoss_units_path + "phoenix.png", zerg_unit_path + "corruptor.png");
            insertObject("Raven", TERRAN, DB_Helper.UNIT, 2, 100, 200, 60, terran_unit_path + "Unofficial/raven.jpg", terran_unit_path + "banshee.png", protoss_units_path + "dark_templar.png", zerg_unit_path + "roach.png", terran_unit_path + "ghost.png", protoss_units_path + "phoenix.png", zerg_unit_path + "corruptor.png");
            insertObject("Banshee", TERRAN, DB_Helper.UNIT, 3, 150, 100, 60, terran_unit_path + "Unofficial/banshee.jpg", terran_unit_path + "siegetank.png", protoss_units_path + "colossus.png", zerg_unit_path + "ultralisk.png", terran_unit_path + "viking.png", protoss_units_path + "phoenix.png", zerg_unit_path + "hydralisk.png");
            insertObject("Battlecruiser", TERRAN, DB_Helper.UNIT, 6, 400, 300, 90, terran_unit_path + "Unofficial/battlecruiser.jpg", terran_unit_path + "thor.png", protoss_units_path + "carrier.png", zerg_unit_path + "mutalisk.png", terran_unit_path + "viking.png", protoss_units_path + "void_ray.png", zerg_unit_path + "corruptor.png");
            #endregion


            #region Terran Buildings
            // Terran buildings
            // need data
            // http://sc2armory.com/game/terran/units

            insertObject("Armory", TERRAN, DB_Helper.BUILDING, 0, 150, 100, 65,"","","","","","","");
            insertObject("Auto-turrent", TERRAN, DB_Helper.BUILDING, 0, 0, 0, 0,"","","","","","","");
            insertObject("Barracks", TERRAN, DB_Helper.BUILDING, 0, 150, 0, 65,"","","","","","","");
            insertObject("Bunker", TERRAN, DB_Helper.BUILDING, 0, 100, 0, 40,"","","","","","","");
            insertObject("Command Center", TERRAN, DB_Helper.BUILDING, 0, 400, 0, 100,"","","","","","","");
            insertObject("Engineering Bay", TERRAN, DB_Helper.BUILDING, 0, 125, 0, 035,"","","","","","","");
            insertObject("Factory", TERRAN, DB_Helper.BUILDING, 0, 150, 100, 60,"","","","","","","");
            insertObject("Fusion Core", TERRAN, DB_Helper.BUILDING, 0, 150, 150, 65,"","","","","","","");
            insertObject("Ghost Academy", TERRAN, DB_Helper.BUILDING, 0, 150, 50, 40,"","","","","","","");
            insertObject("Missile Turret", TERRAN, DB_Helper.BUILDING, 0, 100, 0, 25,"","","","","","","");
            insertObject("Orbital Command", TERRAN, DB_Helper.BUILDING, 0, 150, 0, 35,"","","","","","","");
            insertObject("Planetary Fortress", TERRAN, DB_Helper.BUILDING, 0, 150, 150, 50,"","","","","","","");
            insertObject("Point Defernse Drone", TERRAN, DB_Helper.BUILDING, 0, 0, 0, 0,"","","","","","","");
            insertObject("Reactor", TERRAN, DB_Helper.BUILDING, 0, 50, 50, 50,"","","","","","","");
            insertObject("Refinery", TERRAN, DB_Helper.BUILDING, 0, 75, 0, 30,"","","","","","","");
            insertObject("Sensor Tower", TERRAN, DB_Helper.BUILDING, 0, 125, 100, 25,"","","","","","","");
            insertObject("Starport", TERRAN, DB_Helper.BUILDING, 0, 150, 100, 50,"","","","","","","");
            insertObject("Supply Depot", TERRAN, DB_Helper.BUILDING, 0, 100, 0, 30,"","","","","","","");
            insertObject("Tech Lab", TERRAN, DB_Helper.BUILDING, 0, 50, 25, 25,"","","","","","","");
            #endregion

            #region Terran Upgrades
            // Terran upgrades

            #region Engineering Bay

            #endregion

            #region Armory
            insertObject("Vehicle Weapons Level 1", TERRAN, DB_Helper.UPGRADE, 0, 100, 100, 160,"","","","","","","");
            insertObject("Vehicle Weapons Level 2", TERRAN, DB_Helper.UPGRADE, 0, 175, 175, 190,"","","","","","","");
            insertObject("Vehicle Weapons Level 3", TERRAN, DB_Helper.UPGRADE, 0, 250, 250, 220,"","","","","","","");

            insertObject("Vehicle Plating Level 1", TERRAN, DB_Helper.UPGRADE, 0, 100, 100, 160,"","","","","","","");
            insertObject("Vehicle Plating Level 2", TERRAN, DB_Helper.UPGRADE, 0, 175, 175, 190,"","","","","","","");
            insertObject("Vehicle Plating Level 3", TERRAN, DB_Helper.UPGRADE, 0, 250, 250, 220,"","","","","","","");

            insertObject("Ship Weapons Level 1", TERRAN, DB_Helper.UPGRADE, 0, 100, 100, 160,"","","","","","","");
            insertObject("Ship Weapons Level 2", TERRAN, DB_Helper.UPGRADE, 0, 175, 175, 190,"","","","","","","");
            insertObject("Ship Weapons Level 3", TERRAN, DB_Helper.UPGRADE, 0, 250, 250, 220,"","","","","","","");

            insertObject("Ship Plating Level 1", TERRAN, DB_Helper.UPGRADE, 0, 150, 150, 160,"","","","","","","");
            insertObject("Ship Plating Level 2", TERRAN, DB_Helper.UPGRADE, 0, 225, 225, 190,"","","","","","","");
            insertObject("Ship Plating Level 3", TERRAN, DB_Helper.UPGRADE, 0, 300, 300, 220,"","","","","","","");

            #endregion
            

            #endregion


            #endregion
            
        }

    }
}

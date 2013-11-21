using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    //DropCreateDatabaseIfModelChanges, DropCreateDatabaseAlways
    class DbaseInitializer : DropCreateDatabaseIfModelChanges<Dbase>
    {
        protected override void Seed(Dbase context){
            //IList<Area> areas = new List<Area>();
            //IList<DataCategory> categories = new List<DataCategory>();
            //IList<DataType> dataTypes = new List<DataType>();

            //areas.Add(new Area() { name = "luzon"});
            //areas.Add(new Area() { name = "mindanao" });
            //areas.Add(new Area() { name = "visayas" });

            //categories.Add(new DataCategory() {  name = "psa"});
            //categories.Add(new DataCategory() { name = "demand" });

            //dataTypes.Add(new DataType() { name = "kw" });
            //dataTypes.Add(new DataType() {name = "mwh" });

            //foreach (Area area in areas)
            //{
            //    context.areas.Add(area);
            //}

            //foreach(DataCategory category in categories){
            //    context.dataCategories.Add(category);
            //}

            //foreach(DataType dataType in dataTypes){
            //    context.dataTypes.Add(dataType);
            //}

            base.Seed(context);
        }
    }
}

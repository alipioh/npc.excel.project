using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace com.npc.desktop.com.npc.desktop.entities
{
    //DropCreateDatabaseIfModelChanges, DropCreateDatabaseAlways
    class DbaseInitializer : DropCreateDatabaseIfModelChanges<Dbase>
    {
        protected override void Seed(Dbase context){
            IList<Area> areas = new List<Area>();
            IList<Regions> regions = new List<Regions>();

            areas.Add(new Area() { name = "luzon"});
            areas.Add(new Area() { name = "mindanao" });
            areas.Add(new Area() { name = "visayas" });

            regions.Add(new Regions() { name = "Region 1", area = areas[0] });
            regions.Add(new Regions() { name = "Region 2", area = areas[0] });

            foreach (Regions area in regions)
            {
                context.regions.Add(area);
            }

            base.Seed(context);
        }
    }
}

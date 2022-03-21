using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_demo_essentials.Demo
{
    class DemoReorder
    {
        private List<string> _maps = new List<string>();

        public DemoReorder(string order)
        {
            foreach (string line in File.ReadAllLines(order))
            {
                if (!_maps.Contains(line.Trim()))
                    _maps.Add(line.Trim().ToLower());
            }
        }

        public List<DemoFile> Sort(List<DemoFile> files)
        {
            return files
                .OrderBy(p => _maps.IndexOf(p.MapName.ToLower()))
                .ThenBy(x => x.Index)
                .ThenBy(x => x.Name)
                .ToList();
        }

        public List<MapDemoSegment> SortMaps(List<MapDemoSegment> maps)
        {
            return maps
                .OrderBy(p => _maps.IndexOf(p.Map.ToLower()))
                .ToList();
        }
    }
}

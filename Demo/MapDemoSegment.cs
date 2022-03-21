using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_demo_essentials.Demo
{
    class MapDemoSegment
    {
        public List<DemoFile> Demos = new List<DemoFile>();
        public string Map = "";
        public long TotalTicks = -1;
        public List<string> Players = new List<string>();

        public MapDemoSegment(List<DemoFile> files)
        {
            if (files.Count == 0)
                return;

            files.ToList().ForEach(x => Demos.Add(x));

            TotalTicks = Demos.Sum(x => x.AdjustedTicks);

            Demos.ForEach(x => Players.Add(x.PlayerName));
            Players = Players.Distinct().ToList();

            Map = files.First().MapName;
        }

        public void Add(DemoFile file)
        {
            if (Demos.Any(x => x.FilePath == file.FilePath) 
                || (Map != "" && file.MapName != Map))
                return;

            if (!Players.Contains(file.PlayerName))
                Players.Add(file.PlayerName);

            TotalTicks += file.AdjustedTicks;
        }

        public override string ToString()
        {
            return $"{Map} [{Demos.Count} demos]";
        }
    }
}

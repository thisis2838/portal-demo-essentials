using portal_demo_essentials.Demo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace portal_demo_essentials.Forms.Components
{
    public partial class RunListForm : UserControl
    {
        private long _totalTicks = 0;
        public long TotalTicks
        {
            get
            {
                return _totalTicks;
            }
        }
        public EventHandler<CommonEventArgs> SelectedCell;
        public string FilePath { get; private set; } = "";
        public int DemoCount => _demos.Count;

        private List<DemoFile> _demos = new List<DemoFile>();
        private List<MapDemoSegment> _maps = new List<MapDemoSegment>();
        private bool _autoSelectLast = false;

        public RunListForm(bool autoSelectLast = false)
        {
            InitializeComponent();

            _autoSelectLast = autoSelectLast;

            foreach (DataGridViewColumn column in dgvDemos.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            foreach (DataGridViewColumn column in dgvMaps.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvDemos.SelectionChanged += DgvDemos_SelectionChanged;
            dgvMaps.SelectionChanged += DgvMaps_SelectionChanged;
        }

        private void DgvMaps_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMaps.SelectedCells.Count == 0)
                return;

            if (dgvMaps.SelectedCells[0].RowIndex == 0)
            {
                SelectedTotals();
                return;
            }

            MapDemoSegment sel = _maps[dgvMaps.SelectedCells[0].RowIndex - 1];

            SelectedCell?.Invoke(null, new CommonEventArgs(
                ("file_path", FilePath),
                ("map_name", $"{sel.Map}"),
                ("player_name", $"{string.Join(", ", sel.Players)}"),
                ("time", sel.TotalTicks)
                ));
        }

        private void DgvDemos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDemos.SelectedCells.Count == 0)
                return;

            if (dgvDemos.SelectedCells[0].RowIndex == 0)
            {
                SelectedTotals();
                return;
            }

            DemoFile sel = _demos[dgvDemos.SelectedCells[0].RowIndex - 1];

            SelectedCell?.Invoke(null, new CommonEventArgs(
                ("file_path", sel.FilePath),
                ("map_name", sel.MapName),
                ("player_name", sel.PlayerName),
                ("time", sel.AdjustedTicks)
                ));
        }

        private void SelectedTotals()
        {
            SelectedCell?.Invoke(null, new CommonEventArgs(
                ("file_path", FilePath),
                ("map_name", $"{_maps.Count()} map(s)"),
                ("player_name", $"{_demos.ConvertAll(x => x.PlayerName).Distinct().Count()} player(s)"),
                ("time", TotalTicks)
                ));
        }

        public void Reset()
        {
            _demos.Clear();
            _maps.Clear();

            _totalTicks = 0;
            PopulateDemos(_demos.ToArray());

            Refresh();
        }

        public void Refresh()
        {
            _maps.Clear();
            _demos.ForEach(x => x.Refresh());
            _demos.GroupBy(x => x.MapName).Select(x => x.ToList()).ToList().ForEach(x => _maps.Add(new MapDemoSegment(x)));
            if (DemoCount > 1)
                _totalTicks = _demos.Sum(x => x.AdjustedTicks);
            else _totalTicks = _demos.FirstOrDefault()?.AdjustedTicks ?? 0;
        }

        private void Init(List<DemoFile> files, bool forceReset = true)
        {
            if (forceReset)
                Reset();

            files = files.Where(x => !_demos.Any(y => y.FilePath == x.FilePath)).ToList();
            files.ForEach(x =>
            {
                _demos.Add(x);
            });

            Refresh();

            if (File.Exists(Program.FormsSettingsAbout.MapOrderFile))
            {
                var order = new DemoReorder(Program.FormsSettingsAbout.MapOrderFile);
                _demos = order.Sort(_demos);
                _maps = order.SortMaps(_maps);
            }

            PopulateDemos(_demos.ToArray());
        }

        public void Init(string[] files, bool forceReset = true)
        {
            List<DemoFile> demos = new List<DemoFile>();

            if (forceReset)
                Reset();

            foreach (var file in files)
            {
                try
                {
                    if (_demos.Any(x => x.FilePath == file))
                        continue;
                        
                    var demo = new DemoFile(file);
                    demos.Add(demo);
                } 
                catch { continue; }

            }

            Init(demos, forceReset);
        }

        public void Init(string filePath, bool forceReset = true)
        {
            filePath = Path.GetFullPath(filePath);

            if (File.Exists(filePath))
                filePath = Path.GetDirectoryName(filePath);

            List<string> files = new List<string>();
            if (FilePath != filePath || forceReset)
                _demos.Clear();

            FilePath = filePath;
            files = Directory.EnumerateFiles(filePath, "*.dem").ToList();

            Init(files.ToArray(), FilePath != filePath || forceReset);
        }

        private void PopulateDemos(params DemoFile[] files)
        {
            dgvDemos.Rows.Clear(); 
            dgvDemos.Rows.Add($"-- TOTAL -- {files.Count()} demo(s)", $"{_maps.Count} map(s)", TotalTicks.ToString(), Utils.GetTimeString(TotalTicks));

            files.ToList().ForEach(x => 
            {
                dgvDemos.Rows.Add(x.Name, x.MapName, x.AdjustedTicks.ToString(), Utils.GetTimeString(x.AdjustedTicks));
            });

            if (_autoSelectLast && dgvDemos.Rows.Count > 0)
                dgvDemos.FirstDisplayedScrollingRowIndex = dgvDemos.RowCount - 1;

            PopulateMaps();
        }

        private void PopulateMaps()
        {
            dgvMaps.Rows.Clear();
            dgvMaps.Rows.Add($"-- TOTAL -- {_maps.Count()} map(s)", TotalTicks.ToString(), Utils.GetTimeString(TotalTicks));

            _maps.ToList().ForEach(x =>
            {
                dgvMaps.Rows.Add(x.Map, x.TotalTicks.ToString(), Utils.GetTimeString(x.TotalTicks));
            });

            if (_autoSelectLast && dgvMaps.Rows.Count > 0)
                dgvMaps.FirstDisplayedScrollingRowIndex = dgvMaps.RowCount - 1;
        }
    }
}

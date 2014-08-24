using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using Graph = System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.DataVisualization.Charting;
using ExcelLibrary.Office.Excel;
namespace ESPA
{

    public partial class Form1 : Form
    {
        Dictionary<double, double> lineChartData = new Dictionary<double, double>();
        Graph.Chart chart;
        public Form1()
        {
            InitializeComponent();

        }
        IList<areaCls> allData = new List<areaCls>();
        string mainDir = "";
        string savedir = "";
        private void btnLoad_Click(object sender, EventArgs e)
        {

            label1.Text = "Data Loading...";
            int size = -1;
            DialogResult result = folderBrowserDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string path = folderBrowserDialog1.SelectedPath;
                mainDir = path;
                string inunpath = path + "\\WL\\";
                foreach (string s in Directory.GetDirectories(inunpath))
                {
                    cmbYear.Items.Add(s.Remove(0, inunpath.Length));
                }
                string file = path + "\\area.xlsx";
                try
                {
                    string text = File.ReadAllText(file);
                    var fileName = string.Format(file);
                    var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; data source={0}; Extended Properties=Excel 12.0;", fileName);
                    var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                    var ds = new DataSet();
                    adapter.Fill(ds, "area");
                    DataTable data = ds.Tables["area"];
                    //dataGridView1.DataSource = data;
                    //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                    var enn = ds.Tables["area"].AsEnumerable();
                    allData = enn.Where(x => x.Field<object>(0).ToString() != "FID").Select(x => new areaCls
                    {
                        FID = x.Field<Double?>(0),
                        UNIONCOD01 = x.Field<Double?>(3),
                        DIVNAME = x.Field<String>(4),
                        DISTNAME = x.Field<String>(6),
                        THANAME = x.Field<String>(8),
                        UNINAME = x.Field<String>(10),
                        NGEOCODE = x.Field<Double?>(14),
                        Pol_height = x.Field<Double?>(17),
                        Pol_nam = x.Field<String>(18),
                        LinkID = x.Field<Double?>(33),
                        netCDF_IDs = x.Field<String>(179),
                        DDIEM_dist = x.Field<Double?>(180),
                        DDIEM_than = x.Field<Double?>(181),
                        area_cal = x.Field<Double?>(183),
                        DDIEM_unio = x.Field<Double?>(182),
                        obs_point = x.Field<String>(184)
                    }).ToList();

                    //label1.Text = allData[0].FID.ToString();
                    label1.Text = "Data Loaded";
                    cmbThana.Items.Clear();
                    cmbUnion.Items.Clear();
                    cmbUnionID.Items.Clear();
                    cmbDist.Items.Clear();
                    cmbDist.Items.Add("All");
                    IList<String> dists = (from dbo in allData orderby dbo.DISTNAME ascending select dbo.DISTNAME).Distinct().ToList();
                    foreach (String dist in dists)
                        cmbDist.Items.Add(dist);
                    IList<String> thanas = (from dbo in allData orderby dbo.THANAME ascending select dbo.THANAME).Distinct().ToList();
                    foreach (String dist in thanas)
                        cmbThana.Items.Add(dist);
                    foreach (areaCls tmp in allData)
                    {
                        cmbUnion.Items.Add(tmp.UNINAME);
                        cmbUnionID.Items.Add(int.Parse(tmp.UNIONCOD01.ToString()).ToString());
                    }
                }
                catch (IOException)
                {

                }
            }
            //Console.WriteLine(size); // <-- Shows file size in debugging mode.
            //Console.WriteLine(result); // <-- For debugging use.
        }
        Dictionary<DateTime, double> obs = new Dictionary<DateTime, double>();
        private void btnGraph_Click(object sender, EventArgs e)
        {
            label1.Text = "Computing...";
            if (cmbYear.SelectedItem == null)
            {
                label1.Text = "Please select a Year";
            }
            else
            {
                string inunmapPath = mainDir + "\\Inundation\\" + cmbYear.SelectedItem.ToString() + "\\";
                if (allData.Where(x => x.UNINAME == cmbUnion.SelectedItem.ToString()).FirstOrDefault() == null)
                {
                    label1.Text = "";
                }
                else
                {
                    areaCls row = allData.Where(x => x.UNINAME == cmbUnion.SelectedItem.ToString()).FirstOrDefault();
                    if (row != null)
                    {
                        lineChartData = new Dictionary<double, double>();
                        try
                        {
                            List<DateTime> allDates = new List<DateTime>();
                            IList<areaCls> dateData = new List<areaCls>();
                            Dictionary<DateTime, double> example = new Dictionary<DateTime, double>();
                            foreach (string s in Directory.GetFiles(inunmapPath, "*.xlsx"))
                            {
                                allDates.Add(DateTime.Parse(Path.GetFileNameWithoutExtension(s)));
                                string text = File.ReadAllText(s);
                                var fileName = string.Format(s);
                                var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; data source={0}; Extended Properties=Excel 12.0;", fileName);

                                var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                                var ds = new DataSet();
                                adapter.Fill(ds, "area");
                                DataTable data = ds.Tables["area"];
                                var enn = ds.Tables["area"].AsEnumerable();
                                if (enn.Where(x => x.Field<String>(10) == cmbUnion.SelectedItem.ToString()).ToList().Count == 0)
                                    continue;
                                areaCls tmpData = enn.Where(x => x.Field<object>(0).ToString() != "FID"
                                                            && x.Field<String>(10) == cmbUnion.SelectedItem.ToString()).Select(x => new areaCls
                                {
                                    FID = x.Field<Double?>(0),
                                    UNIONCOD01 = x.Field<Double?>(3),
                                    DIVNAME = x.Field<String>(4),
                                    DISTNAME = x.Field<String>(6),
                                    THANAME = x.Field<String>(8),
                                    UNINAME = x.Field<String>(10),
                                    NGEOCODE = x.Field<Double?>(14),
                                    Pol_height = x.Field<Double?>(17),
                                    Pol_nam = x.Field<String>(18),
                                    LinkID = x.Field<Double?>(33),
                                    netCDF_IDs = x.Field<String>(179),
                                    DDIEM_dist = x.Field<Double?>(180),
                                    DDIEM_than = x.Field<Double?>(181),
                                    area_cal = x.Field<Double?>(183),
                                    DDIEM_unio = x.Field<Double?>(182)
                                }).First();
                                string tmp = Path.GetFileNameWithoutExtension(s);
                                example.Add(DateTime.Parse(tmp), Convert.ToDouble(tmpData.area_cal) / Convert.ToDouble(row.area_cal));
                                dateData.Add(tmpData);
                            }
                            var listY = example.Keys.ToList();
                            listY.Sort();


                            string wlPath = mainDir + "\\WL\\" + cmbYear.SelectedItem.ToString() + "\\" + row.obs_point + ".csv";
                            var reader = new StreamReader(File.OpenRead(wlPath));
                            obs = new Dictionary<DateTime, double>();
                            
                            int i = 0;
                            while (!reader.EndOfStream)
                            {

                                string line = reader.ReadLine();
                                i++;
                                if (i == 1) continue;

                                string[] values = line.Split(',');
                                DateTime tmpDate = DateTime.Parse(values[0]).Date;
                                if (allDates.Contains(tmpDate))
                                {
                                    if (!obs.ContainsKey(tmpDate))
                                        obs.Add(tmpDate, double.Parse(values[1]));
                                    else
                                    {
                                        if (obs[tmpDate] < double.Parse(values[1]))
                                            obs[tmpDate] = double.Parse(values[1]);
                                    }
                                }
                            }

                            foreach (var key in listY)
                            {
                                lineChartData.Add(obs[key], example[key]);
                            }
                            lblerr.Text = "";

                        }
                        catch (Exception ex)
                        {
                            lblerr.Text = " " + ex.Message;
                            label1.Text = "";
                        }


                        /**
                         * chart start
                         * 
                         * */
                        if (lineChartData.Keys.Count > 1)
                        {
                            var list = lineChartData.Keys.ToList();
                            list.Sort();
                            int MaxX = Convert.ToInt32(lineChartData.Keys.Max() + 1.46);
                            // Create new Graph
                            //chart1 = Graph.Chart();
                            chart = chart1;
                            if (chart1.ChartAreas.Count != 0)
                                chart1.ChartAreas.RemoveAt(0);
                            // Add a chartarea called "draw", add axes to it and color the area black
                            chart.ChartAreas.Add("draw");
                            chart.ChartAreas["draw"].AxisX.Minimum = Convert.ToInt32(lineChartData.Keys.Min());
                            chart.ChartAreas["draw"].AxisX.Maximum = MaxX;
                            chart.ChartAreas["draw"].AxisX.Interval = .25;
                            chart.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.Gray;
                            chart.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
                            chart.ChartAreas["draw"].AxisX.Title = "Water elevation";

                            chart.ChartAreas["draw"].AxisY.Title = "%area inundation";
                            chart.ChartAreas["draw"].AxisY.Minimum = 0;
                            chart.ChartAreas["draw"].AxisY.Maximum = 100;
                            chart.ChartAreas["draw"].AxisY.Interval = 10;
                            chart.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.Gray;
                            chart.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
                            //chart.ChartAreas["draw"].BackColor = Color.Black;
                            // Create a new function series
                            if (chart.Series[0].Name != "MyFunc")
                            {
                                
                                chart1.Series.RemoveAt(0);
                            }
                            if (chart1.Series.FirstOrDefault(x => x.Name == "MyFunc") != null) chart1.Series.Remove(chart.Series["MyFunc"]);
                            if (chart1.Series.FirstOrDefault(x => x.Name == "MyOriginalFunc") != null) chart1.Series.Remove(chart.Series["MyOriginalFunc"]);
                            chart.Series.Add("MyFunc");
                            // Set the type to line
                            chart.Series["MyFunc"].ChartType = Graph.SeriesChartType.Line;
                            // Color the line of the graph light green and give it a thickness of 3
                            chart.Series["MyFunc"].Color = Color.Red;
                            chart.Series["MyFunc"].BorderWidth = 5;
                            chart.Series.Add("MyOriginalFunc");
                            // Set the type to line
                            chart.Series["MyOriginalFunc"].ChartType = Graph.SeriesChartType.Point;
                            //This function cannot include zero, and we walk through it in steps of 0.1 to add coordinates to our series
                            //for (double x = 0.1; x < MaxX; x += 0.1)
                            //{
                            //    chart.Series["MyFunc"].Points.AddXY(x, Math.Sin(x) / x);
                            //}
                            Tuple<double, double> getAB = new best_fit().getAB(lineChartData);
                            lblEquation.Text= "f = "+getAB.Item1+" + "+getAB.Item2+"x.";
                            foreach (var key in list)
                            {
                                //chart.Series["MyFunc"].Points.AddXY(key + .46, lineChartData[key] * 100);
                                chart.Series["MyFunc"].Points.AddXY(key + .46,( getAB.Item1+getAB.Item2*key) * 100);
                                //chart.Series["MyFunc"].ToolTip = (Math.Round(key + .46, 2)).ToString() + "," + (Math.Round(lineChartData[key] * 100, 2).ToString());
                                chart.Series["MyFunc"].MarkerColor = Color.Green;
                                chart.Series["MyFunc"].MarkerSize = 5;
                                chart.Series["MyFunc"].MarkerStyle = Graph.MarkerStyle.Circle;

                                chart.Series["MyOriginalFunc"].Points.AddXY(key + .46, lineChartData[key] * 100);

                                //chart.Series["MyFunc"].ToolTip = (Math.Round(key + .46, 2)).ToString() + "," + (Math.Round(lineChartData[key] * 100, 2).ToString());
                                chart.Series["MyOriginalFunc"].MarkerColor = Color.Orange;
                                chart.Series["MyOriginalFunc"].MarkerSize = 10;
                                chart.Series["MyOriginalFunc"].MarkerStyle = Graph.MarkerStyle.Diamond;
                            }
                            chart.Series["MyFunc"].LegendText = cmbUnion.SelectedItem.ToString() + " Inundation Line";
                            // Create a new legend called "MyLegend".
                            if (chart1.Legends.Count != 0)
                                chart1.Legends.RemoveAt(0);
                            chart.Legends.Add("MyLegend");
                            chart.Legends["MyLegend"].BorderColor = Color.Tomato; // I like tomato juice!
                            label1.Text = "";
                            chart.Series["MyOriginalFunc"].LegendText = "Original points";
                            cmdExport.Visible = true;
                            
                        }
                        else
                        {
                            label1.Text = "No Inundation";
                            chart = chart1;
                            if (chart1.ChartAreas.Count != 0)
                                chart1.ChartAreas.RemoveAt(0);
                            // Add a chartarea called "draw", add axes to it and color the area black
                            chart.ChartAreas.Add("draw");
                            chart.ChartAreas["draw"].AxisX.Minimum = Convert.ToInt32(0);
                            chart.ChartAreas["draw"].AxisX.Maximum = 5;
                            chart.ChartAreas["draw"].AxisX.Interval = 1;
                            chart.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.Gray;
                            chart.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;

                            chart.ChartAreas["draw"].AxisY.Minimum = 0;
                            chart.ChartAreas["draw"].AxisY.Maximum = 100;
                            chart.ChartAreas["draw"].AxisY.Interval = 10;
                            chart.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.Gray;
                            chart.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
                            //chart.ChartAreas["draw"].BackColor = Color.Black;
                            // Create a new function series
                            if (chart.Series[0].Name != "MyFunc")
                            {
                                chart1.Series.RemoveAt(0);
                            }
                            if (chart1.Series.FirstOrDefault(x => x.Name == "MyFunc") != null) chart1.Series.Remove(chart.Series["MyFunc"]);
                            if (chart1.Series.FirstOrDefault(x => x.Name == "MyOriginalFunc") != null) chart1.Series.Remove(chart.Series["MyOriginalFunc"]);
                            chart.Series.Add("MyFunc");
                            // Set the type to line
                            chart.Series["MyFunc"].ChartType = Graph.SeriesChartType.Line;
                            chart.Series["MyFunc"].LegendText = cmbUnion.SelectedItem.ToString() + " Inundation Line";
                            if (chart1.Legends.Count != 0)
                                chart1.Legends.RemoveAt(0);
                            chart.Legends.Add("MyLegend");
                            chart.Legends["MyLegend"].BorderColor = Color.Tomato; // I like tomato juice!
                        }
                    }
                    else
                    {
                        lblerr.Text = "No Inundation.";
                    }
                }
                //Controls.Add(this.chart); 
            }
        }

        private void cmbDistChanged(object sender, EventArgs e)
        {
            cmbThana.Items.Clear();
            cmbUnion.Items.Clear();
            cmbUnionID.Items.Clear();
            IList<areaCls> rows = new List<areaCls>();
            rows = (cmbDist.SelectedItem.ToString() != "All") ? allData.Where(x => x.DISTNAME == cmbDist.SelectedItem.ToString()).
                GroupBy(x => x.THANAME).Select(group => group.First()).ToList() : allData;

            foreach (areaCls row in rows)
            {
                cmbThana.Items.Add(row.THANAME);
                cmbUnion.Items.Add(row.UNINAME);
                cmbUnionID.Items.Add(Convert.ToInt32(row.UNIONCOD01).ToString());
            }
        }
        private void cmbUnion_changed(object sender, EventArgs e)
        {
            //cmbUnionID.SelectedText = "";
            areaCls row = allData.Where(x => x.UNINAME == cmbUnion.SelectedItem.ToString()).FirstOrDefault();
            cmbUnionID.SelectedIndex = cmbUnionID.Items.IndexOf(Convert.ToInt32(row.UNIONCOD01).ToString());
        }
        private void cmbUnionID_changed(object sender, EventArgs e)
        {
            //cmbUnionID.SelectedText = "";
            areaCls row = allData.Where(x => x.UNIONCOD01 ==Convert.ToInt32(cmbUnionID.SelectedItem)).FirstOrDefault();
            cmbUnion.SelectedIndex = cmbUnion.Items.IndexOf(row.UNINAME);
        }
        private void cmbThanaChanged(object sender, EventArgs e)
        {
            cmbUnion.Items.Clear();
            cmbUnionID.Items.Clear();
            IList<areaCls> rows = new List<areaCls>();
            rows = (cmbThana.SelectedItem.ToString() != "") ? allData.Where(x => x.THANAME == cmbThana.SelectedItem.ToString())
                .GroupBy(x => x.UNINAME).Select(group => group.First()).ToList() :
                new List<areaCls>(rows.Concat(allData));

            foreach (areaCls row in rows)
            {
                cmbUnion.Items.Add(row.UNINAME);
                cmbUnionID.Items.Add(Convert.ToInt32(row.UNIONCOD01).ToString());
            }
        }

        private void cmdExport_click(object sender, EventArgs e)
        {
            if (obs.Count > 0)
            {
                if (savedir == "")
                {
                    DialogResult result = folderBrowserDialog1.ShowDialog(); // Show the dialog.
                    if (result == DialogResult.OK) // Test result.
                        savedir = folderBrowserDialog1.SelectedPath;

                }
                Tuple<double, double> getAB = new best_fit().getAB(lineChartData);
                //chart1.SaveImage(savedir+"\\"+cmbUnion.SelectedItem.ToString() + "_" + cmbYear.SelectedItem.ToString() + "_chart.png", Graph.ChartImageFormat.Png);
                string file = savedir + "\\" + cmbUnion.SelectedItem.ToString() + "_" + cmbYear.SelectedItem.ToString() + ".xls";
                areaCls row = allData.Where(x => x.UNINAME == cmbUnion.SelectedItem.ToString()).FirstOrDefault();
                Workbook workbook = new Workbook();
                Worksheet worksheet = new Worksheet("First Sheet");
                worksheet.Cells[0, 0] = new Cell("Water elevation");
                worksheet.Cells[0, 1] = new Cell("Polder name");
                worksheet.Cells[0, 2] = new Cell("Polder elevation");
                worksheet.Cells[0, 3] = new Cell("Date(d/MM/YYYY)");
                worksheet.Cells[0, 4] = new Cell("Percent area Inundated");
                worksheet.Cells[0, 5] = new Cell("f value");
                int i = 1;
                foreach (var key in lineChartData.Keys)
                {
                    worksheet.Cells[i, 0] = new Cell(key);
                    if (i == 1)
                    {
                        worksheet.Cells[i, 1] = new Cell(row.Pol_nam.ToString());
                        worksheet.Cells[i, 2] = new Cell(row.Pol_height.ToString());
                    }
                    foreach (var datekey in obs.Keys)
                    {
                        if (obs[datekey] == key)
                            worksheet.Cells[i, 3] = new Cell(datekey.ToShortDateString());
                    }
                    worksheet.Cells[i, 4] = new Cell(lineChartData[key]*100);
                    worksheet.Cells[i, 5] = new Cell(getAB.Item1 + getAB.Item2 * key);
                    i++;
                }
                worksheet.Cells[i+1, 0] = new Cell("Equation: " +lblEquation.Text);
                //worksheet.Cells[2, 0] = new Cell(9999999);
                //worksheet.Cells[3, 3] = new Cell((decimal)3.45);
                //worksheet.Cells[2, 2] = new Cell("Text string");
                //worksheet.Cells[2, 4] = new Cell("Second string");
                //worksheet.Cells[4, 0] = new Cell(32764.5, "#,##0.00");
                //worksheet.Cells[5, 1] = new Cell(DateTime.Now, @"YYYY\-MM\-DD");
                worksheet.Cells.ColumnWidth[0, 0] = 5000; 
                worksheet.Cells.ColumnWidth[0, 1] = 5000;
                worksheet.Cells.ColumnWidth[0, 2] = 5000;
                worksheet.Cells.ColumnWidth[0, 3] = 5000;
                worksheet.Cells.ColumnWidth[0, 4] = 5000;
                worksheet.Cells.ColumnWidth[0, 5] = 5000;
                workbook.Worksheets.Add(worksheet);
                workbook.Save(file);

            }
        }
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        private void chart1_mousemove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 2 &&
                            Math.Abs(pos.Y - pointYPixel) < 2)
                            
                        {

                            tooltip.Show("X=" + Math.Round(prop.XValue, 3) + ", Y=" + Math.Round(prop.YValues[0], 3), this.chart1,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }

        }

        

    }
}
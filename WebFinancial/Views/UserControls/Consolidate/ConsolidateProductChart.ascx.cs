using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class Views_UserControls_Consolidate_Product : System.Web.UI.UserControl
{
    #region Public Properties
    public int HeigthChart
    {
        get
        {
            if (ViewState["HeigthChart"] == null)
                return 400;
            else
                return (int)ViewState["HeigthChart"];
        }
        set { ViewState["HeigthChart"] = value; }
    }
    public int WidthChart
    {
        get
        {
            if (ViewState["WidthChart"] == null)
                return 0;
            else
                return (int)ViewState["WidthChart"];
        }
        set { ViewState["WidthChart"] = value; }
    }
    public bool AllowExport
    {
        get { return (bool)ViewState["AllowExport"]; }
        set { ViewState["AllowExport"] = value; }
    }
    #endregion
    private XAxis xAxis = new XAxis();
    private DotNet.Highcharts.Options.Chart chartInitProperties = new DotNet.Highcharts.Options.Chart();
    protected void Page_InitComplete(object sender, EventArgs e)
    {
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Render_Chart();
    }

    protected void Render_Chart()
    {
        string[] dtCategories = new[] { "Checking", "Saving" };
        Data dtAvailable = new Data(new object[] { 12 });
        Data dtCurrent = new Data(new object[] { -2 });
        Data dttemp = new Data(new[] { 
            new DotNet.Highcharts.Options.Point { 
                Y = 4455,
                Sliced=true,
                Color= Color.SkyBlue,  
                Drilldown = new Drilldown { 
                    Categories=new[]{"1111","2222","1122"}, 
                    Name = "Account 1",
                    Data=new Data(new object[]{1.2,2.3,22.35})}
            },
            new DotNet.Highcharts.Options.Point { 
                Y = 7777,
                Sliced=true,
                Color= Color.SkyBlue,  
                Drilldown = new Drilldown { 
                    Categories=new[]{"3333","4444"}, 
                    Name = "Account 2",
                    Data=new Data(new object[]{33,334})}
            }
        });

        chartInitProperties = new DotNet.Highcharts.Options.Chart()
         {
             DefaultSeriesType = DotNet.Highcharts.Enums.ChartTypes.Column,
             Height = HeigthChart,
             Width = WidthChart
         };


        Exporting chartExporting = new Exporting() { Enabled = AllowExport };
        Highcharts chart = new Highcharts("chart");
        SetFormatGrid(chart);
        xAxis.Categories = dtCategories;
        chart.InitChart(chartInitProperties)
        .SetExporting(chartExporting)
        .SetLegend(new DotNet.Highcharts.Options.Legend() { Enabled = true, Shadow = true })
        .SetCredits(new Credits() { Enabled = false })
        .SetTitle(new DotNet.Highcharts.Options.Title { Text = "Consolidate Posicion", Align = HorizontalAligns.Center })
        .SetSubtitle(new Subtitle() { Text = "Detail of accounts from client." })
        .SetTooltip(new Tooltip()
        {
            Enabled = true,
            HeaderFormat = "<span style=\"font-size:13px\">{series.name}</span><table>",
            PointFormat = "<tr><td style=\"color:{series.color};padding:0\"><b>{point.name}:</b> ${point.y:.2f}</td></tr>",
            FooterFormat = "</table>",
            ValueSuffix = " Usd",
            UseHTML = true,
            HideDelay = 0,
            Shared = true
        })
        .SetPlotOptions(new PlotOptions()
        {
            Columnrange = new PlotOptionsColumnrange() { DataLabels = new PlotOptionsColumnrangeDataLabels() { Enabled = true } },
            Column = new PlotOptionsColumn()
            {
                Shadow = false,
                Cursor = Cursors.Pointer,
                Point = new PlotOptionsColumnPoint { Events = new PlotOptionsColumnPointEvents { Click = "ColumnPointClick" } },
                Animation = new Animation(new AnimationConfig { Duration = 500, Easing = EasingTypes.EaseOutBounce }),
                DataLabels = new PlotOptionsColumnDataLabels()
                {
                    Enabled = true,
                    Formatter = @"function() {return '$ '+this.point.y;}",
                    Style = "fontWeight: 'bold'"
                }
            },
            Pie = new PlotOptionsPie()
            {
                ShowInLegend = true,
                AllowPointSelect = true,
                Cursor = Cursors.Pointer,
                Point = new PlotOptionsPiePoint { Events = new PlotOptionsPiePointEvents { Click = "ColumnPointClick" } },
                Animation = new Animation(new AnimationConfig { Duration = 500, Easing = EasingTypes.EaseOutBounce }),
                DataLabels = new PlotOptionsPieDataLabels()
                {
                    Enabled = true,
                    Distance = -50,
                    Format = "<b>{point.name}</b>: {point.percentage:.2f} %",
                    Style = "fontWeight: 'bold'"
                }
            }
        })
        .SetXAxis(xAxis)
        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = String.Empty } })
        .SetSeries(new DotNet.Highcharts.Options.Series[] { new DotNet.Highcharts.Options.Series { Name = "Available", Data = dttemp } })
        .AddJavascripFunction("ColumnPointClick",
                    @"var drilldown = this.drilldown;
                              if (drilldown) { // drill down
                                setChart(drilldown.name, drilldown.categories, drilldown.data.data, drilldown.color);
                              } else { // restore
                                setChart(name, categories, data.data);
                              }")
        .AddJavascripFunction("setChart",
                    @"chart.xAxis[0].setCategories(categories);
                              chart.series[0].remove();
                              chart.addSeries({
                                 name: name,
                                 data: data,
                                 color: color || 'white'
                              });",
                    "name", "categories", "data", "color"
                )
        .AddJavascripVariable("colors", "Highcharts.getOptions().colors")
        .AddJavascripVariable("name", "'{0}'".FormatWith("demo chart"))
        .AddJavascripVariable("categories", JsonSerializer.Serialize(dtCategories))
        .AddJavascripVariable("data", JsonSerializer.Serialize(dttemp));

        ltrChart.Text = chart.ToHtmlString();
    }

    public void SetFormatGrid(Highcharts chart)
    {
        ColorConverter ccvrt = new ColorConverter();

        GlobalOptions chartOptions = new GlobalOptions()
        {
            Colors = new Color[] { 
            ((Color)ccvrt.ConvertFromString("#058DC7")),
            ((Color)ccvrt.ConvertFromString("#50B432")),
            ((Color)ccvrt.ConvertFromString("#ED561B")),
            ((Color)ccvrt.ConvertFromString("#DDDF00")),
            ((Color)ccvrt.ConvertFromString("#24CBE5")),
            ((Color)ccvrt.ConvertFromString("#64E572")),
            ((Color)ccvrt.ConvertFromString("#FF9655")),
            ((Color)ccvrt.ConvertFromString("#FFF263")),
            ((Color)ccvrt.ConvertFromString("#6AF9C4"))}
        };


        chartInitProperties.BackgroundColor = new BackColorOrGradient(new Gradient()
          {
              LinearGradient = new int[] { 0, 0, 1, 1 },
              Stops = new object[,] { { 0, Color.FromArgb(255, 255, 255) }, { 1, Color.FromArgb(240, 240, 255) } }
          });
        chartInitProperties.BorderWidth = 2;
        chartInitProperties.PlotBackgroundColor = new BackColorOrGradient(Color.FromArgb(1, 255, 255, 255));
        chartInitProperties.PlotShadow = true;
        chartInitProperties.PlotBorderWidth = 1;
        chart.SetOptions(chartOptions);

        xAxis.LineWidth = 1;
        xAxis.LineColor = ColorTranslator.FromHtml("#000");
        xAxis.TickColor = ColorTranslator.FromHtml("#000");
        xAxis.Labels = new XAxisLabels() { Style = "color:'#000'" };
    }
}
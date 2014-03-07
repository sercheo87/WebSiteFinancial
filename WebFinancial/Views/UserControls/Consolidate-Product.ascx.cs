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
    protected void Page_InitComplete(object sender, EventArgs e)
    {
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Render_Chart();
    }

    protected void Render_Chart()
    {
        Highcharts chart = new Highcharts("chart")
       .InitChart(new DotNet.Highcharts.Options.Chart()
       {
           DefaultSeriesType = DotNet.Highcharts.Enums.ChartTypes.Column
       })
       .SetLegend(new DotNet.Highcharts.Options.Legend()
       {
           Shadow = true
       })
       .SetCredits(new Credits() { Enabled = false })
       .SetTooltip(new Tooltip()
       {
           Enabled = true,
           HeaderFormat = "<span style=\"font-size:13px\">{point.key}</span><table>",
           PointFormat = "<tr><td style=\"color:{series.color};padding:0\"><b>{series.name}:</b> ${point.y:.2f}</td></tr>",
           FooterFormat = "</table>",
           ValueSuffix = " Usd",
           UseHTML = true,
           HideDelay = 0,
           Shared = true
       })
       .SetTitle(new DotNet.Highcharts.Options.Title
       {
           Text = "Consolidate Posicion"
       })
       .SetSubtitle(new Subtitle() { Text = "Detail of accounts from client." })
       .SetPlotOptions(new PlotOptions()
       {
           Columnrange = new PlotOptionsColumnrange()
           {
               Animation = new Animation(false),
               DataLabels = new PlotOptionsColumnrangeDataLabels()
               {
                   Enabled = true
               }
           },
           Column = new PlotOptionsColumn()
           {
               Animation = new Animation(new AnimationConfig { Duration = 500, Easing = EasingTypes.EaseOutBounce }),
               DataLabels = new PlotOptionsColumnDataLabels()
               {
                   Enabled = true,
                   Rotation = -90,
                   Align = DotNet.Highcharts.Enums.HorizontalAligns.Center,
                   Color = Color.White,
                   X = 4,
                   Y = 10,
                   Formatter = @"function() {return '$ '+this.point.y;}",
                   Style = "fontSize: '13px', fontFamily: 'Verdana, sans-serif', textShadow: '0 0 3px black'"
               }
           }
       })
       .SetXAxis(new XAxis
       {
           Title = null,
           StartOnTick = true,
           EndOnTick = true,
           ShowLastLabel = true,
           Categories = new[] { "Account 1", "Account 2", "Account 3" },
           Labels = new XAxisLabels()
           {
               Rotation = -45,
               Align = DotNet.Highcharts.Enums.HorizontalAligns.Right,
               Enabled = true,
               Style = "fontSize: '11px', fontFamily: 'Verdana, sans-serif'"
           }
       })
       .SetYAxis(new YAxis
       {
           Title = new YAxisTitle { Text = String.Empty }
       })
       .SetSeries(new DotNet.Highcharts.Options.Series[]{
            new DotNet.Highcharts.Options.Series {
                Name = "Available",
                Data = new Data(new object[] { 29.9, 71.5, 106.4 })
            },
            
            new DotNet.Highcharts.Options.Series {
                Name = "Current",
                Data = new Data(new object[] { 33, -52, 21.25 })
            }
        });

        ltrChart.Text = chart.ToHtmlString();
    }
}
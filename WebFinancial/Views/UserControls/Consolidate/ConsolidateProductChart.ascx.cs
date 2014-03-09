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

        Highcharts chart = new Highcharts("chart")
       .InitChart(new DotNet.Highcharts.Options.Chart() { DefaultSeriesType = DotNet.Highcharts.Enums.ChartTypes.Column })
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
       .SetXAxis(new XAxis { Categories = dtCategories })
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

    public Data demo
    {
        get
        {
            return new Data(new[] { 
            new DotNet.Highcharts.Options.Point { 
                Y = 10,
                Name="Fruits",
                Color= Color.SkyBlue,  
                Drilldown = new Drilldown { 
                    Categories=new[]{"1111","2222","1122"}, 
                    Name = "fruits",
                    Data=new Data(new object[]{1.2,2.3,22.35})
                }
            }
            });
        }
    }
}
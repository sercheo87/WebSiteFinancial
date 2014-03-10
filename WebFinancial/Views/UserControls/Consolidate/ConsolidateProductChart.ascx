<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConsolidateProductChart.ascx.cs" Inherits="Views_UserControls_Consolidate_Product" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<script type="text/javascript">
    var _heigth = <%=HeigthChart %>,
     _width = <%=WidthChart.ToString() %>,
     _allowExport = <%=AllowExport %>,
     _titleXAxis='<%=TitleXAxis %>',
     _titleYAxis='<%=TitleYAxis %>',
     _titleChart='<%=TitleChart %>',
     _subTitleChart='<%=SubTitleChart %>';
    var chart;
    Sys.Application.add_load(function () {
        $(document).ready(function () {
            chart = new Highcharts.Chart({
                chart: {
                    renderTo:'demo',
                    type: 'column',
                    height: _heigth,
                    width: _width
                },
                title: {
                    text: _titleChart
                },
                subtitle: {
                    text: _subTitleChart
                },
                credits: {
                    enabled: false
                },
                xAxis: {
                    title: {
                        text: _titleXAxis
                    },
                    type: 'category'
                },
                yAxis: {
                    title: {
                        text: _titleYAxis
                    }
                },
                legend: {
                    enabled: false
                },
                plotOptions: {
                    series: {
                        borderWidth: 0,
                        dataLabels: {
                            enabled: true,
                            format: 'USD {point.y:.1f}'
                        }
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
                    pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>USD {point.y:.2f}</b> of total<br/>'
                },
                series: [{
                    name: 'Brands',
                    colorByPoint: true,
                    data: <%=Series1 %>
                    }],
                drilldown: {
                    series: <%=DrillDownSeries %>
                    }
            });
        });
    });
</script>
<div id="demo" style="width: 100%; height: 400px;"></div>
<asp:Panel runat="server" ID="pnChart">
    <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
</asp:Panel>

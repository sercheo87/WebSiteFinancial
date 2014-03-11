<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConsolidateProductChart.ascx.cs" Inherits="Views_UserControls_Consolidate_Product" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<script type="text/javascript">
    Highcharts.setOptions({
        lang: {
            decimalPoint: '<%=GetSeparatorDecimal %>',
            thousandsSep: '<%=GetSeparatorGroup %>'
        }
    });
    var _heigth = '<%=HeigthChart %>',
        _width = '<%=WidthChart %>',
        _allowExport = '<%=AllowExport %>',
        _titleXAxis = '<%=TitleXAxis %>',
        _titleYAxis = '<%=TitleYAxis %>',
        _titleChart = '<%=TitleChart %>',
        _seriesName = '<%=SeriesName %>',
        _subTitleChart = '<%=SubTitleChart %>',
        _series = JSON.parse('<%=dtSeries %>'),
        _series_drilldown = JSON.parse('<%=dtDrillDownSeries %>'),
        chart;
    Sys.Application.add_load(function () {
        chart = new Highcharts.Chart({
            chart: {
                renderTo: '<%=dvChart.ClientID%>',
                type: '<%=TypeChart%>',
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
                        format: 'USD $ {point.y:,.2f}'
                    }
                }
            },
            tooltip: {
                headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
                pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>USD {point.y:,.2f}</b><br/>'
            },
            series: [{
                name: _seriesName,
                colorByPoint: true,
                data: _series
            }],
            drilldown: {
                series: _series_drilldown
            }
        });
    });
</script>
<asp:Panel runat="server" ID="dvChart" ClientIDMode="AutoID"></asp:Panel>

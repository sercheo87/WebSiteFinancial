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
        _xAxisType = '<%=TypeXAxis%>',
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
                type: _xAxisType,
                //tickInterval: 7 * 24 * 3600 * 1000, // one week
                tickWidth: 0,
                gridLineWidth: 1
            },
            yAxis: {
                title: {
                    text: _titleYAxis
                },
                labels: {
                    align: 'left',
                    x: 3,
                    y: 16,
                    formatter: function () {
                        return Highcharts.numberFormat(this.value, 0);
                    }
                },
                showFirstLabel: false
            },
            legend: {
                enabled: false
            },
            plotOptions: {
                series: {
                    cursor: 'pointer', point: {
                        events: {
                            click: function () {
                                hs.htmlExpand(null, {
                                    pageOrigin: {
                                        x: this.pageX,
                                        y: this.pageY
                                    },
                                    headingText: this.series.name,
                                    maincontentText: Highcharts.dateFormat('%A, %b %e, %Y', this.x) + ':<br/> ' + this.y + ' visits',
                                    width: 200
                                });
                            }
                        }
                    },
                    borderWidth: 0,
                    dataLabels: {
                        enabled: true,
                        format: 'USD $ {point.y:,.2f}'
                    },
                    marker: {
                        lineWidth: 1
                    }
                }
            },
            tooltip: {
                shared: true,
                crosshairs: true,
                headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
                pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>USD {point.y:,.2f}</b><br/>'
            },
            series: [{
                name: _seriesName,
                colorByPoint: true,
                data: _series,
                lineWidth: 4,
                marker: {
                    radius: 4
                }
            }],
            drilldown: {
                series: _series_drilldown
            }
        });
    });
</script>
<asp:Panel runat="server" ID="dvChart" ClientIDMode="AutoID"></asp:Panel>

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Consolidate-Product.ascx.cs" Inherits="Views_UserControls_Consolidate_Product" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Literal ID="ltrChart" runat="server"></asp:Literal>

<div id="container1"></div>
<div id="container2"></div>
<script type="text/javascript">
    // Internationalization
    Highcharts.setOptions({
        lang: {
            drillUpText: '◁ Back to {series.name}'
        }
    });

    var options = {
        chart: {
            height: 300
        },

        title: {
            text: 'Highcharts Drilldown Plugin'
        },

        xAxis: {
            categories: true
        },

        drilldown: {
            series: [{
                id: 'fruits',
                name: 'Fruits',
                data: [
                    ['Apples', 4],
                    ['Pears', 6],
                    ['Oranges', 2],
                    ['Grapes', 8]
                ]
            }, {
                id: 'cars',
                name: 'Cars',
                data: [{
                    name: 'Toyota',
                    y: 4,
                    drilldown: 'toyota'
                },
                ['Volkswagen', 3],
                ['Opel', 5]
                ]
            }, {
                id: 'toyota',
                name: 'Toyota',
                data: [
                    ['RAV4', 3],
                    ['Corolla', 1],
                    ['Carina', 4],
                    ['Land Cruiser', 5]
                ]
            }]
        },

        legend: {
            enabled: false
        },

        plotOptions: {
            series: {
                dataLabels: {
                    enabled: true
                },
                shadow: false
            },
            pie: {
                size: '80%'
            }
        },

        series: [{
            name: 'Overview',
            colorByPoint: true,
            data: <%=demo %>
            }]
    };

    // Column chart
    options.chart.renderTo = 'container1';
    options.chart.type = 'column';
    var chart1 = new Highcharts.Chart(options);

    // Pie
    options.chart.renderTo = 'container2';
    options.chart.type = 'pie';
    var chart2 = new Highcharts.Chart(options);


</script>

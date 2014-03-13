<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConsolidateProductChart.ascx.cs" Inherits="Views_UserControls_Consolidate_Product_Chart" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<script type="text/javascript">
    Sys.Application.add_load(function () {
        $(function () {
            var optionper = JSON.parse('<%=GetOptionsChart%>');
            createChart();
        });
        function createChart() {
            var _heigth = '<%=HeigthChart %>',
                _width = $('#temdiv').width(),//'<%=WidthChart %>',
                _allowExport = '<%=AllowExport %>',
                _titleXAxis = '<%=TitleXAxis %>',
                _titleYAxis = '<%=TitleYAxis %>',
                _titleChart = '<%=TitleChart %>',
                _xAxisType = '<%=TypeXAxis%>',
                _seriesName = '<%=SeriesName %>',
                _subTitleChart = '<%=SubTitleChart %>',
                _series = JSON.parse('<%=dtSeries %>'),
                _series_drilldown = JSON.parse('<%=dtDrillDownSeries %>');
            
            //var $reporting = $('#reporting');

            var  <%=NameChart%>_chart_per = {
                plotOptions: {
                    series: {
                        dataLabels: {
                            enabled: false
                        }
                    }
                }
            };

            var <%=NameChart%>_chart_opt = {
                chart: {
                    renderTo: '<%=dvChart.ClientID%>',
                    type: '<%=TypeChart%>',
                    height: _heigth,
                    width: _width,
                    zoomType: 'xy'
                },
                title: { text: _titleChart },
                subtitle: { text: _subTitleChart },
                xAxis: {
                    title: { text: _titleXAxis },
                    type: _xAxisType
                },
                yAxis: {
                    title: { text: _titleYAxis },
                    labels: {
                        enabled: false,
                        x: 3,
                        y: 16,
                        formatter: function () {
                            return Highcharts.numberFormat(this.value, 0);
                        }
                    }
                },
                plotOptions: {
                    series: {
                        color: "#058DC7",
                        cursor: 'pointer',
                        point: {
                            events: {
                                mouseOver: function () {
                                    //$reporting.html('x: ' + this.x + ', y: ' + this.y);
                                },
                                click: function () {
                                    var contenido = '';
                                    contenido = '<strong>Concepto: </strong>' + this.msg + '<br/>';
                                    contenido += '<strong>Fecha: </strong>' + this.x + '<br/>';
                                    contenido += '<strong>Monto: </strong> USD' + this.y.toFixed(2) + '<br/>';

                                    $('body').append(customModal);
                                    //TITULO
                                    $('#testmodal').find($('h4')).html(this.series.name);
                                    //CONTENIDO
                                    $('#testmodal').find('.modal-body').html(contenido);
                                    //PIE PAGINA
                                    $('#testmodal').find('.modal-footer').html('<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>');
                                    $('#testmodal').modal({ keyboard: true, show: true });
                                    //hs.htmlExpand(null, {
                                    //    outlineType: 'rounded-white',
                                    //    pageOrigin: {
                                    //        x: this.pageX,
                                    //        y: this.pageY
                                    //    },
                                    //    headingText: this.series.name,
                                    //    maincontentText: '<strong>Concepto: </strong>' + this.msg + '<br/>' + '<strong>Fecha: </strong>' + Highcharts.dateFormat('%A, %b %e, %Y', this.x) + ':<br/> ' + '<strong>Monto: </strong>USD ' + this.y.toFixed(2),
                                    //    width: 300
                                    //});
                                }
                            }
                        },
                        events: {
                            mouseOut: function () {
                                //$reporting.empty();
                            }
                        },
                        borderWidth: 0,
                        dataLabels: {
                            format: 'USD $ {point.y:,.2f}'
                        },
                        marker: { lineWidth: 1 }
                    }
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
            };

            <%=NameChart%>_chart_opt = jQuery.extend(true, {}, <%=NameChart%>_chart_per, <%=NameChart%>_chart_opt);
            var  <%=NameChart%>_chart = new Highcharts.Chart( <%=NameChart%>_chart_opt);
        }
    });
</script>
<div id="temdiv" class="col-md-12">
    <asp:Panel runat="server" ID="dvChart" ClientIDMode="AutoID"></asp:Panel>
</div>
<div id="reporting"></div>

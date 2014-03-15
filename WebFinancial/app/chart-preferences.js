var customModal = $('<div id="testmodal" class="modal fade"><div class="modal-dialog"><div class="modal-content"><div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button><h4 class="modal-title"></h4></div><div class="modal-body"></div><div class="modal-footer"></div></div></div></div>');

var myTheme = {
    colors: ['#058DC7', '#50B432', '#ED561B', '#DDDF00', '#24CBE5', '#64E572', '#FF9655', '#FFF263', '#6AF9C4'],
    chart: {
        backgroundColor: {
            linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
            stops: [
               [0, 'rgb(240, 240, 255)'],
               [1, 'rgb(240, 240, 255)']
            ]
        },
        borderWidth: 0,
        plotBackgroundColor: 'rgba(255, 255, 255, .9)',
        plotShadow: true,
        plotBorderWidth: 0
    },
    title: {
        style: {
            color: '#000',
            font: 'bold 16px "Trebuchet MS", Verdana, sans-serif'
        }
    },
    subtitle: {
        style: {
            color: '#666666',
            font: 'bold 12px "Trebuchet MS", Verdana, sans-serif'
        }
    },
    credits: {
        enabled: false
    },
    xAxis: {
        gridLineWidth: 0,
        lineColor: '#000',
        tickColor: '#000',
        labels: {
            style: {
                color: '#000',
                font: '11px Trebuchet MS, Verdana, sans-serif'
            }
        },
        title: {
            style: {
                color: '#333',
                fontWeight: 'bold',
                fontSize: '12px',
                fontFamily: 'Trebuchet MS, Verdana, sans-serif'

            }
        }
    },
    yAxis: {
        gridLineWidth: 0,
        minorGridLineWidth: 0,
        minorTickInterval: 'auto',
        lineColor: '#000',
        lineWidth: 1,
        tickWidth: 1,
        tickColor: '#000',
        labels: {
            enabled: true,
            align: 'left',
            style: {
                color: '#000',
                font: '11px Trebuchet MS, Verdana, sans-serif'
            }
        },
        title: {
            style: {
                color: '#333',
                fontWeight: 'bold',
                fontSize: '12px',
                fontFamily: 'Trebuchet MS, Verdana, sans-serif'
            }
        }
    },
    legend: {
        enabled: true,
        itemStyle: {
            font: '9pt Trebuchet MS, Verdana, sans-serif',
            color: 'black'

        },
        itemHoverStyle: { color: '#039' },
        itemHiddenStyle: { color: 'gray' }
    },
    labels: {
        style: { color: '#99b' }
    },
    tooltip: {
        shared: true,
        crosshairs: true,
        useHTML: true,
        headerFormat: '<span style="font-size:11px">Detail</span><br>',
        pointFormat: '<span style="color:{point.color}">{point.msg}</span><br><b>USD {point.y:,.2f}</b><br/>',
        valueDecimals: 2
    },
    navigation: {
        buttonOptions: {
            theme: { stroke: '#CCCCCC' }
        }
    },
    lang: {
        decimalPoint: '.',
        thousandsSep: ','
    }
};

//APPLY THEME
Highcharts.setOptions(myTheme);
Highcharts.setOptions({
    global: {
        useUTC: true
    }
});

//Highcharts.Data.prototype.dateFormats['m/d/Y'] = {
//    regex: '^([0-9]{1,2})\/([0-9]{1,2})\/([0-9]{2})$',
//    parser: function (match) {
//        return Date.UTC(+('20' + match[3]), match[1] - 1, +match[2]);
//    }
//};
hs.align = 'center';
hs.transitions = ['expand', 'crossfade'];
hs.outlineType = 'rounded-white';
hs.fadeInOut = true;
hs.dimmingOpacity = 0.75;
hs.useBox = true;
hs.showCredits = false;
hs.addSlideshow({
    fixedControls: 'fit', useControls: false, overlayOptions: {
        position: 'bottom center',
        opacity: 0.75,
        offsetY: 50,
        hideOnMouseOut: false
    }
});


var customChart = function createChart(series, drillDown, divContent, options) {
    var _allowExport = 'true',
        _titleXAxis = 'Productos',
        _titleYAxis = 'Valor',
        _xAxisType = 'category',
        _seriesName = 'Producto',
        _series = series,
        _series_drilldown = drillDown;

    var optionsChartBase = {
        chart: {
            renderTo: divContent,
            zoomType: 'xy'
        },
        xAxis: {
            title: { text: _titleXAxis },
            dateTimeLabelFormats: { //custom date formats for different scales
                second: '%H:%M:%S',
                minute: '%H:%M',
                hour: '%H:%M',
                day: '%e. %b',
                week: '%e. %b',
                month: '%b', //month formatted as month only
                year: '%Y'
            }
        },
        yAxis: {
            title: { text: _titleYAxis },
            labels: {
                enabled: true,
                x: 3,
                y: 16,
                formatter: function () {
                    return Highcharts.numberFormat(this.value, 0);
                }
            }
        },
        rangeSelector: {
            selected: 1,
            enabled: false,
            buttons: [
                { type: 'minute', count: 1, text: '1min' },
                { type: 'minute', count: 5, text: '5min' },
                { type: 'minute', count: 60, text: '1hr' },
                { type: 'week', count: 1, text: '1w' },
                { type: 'month', count: 1, text: '1m' },
                { type: 'year', count: 1, text: '1y' },
                { type: 'all', text: 'All' }
            ]
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
                            contenido += '<strong>Monto: </strong> USD' + this.y + '<br/>';

                            $('body').append(customModal);
                            if (this.series.name == null)
                                this.series.name = "";
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
        scrollbar: {
            enabled: false
        },
        navigator: {
            enabled: false
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

    var chart1 = new Highcharts.StockChart(Highcharts.merge(optionsChartBase, options));
}
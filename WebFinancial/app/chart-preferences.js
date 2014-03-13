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
        headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
        pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>USD {point.y:,.2f}</b><br/>'
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


Highcharts.Data.prototype.dateFormats['m/d/Y'] = {
    regex: '^([0-9]{1,2})\/([0-9]{1,2})\/([0-9]{2})$',
    parser: function (match) {
        return Date.UTC(+('20' + match[3]), match[1] - 1, +match[2]);
    }
};
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
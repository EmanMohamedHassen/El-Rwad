
function draw3DPieChart (data, elementId, chartName)  {
    FusionCharts.ready(function() {
        var demographicsChart = new FusionCharts({
            type: 'pie3d',
            renderAt: elementId,
            width: '100%',
            dataFormat: 'json',
            dataSource: {
                'chart': {
                    "caption": chartName,
                    "startingangle": "120",
                    "showlabels": "0",
                    "showlegend": "1",
                    "enablemultislicing": "0",
                    "slicingdistance": "15",
                    "showpercentvalues": "1",
                    "showpercentintooltip": "0",
                    "theme": "zune",
                    "baseFont": "Helvetica",
                    "baseFontSize": "11",
                    "height": '100%',
                    "bgcolor": "FFFFFF"
                },
                'data': data
            }
        });
        demographicsChart.render();
    });
}

function draw3DBarChart (data, elementId, chartName) {
    FusionCharts.ready(function() {
        var demographicsChart = new FusionCharts({
            type: 'column3d',
            renderAt: elementId,
            width: '100%',

            dataFormat: 'json',
            dataSource: {
                'chart': {
                    "caption": chartName,
                    "bgcolor": "FFFFFF",
                    "yaxisname": "مجمل الحضور",
                    "xaxisname": "ايام الشهر",
                    "divlinecolor": "FFFFFF",
                    "numbersuffix": "",
                    "palettecolors": "#F6BD0F,#FF6600,#8BBA00,#F984A1,#A66EDD,#B2FF66,#AFD8F8",
                    "divlinealpha": "30",
                    "showborder": "0",
                    "baseFont": "Helvetica",
                    "baseFontSize": "11",
                    "plottooltext": "$label  : $value ",
                    "theme": "fint",
                    "labelDisplay": "auto"
            
                },
                'data': data
            }
        });
        demographicsChart.render();
    });

}

function draw3DLineChart(data,elementId,chartName,footer){

    FusionCharts.ready(function() {
        var demographicsChart = new FusionCharts({
            type: 'line',
            renderAt: elementId,
            width: '100%',
       
            dataFormat: 'json',
            dataSource: {
                'chart': {
                    "caption": chartName,
                    "setAdaptiveYMin": "1",
                    "showLimits":"1",
                    "showvalues": "1",
                 
                    "bgcolor": "FFFFFF",
                    "showalternatehgridcolor": "0",
                    "showplotborder": "0",
                    "plotbordercolor": "999999",
                    "divlinecolor": "CCCCCC",
                    "canvasborderalpha": "0",
                    "linecolor": "008ee4",
                    "anchorbordercolor": "008ee4",
                    "anchorradius": "1",
                    "showshadow": "1",
                    "animation": "1",
                    "numvdivlines": "20",
                    "linethickness": "2",
                    "theme": "ocean",
                    "exportEnabled": "1",
                    "baseFont": "Verdana",
                    "baseFontSize": "11",
                    "outCnvBaseFontSize": "12",
                    "baseFontColor": "#0066cc",
                    "xAxisName": footer,
                    "yaxisname": "Hourly Volume.",
                    "legendBgColor": "#CCCCCC",
                    "legendBgAlpha": "20",
                    "legendBorderColor": "#666666",
                    "legendBorderThickness": "1",
                    "legendBorderAlpha": "40",
                    "legendShadow": "1",
                    "reverseLegend": "1",
                    "checkBoxColor": "#3333cc",
                    "captionFontSize": "18",
                    "captionFontBold": "1",
                },
                'data': data
                
            }, events: {
                renderComplete: function (event) {
                    debugger;

                  
                    // assuming a button exists on page with a specific id
                    var button = document.getElementById('btn-export');
                    button.onclick = function () {
                        event.sender.print();
                    };
                }
            }
        });
        demographicsChart.render();
    });
}

function draw3DMultiSeriesLineChart(data, category, average, elementId, chartName) {

            FusionCharts.ready(function() {
                var demographicsChart = new FusionCharts({
                    type: 'msline',
                    renderAt: elementId,
                    width: '100%',
                    height:"600px",
                    dataFormat: 'json',
                    dataSource: {
                        "chart": {
                            "caption": chartName,
                            
                            "linethickness": "2",
                            "showvalues": "1",
                            "numvdivlines": "22",
                            "formatnumberscale": "1",
                            "labeldisplay": "ROTATE",
                            "slantlabels": "1",
                            "anchorradius": "2",
                            "anchorgbalpha": "50",
                            "showalternatevgridcolor": "0",
                            "showalternatehgridcolor": "0",
                            "anchoralpha": "100",
                            "animation": "1",
                            "legendshadow": "0",
                            "legendborderalpha": "30",
                            "bgcolor": "ffffff",
                            "divlineisdashed": "1",
                            "divlinedashlen": "2",
                            "divlinedashgap": "4",
                            "canvasborderthickness": "1",
                            "canvasborderalpha": "30",
                            "showborder": "0",
                            "theme": "ocean",
                            "exportEnabled": "1",
                            "baseFont": "Verdana",
                            "baseFontSize": "11",
                            "outCnvBaseFontSize": "12",
                            "baseFontColor": "#0066cc",
                            "xAxisName": "Days Of Month",
                            "yAxisName": "No. of Vehicles",
                            "legendBgColor": "#CCCCCC",
                            "legendBgAlpha": "20",
                            "legendBorderColor": "#666666",
                            "legendBorderThickness": "1",
                            "legendBorderAlpha": "40",
                            "legendShadow": "1",
                            "reverseLegend": "1",
                            "checkBoxColor": "#3333cc",
                            "captionFontSize": "18",
                            "captionFontBold": "1",
                            
                        },
                        "categories": [
                            {
                                "category":category
                            }
                        ],
                        "dataset": [
                            {
                                "seriesname": "Days Of Month",
                                "color": "0080C0",
                                "anchorbordercolor": "0080C0",
                                "data": data
                            }
                            
                                                  ],
                        "trendlines": [
                            {
                                "line": [
                                    {
                                        "startvalue": average,
                                        "displayvalue": "Average : " +average,
                                        "valueonright": "1",
                                        "color": "999999",
                                        "origText": "Average :" +average
                                    }
                                ]
                            }
                        ]
                    }, events: {
                        renderComplete: function (event) {
                            debugger;
                            // assuming a button exists on page with a specific id
                            var button = document.getElementById('btn-export');
                            button.onclick = function () {
                                event.sender.print();
                            };
                        }
                    }
                });
        demographicsChart.render();
        });
}
function handleJsonDate(jsonDate) {
    var dateString = jsonDate.substr(6);
    var currentTime = new Date(parseInt(dateString));
    var month = currentTime.getMonth() + 1;
    var day = currentTime.getDate();
    var year = currentTime.getFullYear();
    var date = day + "/" + month + "/" + year;
    return date;
}

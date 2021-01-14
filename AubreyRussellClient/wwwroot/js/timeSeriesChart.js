var charts = {};
function updateChart(chartId, chartJson) {
    var ctx = document.getElementById('chart' + chartId).getContext('2d');
    chartJson = JSON.parse(chartJson);

    if (charts[chartId]) {
        charts[chartId].data.datasets = chartJson["data"]["datasets"];
        charts[chartId].data.labels = chartJson["data"]["labels"];
        charts[chartId].update();
    }
    else {
        charts[chartId] = new Chart(ctx, chartJson);
    }

}
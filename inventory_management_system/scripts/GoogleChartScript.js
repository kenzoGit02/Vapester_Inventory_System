google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(monthlyChart);
google.charts.setOnLoadCallback(quarterlyChart);
google.charts.setOnLoadCallback(yearlyChart);

function monthlyChart() {

    var data = google.visualization.arrayToDataTable([
        ['Product', 'Sales per year'],
        ['Strawberry', 10],
        ['Grapes', 20],
        ['Apple', 30],
        ['Adobo', 60],
        ['Sinigang', 30]
    ]);

    var options = {
        title: 'SALE',
        width: '500'
    };

    var chart = new google.visualization.PieChart(document.getElementById('monthlychart'));

    chart.draw(data, options);
}

function quarterlyChart() {

    var data = google.visualization.arrayToDataTable([
        ['Product', 'Sales per year'],
        ['Strawberry', 100],
        ['Grapes', 200],
        ['Apple', 300],
        ['Adobo', 400],
        ['Sinigang', 500]
    ]);

    var options = {
        title: 'Quarterly Sales',
        width: '500'
    };

    var chart = new google.visualization.PieChart(document.getElementById('quarterlychart'));

    chart.draw(data, options);
}

function yearlyChart() {

    var data = google.visualization.arrayToDataTable([
        ['Product', 'Sales per year'],
        ['Strawberry', 1000],
        ['Grapes', 2000],
        ['Apple', 3000],
        ['Adobo', 4000],
        ['Sinigang', 5000]
    ]);

    var options = {
        title: 'Yearly Sales',
        width: '500'
    };

    var chart = new google.visualization.PieChart(document.getElementById('yearlychart'));

    chart.draw(data, options);
}


google.charts.load('current', { 'packages': ['bar'] });
google.charts.setOnLoadCallback(performanceChart);
function performanceChart() {

    var data = google.visualization.arrayToDataTable([
        ['Year', 'Sales', 'Expenses', 'Profit'],
        ['2016', 1000, 400, 200],
        ['2017', 1170, 460, 250],
        ['2018', 660, 1120, 300],
        ['2019', 1030, 540, 350]
    ]);

    var options = {
        chart: {
            title: 'Company Performance',
            subtitle: 'Sales, Expenses, and Profit: 2014-2017',
            width: '500'
        }
    };

    var chart = new google.charts.Bar(document.getElementById('performance_chart'));

    chart.draw(data, google.charts.Bar.convertOptions(options));
}
google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(monthlyChart);
google.charts.setOnLoadCallback(quarterlyChart);
google.charts.setOnLoadCallback(yearlyChart);

google.charts.load('current', { 'packages': ['bar'] });
google.charts.setOnLoadCallback(performanceChart);

function monthlyChart() {

    var data = google.visualization.arrayToDataTable([
        ['Product', 'Sales per year'],
        ['Strawberry', 10],
        ['Grapes', 20],
        ['Apple', 30],
        ['Adobo', 40],
        ['Sinigang', 50]
    ]);

    var options = {
        title: 'Monthly Sales'
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
        title: 'Quarterly Sales'
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
        title: 'Yearly Sales'
    };

    var chart = new google.visualization.PieChart(document.getElementById('yearlychart'));

    chart.draw(data, options);
}

function performanceChart() {

    var data = google.visualization.arrayToDataTable([
        ['Year', 'Sales', 'Expenses', 'Profit'],
        ['2014', 1000, 400, 200],
        ['2015', 1170, 460, 250],
        ['2016', 660, 1120, 300],
        ['2017', 1030, 540, 350]
    ]);

    var options = {
        chart: {
            title: 'Company Performance',
            subtitle: 'Sales, Expenses, and Profit: 2014-2017',
        }
    };

    var chart = new google.charts.Bar(document.getElementById('performance_chart'));

    chart.draw(data, google.charts.Bar.convertOptions(options));
}
@ModelType IEnumerable(Of Fuel_Tax_Project.CChartData)

@Code
    ViewData("Title") = "North, South, Rural Total Fuel Percentages"
End Code

<h2>North, South, Rural Total Fuel Percentages</h2>
<div class="field-validation-error">@ViewData("errMessage")</div>
<div class="row-fluid">
    <div class="span8">
        <div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
    </div> <!-- end span8 -->
    <div class="span3">
        <!-- This is where the table will be -->
        <table class="table" id="datatable">
            <tr>
                <th>
                    County
                </th>
                <th>
                    Gallons
                </th>
                <th>
                    Percentages
                </th>
            </tr>
            @For Each item As CChartData In Model
                @<tr>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.ValueString)
                    </td>
                    <td>

                        @Html.DisplayFor(Function(modelItem) item.ValueLong)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.ValueDbl)

                    </td>
                </tr>
            Next

        </table>
    </div><!-- end span3 -->
</div> <!-- End row-fluid -->


<div id="container" style="min-width: 40%; height: 40%; margin: 0 auto"></div>

<script class="code" type="text/javascript">
    $(function () {
        var chart;


        pie_values = [['Clark', @ViewData("perCla")], ['Washoe/Carson City',  @ViewData("perWas")], ['Rural', @ViewData("perRur")]];

        $(document).ready(function () {

            // Build the chart
            $('#container').highcharts({

                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false
                },
                title: {
                    text: 'North, South Rural Total Fuel Percentages'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true
                        },
                        showInLegend: true
                    }
                },
                series: [{
                    type: 'pie',
                    name: 'Region share',
                    data: pie_values

                }]
            });
        });

    });
</script>

<br>
<div id="container1" style="min-width: 100%; height: 60%; margin: 0 auto"></div>
<script class="code" type="text/javascript">

    $(function () {
        $('#container1').highcharts({
            data: {
                table: document.getElementById('datatable')
            },
            chart: {
                type: 'column'
            },
            title: {
                text: 'North, South, Rural Total Fuel Percentages'
            },
            yAxis: {
                min: 0,
                title: {
                    text: 'Total (Gallons)',
                    align: 'high'
                },
                labels: {
                    formatter: function () {
                        return Highcharts.numberFormat(this.value / 1000000, 0) + 'M ';
                    }
                },
            },
            tooltip: {
                valuePrefix: ""
            },
        })
    })
</script>


@ModelType IEnumerable(Of Fuel_Tax_Project.CChartData)

@Code
    ViewData("Title") = "Custom Scenarios"
End Code
<h2>Custom Scenarios</h2>

<div class="row-fluid">
    <div class="span8">
        <div id="container" style="width: 100%; height: 33%; margin: 0 auto"></div>
    </div> <!-- end span8 -->
    <div class="span3">
        <!-- This is where the table will be -->
        <table class="table" id="datatable">
            <thead>
            <tr>
                <th>
                    Year
                </th>
                <th>
                    Revenue
                </th>
                <th>
                    Scenario 1
                </th>
                <th>
                    Scenario 2
                </th>
                <th>
                    Scenario 3
                </th>
                <th>
                    Scenario 4
                </th>
            </tr>
             </thead>
            <tbody>
            @For Each item As CChartData In Model
                @<tr>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.Year)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.ValueS1)
                    </td>
                     <td>
                         @Html.DisplayFor(Function(modelItem) item.ValueS2)
                     </td>
                     <td>
                         @Html.DisplayFor(Function(modelItem) item.ValueS3)
                     </td>
                     <td>
                         @Html.DisplayFor(Function(modelItem) item.ValueS4)
                     </td>
                     <td>
                         @Html.DisplayFor(Function(modelItem) item.ValueS5)
                     </td>
                </tr>   
            Next
            </tbody>    
        </table>
    </div><!-- end span3 -->
</div> <!-- End row-fluid -->

<script class="code" type="text/javascript">
    $(function () {
        $('#container').highcharts({
            data: {
                table: document.getElementById('datatable')
            },
            chart: {
                type: 'line'
            },
            title: {
                text: 'Gasoline Revenue Per Year'
            },
            yAxis: {
                min: 0,
                title: {
                    text: 'Revenue ($USD)',
                    align: 'high'
                },
                labels: {
                    formatter: function() {
                        return '$' + Highcharts.numberFormat(this.value/1000000, 0) +'M ';
                    }
                },
            },
            tooltip: {
            valuePrefix: '$'
        },
        })
    })
</script>

@ModelType IEnumerable(Of Fuel_Tax_Project.CChartData)

@Code
    ViewData("Title") = "Total Tax By County Annually"
End Code

<h2>Total Tax By County Annually</h2>

<div class="row-fluid">
    <div class="span8">
        <div id="container" style="width: 100%; height: 33%; margin: 0 auto"></div>
    </div> <!-- end span8 -->
    <div class="span3">
        <!-- This is where the table will be -->
        <table class="table" id="datatable">
            <tr>
                <th>
                    County
                </th>
                <th>
                    Tax Revenue
                </th>
            </tr>
            @For Each item As CChartData In Model
                @<tr>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.ValueString)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.ValueS1)
                    </td>
                </tr>
            Next

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
                type: 'column'
            },
            title: {
                text: 'Total Tax Revenue by County'
            },
            yAxis: {
                min: 0,
                title: {
                    text: 'Total ($M)',
                    align: 'high'
                },
                labels: {
                    formatter: function () {
                        return Highcharts.numberFormat(this.value / 1000000, 0) + 'M ';
                    }
                },
            },
            tooltip: {
                valuePrefix: "$"
            },
        })
    })
</script>




<!-- **** JQPLOT CODE SAVE FOR EMERGENCIES
<script class="code" type="text/javascript">

      $(document).ready(function () {
        var s2 = [

            @For Each v As CChartData  In Model
                @String.Format("[{0}, {1}], ", v.ValueString, v.ValueS1)
            Next
        ];

        var s1 = [];

          plot1 = $.jqplot("chart1", [s2, s1], {
              // Turns on animatino for all series in this plot.
              animate: true,
              // Will animate plot on calls to plot1.replot({resetAxes:true})
              animateReplot: true,
              cursor: {
                  show: true,
                  zoom: true,
                  looseZoom: true,
                  showTooltip: false
              },
              series: [
                  {
                      pointLabels: {
                          show: false
                      },
                      renderer: $.jqplot.BarRenderer,
                      showHighlight: true,
                      yaxis:          'yaxis',
                      rendererOptions: {
                          // Speed up the animation a little bit.
                          // This is a number of milliseconds.
                          // Default for bar series is 3000.
                          animation: {
                              speed: 2500
                          },
                          barWidth: 15,
                          barPadding: -15,
                          barMargin: 10,
                          highlightMouseOver: false
                      }
                  },
                  {
                      rendererOptions: {
                          // speed up the animation a little bit.
                          // This is a number of milliseconds.
                          // Default for a line series is 2500.
                          animation: {
                              speed: 2000
                          }
                      }
                  }
              ],
              axesDefaults: {
                  pad: 0
              },
              axes: {
                  // These options will set up the x axis like a category axis.
                  xaxis: {
                      tickInterval: 1,
                      drawMajorGridlines: false,
                      drawMinorGridlines: true,
                      drawMajorTickMarks: false,
                      rendererOptions: {
                          tickInset: 0.5,
                          minorTicks: 1
                      }
                  },
                  yaxis: {
                      tickOptions: {
                          formatString: "$%'d"
                      },
                      rendererOptions: {
                          forceTickAt0: true
                      }
                  },
                  y2axis: {
                      tickOptions: {
                          formatString: "$%'d"
                      },
                      rendererOptions: {
                          // align the ticks on the y2 axis with the y axis.
                          alignTicks: true,
                          forceTickAt0: true
                      }
                  }
              },
              highlighter: {
                  show: true,
                  showLabel: true,
                  tooltipAxes:    'y',
                  sizeAdjust: 7.5, tooltipLocation: 'ne'
              }
          });

      });


</script>
    -->
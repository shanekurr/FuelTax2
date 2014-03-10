@ModelType IEnumerable(Of Fuel_Tax_Project.CChartData)
@Code
    ViewData("Title") = "Reports List"
End Code

<h2>Historical Data</h2>
<div class="field-validation-error">@ViewData("errMessage")</div>
<div class="row-fluid">
    <div class="span8">
      
    </div> <!-- end span8 -->
    <div class="span3">
        <!-- This is where the table will be -->
        @ViewData("Month")
        <table class="table" id="datatable">
 
           

            @For Each item As CChartData In Model
                @<tr>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.ValueString)
                    </td>
                </tr>
            Next

        </table>
    </div><!-- end span3 -->
</div> <!-- End row-fluid -->


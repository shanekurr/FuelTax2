@ModelType IEnumerable(Of Fuel_Tax_Project.FileData)

@Code
    ViewData("Title") = "Download"
End Code

<h2>Download</h2>
<div class="field-validation-error">
    @ViewData("msg")
</div>

<div class="row-fluid">

    @Using Html.BeginForm("GetFile", "userHistorical", method:=FormMethod.Post)
        @Html.ValidationSummary(True)
        @<fieldset>

            <div class="span6">
                <!-- This is where the table will be -->
                <table class="table" id="datatable">
                    <tr>
                        <th>
                            Date
                        </th>
                        <th>
                            File Name(s)
                        </th>
                        <th>
                            Download
                        </th>
                    </tr>
                    @For Each item As FileData In Model
                        @<tr>
                             <td>
                                 @Html.DisplayFor(Function(down) item.months, ViewData("files")) |
                                 @Html.DisplayFor(Function(down) item.years, ViewData("files"))
                             </td>
                            <td>
                                @Html.DisplayFor(Function(down) item.fName, ViewData("files"))
                            </td>
               
                            <td>
                      
                                
                                @Html.ActionLink("Download", "GetFile", New With {.fName = item.fName, .years = item.years, .months = item.months, .report = item.report, .radio = item.radio})

                                <!--<button id="submit" name="submit" class="btn-btn-primary">Download</button>   -->    
                            </td>

                        </tr>
                    Next
                </table>
            </div><!-- end span3 -->
        </fieldset>
    End Using
</div>


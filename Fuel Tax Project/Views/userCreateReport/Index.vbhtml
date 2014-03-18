@ModelType FileData
@Code
    ViewData("Title") = "Create A Fuel tax Report"
End Code
<div class="row-fluid"> 
    <div class="span12">
        <h4>Use this form to create a report on the monthly consumption of gasoline.</h4>
        Select a Fiscal Year file and a Gasgal file then click "Create Report".
        @Using Html.BeginForm("ContentUpload_Post", "userCreateReport", FormMethod.Post, New With {.enctype = "multipart/form-data"})
            @Html.ValidationSummary(True)
            @<fieldset>
                <br>
                <div class="row-fluid">
                    <div class="span6">
                        <p>Please Select Year</p>
                        <div class="span6">
                            @Html.DropDownListFor(Function(ed1) Model.years, ViewData("YearsPicker"))
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span6">
                        <p>Please Select A Month</p>
                        <div class="span6">
                            @Html.DropDownListFor(Function(ed1) Model.months, ViewData("MonthsPicker"))
                        </div>
                    </div>
                </div>
                <br>
                 <label>Fiscal Year File: <input type="file" name="ExcelFile" id="ExcelFile" /> </label>
                 <label>Gasgal File: <input type="file" name="ExcelFile2" id="ExcelFile2" /> </label>
                 <div class="span6 offset1">
                     <br> <input type="submit" id="submit" name="submit" value="Create Report" class="btn-btn-primary">
                 </div>
                  <br>
            </fieldset>
        End Using
    </div>
    <div class="row-fluid">
        <div class="span8">
            <!--<p><b>Please use only the following formats: </b></p>
            <div class="span6">
                Html.ActionLink("Sample Fiscal Year Report", "GetFile", New With {.fName = "Fy2013sf.xlsx"}) <br>
                Html.ActionLink("Sample Gasgal Report", "GetFile", New With {.fName = "Gasgal2013.xlsx"}) <br />
                Html.ActionLink("Sample Generated Report", "GetFile", New With {.fName = "2000January.xlsx"}) <br />

            </div> -->
            Note: You may need Microsoft Office installed on your computer to properly use this feature. <br> After report has been generated please save to your computer. 
        </div>
    </div>
</div>


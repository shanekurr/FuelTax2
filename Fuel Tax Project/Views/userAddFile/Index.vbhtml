@ModelType FileData
@Code
    ViewData("Title") = "Add File to Database"
End Code
<div class="row-fluid">
    <div class="span12">
        <h2>Select the file to upload data into the database</h2>
    </div>
    <div class="span6">
        <!-- New With {.enctype = "multipart/form-data", .onsubmit = "return confirmSubmit();"}) -->
        @Using Html.BeginForm("ContentUpload_Post", "userAddFile", FormMethod.Post, New With {.enctype = "multipart/form-data"})
            @Html.ValidationSummary(True)
            @<fieldset>   
            <br>
                <div class="row-fluid">
                    <div class="span6">
                        <p>Please Select A Report Type</p>
                        <div class="span6">
                            @Html.DropDownListFor(Function(ed1) Model.report, ViewData("ReportPicker"))
                        </div>
                    </div>
                </div>
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
                 <label>Data File: <input type="file" name="ExcelFile" id="ExcelFile"/> </label>
                     <div class="span6 offset3">
                        <br> <input type="submit" id="submit" name="submit" value="Upload" class="btn-btn-primary">
                     </div> 
</fieldset> 
        End Using
    </div>
    <div class="row-fluid">
        <div class="span8">
            <p><b>Please use only the following formats: </b></p>
            <div class="span6">
                @Html.ActionLink("Sample DMV Statistical Report", "GetFile", New With {.fName = "STAT03-13Records.xlsx"}) <br>
               @Html.ActionLink("Sample FHWA 551M Report", "GetFile", New With {.fName = "Mar2013.xlsx"}) <br />
                @Html.ActionLink("Sample Source Data for FHWA 551M Report", "GetFile", New With {.fName = "Mar2013Fh551.xlsx"}) <br>
             
            </div>
        </div>
    </div>
</div>


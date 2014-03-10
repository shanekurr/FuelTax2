@ModelType FileData
@Code
ViewData("Title") = "Historical Reports"
End Code


<div class="row-fluid">
    <div class="span6">

        <h2>Historical Reports</h2>



        @Using Html.BeginForm("Download", "userHistorical", method:=FormMethod.Post)
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

                @Html.RadioButton("radio", "1", True) Final Report<br />
                @Html.RadioButton("radio", "2", False) Source Data for Final FHWA Report<br />


                <div class="span12 offset8">
                    <br><button id="submit" name="submit" class="btn-btn-primary">Submit</button>
                </div>
            </fieldset>

        End Using
    </div> <!-- end third form -->
</div>



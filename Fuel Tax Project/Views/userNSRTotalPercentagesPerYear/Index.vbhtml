@ModelType DropDownData

@Code
    ViewData("Title") = "North, South, Rural Percentages"
End Code
<div class="row-fluid">
    <div class="span12">
        <h2>North, South, Rural Total Gallons Per Year</h2>

        @Using Html.BeginForm("Chart", "userNSRTotalPercentagesPerYear", method:=FormMethod.Post)
            @Html.ValidationSummary(True)
        @<fieldset>
            <legend>Please Select Graph Parameters</legend>

            <div class="row-fluid">
                <div class="span6">
                </div>
            </div>
            <div class="row-fluid">
                <div class="span6">
                    <p>Please Select A Year</p>
                    <div class="span6">
                        @Html.DropDownListFor(Function(ed1) Model.startDD, ViewData("startDD"))
                    </div>
                </div>
            </div>
    <br /><br />
                Calendar         @Html.RadioButton("reportType", "Calendar", True)
                State Fiscal     @Html.RadioButton("reportType", " State Fiscal", False)
                Federal Fiscal   @Html.RadioButton("reportType", "Federal Fiscal", False)
                <br><br>
                <div class="span2 offset3">

                    <button id="submit" name="submit" class="btn-btn-primary">Submit</button>
                </div>
            </fieldset>
        End Using
    </div>
</div>

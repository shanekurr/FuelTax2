@ModelType DropDownData

@Code
    ViewData("Title") = "Total Tax By County Annually"
End Code

<div class="row-fluid">
    <div class="span12">
        <h2>Total Tax By County Annually</h2>
    </div>
    @Using Html.BeginForm("Chart", "userTotalTaxByCounty", method:=FormMethod.Post)
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
             Calendar         @Html.RadioButton("RadioValue", "1", True)
             State Fiscal     @Html.RadioButton("RadioValue", "2", False)
             Federal Fiscal   @Html.RadioButton("RadioValue", "3", False)
             <br /><br />
            <div class="span2 offset3">
                <button id="submit" name="submit" class="btn-btn-primary">Submit</button>
            </div>
        </fieldset>
    End Using
</div>
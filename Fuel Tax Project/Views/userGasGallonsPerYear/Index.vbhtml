@ModelType DropDownData

@Code
    ViewData("Title") = "Total Gallons Per Year"
End Code

<div class="row-fluid">
    <div class="span12">
        <h2>Total Gallons Per Year</h2>
    </div>
    <div class="span6">
        @Using Html.BeginForm("Chart", "userGasGallonsPerYear", method:=FormMethod.Post)
            @Html.ValidationSummary(True)
            @<fieldset>
                <legend>Please Select Graph Parameters</legend>
                <div class="row-fluid">
                    <div class="span6">
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span6">
                        <p>From Year</p>
                        <div class="span6">
                            @Html.DropDownListFor(Function(ed1) Model.startDD, ViewData("startDD"))
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span6">
                        <p>To Year</p>
                        <div class="span6">
                            @Html.DropDownListFor(Function(ed1) Model.endDD, ViewData("endDD"))
                        </div>
                    </div>
                </div>
                <div class="span2 offset3">
                    <button id="submit" name="submit" class="btn-btn-primary">Submit</button>
                </div>
            </fieldset>
        End Using
    </div>
</div>

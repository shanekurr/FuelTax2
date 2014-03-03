@ModelType DropDownData

@Code
    ViewData("Title") = "Linear Regression"
End Code

<div class="row-fluid">
    <div class="span12">
        
    </div>
    @Using Html.BeginForm("Chart", "userLinearRegression", method:=FormMethod.Post)
        @Html.ValidationSummary(True)
        @<fieldset>
            <legend>Please Select Graph Parameters</legend>

            <div class="row-fluid">
                <div class="span6">
                </div>
            </div>
            <div class="row-fluid">
                <div class="span6">
                    <p>End Projection Year</p>
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


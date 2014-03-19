@ModelType DropDownData

@Code
    ViewData("Title") = "Linear Regression"
End Code

<div class="row-fluid">
    <div class="span12">
        <h2> Linear Regression </h2>
    </div>
    <div class="span4">
    @Using Html.BeginForm("Chart", "userLinearRegression", method:=FormMethod.Post)
        @Html.ValidationSummary(True)
        @<fieldset>
            <legend>Please Select Graph Parameters</legend>

            <div class="row-fluid">
                <div class="span12">
                </div>
            </div>
            <div class="row-fluid">
                <div class="span12">
                    <p>End Projection Year</p>
                    <div class="span12">
                        @Html.DropDownListFor(Function(ed1) Model.endDD, ViewData("endDD"))

                    </div>
                </div>
            </div>
            <div class="span10 offset9">
                <button id="submit" name="submit" class="btn-btn-primary">Submit</button>
            </div>
        </fieldset>
    End Using
        </div>
</div>


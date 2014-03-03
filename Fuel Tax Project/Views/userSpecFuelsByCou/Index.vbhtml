@ModelType DropDownData

@Code
    ViewData("Title") = "Special Fuels By County Annually"
End Code

<div class="row-fluid">
    <div class="span12">
        <h2>Special Fuels By County Annually</h2>
    </div>
    @Using Html.BeginForm("Chart", "userSpecFuelsByCou", method:=FormMethod.Post)
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
            <div class="span2 offset3">
                <button id="submit" name="submit" class="btn-btn-primary">Submit</button>
            </div>
        </fieldset>
    End Using
</div>
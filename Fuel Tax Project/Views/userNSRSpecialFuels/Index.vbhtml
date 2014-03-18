@ModelType DropDownData

@Code
    ViewData("Title") = "North, South, Rural Special Fuels"
End Code

<div class="row-fluid">
    <div class="span12">
        <h2>North, South, Rural Special Fuels</h2>

    @Using Html.BeginForm("Chart", "userNSRSpecialFuels", method:=FormMethod.Post)
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
    <div class="row-fluid">
        <div class="span6">
            <p>To Year</p>
            <div class="span6">
                @Html.DropDownListFor(Function(ed1) Model.endDD, ViewData("endDD"))
            </div>
        </div>
    </div>
             <br />
             @Html.RadioButton("RadioValue", "1", True) Calendar         <br/>
             @Html.RadioButton("RadioValue", "2", False) State Fiscal    <br/>
             @Html.RadioButton("RadioValue", "3", False) Federal Fiscal  
    <br /><br />

    <div class="span2 offset3">
        <button id="submit" name="submit" class="btn-btn-primary">Submit</button>
    </div>
</fieldset>
    End Using
    </div>
</div>

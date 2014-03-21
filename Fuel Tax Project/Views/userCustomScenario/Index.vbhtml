@ModelType DropDownData

@Code
    ViewData("Title") = "Custom Scenarios "
End Code

<div class="row-fluid">
    <div class="span12">
        <h2>Gasoline Revenue Per Year</h2>
    </div>
    <div class="span6">
        @Using Html.BeginForm("Chart", "userCustomScenario", method:=FormMethod.Post)
            @Html.ValidationSummary(True)
            @<fieldset>
                <legend>Please Set Custom Scenarios</legend>
                <div class="row-fluid">
                    <div class="span6">
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span6">
                        <p>Scenario 1</p>
                        <div class="span6">
                            @Html.DropDownListFor(Function(ed1) Model.Scen1DD, ViewData("IntList"))
                            @Html.RadioButton("Scen1Radio", "1", False) Up  
                            @Html.RadioButton("Scen1Radio", "2", False) Down<br /><br />
                        </div>
                    </div>
            
                    <div class="span6">
                        <p>Scenario 2</p>
                        <div class="span6">
                            @Html.DropDownListFor(Function(ed1) Model.Scen2DD, ViewData("IntList"))
                            @Html.RadioButton("Scen2Radio", "1", False) Up
                            @Html.RadioButton("Scen2Radio", "2", False) Down<br /><br />
                        </div>
                    </div>
                </div><br />

                 <div class="row-fluid">
                     <div class="span6">
                         
                         <p>Scenario 3</p>
                         <div class="span6">
                             @Html.DropDownListFor(Function(ed1) Model.Scen3DD, ViewData("IntList"))
                             @Html.RadioButton("Scen3Radio", "1", False) Up
                             @Html.RadioButton("Scen3Radio", "2", False) Down<br />
                         </div>
                     </div>
                     <div class="span6">
                         <p>Scenario 4</p>
                         <div class="span6">
                             @Html.DropDownListFor(Function(ed1) Model.Scen4DD, ViewData("IntList"))
                             @Html.RadioButton("Scen4Radio", "1", False) Up
                             @Html.RadioButton("Scen4Radio", "2", False) Down<br />
                         </div>
                     </div>
                 </div><br /><br />
                <div class="span2">
                    <button id="submit" name="submit" class="btn-btn-primary">Submit</button>
                </div>
            </fieldset>
        End Using
    </div>
</div>

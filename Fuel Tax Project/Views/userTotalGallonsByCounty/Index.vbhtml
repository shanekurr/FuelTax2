@ModelType DropDownData

@Code
    ViewData("Title") = "Total Gallons By County"
End Code

<div class="row-fluid">
    <div class="span12">
        <h2>Total Gallons By County</h2>
    </div>
    <div class="span3">
    @Using Html.BeginForm("Chart1", "userTotalGallonsByCounty", method:=FormMethod.Post)
        @Html.ValidationSummary(True)
        @<fieldset>
            <legend>Gasoline Gallons By County</legend>

            <div class="row-fluid">
                <div class="span12">
                    <p>Please Select A Year</p>
                    <div class="span12">
                        @Html.DropDownListFor(Function(ed1) Model.startDD, ViewData("startDD"))
                    </div>
                </div>
            </div>
             @Html.RadioButton("RadioValue", "1", True) Calendar<br />
             @Html.RadioButton("RadioValue", "2", False) State Fiscal<br />
             @Html.RadioButton("RadioValue", "3", False) Federal Fiscal<br />
            
            <div class="span12 offset8">
                <button id="submit" name="submit" class="btn-btn-primary">Submit</button>
            </div>
        </fieldset>
    End Using
    </div> <!-- end first form -->
    <div class="span4">
        @Using Html.BeginForm("Chart2", "userTotalGallonsByCounty", method:=FormMethod.Post)
            @Html.ValidationSummary(True)
            @<fieldset>
                <legend>Gasoline Gallons By Month and County</legend>

                <div class="row-fluid">
                    <p>Please Select A County</p>
                    <div class="span6">
                        @Html.DropDownListFor(Function(ed1) Model.county, ViewData("county"))
                    </div>
                </div>
        <br />
                <div class="row-fluid">
                    <div class="span6">
                        <p>Please Select A Year </p>
                        <div class="span6">
                            @Html.DropDownListFor(Function(ed1) Model.startDD, ViewData("startDD"))
                        </div>
                    </div>
                </div>
                <div class="span12 offset8">
                    <button id="submit" name="submit" class="btn-btn-primary">Submit</button>
                </div>
            </fieldset>
        End Using
    </div> <!-- end second form -->
    <div class="span4">
        @Using Html.BeginForm("Chart3", "userTotalGallonsByCounty", method:=FormMethod.Post)
            @Html.ValidationSummary(True)
            @<fieldset>
                <legend>Gasoline Gallons By Years and County</legend>

                <div class="row-fluid">
                    <div class="span6">
                        <p>Please Select A County</p>
                        <div class="span6">
                            @Html.DropDownListFor(Function(ed1) Model.county, ViewData("county"))
                        </div>
                    </div>
                </div>
                 <div class="row-fluid">
                     <div class="span6">
                         <p>Please Select A Start Year</p>
                         <div class="span6">
                             @Html.DropDownListFor(Function(ed1) Model.startDD, ViewData("startDD"))
                         </div>
                     </div>
                </div>
                 <div class="row-fluid">
                     <div class="span6">
                         <p>Please Select An End Year</p>
                         <div class="span6">
                             @Html.DropDownListFor(Function(ed1) Model.endDD, ViewData("endDD"))
                         </div>
                     </div>
                 </div>
                
                 @Html.RadioButton("RadioValue", "1", True) Calendar<br />
                 @Html.RadioButton("RadioValue", "2", False) State Fiscal<br />
                 @Html.RadioButton("RadioValue", "3", False) Federal Fiscal<br />
              
                <div class="span12 offset8">
                    <button id="submit" name="submit" class="btn-btn-primary">Submit</button>
                </div>
            </fieldset>
        End Using
    </div> <!-- end third form -->
</div>
@ModelType gasrevperyearscen1
@Code
    ViewData("Title") = "Gasoline Revenue Per Year Scenario One"
End Code

<h2>Gasoline Revenue Per Year Scenario One</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>Create</h4>
        <hr />
        @Html.ValidationSummary(true)
        <div class="form-group">
            @Html.LabelFor(Function(model) model.ID, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ID)
                @Html.ValidationMessageFor(Function(model) model.ID)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.year, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.year)
                @Html.ValidationMessageFor(Function(model) model.year)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.amount, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.amount)
                @Html.ValidationMessageFor(Function(model) model.amount)
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

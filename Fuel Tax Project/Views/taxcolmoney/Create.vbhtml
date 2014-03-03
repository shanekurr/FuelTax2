@ModelType taxcolmoney
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>taxcolmoney</h4>
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
            @Html.LabelFor(Function(model) model.CountyN, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.CountyN)
                @Html.ValidationMessageFor(Function(model) model.CountyN)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.AmountD, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.AmountD)
                @Html.ValidationMessageFor(Function(model) model.AmountD)
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

@ModelType gasolinegbycou
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>gasolinegbycou</h4>
        <hr />
        @Html.ValidationSummary(true)
        @Html.HiddenFor(Function(model) model.ID)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.year, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.year)
                @Html.ValidationMessageFor(Function(model) model.year)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.month, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.month)
                @Html.ValidationMessageFor(Function(model) model.month)
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
            @Html.LabelFor(Function(model) model.Gallon, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Gallon)
                @Html.ValidationMessageFor(Function(model) model.Gallon)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.perTotal, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.perTotal)
                @Html.ValidationMessageFor(Function(model) model.perTotal)
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@ModelType taxcollgall
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>taxcollgall</h4>
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
            @Html.LabelFor(Function(model) model.Diesel, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Diesel)
                @Html.ValidationMessageFor(Function(model) model.Diesel)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.CNG, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.CNG)
                @Html.ValidationMessageFor(Function(model) model.CNG)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.LPG, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.LPG)
                @Html.ValidationMessageFor(Function(model) model.LPG)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.A55, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.A55)
                @Html.ValidationMessageFor(Function(model) model.A55)
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

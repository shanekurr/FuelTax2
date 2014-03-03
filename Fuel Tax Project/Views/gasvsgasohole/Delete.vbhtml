@ModelType gasvsgasohole
@Code
    ViewData("Title") = "Gasoline Vs Gasohole"
End Code

<h2>Gasoline Vs Gasohole</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Delete</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.year)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.year)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.gasoline)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.gasoline)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.gasohole)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.gasohole)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.total)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.total)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>

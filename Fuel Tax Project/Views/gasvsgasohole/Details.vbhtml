@ModelType gasvsgasohole
@Code
    ViewData("Title") = "Gasoline Vs Gasohole"
End Code

<h2>Gasoline Vs Gasohole</h2>

<div>

    <h4>Details</h4>
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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>

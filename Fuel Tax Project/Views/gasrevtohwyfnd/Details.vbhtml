@ModelType gasrevtohwyfnd
@Code
    ViewData("Title") = "Gasoline Revenue To Highway Fund"
End Code

<h2>Gasoline Revenue To Highway Fund</h2>

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
            @Html.DisplayNameFor(Function(model) model.month)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.month)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.amount)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.amount)
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

@ModelType gasrevperyear
@Code
    ViewData("Title") = "Gasoline Revenur Per Year"
End Code

<h2>Gasoline Revenur Per Year</h2>

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
            @Html.DisplayNameFor(Function(model) model.amount)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.amount)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Back to List", "Index")
</p>

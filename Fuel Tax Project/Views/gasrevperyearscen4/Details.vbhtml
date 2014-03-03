@ModelType gasrevperyearscen4
@Code
    ViewData("Title") = "Gas Revenue Per Year Scene Four"
End Code

<h2>Gas Revenue Per Year Scene Four</h2>

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
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>

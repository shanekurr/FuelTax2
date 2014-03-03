@ModelType taxcolmoney
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>taxcolmoney</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.CountyN)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CountyN)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.AmountD)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AmountD)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>

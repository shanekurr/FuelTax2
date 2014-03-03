@ModelType taxcollgall
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>taxcollgall</h4>
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
            @Html.DisplayNameFor(Function(model) model.CountyN)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CountyN)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Diesel)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Diesel)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CNG)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CNG)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LPG)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LPG)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.A55)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.A55)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>

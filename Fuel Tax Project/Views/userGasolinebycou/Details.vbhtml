@ModelType gasolinegbycou
@Code
    ViewData("Title") = "Gasoline By County"
End Code

<h2>Gasoline By County</h2>

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
            @Html.DisplayNameFor(Function(model) model.CountyN)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CountyN)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Gallon)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Gallon)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.perTotal)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.perTotal)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Back to List", "Index")
</p>

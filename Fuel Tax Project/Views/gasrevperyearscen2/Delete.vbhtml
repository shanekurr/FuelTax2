@ModelType gasrevperyearscen2
@Code
    ViewData("Title") = "Gasoline Revenue Per Year Scenario Two"
End Code

<h2>Gasoline Revenue Per Year Scenario Two</h2>

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
            @Html.DisplayNameFor(Function(model) model.amount)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.amount)
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

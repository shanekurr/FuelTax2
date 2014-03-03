@ModelType taxcolmoney2
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>taxcolmoney2</h4>
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
            @Html.DisplayNameFor(Function(model) model.AmountD)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AmountD)
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

@ModelType news
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>news</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Titre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Titre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.contenu)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.contenu)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>

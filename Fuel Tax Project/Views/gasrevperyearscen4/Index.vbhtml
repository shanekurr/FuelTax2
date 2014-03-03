@ModelType IEnumerable(Of gasrevperyearscen4)
@Code
    ViewData("Title") = "Gas Revenue Per Year Scene Four"
End Code

<h2>Gas Revenue Per Year Scene Four</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.year)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.amount)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.year)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.amount)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>

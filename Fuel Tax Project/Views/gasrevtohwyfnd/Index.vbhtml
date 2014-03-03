@ModelType IEnumerable(Of gasrevtohwyfnd)
@Code
    ViewData("Title") = "Gasoline Revenue To Highway Fund"
End Code

<h2>Gasoline Revenue To Highway Fund</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.year)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.month)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.amount)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.total)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.year)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.month)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.amount)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.total)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>

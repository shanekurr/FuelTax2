@ModelType IEnumerable(Of gasvsgasohole)
@Code
    ViewData("Title") = "Gasoline Vs Gasohole"
End Code

<h2>Gasoline Vs Gasohole</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.year)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.gasoline)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.gasohole)
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
            @Html.DisplayFor(Function(modelItem) item.gasoline)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.gasohole)
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

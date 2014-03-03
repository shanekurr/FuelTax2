@ModelType IEnumerable(Of gasolinegbycou)
@Code
ViewData("Title") = "Gasoline By County"
End Code

<h2>Gasoline By County</h2>

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
            @Html.DisplayNameFor(Function(model) model.CountyN)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Gallon)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.perTotal)
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
            @Html.DisplayFor(Function(modelItem) item.CountyN)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Gallon)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.perTotal)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>

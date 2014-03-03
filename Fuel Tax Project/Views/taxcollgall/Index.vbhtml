@ModelType IEnumerable(Of taxcollgall)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

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
            @Html.DisplayNameFor(Function(model) model.Diesel)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CNG)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LPG)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.A55)
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
            @Html.DisplayFor(Function(modelItem) item.Diesel)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CNG)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LPG)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.A55)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>

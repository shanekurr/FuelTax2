@ModelType FileData
@Code
    ViewData("Title") = "ContentUpload_Post"
End Code


<h3>@ViewData("err")</h3>
<br>

<div class="row-fluid" >

    If you want to add another file
    @Html.ActionLink("Click Here.", "Index", "userAddFile")
    <br>
    <br>
    @Html.ActionLink("Return To Main Menu", "Index", "Home")
    <br>
    <br>

</div>  



﻿@ModelType FileData
@Code
    ViewData("Title") = "ContentUpload_Post"
End Code
<br>
<div class="field-validation-error">
    @ViewData("err")
</div>
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


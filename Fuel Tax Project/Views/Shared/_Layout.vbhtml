<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - NDOT</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @Styles.Render("~/Content/Plugins/JQplot/CSS")


    @Scripts.Render("~/Content/Plugins/JQplot/JS")
    @Scripts.Render("~/Content/Plugins/highchart")
    @RenderSection("scripts", required:=False)
</head>
<body>




    <
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="navbar-inner">
            <div class="container">
                <button type="button" class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("NDOT Fuel Tax Data Management and Reporting System", "Index", "Home", Nothing, New With {.[class] = "brand"})
                <div class="nav-collapse collapse">
               
                    @Html.Partial("_LoginPartial") <br />
                    <div class="nav-collapse collapse">
                        <ul class="nav">
                            <li class="dropdown">
                                <a href="#" data-toggle="dropdown" id="dropdownMenu1" class="dropdown-toggle">State Highway Fund</a>
                                <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                                    <li class="nav-header">Gallons</li>
                                    <li>@Html.ActionLink("Total", "Index", "userTotalGallonsPerYear")</li>
                                    <li>@Html.ActionLink("Gasoline", "Index", "userGasGallonsPerYear")</li>
                                    <li>@Html.ActionLink("Special Fuels", "Index", "userSFGallonsPerYear")</li>
                                    <li class="divider"></li>
                                    <li class="nav-header">Revenue</li>
                                    <li>@Html.ActionLink("Total", "Index", "userTotalTaxRevPerYear")</li>
                                    <li>@Html.ActionLink("Gasoline", "Index", "usergasrevperyear")</li>
                                    <li>@Html.ActionLink("Special Fuels", "Index", "userSFRevPerYear")</li>
                                </ul>
                            </li>
                            <li class="dropdown">
                                <a href="#" data-toggle="dropdown" id="dropdownMenu2" class="dropdown-toggle">County</a>
                                <ul class="dropdown-menu" aria-labelledby="dropdownMenu2">
                                    <li class="nav-header">Monthly Gallons</li>
                                    <li>@Html.ActionLink("Total Gallons", "Index", "userTotalGallonsByCounty")</li>
                                    <li>@Html.ActionLink("Gasoline", "Index", "userGasolinebycou")</li>
                                    <li>@Html.ActionLink("Special Fuels", "Index", "userSpecFuelsByCou")</li>
                                    <li class="divider"></li>
                                    <li>@Html.ActionLink("Total Tax", "Index", "userTotalTaxByCounty")</li>
                                </ul>
                            </li>
                            <li class="dropdown">
                                <a href="#" data-toggle="dropdown" id="dropdownMenu3" class="dropdown-toggle">North, South, Rural Percentages</a>
                                <ul class="dropdown-menu" aria-labelledby="dropdownMenu3">
                                    <li>@Html.ActionLink("Total Gallons", "Index", "userNSRTotalPercentagesPerYear")</li>
                                    <li>@Html.ActionLink("Gasoline", "Index", "userNSRGasoline")</li>
                                    <li>@Html.ActionLink("Special Fuels", "Index", "userNSRSpecialFuels")</li>
                                    <li class="divider"></li>
                                    <li>@Html.ActionLink("Total Revenue", "Index", "userNSRTotalRevenue")</li>
                                </ul>
                            </li>
                            <li class="dropdown">
                                <a href="#" data-toggle="dropdown" id="dropdownMenu4" class="dropdown-toggle">Historical Data</a>
                                <ul class="dropdown-menu" aria-labelledby="dropdownMenu4">
                                    <li>@Html.ActionLink("Historical Reports", "Index", "userHistorical")</li>
                                    <li>@Html.ActionLink("Add File to Database", "Index", "userAddFile")</li>
                                </ul>
                            <li class="dropdown">
                                <a href="#" data-toggle="dropdown" id="dropdownMenu4" class="dropdown-toggle">Projections</a>
                                <ul class="dropdown-menu" aria-labelledby="dropdownMenu4">
                                    <li>@Html.ActionLink("Linear Regression", "Index", "userLinearRegression")</li>
                                    <li>@Html.ActionLink("Custom Scenarios", "CustomScenarios", "Home")</li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
  <br />
    <div class="container">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - Fuel Tax Project</p>
        </footer>
    </div>
 
    
</body>
</html>

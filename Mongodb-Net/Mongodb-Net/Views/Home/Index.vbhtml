@ModelType IEnumerable(Of Mongodb_Net.Sanatci)

@Html.Partial("Header")

<div id="body">

    @Html.Partial("Menu")

    <section class="content-wrapper main-content clear-fix">

        <ol>
            @For Each item In Model
                @<li>@item.Ad - <a href="/Home/Sanatci/@item._id">Detay</a></li>
            Next
        </ol>

    </section>
</div>

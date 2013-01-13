@ModelType IEnumerable(Of Mongodb_Net.Sanatci)

@Html.Partial("Header")

<div id="body">

    @Html.Partial("Menu")

    <section class="content-wrapper main-content clear-fix">

        <ol>
            @For Each item In Model
                @<li>@item.Ad - <a href="/Home/Sanatci/@item._id">Detay</a> | <a href="/Duzenle/Sanatci/@item._id">Düzenle</a> | <a href="/Sil/Sanatci/@item._id">Sil</a></li>
            Next
        </ol>

    </section>
</div>

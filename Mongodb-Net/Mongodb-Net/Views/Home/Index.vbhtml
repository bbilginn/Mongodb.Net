@ModelType IEnumerable(Of Mongodb_Net.Sanatci)


<div id="body">

    @Html.Partial("Menu")

    <section class="content-wrapper main-content clear-fix">

        <p>
            Sayfada @Model.Count sanatçı, @Model.Select(Function(x) x.Albums.Count).DefaultIfEmpty(0).Sum albüm bulunmaktadır.
        </p>

        <table>
            <tr>
                <th>Sanatçı</th>
                <th>Albüm</th>
                <th>İşlemler</th>
            </tr>
            @For Each item In Model
                @<tr>
                    <td style="width:65%">@item.Ad</td>
                    <td>@item.Albums.Count</td>
                    <td><a href="/Home/Sanatci/@item._id">Detay</a> | <a href="/Duzenle/Sanatci/@item._id">Düzenle</a> | <a href="/Sil/Sanatci/@item._id">Sil</a></td>
                </tr>
            Next
        </table>

    </section>
</div>

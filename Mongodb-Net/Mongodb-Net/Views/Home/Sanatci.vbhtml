@ModelType Mongodb_Net.Sanatci

@Code
    ViewData("Title") = "Sanatci Detay"
End Code


<div id="body">

    @Html.Partial("Menu")

    <section class="content-wrapper main-content clear-fix">

        <fieldset>
            <legend>Sanatci</legend>

            @*    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Ad)
    </div>*@

            <div class="display-field">
                <h1>@Html.DisplayFor(Function(model) model.Ad)</h1>
            </div>

            @*    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Albums)
    </div>*@

            <div class="display-field">
                <ul>
                    @If Model.Albums.Any Then
                        For Each album In Model.Albums.OrderByDescending(Function(x) x.Yil)
                        @<li>
                            <div>
                                <span>@album.Isim - @album.Yil - 
                                    <a href="/Duzenle/Album/@album._id">Albümü Düzenle</a> | 
                                    <a href="/Sil/Album/@album._id">Albümü Sil</a></span><br />
                                <img style="height:80px;width:80px;" src="@album.Resim" alt="@album.Isim - @album.Yil" />
                            </div>
                        </li>
                        Next
                    Else
                        @<li>Albüm bulunamadı</li>
                    End If
                    <li><a href="/Yeni/Album/@Model._id">Yeni Ekle</a></li>
                </ul>
            </div>



        </fieldset>
        <p>
            @Html.ActionLink("Sanatçıyı Düzenle", "Sanatci", New With {.id = Model._id, .controller = "Duzenle"}) |
            @Html.ActionLink("Back to List", "Index", "Home")
        </p>

    </section>
</div>


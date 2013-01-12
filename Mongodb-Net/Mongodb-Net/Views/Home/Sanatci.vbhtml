@ModelType Mongodb_Net.Sanatci

@Code
    ViewData("Title") = "Sanatci Detay"
End Code

@Html.Partial("Header")

<div id="body">

    @Html.Partial("Menu")

    <section class="content-wrapper main-content clear-fix">

        <fieldset>
            <legend>Sanatci</legend>

            @*    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Ad)
    </div>*@

            <div class="display-field">
                @Html.DisplayFor(Function(model) model.Ad)
            </div>

            @*    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Albums)
    </div>*@

            <div class="display-field">
                <ul>
                    @If Model.Albums IsNot Nothing Then ' If item.Albums.Any Then - yemedi ya lan!
                        For Each album In Model.Albums
                        @<li>
                            <div>
                                <span>@album.Isim - @album.Yil - <a href="/Duzenle/Album/@album._id">Düzenle</a></span><br />
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
            @Html.ActionLink("Düzenle", "Duzenle", New With {.id = Model._id}) |
    @Html.ActionLink("Back to List", "Index")
        </p>

    </section>
</div>


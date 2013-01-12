@ModelType IEnumerable(Of Mongodb_Net.Sanatci)
<header>
    <div class="content-wrapper">
        <div class="float-left">
            <p class="site-title">
                <a href="~/">ASP.NET ve Mongodb</a>
            </p>
        </div>
    </div>
</header>
<div id="body">
    
    @Html.Partial("Menu")
    
    <section class="content-wrapper main-content clear-fix">

        <ol>
            @For Each item In Model
                @<li>@item.Ad
                    <ul>
                        @For Each album In item.Albums
                            @<li>
                                <div>
                                    <span>@album.Isim - @album.Yil</span><br />
                                    <img style="height:80px;width:80px;" src="@album.Resim" alt="@album.Isim - @album.Yil" />
                                </div>
                            </li>
                        Next
                    </ul>
                </li>
            Next
        </ol>

    </section>
</div>

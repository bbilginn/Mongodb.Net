@ModelType Mongodb_Net.Album

@Code
    ViewData("Title") = "Album"
End Code



<div id="body">

    @Html.Partial("Menu")

    <section class="content-wrapper main-content clear-fix">

        @Using Html.BeginForm()
            @Html.ValidationSummary(True)

            @<fieldset>
                <legend>Album</legend>

                <div class="editor-label">
                    @Html.LabelFor(Function(model) model.Isim)
                </div>
                <div class="editor-field">
                    @Html.EditorFor(Function(model) model.Isim)
                    @Html.ValidationMessageFor(Function(model) model.Isim)
                </div>

                <div class="editor-label">
                    @Html.LabelFor(Function(model) model.Yil)
                </div>
                <div class="editor-field">
                    @Html.EditorFor(Function(model) model.Yil)
                    @Html.ValidationMessageFor(Function(model) model.Yil)
                </div>

                <div class="editor-label">
                    @Html.LabelFor(Function(model) model.Resim)
                </div>
                <div class="editor-field">
                    @Html.EditorFor(Function(model) model.Resim)
                    @Html.ValidationMessageFor(Function(model) model.Resim)
                </div>

                <p>
                    <input type="submit" value="Save" />
                </p>
            </fieldset>
        End Using

        <div>
            @Html.ActionLink("Back to List", "Index")
        </div>

        @Section Scripts
            @Scripts.Render("~/bundles/jqueryval")
        End Section

    </section>
</div>


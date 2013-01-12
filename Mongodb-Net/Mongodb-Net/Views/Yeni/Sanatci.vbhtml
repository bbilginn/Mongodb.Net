@ModelType Mongodb_Net.Sanatci

@Code
    ViewData("Title") = "Yeni Sanatci"
End Code

@Html.Partial("Header")

<div id="body">

    @Html.Partial("Menu")

    <section class="content-wrapper main-content clear-fix">

        @Using Html.BeginForm()
            @Html.ValidationSummary(True)

            @<fieldset>
                <legend>Sanatci</legend>

                <div class="editor-label">
                    @Html.LabelFor(Function(model) model.Ad)
                </div>
                <div class="editor-field">
                    @Html.EditorFor(Function(model) model.Ad)
                    @Html.ValidationMessageFor(Function(model) model.Ad)
                </div>

                <p>
                    <input type="submit" value="Create" />
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


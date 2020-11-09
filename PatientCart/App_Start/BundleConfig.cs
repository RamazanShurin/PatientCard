using System.Web;
using System.Web.Optimization;

namespace PatientCart
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // готово к выпуску, используйте средство сборки по адресу https://modernizr.com, чтобы выбрать только необходимые тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
              "~/Scripts/adminlte/plugins/jquery/jquery.js",
             "~/Scripts/adminlte/plugins/popper/popper.js",
             "~/Scripts/adminlte/plugins/bootstrap/js/bootstrap.js",
              "~/Scripts/adminlte/adminlte.js",
             "~/Scripts/adminlte/plugins/daterangepicker/moment.min.js",
             "~/Scripts/adminlte/plugins/daterangepicker/daterangepicker.js",
              "~/Scripts/adminlte/plugins/select2/js/select2.full.js",
              "~/Scripts/adminlte/plugins/select2/js/i18n/ru.js",
             "~/Scripts/adminlte/plugins/datatable/datatables/jquery.dataTables.js",
              "~/Scripts/adminlte/plugins/datatable/datatables-bs4/js/dataTables.bootstrap4.js",
              "~/Scripts/adminlte/plugins/datatable/datatables-fixedheader/js/fixedHeader.bootstrap4.js",
              "~/Scripts/adminlte/plugins/datatable/datatables-fixedheader/js/dataTables.fixedHeader.js",
              "~/Scripts/adminlte/plugins/datatable/datetime-sort/datetime-moment.js",
              "~/Scripts/adminlte/plugins/inputmask/inputmask/inputmask.js",
              "~/Scripts/adminlte/plugins/inputmask/inputmask/inputmask.extensions.js",
             "~/Scripts/adminlte/plugins/inputmask/inputmask/jquery.inputmask.js",
              "~/Scripts/jquery.maphilight.js"
             ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //bundles.Add(new Bundle("~/Content/adminlte").Include(
            //         "~/Content/fontawesome/all.min.css",
            //         "~/Content/adminlte/adminlte.min.css"
            //         ));
            bundles.Add(new Bundle("~/Content/adminlte").Include(
                   "~/Content/fontawesome/css/all.min.css",
                   "~/Content/adminlte/adminlte.min.css",
                   "~/Content/adminlte/plugins/daterangepicker/daterangepicker.css",
                   "~/Content/adminlte/plugins/select2/css/select2.css",
                   "~/Content/adminlte/plugins/select2-bootstrap4-theme/select2-bootstrap4.css",
                   "~/Content/adminlte/plugins/datatable/datatables-bs4/css/dataTables.bootstrap4.css",
                   "~/Content/adminlte/plugins/datatable/datatables-fixedheader/css/fixedHeader.bootstrap4.css",
                   "~/Content/adminlte/plugins/icheck-bootstrap/icheck-bootstrap.css",
                   "~/Content/ionicons.min.css"

                   ));
        }
    }
}

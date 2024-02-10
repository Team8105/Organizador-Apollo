using Organizador_Apollo.Views;

namespace Organizador_Apollo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("material", typeof(Materials));
            Routing.RegisterRoute("material/details", typeof(Material));
            Routing.RegisterRoute("classification", typeof(Classifications));
            Routing.RegisterRoute("classification/details", typeof(ClassificationPage));
            Routing.RegisterRoute("about", typeof(About));
        }
    }
}

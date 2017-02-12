using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Features.ResolveAnything;
using Prism.Autofac;
using Prism.Autofac.Forms;
using TeamFormation.Services;
using TeamFormation.ViewModels;
using TeamFormation.Views;
using Xamarin.Forms;

namespace TeamFormation
{
    public partial class App : PrismApplication
    {
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("ListingPage");
        }

        protected override void RegisterTypes()
        {
            var builder = new ContainerBuilder();

            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            Container.RegisterTypeForNavigation<ListingPage>();

            builder.RegisterType<LeagueService>().As<ILeagueService>();
            builder.RegisterType<DataService>().As<IDataService>();

            builder.Update(Container);
        }
    }
}

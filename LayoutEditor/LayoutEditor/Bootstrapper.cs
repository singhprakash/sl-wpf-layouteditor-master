using System.Windows;
using LayoutEditor.Common;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace LayoutEditor
{
    public partial class Bootstrapper : UnityBootstrapper
    {
        protected override IUnityContainer CreateContainer()
        {
            var container = base.CreateContainer();
            RegisterTypes(container);
            return container;
        }

        private void RegisterTypes(IUnityContainer container)
        {
            //Register Common unity container
            var commonContainer = new CommonUnityExtension();
            container.AddExtension(commonContainer);
        }

        protected override DependencyObject CreateShell()
        {
            // Use the container to create an instance of the shell.
            var view = Container.TryResolve<MainPage>();
            // Set it as the root visual for the application.
            Application.Current.RootVisual = view;
            return view;
        }
    }
}
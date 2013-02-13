using LayoutEditor.Common.Services;
using Microsoft.Practices.Unity;

namespace LayoutEditor.Common
{
    public class CommonUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IUserSettingsService, UserSettingsService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ILayoutEditorPopulationService, LayoutEditorPopulationService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IUserLayoutService, UserLayoutService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IMessageService, MessageService>();
        }
    }
}
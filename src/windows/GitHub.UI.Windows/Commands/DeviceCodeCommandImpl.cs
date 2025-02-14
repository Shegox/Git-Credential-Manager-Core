using System.Threading;
using System.Threading.Tasks;
using GitHub.UI.ViewModels;
using GitHub.UI.Views;
using Microsoft.Git.CredentialManager;
using Microsoft.Git.CredentialManager.UI;

namespace GitHub.UI.Commands
{
    public class DeviceCodeCommandImpl : DeviceCodeCommand
    {
        public DeviceCodeCommandImpl(ICommandContext context) : base(context) { }

        protected override Task ShowAsync(DeviceCodeViewModel viewModel, CancellationToken ct)
        {
            return Gui.ShowDialogWindow(viewModel, () => new DeviceCodeView(), GetParentHandle());
        }
    }
}

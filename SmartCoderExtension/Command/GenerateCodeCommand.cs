// Controls/GenerateCodeCommand.cs
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using SmartCoderExtension.Controls;
using SmartCoderExtension.Utilities;
using System;
using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace SmartCoderExtension.Commands
{
    internal sealed class GenerateCodeCommand
    {
        private static AsyncPackage _package;

        public static async Task InitializeAsync(AsyncPackage package)
        {
            _package = package;
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            var commandService = await package.GetServiceAsync<IMenuCommandService, OleMenuCommandService>();
            var commandId = new CommandID(PackageGuids.CommandSet, PackageIds.GenerateCodeCommand);
            var menuCommand = new MenuCommand(Execute, commandId);
            ((IMenuCommandService)commandService).AddCommand(menuCommand);
        }
        private static void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var window = _package.FindToolWindow(typeof(CodeAssistantWindow), 0, true);
            if (window?.Frame is IVsWindowFrame windowFrame)
            {
                windowFrame.Show();
            }
        }
    }
}
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
        // 异步包实例
        private static AsyncPackage _package;

        // 初始化命令
        public static async Task InitializeAsync(AsyncPackage package)
        {
            _package = package;
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            // 获取命令服务
            var commandService = await package.GetServiceAsync<IMenuCommandService, OleMenuCommandService>();
            // 创建命令ID
            var commandId = new CommandID(PackageGuids.CommandSet, PackageIds.GenerateCodeCommand);
            // 创建菜单命令并添加到命令服务
            var menuCommand = new MenuCommand(Execute, commandId);
            ((IMenuCommandService)commandService).AddCommand(menuCommand);
        }

        // 执行命令
        private static void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            // 查找并显示工具窗口
            var window = _package.FindToolWindow(typeof(CodeAssistantWindow), 0, true);
            if (window?.Frame is IVsWindowFrame windowFrame)
            {
                windowFrame.Show();
            }
        }
    }
}
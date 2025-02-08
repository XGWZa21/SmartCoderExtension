using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;
using SmartCoderExtension.Commands;
using SmartCoderExtension.Controls;
using SmartCoderExtension.Utilities;
using Microsoft.VisualStudio.Shell.Interop;

// 必须的GUID注册
[PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
[Guid(PackageGuids.PackageString)] // 使用统一包GUID
[ProvideMenuResource("Menus.ctmenu", 1)] // 菜单资源标识
[ProvideToolWindow(typeof(CodeAssistantWindow))] // 注册工具窗口
public sealed class SmartCoderPackage : AsyncPackage
{

    private async Task AddToolWindowAsync(Type type)
    {
        await Task.CompletedTask;
    }

    #region 初始化方法

    protected override async Task InitializeAsync(
     CancellationToken cancellationToken,
     IProgress<ServiceProgressData> progress)
    {
        await base.InitializeAsync(cancellationToken, progress);

        // 初始化生成代码命令
        await GenerateCodeCommand.InitializeAsync(this);

        // 注册工具窗口到IDE
        await this.AddToolWindowAsync(typeof(CodeAssistantWindow));

        // 调试时自动打开窗口
#if DEBUG
        await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
        var window = this.FindToolWindow(typeof(CodeAssistantWindow), 0, true);
        if (window?.Frame is IVsWindowFrame frame)
        {
            frame.Show();
        }
#endif
    }

    #endregion
}


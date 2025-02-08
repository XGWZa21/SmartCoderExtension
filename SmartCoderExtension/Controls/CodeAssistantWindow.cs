// Controls/CodeAssistantWindow.cs
using System.Diagnostics;
using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace SmartCoderExtension.Controls
{
    [Guid("3B2D89F1-4D8C-4A6F-9E7B-6C1F8D9E0A2B")] // 唯一窗口GUID
    public sealed class CodeAssistantWindow : ToolWindowPane
    {
        // 唯一构造函数
        public CodeAssistantWindow() : base(null)
        {
            // 初始化配置
            this.Caption = "AI代码助手";
            this.Content = new CodeAssistantControl();

            // 可选：设置窗口图标（需添加资源文件）
            // this.BitmapResourceID = 301;

            try
            {
                this.Content = new CodeAssistantControl();
                Debug.WriteLine("XAML控件加载成功");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"控件加载失败: {ex}");
            }

        }
    }

}

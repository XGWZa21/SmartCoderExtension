using SmartCoderExtension.Services;
using System;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using Task = System.Threading.Tasks.Task;
namespace SmartCoderExtension.Controls
{
    public partial class CodeAssistantControl : UserControl
    {
        public CodeAssistantControl()
        {
            InitializeComponent();
            this.DataContext = new CodeAssistantViewModel();  // 设置 DataContext 绑定到 ViewModel
        }

        private readonly DeepSeekClient _client = new DeepSeekClient();



        private async void Generate_Click(object sender, RoutedEventArgs e)
        {
            await Generate_ClickAsync(sender, e).ConfigureAwait(false);
        }

        // 点击生成代码按钮时触发
        private async Task Generate_ClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = await _client.GenerateCodeAsync(txtPrompt.Text);
                txtResult.Text = CodeFormatter.Format(response);  // 格式化并显示生成的代码
            }
            catch (Exception ex)
            {
                MessageBox.Show($"生成失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // ViewModel 用于绑定数据
        public class CodeAssistantViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            // 通知 UI 更新
            protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}


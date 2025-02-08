using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartCoderExtension.Controls
{
    /// <summary>
    /// Interaction logic for CodeAssistantWindowControl.
    /// </summary>
    public partial class CodeAssistantWindowControl : UserControl
    {
        public CodeAssistantWindowControl()
        {
            InitializeComponent();
            this.DataContext = new CodeAssistantViewModel(); // 绑定到 ViewModel
        }

        // ViewModel 用于处理数据
        public class CodeAssistantViewModel : INotifyPropertyChanged
        {
            private string _someText = "默认文本"; // 确保有默认值
            public string SomeText
            {
                get => _someText;
                set { _someText = value; OnPropertyChanged(); }
            }

            private string _compartmentName = "Unpublished Changes"; // 默认名称
            public string CompartmentName
            {
                get => _compartmentName;
                set { _compartmentName = value; OnPropertyChanged(); }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            // 通知 UI 更新
            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public Color TableControlBackground { get; set; } = Colors.LightGray;
            public double RotateAngle { get; set; } = 45; // 默认值
        }

        // 点击按钮时触发的事件
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "CodeAssistantWindow");
        }
    }
}

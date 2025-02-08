// ViewModels/CodeAssistantViewModel.cs
using System.ComponentModel;
using System.Windows.Media;

namespace SmartCoderExtension.ViewModels
{
    public class CodeAssistantViewModel : INotifyPropertyChanged
    {
        private string _generatedCode;
        public string GeneratedCode
        {
            get => _generatedCode;
            set
            {
                _generatedCode = value;
                OnPropertyChanged(nameof(GeneratedCode));
            }
        }

        private string _glyphButtonName = "生成代码";  // 默认值
        public string GlyphButtonName
        {
            get => _glyphButtonName;
            set
            {
                if (_glyphButtonName != value)
                {
                    _glyphButtonName = value;
                    OnPropertyChanged();  // 触发属性变化通知
                }
            }
        }

        private double _someOffset = 0.5;  // 默认偏移值
        public double SomeOffset
        {
            get => _someOffset;
            set
            {
                if (_someOffset != value)
                {
                    _someOffset = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _rotateAngle = 45;  // 默认旋转角度
        public double RotateAngle
        {
            get => _rotateAngle;
            set
            {
                if (_rotateAngle != value)
                {
                    _rotateAngle = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _compartmentName = "Unpublished Changes";
        public string CompartmentName
        {
            get => _compartmentName ?? string.Empty;
            set
            {
                if (_compartmentName != value)
                {
                    _compartmentName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _someText = "默认文本"; // 确保有默认值
        public string SomeText
        {
            get => _someText;
            set
            {
                if (_someText != value)
                {
                    _someText = value;
                    OnPropertyChanged();
                }
            }
        }

        public Color TableControlBackground { get; set; } = Colors.LightGray;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

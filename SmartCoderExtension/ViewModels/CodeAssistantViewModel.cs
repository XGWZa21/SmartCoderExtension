using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
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

        public double Angle { get; set; }

        public double ActualHeight { get; set; }

        public IList Controls { get; set; }

        public int Count { get; set; }

        public string ShortcutText { get; set; }

        public ICommand NewCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public class CompartmentItem
        {
            public string Header { get; set; }
            public ObservableCollection<CompartmentItem> Children { get; set; }
        }

        public CodeAssistantViewModel()
        {
            NewCommand = new RelayCommand(NewCommandExecute);
            OpenCommand = new RelayCommand(OpenCommandExecute);
            ExitCommand = new RelayCommand(ExitCommandExecute);

            // 示例数据
            TrackingItems = new ObservableCollection<TrackingItem>
        {
            new TrackingItem { Name = "任务1", Status = "完成" },
            new TrackingItem { Name = "任务2", Status = "进行中" }
        };


            CompartmentItems = new ObservableCollection<CompartmentItem>
        {
            new CompartmentItem
            {
                Header = "主分支",
                Children = new ObservableCollection<CompartmentItem>
                {
                    new CompartmentItem { Header = "历史记录" }
                }
            }
        };

        }

        private ObservableCollection<TrackingItem> _trackingItems;

        public ObservableCollection<TrackingItem> TrackingItems
        {
            get => _trackingItems;
            set
            {
                if (_trackingItems != value)
                {
                    _trackingItems = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<CompartmentItem> CompartmentItems { get; private set; }

        private ObservableCollection<CompartmentItem> _compartmentItems;

        



        private void NewCommandExecute(object parameter) { /* 执行新建操作 */ }
        private void OpenCommandExecute(object parameter) { /* 执行打开操作 */ }
        private void ExitCommandExecute(object parameter) { /* 执行退出操作 */ }


        private bool isSelected;

        public bool GetIsSelected()
        {
            return isSelected;
        }

        public void SetIsSelected(bool value)
        {
            isSelected = value;
        }

        public Color TableControlBackground { get; set; } = Colors.LightGray;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        public class TrackingItem
        {
            public string Name { get; internal set; }
            public string Status { get; internal set; }
        }
    }

    internal class CompartmentItem
    {
        public string Header { get; internal set; }
        public ObservableCollection<CompartmentItem> Children { get; internal set; }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }

}

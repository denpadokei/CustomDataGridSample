using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomDataGridSample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public class SortTargetEntity
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime BirthDay { get; set; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private bool SetProperty<T>(ref T field, T value, [CallerMemberName]string name = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) {
                return false;
            }
            field = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            return true;
        }

        /// <summary>説明 を取得、設定</summary>
        private ObservableCollection<SortTargetEntity> _sortTargets;
        /// <summary>説明 を取得、設定</summary>
        public ObservableCollection<SortTargetEntity> SortTargets
        {
            get => this._sortTargets;

            set => this.SetProperty(ref this._sortTargets, value);
        }

        public MainWindowViewModel()
        {
            this._sortTargets = new ObservableCollection<SortTargetEntity>();
            for (int i = 0; i < 10; i++) {
                this._sortTargets.Add(new SortTargetEntity()
                {
                    ID = i + 1,
                    Name = $"SampleName{i}",
                    Age = 10 * i,
                    BirthDay = DateTime.Now.AddYears(i)
                });
            }
        }
    }
}

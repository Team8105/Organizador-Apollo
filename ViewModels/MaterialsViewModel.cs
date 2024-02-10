
using Organizador_Apollo.Model;
using Organizador_Apollo.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Organizador_Apollo.ViewModels
{
    public class MaterialsViewModel : INotifyPropertyChanged
    {
        bool isRefreshing;
        int RefreshDuration = 2;
        DatabaseService databaseService;
        public ObservableCollection<Material> Materials { get; private set; } = new ObservableCollection<Material>();
        public bool IsRefreshing
        {
            get { return isRefreshing; } 
            set 
            {
                IsRefreshing = value;
                OnPropertyChanged();
            }
        }
        public MaterialsViewModel()
        {
            databaseService = new();
            addMaterials();
        }
        public ICommand RefreshCommand => new Command(async () => await RefreshDataAsync());
        public ICommand DeleteCommand => new Command<Material>(RemoveMaterial);
        async void addMaterials()
        {
            var materials = await databaseService.GetMaterials();
            if(materials.Count > 0)
                Materials.Clear();

            foreach(Material material in materials)
                Materials.Add(material);
        }
        async void RemoveMaterial(Material material)
        {
            if(Materials.Contains(material))
            {
                await databaseService.DeleteMaterial(material);
                Materials.Remove(material);
            }
        }
        async Task RefreshDataAsync()
        {
            IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            addMaterials();
            IsRefreshing = false;
        }
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace RestaurantDesktopApp.MVVM.Models
{
    public partial class MenuItemModel : ObservableObject
    {
        public int Id { get; set; }

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private decimal _price;

        [ObservableProperty]
        private string _icon;

        [ObservableProperty]
        private string _description;

        public ObservableCollection<MenuCategoryModel> Categories { get; set; } = [];

        public MenuCategoryModel[] SelectedCategories => Categories.Where(x => x.IsSelected).ToArray();
    }
}

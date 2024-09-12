using CommunityToolkit.Mvvm.Messaging.Messages;

namespace RestaurantDesktopApp.MVVM.Models
{
    public class MenuItemDeletedMessage : ValueChangedMessage<MenuItemModel>
    {
        public MenuItemDeletedMessage(MenuItemModel value) : base(value)
        {
        }

        public static MenuItemDeletedMessage From(MenuItemModel value) => new(value);
    }
}

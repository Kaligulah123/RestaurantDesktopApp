using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace RestaurantDesktopApp.MVVM.Models
{
    public class ShowOrderMessage : ValueChangedMessage<bool>
    {
        public ShowOrderMessage(bool value) : base(value)
        {
        }
    }
}

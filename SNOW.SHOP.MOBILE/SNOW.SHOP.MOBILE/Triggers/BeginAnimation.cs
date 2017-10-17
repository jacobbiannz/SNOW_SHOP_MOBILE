using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNOW.SHOP.MOBILE.Animations.Base;
using Xamarin.Forms;

namespace SNOW.SHOP.MOBILE.Triggers
{

    public class BeginAnimation : TriggerAction<VisualElement>
    {
        public AnimationBase Animation { get; set; }

        protected override async void Invoke(VisualElement sender)
        {
            if (Animation != null)
                await Animation.Begin();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNOW.SHOP.MOBILE.Animations.Base;

using Xamarin.Forms;

namespace SNOW.SHOP.MOBILE.Animations
{

    [ContentProperty("Animations")]
    public class StoryBoard : AnimationBase
    {
        public StoryBoard()
        {
            Animations = new List<AnimationBase>();
        }

        public StoryBoard(List<AnimationBase> animations)
        {
            Animations = animations;
        }

        public List<AnimationBase> Animations
        {
            get;
        }

        protected override async Task BeginAnimation()
        {
            foreach (var animation in Animations)
            {
                if (animation.Target == null)
                    animation.Target = Target;

                await animation.Begin();
            }
        }

        protected override async Task ResetAnimation()
        {
            foreach (var animation in Animations)
            {
                if (animation.Target == null)
                    animation.Target = Target;

                await animation.Reset();
            }
        }
    }
}
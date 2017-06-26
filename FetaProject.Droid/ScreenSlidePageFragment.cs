using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;

namespace FetaProject.Droid
{
    class ScreenSlidePageFragment : Fragment
    {
        private int pageIndex;

        public ScreenSlidePageFragment(int index)
        {
            pageIndex = index;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            switch (pageIndex)
            {
                case 0:
                    return (ViewGroup)inflater.Inflate(Resource.Layout.fragment_screen_slide_page_main, container, false);
                case 1:
                    return (ViewGroup)inflater.Inflate(Resource.Layout.fragment_screen_slide_page_about, container, false);
                case 2:
                    return (ViewGroup)inflater.Inflate(Resource.Layout.fragment_screen_slide_page_gallery, container, false);
                case 3:
                    return (ViewGroup)inflater.Inflate(Resource.Layout.fragment_screen_slide_page_map, container, false);
                case 4:
                    return (ViewGroup)inflater.Inflate(Resource.Layout.fragment_screen_slide_page_settings, container, false);
                default:
                    return (ViewGroup)inflater.Inflate(Resource.Layout.fragment_screen_slide_page_main, container, false);

            }
        }
    }
}
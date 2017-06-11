using System;
using System.Collections.Generic;
using UIKit;

namespace FetaProject.iOS
{
    public partial class MapViewController : UIViewController
    {
        private readonly DisplayMapView _mapView;
        private readonly Dictionary<int, string> _eventsDayMapper = new Dictionary<int, string>
        {
            {0, "13.07"},
            {1, "14.07"},
            {2, "15.07"},
            {3, "16.07"}
        };

        public override void ViewDidLoad()
        {
            map.Image = UIImage.FromBundle("Photo/Map.jpg");
            SelectDay.ValueChanged += SegmentChange;
        }

        public MapViewController(IntPtr handle) : base(handle)
        {
            var storyboard = UIStoryboard.FromName("Main", null);
            _mapView = storyboard.InstantiateViewController("map") as DisplayMapView;
        }

        private void SegmentChange(object sender, EventArgs e)
        {
            var selectedSegmentId = (int)(sender as UISegmentedControl).SelectedSegment;
            _mapView.LoadMap(_eventsDayMapper[selectedSegmentId]);
        }
    }
}
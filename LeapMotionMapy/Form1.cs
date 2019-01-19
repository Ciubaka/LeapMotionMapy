using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Leap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeapMotionMapy
{
    public partial class Form1 : Form
    {
        private byte[] imagedata = new byte[1];
        private Controller controller = new Controller();
        Bitmap bitmap = new Bitmap(640, 480, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
        List<PointLatLng> _points;
        private int blokada2;
        private int blokada3;
        public Form1()
        {
            InitializeComponent();
            _points = new List<PointLatLng>();
            controller.EventContext = WindowsFormsSynchronizationContext.Current;
            blokada2 = new Int32();
            blokada3 = new Int32();
            controller.FrameReady += newFrameHandler;
            controller.ImageReady += onImageReady;
            controller.ImageRequestFailed += onImageRequestFailed;

            //set greyscale palette for image Bitmap object
            ColorPalette grayscale = bitmap.Palette;
            for (int i = 0; i < 256; i++)
            {
                grayscale.Entries[i] = Color.FromArgb((int)255, i, i, i);
            }
            bitmap.Palette = grayscale;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            map.DragButton = MouseButtons.Left;
            map.CanDragMap = true;
            // map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            //map.IgnoreMarkerOnMouseWheel = true;
            map.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            map.MapProvider = GMapProviders.GoogleMap;
            map.Zoom = 3;
            //txtPrzyklad.Text = _points.Count.ToString();
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyC0azH144FlQ3hP3mS6SLVLISaraYg-sJM";
            //map.SetPositionByKeywords("Warsaw, Poland");
            
            
        }
        void newFrameHandler(object sender, FrameEventArgs eventArgs)
        {
            Frame frame = eventArgs.frame;
            //The following are Label controls added in design view for the form
            //this.displayID.Text = frame.Id.ToString();
            //this.displayTimestamp.Text = frame.Timestamp.ToString();
            //this.displayFPS.Text = frame.CurrentFramesPerSecond.ToString();
            //this.displayHandCount.Text = frame.Hands.Count.ToString();

            
            foreach (Hand hand in frame.Hands)
            {
                float pitch = hand.Direction.Pitch;
                float yaw = hand.Direction.Yaw;
                float roll = hand.PalmNormal.Roll;

                double degPitch = pitch * (180 / Math.PI);
                double degYaw = yaw * (180 / Math.PI);
                double degRoll = roll * (180 / Math.PI);

                txtPrzyklad.Text = _points.Count.ToString() + " " + hand.GrabStrength.ToString();
                //zooom 0-2
                double pitch2 = (degPitch * 3);
                double yaw2 = (degYaw * 3);
                //2-5
                double pitch4 = (degPitch);
                double yaw4 = (degYaw);
                //6-9
                double pitch6 = (degPitch / 3);
                double yaw6 = (degYaw / 3);

                double pitch10 = (degPitch / 6);
                double yaw10 = (degYaw / 6);



                float roll2 = (float)(degRoll / 5);

                var center2 = map.Position;

                if (center2.Lat < 0)
                {
                    txtLat.Text = (-center2.Lat).ToString() + " S";
                }
                else
                {
                    txtLat.Text = center2.Lat.ToString() + " N";
                }
                if (center2.Lng < 0)
                {
                    txtLong.Text = (-center2.Lng).ToString() + " W";
                }
                else
                {
                    txtLong.Text = center2.Lng.ToString() + " E";
                }

                mapZoomik.Text = "Map zoom: " + map.Zoom;
                numberofDetectedHands.Text = "Liczba wykrytcyh rąlk: " + frame.Hands.Count.ToString();
                //ktora dlon

                //map.MouseMove = center2;

                if (frame.Hands.Count != 2)
                {
                    //if(pitch2 > 14 && pitch2 < 24)
                        
                    map.Position = new PointLatLng(pitch2, yaw2);
                    //else
                    //{

                    //}

                    //if()
                    //var cemter = 
                    //map.Position = new
                    blokada2 = 0;
                }
                else
                {
                    if(hand.PalmVelocity.y > 2000 & blokada2 < 1)
                    {
                        var center = map.Position;
                        // PointLatLng point = new PointLatLng(degPitch, degYaw);
                        PointLatLng point = new PointLatLng(center.Lat, center.Lng);
                        AddMarker(point);
                        blokada2++;
                    }
                }

                //if (hand.GrabStrength == 1)
                //{
                //    RemoveAllObject();
                //}
                if(hand.PalmVelocity.x < -2000)
                {
                    RemoveAllObject();
                }

                if ((hand.PalmVelocity.x) > 2000)
                {
                    //var polygon = new GMap.NET.WindowsForms.GMapPolygon(_points, "My Area")
                    //{
                    //    Stroke = new Pen(Color.DarkBlue, 3),
                    //    Fill = new SolidBrush(Color.BurlyWood)
                    //};
                    //var polygons = new GMapOverlay("polygons");
                    //polygons.Polygons.Add(polygon);
                    //map.Overlays.Add(polygons);

                    markPolygon();
                }

                if (hand.IsRight)
                {
                    blokada3 = 0;
                }
                else
                {
                    if (hand.GrabStrength == 1 && blokada3 < 1)
                    {
                        //MapRoute route = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(
                        // _points.First(), _points.Last(), false, false, 15);
                        //GMapRoute r = new GMapRoute(route.Points, "My route")
                        //{
                        //    Stroke = new Pen(Color.Red, 5)
                        //};
                        //GMapOverlay routes = new GMapOverlay("routes");
                        //GMapOverlay routesOverlay = new GMapOverlay("routes");
                        //routesOverlay.Routes.Add(r);
                        //map.Overlays.Add(routesOverlay);
                        //lblDistance.Text = route.Distance + "km";
                        getRoute();
                        blokada3++;
                    }
                }




            }


                controller.RequestImages(frame.Id, Leap.Image.ImageType.DEFAULT, imagedata);
        }

        void onImageRequestFailed(object sender, ImageRequestFailedEventArgs e)
        {
            //if (e.reason == Leap.Image.RequestFailureReason.Insufficient_Buffer)
            //{
            //    imagedata = new byte[e.requiredBufferSize];
            //}
            //Console.WriteLine("Image request failed: " + e.message);
        }

        void onImageReady(object sender, ImageEventArgs e)
        {
            //Rectangle lockArea = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            //BitmapData bitmapData = bitmap.LockBits(lockArea, ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
            //byte[] rawImageData = imagedata;
            //System.Runtime.InteropServices.Marshal.Copy(rawImageData, 0, bitmapData.Scan0, e.image.Width * e.image.Height * 2 * e.image.BytesPerPixel);
            //bitmap.UnlockBits(bitmapData);
            //displayImages.Image = bitmap;
        }


        private void btnLoadIntoMap_Click_1(object sender, EventArgs e)
        {
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            if (txtLat.Text.Length != 0 && txtLong.Text.Length != 0)
            {
                //Loadposition();
                double lat = Convert.ToDouble(txtLat.Text);
                double longt = Convert.ToDouble(txtLong.Text);
                map.Position = new PointLatLng(lat, longt);
            }
            else
            {
                map.Position = new PointLatLng(0, 0);
            }

            map.MinZoom = 2;
            map.MaxZoom = 18;
            map.Zoom = 10;
        }
      private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            RemoveAllObject();
        }
        private void map_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                
                var point = map.FromLocalToLatLng(e.X, e.Y);
                double latt = point.Lat;
                double lngg = point.Lng;
                _points.Add(new PointLatLng(latt, lngg));
                //LoadMap(point);
                AddMarker(point);
                var addresses = GetAddress(point);

                if (addresses != null)
                    txtAddress.Text = String.Join(", ", addresses.ToArray());
                else
                    txtAddress.Text = "Nie mozna zaladowac adresu";
            }
        }

        private void LoadMap(PointLatLng point)
        {
            map.Position = point;
        }

        private void AddMarker(PointLatLng pointToAdd, GMarkerGoogleType markerType = GMarkerGoogleType.arrow)
        {
                _points.Add(pointToAdd);
                var markers = new GMapOverlay("markers");
                var marker = new GMarkerGoogle(pointToAdd, markerType);
                markers.Markers.Add(marker);
                map.Overlays.Add(markers);
                txtLat.Text = pointToAdd.Lat.ToString();
                txtLong.Text = pointToAdd.Lng.ToString();



                //map.Refresh();
        }

        //private void btnClear_Click(object sender, EventArgs e)
        //{
        //    _points.Clear();
        //}

        private void btnGetRoute_Click(object sender, EventArgs e)
        {
            //MapRoute route = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(
            //             _points.First(), _points.Last(), false, false, 15);
            //GMapRoute r = new GMapRoute(route.Points, "My route")
            //{
            //    Stroke = new Pen(Color.Red, 5)
            //};
            //GMapOverlay routes = new GMapOverlay("routes");
            //GMapOverlay routesOverlay = new GMapOverlay("routes");
            //routesOverlay.Routes.Add(r);
            //map.Overlays.Add(routesOverlay);
            //lblDistance.Text = route.Distance + "km";
            getRoute();
        }

        private void btnAddPoly_Click(object sender, EventArgs e)
        {
            markPolygon();
        }

        private void RemoveAllObject()
        {
            if (map.Overlays.Count > 0)
            {
                map.Overlays.RemoveAt(0);
                _points.Clear();
                map.Refresh();
            }
        }

        private void markPolygon()
        {
            var polygon = new GMap.NET.WindowsForms.GMapPolygon(_points, "My Area")
            {
                Stroke = new Pen(Color.DarkBlue, 3),
                Fill = new SolidBrush(Color.BurlyWood)
            };
            var polygons = new GMapOverlay("polygons");
            polygons.Polygons.Add(polygon);
            map.Overlays.Add(polygons);
            map.Refresh();
        }

        private void getRoute()
        {
            if (_points.Count > 1)
            {


                MapRoute route = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(
                             _points.First(), _points.Last(), false, false, 15);
                GMapRoute r = new GMapRoute(route.Points, "My route")
                {
                    Stroke = new Pen(Color.Red, 5)
                };
                GMapOverlay routes = new GMapOverlay("routes");
                GMapOverlay routesOverlay = new GMapOverlay("routes");
                routesOverlay.Routes.Add(r);
                map.Overlays.Add(routesOverlay);
                lblDistance.Text = route.Distance + "km";
            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //e.X
        }
        private List<String> GetAddress(PointLatLng point)
        {
            List<Placemark> placemarks = null;
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyC0azH144FlQ3hP3mS6SLVLISaraYg-sJM";
            var statusCode = GMapProviders.GoogleMap.GetPlacemarks(point, out placemarks);
            txtPrzyklad.Text = statusCode.ToString();
            if (statusCode == GeoCoderStatusCode.OK && placemarks != null)
            {
                List<String> addresses = new List<string>();
                foreach(var placemark in placemarks)
                {
                    addresses.Add(placemark.Address);
                }
                return addresses;
            }
            return null;
        }
    }
}

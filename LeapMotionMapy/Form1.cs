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
        /// <summary>
        /// Inicjowanie/tworzenie obiektu kontrolera - najwazniejszego interfejsu urzadzenia, oraz blokad i listy punktów
        /// </summary>
        //private byte[] imagedata = new byte[1];
        private Controller controller = new Controller();
        //Bitmap bitmap = new Bitmap(400, 200, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
        List<PointLatLng> _points;

        private int blokada;
        private int blokada2;
        private int blokada3;

        /// <summary>
        /// Konstruktor klasy uruchamiającej inicjujący kontrole zdarzeń Leapa'a, generowanie ramek oraz twoerzenie obiektow blokad i listy punktow
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            _points = new List<PointLatLng>();
            controller.EventContext = WindowsFormsSynchronizationContext.Current;
            blokada = new Int32();
            blokada2 = new Int32();
            blokada3 = new Int32();
            controller.FrameReady += newFrameHandler;
            //controller.ImageReady += onImageReady;
            //controller.ImageRequestFailed += onImageRequestFailed;

            //set greyscale palette for image Bitmap object
            //ColorPalette grayscale = bitmap.Palette;
            //for (int i = 0; i < 256; i++)
            //{
            //    grayscale.Entries[i] = Color.FromArgb((int)255, i, i, i);
            //}
            //bitmap.Palette = grayscale;
        }

        /// <summary>
        /// Metoda wywoływana podczas uruchomienia aplikacji, ustawia Google jako dostawce map oraz umożliwia sterowania mapa przy użyciu myszy, Api key w celu wykonywania wszystich 
        /// operacji, uszyskany po załozeniu konta na Cloud'zie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            map.DragButton = MouseButtons.Left;
            map.CanDragMap = true;
            map.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            map.MapProvider = GMapProviders.GoogleMap;
            map.Zoom = 3;
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyC0azH144FlQ3hP3mS6SLVLISaraYg-sJM";
            //map.SetPositionByKeywords("Warsaw, Poland");
            
            
        }
        /// <summary>
        /// Klasa odpowiadajaąca za sterowanie gestami, przechwytuje ramki danych i steruje mapa przy uzyciu wylapanych gestów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs">Przechwytywanie zdarzenia generowania ramek danych</param>
        void newFrameHandler(object sender, FrameEventArgs eventArgs)
        {
            ///Inicjowanie obiektu ramki do przechwytywania ramek danych śledzonych przez kontroler
            Frame frame = eventArgs.frame;
            ///Użycie API Keya w celu swobodnego korzystania z wszyskich metod udostępnianych przez dostawce map Google Maps
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyC0azH144FlQ3hP3mS6SLVLISaraYg-sJM";
     
            ///Wydobywanie obiektu ręki z ramki
            foreach (Hand hand in frame.Hands)
            {
                ///Wyciaganie kątów położenia dłoni w stosunku do 3 płaszczyzn
                float pitch = hand.Direction.Pitch;
                float yaw = hand.Direction.Yaw;
                float roll = hand.PalmNormal.Roll;

                ///przeliczanie kątów na stopnie
                double degPitch = pitch * (180 / Math.PI);
                double degYaw = yaw * (180 / Math.PI);
                double degRoll = roll * (180 / Math.PI);

                ///dostoswowywanie wartości kątów do wartości współrzędnych w celu swodbonego poruszania po mapie
                double pitch2 = (degPitch * 3);
                double yaw2 = (degYaw * 3);

                ///pobieranie artualnych wartości współrzenych wskaźnika-czerwonego krzyża- z mapy
                var center2 = map.Position;
                ///ustawianie oraz wyświetlanie akutalnych watości współrzędnych wskaźnika
                setCoordinates(center2);

                ///wyświetlanie aktualnego  poziomu przybliżenia mapy
                mapZoomik.Text = map.Zoom.ToString();
                ///wyświetlanie aktualnego watości liczby dłoni wykrytej przez kontroler
                numberofDetectedHands.Text = frame.Hands.Count.ToString();
                //wyświetlanie aktualnej dłoni sterujacej 
                ///=
                ///

                ///
                ///Zmiana watości aktualnej odległosci palca wskazującego od kciuka dłoni sterującej
                ///
                ///Jeżeli odległość palca wskazującego od kciuka zwiększy się do ponad 90 mm przybliż mapę 
                if (hand.PinchDistance > 90 && blokada < 2)
                {
                    map.Zoom += 1;
                    blokada++;
                }
                ///Jeżeli odległość palca wskazującego od kciuka zmnieszy się do mniej niż 20mm - oddalmapę 90 mm  
                else if (hand.PinchDistance < 20 && blokada > 0)
                {
                    map.Zoom -= 1;
                    blokada--;
                }


                ///jeżeli konroler nie wykrył dwóch dłoni w polu śledzenia
                if (frame.Hands.Count != 2)
                {
                    ///steruj położeniem mapy według wczęsniej ustalonych zakresów wartości                        
                    map.Position = new PointLatLng(pitch2,yaw2);
                    ///zmien watość blokady sterującej możliwościa zaznaczanie punktu na mapie na 0
                    blokada2 = 0;
                }

                ///jeżeli wykrył dwie dłonie w polu śledzenia zatrzymaj wskaźnik - nie kieruj polozeniem mapy
                else
                {
                    ///jezeli predkośc ruchu dłoni w góre przekroczy 2000mm/s i blokada bedzie mniejsza od 1 wykonaj 
                    if(hand.PalmVelocity.y > 2000 & blokada2 < 1)
                    {
                        ///pobierz współrzędne geograficzne zatrzymanego wskaźnika do zmiennej center
                        PointLatLng center = map.Position;
                        ///wykonaj funckję dodająca punkt do mapy podając w argumencie współrzędne kursora
                        AddMarker(center);
                        ///wykonaj funcję określająca dokładna lokalizację zaznaczonego punktu podajac w agumencie współrzedne zaznaczonego punktu
                        var addresses = GetAddress(center);
                        ///sprawdz czy rezultat wykoniania funcji nie zwróci pustego pola, jeżeli nie wyświetl lokalizację w polu txtAddress
                        if (addresses != null)
                            txtAddress.Text = String.Join(", ", addresses.ToArray());
                        else
                            ///jeżeli dostawca map nie ma informacji o dodanym punkcie, wyswietl string z informacją
                            txtAddress.Text = "Nie mozna zaladowac adresu";
                        ///zwiększ wartość blokady sterującej możliwościa zaznaczania punktów na mapie w celu zaznaczenia tylko jednego ppunktu za ednym razem
                        blokada2++;
                    }
                }
                

                ///gest pozwalający usunąc wszystkie zaznaczone punknty, trasy, obszary z mapy
                ///jeżeli prędkość ruchu dłoni w lewo przekroczy 2000mm/s wykonaj funckję czyszczenia mapy
                if(hand.PalmVelocity.x < -2000)
                {
                    RemoveAllObject();
                }


                ///gest pozwalający zaznaczyć obszar mapy ograniczony wcześniej zaznaczonymi punktami
                ///jeżeli prędkość ruchu dłoni w prawo przekroczy 2000mm/s wykonaj funckję zaznaczania obszaru mapy
                if ((hand.PalmVelocity.x) > 2000)
                {
                    markPolygon(_points);
                }


                ///gest pozwalający  wyznaczyć trasę z punktu początkowego do końcowego
                ///gest może być wykonany tylko prawą dłonią
                ///jeżeli jest lewa
                if (hand.IsLeft)
                {
                    ///zmień wartość blokady sterującej możliwościa  wyznacznia tras z punktu do punktu na  zero w celu ponownego korzystania z możliwości wyznaczania tras
                    blokada3 = 0;
                }
                ///jeżeli prawa dłon jest dłonią sterującą
                else
                {
                    ///sprawdz czy jest ona zaciśnięta w pięść i czy blokada pozwala na wykonianie fukncji
                    if (hand.GrabStrength == 1 && blokada3 < 1)
                    {
                        ///jezeli tak wykonanj funcję wyznaczająca trasę między punktami 
                       getRoute();
                        ///zwiększ wartość blokady sterującej możliwościa wyznacznia tras z punktu do punktu w celu wyznaczenia tylko jednej trasy za jednym razem
                        blokada3++;
                    }
                }

            }


                //controller.RequestImages(frame.Id, Leap.Image.ImageType.DEFAULT, imagedata);
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

        /// <summary>
        /// dla alternatywnego interfejsu, przycisk pozwalający załadować mapę w szerokości i długości geograicznej wpisanej w polach oraz określeniu podstawowych wartości mapy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadIntoMap_Click_1(object sender, EventArgs e)
        {
            ///możliwość przesuwania mapy przy użyciu lewego przycisku myszy
            map.DragButton = MouseButtons.Left;
            ///ustalenie Google jako dostawcy map
            map.MapProvider = GMapProviders.GoogleMap;
            ///dodanie indywidualnego API Key'a umożlwiającego korzystanie w pełni z zasobów dostawcy
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyC0azH144FlQ3hP3mS6SLVLISaraYg-sJM";

            ///jeżeli pola dotyczące długości i szerokości będą wpisane współrzędne
            if (txtLat.Text.Length != 0 && txtLong.Text.Length != 0)
            {
                ///przekonvertuj je do zmiennej double 
                double lat = Convert.ToDouble(txtLat.Text);
                double longt = Convert.ToDouble(txtLong.Text);
                ///i ustaw jako pozycję mapy, kursora
                map.Position = new PointLatLng(lat, longt);
            }
            ///jeżeli nie ustaw kursor na wspołrzednych 0,0
            else
            {
                map.Position = new PointLatLng(0, 0);
            }
            ///ustaw minimalny poziom oddalenia mapy
            map.MinZoom = 2;
            ///ustaw max poziom przyblizenia mapy
            map.MaxZoom = 18;
            ///ustaw domyślny poziom skali mapy
            map.Zoom = 10;
        }

        /// <summary>
        /// dla alterntywnego interfejsu, przycisk wywołujący funkcję usuwania wszystkich zaznaczonych punktów, tras i obszarów z mapy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            RemoveAllObject();
        }


        /// <summary>
        /// dla alternatywnego intefejsu, pozwala na dodawanie punktów do mapy za pomoca prawego przycisku myszy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void map_MouseClick(object sender, MouseEventArgs e)
        {
            ///sprawdza czy wcisniety został prawy przycisk myszy
            if(e.Button == MouseButtons.Right)
            {
                ///jezeli tak to pobierz wartości wspołrzednych x i y z mapy i zapisz w  zmiennych double latt i lngg
                var point = map.FromLocalToLatLng(e.X, e.Y);
                double latt = point.Lat;
                double lngg = point.Lng;
                ///dodaj punkt stworzony z wspołrzednych prawego przycisku do listy zaznaczonych puntków
                _points.Add(new PointLatLng(latt, lngg));
                ///wykonaj funcję dodawania punktu do mapy
                AddMarker(point);

                var addresses = GetAddress(point);
                ///sprawdz czy rezultat wykoniania funcji nie zwróci pustego pola, jeżeli nie wyświetl lokalizację w polu txtAddress
                if (addresses != null)
                    txtAddress.Text = String.Join(", ", addresses.ToArray());
                else
                    ///jeżeli dostawca map nie ma informacji o dodanym punkcie, wyswietl string z informacją
                    txtAddress.Text = "Nie mozna zaladowac adresu";
            }
        }

        /// <summary>
        /// funkcja ładujaca mapę na konretnym, wskazanym przez wartości współrzednych punktu dodanego w parametrze punkcie
        /// </summary>
        /// <param name="point"></param>
        private void LoadMap(PointLatLng point)
        {
            map.Position = point;
        }


        /// <summary>
        /// funcja dodająca punkt do mapy
        /// </summary>
        /// <param name="pointToAdd">punkt którego wspołrzedne określaja miejsce dodania markera na mapie</param>
        /// <param name="markerType">typ markera zaznaczonego na mapie</param>
        private void AddMarker(PointLatLng pointToAdd, GMarkerGoogleType markerType = GMarkerGoogleType.red_big_stop)
        {
                _points.Add(pointToAdd);
                GMapOverlay markers = new GMapOverlay("markers");
                GMarkerGoogle marker = new GMarkerGoogle(pointToAdd, markerType);
                markers.Markers.Add(marker);
                map.Overlays.Add(markers);
                ///wywołanie funcji wyświetlania dodanego puntu w polach widocznych w interfejsie użytkownika
                setCoordinates(pointToAdd);
                ///odśwież mapę w celu zobaczenia nałożonych punktów
                map.Refresh();
        }


   
        /// <summary>
        /// funkcja wyświeltająca wartości współrzędnych geograficznych w interfejsie, zaokrąglone do 2 miejsc po przecinku
        /// </summary>
        /// <param name="point"></param>
        private void setCoordinates(PointLatLng point)
        {
            ///wyciaganie z punktu wartości szerkokości i długości geograficznych
            var szerokosc = Math.Round(point.Lat, 2, MidpointRounding.AwayFromZero);
            var dlugosc = Math.Round(point.Lng, 2, MidpointRounding.AwayFromZero);

            if (szerokosc < 0)
            {
                txtLat.Text = szerokosc < -90 ? "90.00 S" : (-szerokosc).ToString() + " S";
            }
            else
            {
                txtLat.Text = szerokosc > 90 ? "90.00 N" : szerokosc.ToString() + " N";
            }

            if (dlugosc < 0)
            {
                txtLong.Text = dlugosc < -180 ? "180.00 W" : (-dlugosc).ToString() + " W";
            }
            else
            {
                txtLong.Text = dlugosc > 180 ? "180.00 E" : dlugosc.ToString() + " E";
            }
        }

        /// <summary>
        /// dla interfjesu alternatynego, wyznaczanie trasy miedzy punktami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetRoute_Click(object sender, EventArgs e)
        {
           getRoute();
        }

        /// <summary>
        /// dla interfjesu alternatywnego, zaznaczanie obszaru mapy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPoly_Click(object sender, EventArgs e)
        {
            markPolygon(_points);
        }


        /// <summary>
        /// fukncja usuwaniająca/czyszczaca zaznaczone punkty, trasy i obszary z trasy 
        /// </summary>
        private void RemoveAllObject()
        {
            if (map.Overlays.Count > 0)
            {
                map.Overlays.RemoveAt(0);
                _points.Clear();
                txtAddress.Clear();
                lblDistance.Text = "";
                txtPolygonArea.Text = "";
                map.Refresh();
            }
        }


        /// <summary>
        /// funkcja zaznaczajaca obszary na mapie
        /// </summary>
        /// <param name="poinT"></param>
        private void markPolygon(List<PointLatLng> poinT)
        {
            if (poinT.Count > 2)
            {
                var polygon = new GMapPolygon(_points, "My Area")
            {
                Stroke = new Pen(Color.DarkGreen, 3),
                Fill = new SolidBrush(Color.DarkBlue)
            };
                var polygons = new GMapOverlay("polygons");
                polygons.Polygons.Add(polygon);
                map.Overlays.Add(polygons);
                ///obliczanie pola powierzchni zaznaczonego obszaru
                txtPolygonArea.Text =  calculatePolygonAreas(poinT);
                map.Refresh();
            }
        }

        /// <summary>
        /// funkcja obliczajaca pole powierzchni zaznaczonego obszaru
        /// </summary>
        /// <param name="coords"></param>
        /// <returns>zwraca pole powierzchni w metrach kwadratowych, hektarach albo kilometrach kwadratowych</returns>
        private string calculatePolygonAreas(List<PointLatLng> coords)
        {
            IList<PointLatLng> points = new List<PointLatLng>();
            foreach (PointLatLng coord in coords)
            {
                PointLatLng p = new PointLatLng(
                  coord.Lng * (System.Math.PI * 6378137 / 180),
                  coord.Lat * (System.Math.PI * 6378137 / 180)
                );
                points.Add(p);
            }
            points.Add(points[0]);
            var area1 = Math.Abs(points.Take(points.Count - 1)
              .Select((p, i) => (points[i + 1].Lat - p.Lat) * (points[i + 1].Lng + p.Lng))
              .Sum() / 2);
            
            double area  = Math.Round(area1, 2, MidpointRounding.AwayFromZero);

            if (area > 10000)
            {
                return (area > 1000000) ? Math.Round((area / 1000000), 2, MidpointRounding.AwayFromZero).ToString() + " km2" : Math.Round((area / 10000), 2, MidpointRounding.AwayFromZero).ToString() + " ha";
            }
            else
            {
                return Math.Round(area, 2, MidpointRounding.AwayFromZero).ToString() + " m2";
            }
        }


        /// <summary>
        /// funkcja wyznaczajaca trasę miedzy punktami zaznaczonymi na mapie
        /// </summary>
        private void getRoute()
        {
            if (_points.Count > 1)
            {

                MapRoute route = GoogleMapProvider.Instance.GetRoute(
                             _points.First(), _points.Last(), false, false, 15);
                GMapRoute r = new GMapRoute(route.Points, "My route")
                {
                    Stroke = new Pen(Color.Red, 5)
                };
                GMapOverlay routesOverlay = new GMapOverlay("routes");
                routesOverlay.Routes.Add(r);
                map.Overlays.Add(routesOverlay);
                lblDistance.Text = route.Distance + "km";
                map.Refresh();
            }
        }


        /// <summary>
        /// funckja określająca i wyświetlajaąca dokladna lokalizacje punktu na mapie
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private List<String> GetAddress(PointLatLng point)
        {
            List<Placemark> placemarks = null;
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyC0azH144FlQ3hP3mS6SLVLISaraYg-sJM";
            var statusCode = GMapProviders.GoogleMap.GetPlacemarks(point, out placemarks);
            //txtPrzyklad.Text = statusCode.ToString();
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

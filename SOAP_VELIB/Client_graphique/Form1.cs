using Client.ServiceReference1;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_graphique
{
    public partial class Form1 : Form
    {

        VelibOperationClient service;
        City selected_city;
        City[] cities;
        Station[] stations;
        Station selected_station;

        public Form1()
        {
            InitializeComponent();
            service = new VelibOperationClient();
            cities = service.GetCities();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(City city in cities)
            {
                this.listBox1.Items.Add(city.Name);
            }            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = ""+selected_station.Available_Velib;
            map.ShowCenter = false;
            map.MapProvider = GMapProviders.GoogleMap;
            map.Position = new GMap.NET.PointLatLng(selected_station.Latitude, selected_station.Longitude);
            map.MinZoom = 5;
            map.MaxZoom = 100;
            map.Zoom = 10;
            map.DragButton = MouseButtons.Left;
            map.MouseWheelZoomEnabled = true;
            GMapOverlay markers = new GMapOverlay("markers");
            GMapMarker marker = new GMarkerGoogle(new GMap.NET.PointLatLng(selected_station.Latitude, selected_station.Longitude),
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red);
            markers.Markers.Clear();
            map.Overlays.Clear();
            markers.Markers.Add(marker);
            map.Overlays.Add(markers);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string current_item = listBox1.SelectedItem.ToString();
            int index = listBox1.FindString(current_item);
            selected_city = cities[index];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            stations = service.GetVelibStations(selected_city);
            foreach(Station station in stations)
            {
                this.listBox2.Items.Add(station.Name);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string current_item = listBox2.SelectedItem.ToString();
            int index = listBox2.FindString(current_item);
            selected_station = stations[index];
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {            
            
        }
    }
}

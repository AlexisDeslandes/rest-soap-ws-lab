using Monitoring.ServiceReference1;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Monitoring
{
    public partial class Form1 : Form
    {

        static IMonitoringOperation service;
        private string client_count_string = "Client count";
        private string request_count = "Request count";
        private string request_service_count = "Request service count";
        private string average_delay_string = "Average delay";
        private string montant = "Montant";     

        public Form1()
        {
            InitializeComponent();
            service = new MonitoringOperationClient();
            initialise_chart();            
        }

        private void maj_client_count()
        {                                    
            this.chart1.Series[montant].Points.AddXY(client_count_string, service.getClientCount());
        }

        private void maj_request_count()
        {
            this.chart1.Series[montant].Points.AddXY(request_count, service.getNumberOfRequestSinceStart());
        }

        private void maj_request_service_count()
        {
            this.chart1.Series[montant].Points.AddXY(request_service_count, service.getNumberOfRequestForWSVelib());
        }

        private void maj_avg_delay()
        {
            this.chart1.Series[montant].Points.AddXY(average_delay_string, service.getAverageDelayForResponse());
        }



        private void initialise_chart()
        {
            this.chart1.Series[montant].Points.Clear();
            maj_client_count();                        
            maj_avg_delay();
            maj_request_service_count();
            maj_request_count();
            maj_ips();
        }

        private void maj_ips()
        {
            this.listBox1.Items.Clear();
            string[] ips = service.getIPClientsConnected();
            foreach(string ip in ips)
            {
                this.listBox1.Items.Add(ip);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            initialise_chart();
        }        

        private void button5_Click(object sender, EventArgs e)
        {
            maj_ips();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}

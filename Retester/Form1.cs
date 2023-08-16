using Npgsql;
using Opc.Ua;
using Opc.UaFx;
using Opc.UaFx.Client;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace Retester
{
    public partial class Form1 : Form
    {
        OpcClient client;
        int tempo = 5000;

        List<Retest> allParts = new List<Retest>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = this.OpcUaServerConnect();
            //client = await this.OpcUaServerConnectAsync();
            textBox_SP.Text = "SP130.01";
            textBox_OP.Text = "OP135";
            textBox_SOP.Text = "01";
            textBox_tempo.Text = tempo.ToString();
        }

        private OpcClient OpcUaServerConnect()
        {
            var endpointUrl = "opc.tcp://10.100.1.2:5776";
            var connectionTimeout = TimeSpan.FromSeconds(10);

            MessageBoxIcon errorIcon = MessageBoxIcon.Error;
            MessageBoxButtons button = MessageBoxButtons.OK;
            OpcClient client = new OpcClient(endpointUrl);
            try
            {
                client.Connect();
                Console.WriteLine("Connected to OPC UA server.");
                label_connected.Text = "Connecté";
                label_connected.ForeColor = Color.Green;
            }
            catch (OpcException ex)
            {
                MessageBox.Show($"Impossible de se connecter au line middleware {ex.Message} ", "Erreur", button, errorIcon);
                throw new TimeoutException("Connection to OPC UA server timed out.");
            }
            catch (Exception ex) { MessageBox.Show($"Impossible de se connecter au line middleware {ex.Message} ", "Erreur", button, errorIcon); }
            return client;
        }

        private async Task<OpcClient> OpcUaServerConnectAsync()
        {
            var endpointUrl = "opc.tcp://10.100.1.2:5776";
            var connectionTimeout = TimeSpan.FromSeconds(10);

            MessageBoxIcon errorIcon = MessageBoxIcon.Error;
            MessageBoxButtons button = MessageBoxButtons.OK;
            OpcClient client = new OpcClient(endpointUrl);

            try
            {
                var connectTask = Task.Run(() => client.Connect());
                var timeoutTask = Task.Delay(connectionTimeout);

                var completedTask = await Task.WhenAny(connectTask, timeoutTask);

                if (completedTask == connectTask)
                {
                    await connectTask;
                    Console.WriteLine("Connected to OPC UA server.");
                    MessageBox.Show("Connecté au Line Middleware Stator");
                }
                else
                {
                    MessageBox.Show("Impossible de se connecter au line middleware", "Erreur", button, errorIcon);
                    throw new TimeoutException("Connection to OPC UA server timed out.");
                }
            }
            catch (OpcException ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}");
            }
            return client;
        }

        private void button_retest_Click(object sender, EventArgs e)
        {
            button_retest.BackColor = Color.Gray;
            button_retest.Enabled = false;
            string textBox_DMC_input_content = textBox_DMC_input.Text;
            string[] allDmcs = textBox_DMC_input_content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            //Connexion à KPITR
            string connectionString = "Host=10.57.107.15;" +
                                    "Port=5432;" +
                                    "Database=kpitr;" +
                                    "Username=produser1;" +
                                    "Password=userprod1";
            NpgsqlConnection kpitrConnection = new NpgsqlConnection(connectionString);
            kpitrConnection.Open();

            int indexLine = 0;
            foreach (string dmc in allDmcs)
            {
                Retest retest = new Retest(kpitrConnection, dmc);
                bool is_tracking_id_ok = retest.FindTrackingId();
                ScanVerdict(is_tracking_id_ok);
                if (!is_tracking_id_ok) { break; }
                
                //Set Infos form TextBoxs
                SetInfosFromInputs(ref retest);

                tempo = int.Parse(textBox_tempo.Text);

                try
                {
                    while (client.State != OpcClientState.Connected)
                    {
                        label_connected.Text = client.State.ToString();
                        label_connected.ForeColor = Color.Yellow;
                        Thread.Sleep(6000);
                    }
                    label_connected.Text = "Connecté";
                    label_connected.ForeColor = Color.Green;

                    //Call the Method
                    
                    Thread.Sleep(tempo);
                    string rescode = retest.CallMethod(client);
                    if(rescode=="0") { textBox_method_validation.Text = textBox_method_validation.Text + "OK " + rescode + Environment.NewLine; }
                    else { textBox_method_validation.Text = textBox_method_validation.Text + "Nok " + rescode + Environment.NewLine; }
                    allParts.Add(retest);
                    indexLine = indexLine + 1;
                    textBox_comment.Text += retest.Get_tracking_id() + Environment.NewLine;

                }
                catch (System.ComponentModel.LicenseException ex) { MessageBox.Show("Relancer le programme car : " + ex.Message + Environment.NewLine + "Le nombre de pièces déjà faites sont de " + indexLine); }
            }
            button_retest.BackColor = Color.DarkCyan;
            button_retest.Enabled = true;
            kpitrConnection.Close();

        }

        private void ScanVerdict(bool is_tracking_id_ok)
        {
            if (is_tracking_id_ok)
            {
                label_scan.Text = "Scan OK";
                label_scan.ForeColor = Color.Green;
            }
            else
            {
                label_scan.Text = "Scan NOK";
                label_scan.ForeColor = Color.Red;
            }
        }

        private void SetInfosFromInputs(ref Retest retest)
        {
            retest.Set_exit_by_op(textBox_SP.Text);
            retest.Set_last_op_working(textBox_OP.Text);
            retest.Set_last_ssop_working(textBox_SOP.Text);
            //if (textBox_comment.Text != "") { retest.Set_comment(textBox_comment.Text); }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                client.Disconnect();
            }
            catch (System.ComponentModel.LicenseException)
            {
                Console.WriteLine("fermeture");
            }
        }

        private void label_tempo_Click(object sender, EventArgs e)
        {

        }
    }
}
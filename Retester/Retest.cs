using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Opc.UaFx.Client;
using static System.Windows.Forms.LinkLabel;

namespace Retester
{
    internal class Retest
    {
        private string dmc;
        private string tracking_id;
        private string exit_by_op;
        private string last_op_working;
        private string last_ssop_working;
        private string operator_name = "Retester";
        private string comment = "Retester en lot";
        private int lineInTextBox;
        private NpgsqlConnection connection;

        public Retest(NpgsqlConnection _connection, string _dmc, string _tracking_id="", string _exit_by_op = "", string _last_op_working = "", string _last_ssop_working = "")
        {
            dmc = _dmc;
            tracking_id = _tracking_id;
            exit_by_op = _exit_by_op;
            last_op_working = _last_op_working;
            last_ssop_working = _last_ssop_working;
            connection = _connection;
        }

        public bool FindTrackingId()
        {
            try
            {
                using (var command = new NpgsqlCommand("SELECT tracking_id FROM kpitr.part_produce WHERE supplier_id like '" + this.dmc + "' order by time_stamp DESC LIMIT 1", this.connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if(reader.Read()) 
                        {
                            this.tracking_id = reader.GetString(0);
                        }
                        else
                        {
                            MessageBox.Show("Impossible de retrouver la pièce : " + dmc);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur de l'execution de lma requete SQL, pièce : " + dmc + " ; message d'erreur: " + ex.Message);
                return false;
            }
            return true;
        }

        public string CallMethod(OpcClient _client)
        {
            object[] result = _client.CallMethod(
                    "ns=4;s=Stator",
                    "ns=4;s=Stator.SetWaitingRetest",      
                    tracking_id,
                    exit_by_op,
                    last_op_working,
                    last_ssop_working,
                    operator_name,
                    comment);
            return (result[0].ToString());
        }

        public void Set_exit_by_op(string _) {this.exit_by_op = _;}
        public void Set_last_op_working(string _) { this.last_op_working = _; }
        public void Set_last_ssop_working(string _) { this.last_ssop_working = _; }
        public void Set_comment(string _) { this.comment = _; }
        public string Get_tracking_id() { return this.tracking_id; }

    }
}

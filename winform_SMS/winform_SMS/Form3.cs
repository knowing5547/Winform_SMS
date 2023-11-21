using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;


namespace winform_SMS
{
    public partial class Form3 : Form
    {
        DataTable dt7 = new DataTable();
        DataTable dt5_Load = new DataTable();
        Form1 _Form1;

        public Form3(Form1 _Form1_Data)
        {
            InitializeComponent();
            _Form1 = _Form1_Data;
        }

        public void AddressData(DataTable dt)
        {
            dt5_Load = dt;
        }

        public void dgv1Data()
        {
            dt7.Columns.Clear();
            dt7.Columns.Add("이름");
            dt7.Columns.Add("전화번호");
            dt7.Columns.Add("이메일");
            dt7.Columns.Add("그룹");

            DataRow row = dt7.NewRow();

            if (dt5_Load.Rows.Count > 0)
            {
                for (int i = 0; i < dt5_Load.Rows.Count; i++)
                {
                    row["이름"] = dt5_Load.Rows[i][0];
                    row["전화번호"] = dt5_Load.Rows[i][1];
                    row["이메일"] = dt5_Load.Rows[i][2];
                    row["그룹"] = dt5_Load.Rows[i][3];
                    dt7.Rows.Add(row.ItemArray);

                    string strName = Convert.ToString(dt7.Rows[i][0]);
                    comboBox1.Items.Add(strName);
                }
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dgv1Data();
        }
    }
}

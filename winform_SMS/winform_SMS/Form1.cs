using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace winform_SMS
{
    public partial class Form1 : Form
    {
        DataTable dt5 = new DataTable();
        DataTable dt6 = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        public void setAddress(DataTable Form2Datatable)
        {
            dt5 = Form2Datatable;
        }

        public void setGroup(DataTable Form2_1Datatable)
        {
            dt6 = Form2_1Datatable;
        }

        // 전화번호부 연결
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 _Form2 = new Form2(this);
            _Form2.dt3_Groupdata1(dt5);
            _Form2.dt2_Groupdata1(dt6);
            _Form2.ShowDialog();
        }

        // 메세지보내기 연결
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 _Form3 = new Form3(this);
            _Form3.AddressData(dt5);
            _Form3.ShowDialog();
        }
    }
}

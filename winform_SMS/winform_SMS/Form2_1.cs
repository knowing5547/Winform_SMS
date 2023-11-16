using Google.Cloud.Firestore;
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
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

namespace winform_SMS
{
    public partial class Form2_1 : Form
    {
        DataTable dt1 = new DataTable();
        FirestoreDb db;
        int i = 0;
        Form2 _Form2;

        public Form2_1(Form2 _Form2_Data)
        {
            InitializeComponent();
            
            _Form2 = _Form2_Data;
        }

        // dt 기본 설정
        void dgv1Data()
        {
            dt1.Columns.Clear();
            dt1.Columns.Add("번호");
            dt1.Columns.Add("그룹");
            dataGridView1.DataSource = dt1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }



        // Form2_1 Load시 firabase 연동
        private void Form2_1_Load(object sender, EventArgs e)
        {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"winformsms-firebase-adminsdk-7dyve-b38ad43492.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

                db = FirestoreDb.Create("(default)");

                dgv1Data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // String.IsNullOrEmpty 함수는 문자열이 비어있으면 true, 그렇지않으면 false
            if (!(String.IsNullOrEmpty(textBox1.Text)))
            {
                i++;
                DataRow row = dt1.NewRow();
                row["번호"] = i;
                row["그룹"] = textBox1.Text;
                dt1.Rows.Add(row);
                dataGridView1.DataSource = dt1;

                textBox1.Clear();

                // textbox1으로 다시 포커싱 가도록 설정
                this.ActiveControl = textBox1;
            }
            else;
                this.ActiveControl = textBox1;

        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            
            DataGridViewRow CR = dataGridView1.CurrentRow;

            if (CR == null)
            {
                MessageBox.Show("삭제할 행을 먼저 선택하십시오.");
                return;
            }

            int ID = dataGridView1.CurrentRow.Index;
            DataRow row = dt1.Rows[ID];
            row.Delete();

            /*
            // 특정 행이 삭제될 시 번호칸을 1부터 끝까지 돌리기
            for(int j = 1; j < dt.Rows.Count; j++)
            {
                dt.Rows["번호"].clear();
                row["번호"] = j;
                dt.Rows.Add(row);
                dataGridView1.DataSource = dt;
            }
            */

        }

        // 버튼 클릭시 Form2_1의 데이터를 Form2에 전송
        private void button3_Click(object sender, EventArgs e)
        {
            _Form2.setGroup(dt1);
            this.Close();
            
        }
    }
}

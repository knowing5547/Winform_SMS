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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace winform_SMS
{
    public partial class Form2 : Form
    {
        int N = 0;
        int ID_Get = 0;
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();

        public Form2()
        {
            InitializeComponent();
        }

        // DataGridView1 기본 값 정리
        public void dgv1Data()
        {
            dt3.Columns.Clear();
            dt3.Columns.Add("이름");
            dt3.Columns.Add("전화번호");
            dt3.Columns.Add("이메일");
            dt3.Columns.Add("그룹");
            dataGridView1.DataSource = dt3;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        // Form2_1의 Group DataTable을 Form2의 combobox1으로 이전
        public void setGroup(DataTable Form2_1Datatable)
        {
            dt2 = Form2_1Datatable;

            // comboBox1.DisplayMember = "Name";
            // comboBox1.ValueMember = "Num";

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    string strName = Convert.ToString(dt2.Rows[i][j]);
                    comboBox1.Items.Add(strName);
                }
            }
        }

        // textBox 공백 일괄 검사
        private bool TextCheck()
        {
            if (this.textBox1.Text != "" && this.textBox2.Text != "" && this.textBox3.Text != ""&& this.comboBox1.Text != "")
            {
                return true;
            }
            else
                return false;
        }

        // dataGridView1_CellMouseDoubleClick 에 넣을거
        public void data_Selected()
        {
            int ID = dataGridView1.CurrentRow.Index;
            ID_Get = ID;
            DataRow dt3_row = dt3.Rows[ID];
            int M = 0;

            for (int j = 1; j <= 3; j++)
            {
                string tb_Value = Convert.ToString(dt3_row[j - 1]);
                this.Controls["textBox" + j].Text = "";
                this.Controls["textBox" + j].Text = tb_Value;
                M++;

                if (M == 2)
                {
                    string cb_Value = Convert.ToString(dt3_row[3]);
                    // k 반복을 3열(그룹) 부분에 돌려서 선택한 부분이랑 같은 걸 찾아내기
                    for (int k = 0; k < dt3.Rows.Count; k++)
                    {
                        if (cb_Value == Convert.ToString(dt3.Rows[k][3]))
                        {
                            // comboBox를 dropdownlist로 만들어두면 readonly 상태가 되서
                            // selectedText는 아예 안먹고, selectedIndex만 먹음
                            // selectedIndex는 기본 빈값이 -1이고, 0,1,2에서 점점 늘어나는 값을 가지고있기때문에
                            // 선택한 부분이랑 같은 행을 찾아서 넣어준것
                            this.comboBox1.SelectedIndex = k;
                        }
                    }
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dgv1Data();
        }

        // 주소록 추가 (이름 / 전화번호 / 이메일 / 그룹)
        private void button1_Click(object sender, EventArgs e)
        {
            if (TextCheck() == true)
            {
                DataRow row = dt3.NewRow();
                row["이름"] = textBox1.Text;
                row["전화번호"] = textBox2.Text;
                row["이메일"] = textBox3.Text;
                row["그룹"] = comboBox1.SelectedItem;



                dt3.Rows.Add(row);
                dataGridView1.DataSource = dt3;

                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.comboBox1.SelectedIndex = -1; // 값을 -1로 둬야 빈값이 나옴
            }
            else
            {
                MessageBox.Show("빈 칸이 존재합니다.");
            }
        }

        // 주소록 수정
        // 11/17_12:59 이어서하기
        private void button9_Click(object sender, EventArgs e)
        {
            if (!(TextCheck() == true))
            {
                DataRow dt3_row = dt3.Rows[ID_get];
                dt3_row["이름"] = textBox1.Text;
                dt3_row["전화번호"] = textBox2.Text;
                dt3_row["이메일"] = textBox3.Text;
                dt3_row["그룹"] = comboBox1.SelectedItem;

                dt3.Rows.Add(dt3_row);
            }
        }

        // 주소록 삭제
        private void button10_Click(object sender, EventArgs e)
        {
            DataGridViewRow CR = dataGridView1.CurrentRow;

            if (CR == null)
            {
                MessageBox.Show("삭제할 행을 먼저 선택하십시오.");
                return;
            }

            int ID = dataGridView1.CurrentRow.Index;
            DataRow row = dt3.Rows[ID];
            row.Delete();
        }

        // 주소록 입력중 초기화
        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.comboBox1.SelectedIndex = -1;
        }

        // Form2_1 모달로 생성
        private void button6_Click(object sender, EventArgs e)
        {
            Form2_1 _Form2_1 = new Form2_1(this);
            _Form2_1.ShowDialog();

        }
        public int ID_get
        {
            get { return ID_get; }
        }
        // dataGridView1 더블클릭시 해당 row 값 옮겨담기 
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            data_Selected();
        }
    }
}

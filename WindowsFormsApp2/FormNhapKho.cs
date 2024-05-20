using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.OleDb;


namespace WindowsFormsApp2
{
    public partial class FormNhapKho : Form
    {
        DataTable table = new DataTable("DuLieuNhapKho");
        string text_sc = string.Empty;

        public FormNhapKho()
        {
            InitializeComponent();
        }

        private void FormNhapKho_Load(object sender, EventArgs e)
        {
            table.Columns.Add("PITEMID", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("POREQNO", typeof(string));
            table.Columns.Add("SNO", typeof(string));
            table.Columns.Add("CUSTNO", typeof(string));
            table.Columns.Add("ITEMFULL", typeof(string));
            table.Columns.Add("TYPE", typeof(string));
            table.Columns.Add("SIJIDT", typeof(string));
            table.Columns.Add("ID_NV", typeof(string));


            dataGridViewNk.DataSource = table;
            foreach (DataGridViewColumn col in dataGridViewNk.Columns)
            {
                col.HeaderText = col.Name;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridViewNk.Columns["ID_NV"].ReadOnly = true;
            dataGridViewNk.Columns["POREQNO"].ReadOnly = true;
            dataGridViewNk.Columns["SNO"].ReadOnly = true;
            dataGridViewNk.Columns["CUSTNO"].ReadOnly = true;

            dataGridViewNk.Columns["CUSTNO"].Width = 134;
            dataGridViewNk.Columns["ITEMFULL"].ReadOnly = true;
            //dataGridViewNk.Columns["QTY"].ReadOnly = true;
            dataGridViewNk.Columns["PITEMID"].ReadOnly = true;
            dataGridViewNk.Columns["TYPE"].ReadOnly = true;
            dataGridViewNk.Columns["SIJIDT"].ReadOnly = true;


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                if (e.KeyChar == 13)
                {
                    txtID.Enabled = false;
                    txtQRcode.Enabled = true;
                    ckbID.Checked = true;
                    txtQRcode.Focus();
                }
            }
        }

        private void txtQRcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            string[] rows = new string[9];
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                text_sc = txtQRcode.Text;
                string MaNV = txtID.Text;
                if (e.KeyChar == 13)
                {
                    if (radDefault.Checked ==true)
                    {
                        try
                        {
                            //using (OracleConnection connection = new OracleConnection(ConnectionDatabase.cn_oracle))
                            //{
                            //    if (connection.State == ConnectionState.Closed) connection.Open();
                            using (SqlConnection connection = new SqlConnection(ConnectionDatabase.connString059))
                            {
                                if (connection.State == ConnectionState.Closed) connection.Open();
                                txtQRcode.Clear();
                                string sChuoi;
                                string[] arrListStr = text_sc.Split(',');
                                sChuoi = arrListStr[1];

                                //string query = @"Select PITEMID,QTY,POREQNO,SNO,CUSTNO,ITEMFULL,TYPE,SIJIDT from T_ORDER where POREQNO= '" + sChuoi + "'";
                                //OracleCommand cmd_ms1 = new OracleCommand(query, connection);
                                //OracleDataReader ms_data = cmd_ms1.ExecuteReader();
                                string query = @"SELECT a.PHCD as PITEMID,a.GAMNG as QTY,a.AUFNR as POREQNO,c.VBELN as SNO,b.ROODNB as CUSTNO,c.RONAME as ITEMFULL,a.PSTX as TYPE, a.GSTRP as SIJIDT FROM MANUFA_F_PD_DT_REQ_HED a inner join MANUFA_F_PD_DT_ORDER_HED b on a.KDAUF =b.VBELN  inner join MANUFA_F_PD_DT_ORDER_DTL c on c.VBELN = b.VBELN where a.AUFNR='" + sChuoi + "'";
                                SqlCommand command = new SqlCommand(query, connection);
                                SqlDataReader ms_data = command.ExecuteReader();
                                DataGridViewRow row = new DataGridViewRow();
                                ms_data.Read();
                                int sl = int.Parse(ms_data["Qty"].ToString());

                               
                                if (sl > 1)
                                {
                                    rows[8] = txtID.Text.Trim();
                                    rows[2] = ms_data["POREQNO"].ToString();
                                    rows[3] = ms_data["SNO"].ToString();
                                    rows[4] = ms_data["CUSTNO"].ToString();
                                    rows[5] = ms_data["ITEMFULL"].ToString();
                                    rows[1] = "1";
                                    
                                    rows[0] = ms_data["PITEMID"].ToString();
                                    rows[6] = ms_data["TYPE"].ToString();
                                    rows[7] = ms_data["SIJIDT"].ToString();
                                }

                                    table.Rows.Add(rows);

                                dataGridViewNk.DataSource = table;
                                txtQRcode.Focus();
                                ms_data.Dispose();
                                ms_data.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                    else
                    {
                        string sql = @"select count(*) as CuontSL from F2_Data_Warehouse where POREQNO = @ID and CUSTNO = @LOT and TYPE = @PNAME and Note = 'NHAP-KHO'";//and QTY = @QTY 
                        string sql1 = @"select top 1 PITEMID,QTY,POREQNO,SNO,CUSTNO,ITEMFULL,TYPE,SIJIDT from F2_Data_Warehouse where POREQNO = @ID and CUSTNO = @LOT and TYPE = @PNAME and Note = 'CHUYEN-KHO' order by Date desc"; //and QTY = @QTY

                        string str = txtQRcode.Text.Trim();
                        txtQRcode.Clear();
                        string[] arrListStr = str.Split(',');

                        try
                        {
                            using (SqlConnection cn = new SqlConnection(ConnectionDatabase.connString))
                            {

                                if (cn.State == ConnectionState.Closed) cn.Open();
                                SqlCommand command = new SqlCommand(sql, cn);
                                command.CommandType = CommandType.Text;
                                command.Parameters.AddWithValue("@ID", arrListStr[1]);
                                command.Parameters.AddWithValue("@LOT", arrListStr[0]);
                                command.Parameters.AddWithValue("@PNAME", arrListStr[2]);
                                //command.Parameters.AddWithValue("@QTY", arrListStr[4]);
                                SqlDataReader dr_ms = command.ExecuteReader();
                                dr_ms.Read();
                                int result = int.Parse(dr_ms["CuontSL"].ToString());
                                command.Dispose();
                                dr_ms.Close();
                                if (result == 0)
                                {

                                    SqlCommand cmd_ms1 = new SqlCommand(sql1, cn);
                                    cmd_ms1.CommandType = CommandType.Text;
                                    cmd_ms1.Parameters.AddWithValue("@ID", arrListStr[1]);
                                    cmd_ms1.Parameters.AddWithValue("@LOT", arrListStr[0]);
                                    cmd_ms1.Parameters.AddWithValue("@PNAME", arrListStr[2]);
                                    //cmd_ms1.Parameters.AddWithValue("@QTY", arrListStr[4]);
                                    SqlDataReader dr_ms1 = cmd_ms1.ExecuteReader();
                                    if (dr_ms1.Read())
                                    {
                                        rows[8] = txtID.Text.Trim();
                                        rows[2] = dr_ms1["POREQNO"].ToString();
                                        rows[3] = dr_ms1["SNO"].ToString();
                                        rows[4] = dr_ms1["CUSTNO"].ToString();
                                        rows[5] = dr_ms1["ITEMFULL"].ToString();
                                        rows[1] = dr_ms1["QTY"].ToString();
                                        //if (!arrListStr[4].Equals(rows[1]))
                                        //{
                                        //    MessageBox.Show("Số lượng chuyển kho = " + rows[1] + ", số lượng trên Tem = " + arrListStr[4] + ", không trùng khớp!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //    cmd_ms1.Dispose();
                                        //    dr_ms1.Close();
                                        //    cn.Close();
                                        //    return;
                                        //}
                                        rows[0] = dr_ms1["PITEMID"].ToString();
                                        rows[6] = dr_ms1["TYPE"].ToString();
                                        rows[7] = dr_ms1["SIJIDT"].ToString();
                                    }
                                    cmd_ms1.Dispose();
                                    dr_ms1.Close();
                                    cn.Close();

                                    if (!string.IsNullOrEmpty(rows[2]) && table.Rows.Count == 0)
                                    {
                                        table.Rows.Add(rows);
                                    }
                                    else
                                    {
                                        bool duplicate = false;
                                        foreach (DataRow row in table.Rows)
                                        {
                                            string a = row[2].ToString();
                                            string b = rows[2];
                                            if (a.Equals(b))
                                            {
                                                duplicate = true;
                                            }
                                        }
                                        if (!string.IsNullOrEmpty(rows[2]) && !duplicate) table.Rows.Add(rows);
                                    }


                                    dataGridViewNk.DataSource = table;
                                    txtQRcode.Focus();
                                }
                                //else if(result == 0) MessageBox.Show("Đơn hàng này chưa được xuất kho.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else MessageBox.Show("Đơn hàng này đã được nhập kho.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
            }


        }

        private void ckbID_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbID.Checked) txtID.Enabled = false;
            else { txtID.Enabled = true; txtID.Clear(); txtID.Focus(); txtQRcode.Enabled = false; }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (table.Rows.Count > 0)
            {
                string sql = @"Insert into F2_Data_Warehouse (POREQNO,SNO,CUSTNO,ITEMFULL,QTY,PITEMID,TYPE,SIJIDT,Note,NhanVienID) " +
                            "values (@POREQNO,@SNO,@CUSTNO,@ITEMFULL,@QTY,@PITEMID,@TYPE,@SIJIDT,@Note,@NhanVienID)";
                this.Enabled = false;
                bool res = true;
                try
                {
                    using (SqlConnection cn = new SqlConnection(ConnectionDatabase.connString))
                    {

                        if (cn.State == ConnectionState.Closed) cn.Open();

                        foreach (DataRow row in table.Rows)
                        {
                            SqlCommand command = new SqlCommand(sql, cn);
                            command.CommandType = CommandType.Text;
                            command.Parameters.AddWithValue("@POREQNO", row[2].ToString());
                            command.Parameters.AddWithValue("@SNO", row[3].ToString());
                            command.Parameters.AddWithValue("@CUSTNO", row[4].ToString());
                            command.Parameters.AddWithValue("@ITEMFULL", row[5].ToString());
                            command.Parameters.AddWithValue("@QTY", row[1].ToString());
                            command.Parameters.AddWithValue("@PITEMID", row[0].ToString());
                            command.Parameters.AddWithValue("@TYPE", row[6].ToString());
                            command.Parameters.AddWithValue("@SIJIDT", row[7].ToString());
                            command.Parameters.AddWithValue("@Note", "NHAP-KHO");
                            command.Parameters.AddWithValue("@NhanVienID", row[8].ToString());
                            int result = command.ExecuteNonQuery();
                            if (result < 0) res = false;
                            command.Dispose();
                        }

                    }
                    table.Rows.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Enabled = true;
                if (res) MessageBox.Show("Saved successfully !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Save failed !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQRcode.Focus();
            }
        }

        private void FormNhapKho_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("You don't save data. Please save data before closing the form.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void dataGridViewNk_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (table.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("You want to refuse this order ?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    table.Rows.RemoveAt(e.RowIndex);
                    dataGridViewNk.Refresh();
                }
                else
                {

                }
            }
        }

        //private void dataGridViewNk_CellValidated(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == 0 && dataGridViewNk.CurrentCell.Value != null)
        //    {
        //        var cellValue = dataGridViewNk.CurrentCell.Value.ToString();
        //        var isExist = dataGridViewNk.Rows.Cast<DataGridViewRow>().Count(c => c.Cells[0].EditedFormattedValue.ToString() == cellValue) > 1;
        //        if (isExist)
        //        {
        //            dataGridViewNk.CurrentCell.Value = null;
        //        }
        //    }
        //}
    }
}

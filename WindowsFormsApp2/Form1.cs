using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        DataTable table = new DataTable("DanhSach");
        string text_sc = string.Empty;
        private void txtScan_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!string.IsNullOrEmpty(txtScan.Text))
            {
                if (e.KeyChar == 13)
                {
                    dataGridViewds.Columns["QTY"].ReadOnly = false;
                    btnPrint.Enabled = false;
                    text_sc = txtScan.Text;
                    txtScan.Clear();
                    txtScan.Focus();
                    //bool a = Check_Data();
                    //if (a) { MessageBox.Show("You already put in this the order !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    try
                    {
                        //using (OracleConnection connection = new OracleConnection(ConnectionDatabase.cn_oracle))
                        using (SqlConnection connection = new SqlConnection(ConnectionDatabase.connString059))
                        {
                            if (connection.State == ConnectionState.Closed) connection.Open();
                            //string query = "Select POREQNO, SNO, CUSTNO, ITEMFULL, QTY, PITEMID, TYPE, SIJIDT from T_ORDER where POREQNO='" + text_sc + "'";
                            string query = "";
                            //query = "SELECT a.AUFNR as POREQNO,c.VBELN as SNO,(case when c.RRONYU1 in('KJS', 'KJK', 'KJS_TK', 'ERC', 'WRC', 'CRC', 'FJS') and SUBSTRING(b.ROODNB,7,1)='-' then SUBSTRING(b.ROODNB,8,len(b.ROODNB)) ";
                            //query = query + " else b.ROODNB end ) as CUSTNO,isnull(f.product_code, a.PHTX) as ITEMFULL,a.GAMNG as QTY,a.PHCD as PITEMID,a.PSTX as TYPE,GSTRP as SIJIDT FROM MANUFA_F_PD_DT_REQ_HED a left join MANUFA_F_PD_DT_ORDER_HED b on a.KDAUF =b.VBELN  left join MANUFA_F_PD_DT_ORDER_DTL c on c.VBELN = b.VBELN   left join MANUFA_F_PD_W_ORDER f on f.mpo=b.ROODNB where a.AUFNR='" + text_sc + "'";


                            string strSql = string.Format(@"select POREQNO,SNO ,CUSTNO as CUSTNO,ProductName as ITEMFULL,QTY,PITEMID,TYPE,SIJIDT  from 
                                ( 
                                SELECT hed.AUFNR AS POREQNO, wod.MPO as MPONew,GSTRP as SIJIDT,PSTX as TYPE,
                                case when(ord_dtl.RRONYU1 = 'FJS' or  substring(ord_dtl.RRONYU1, 1, 2) = 'KJ' or REVERSE(substring(REVERSE(ord_dtl.RRONYU1), 1, 2)) = 'RC') then trim(SUbstring(isnull(ord_dtl.ZGLOBAL_CODE, ''), 8, 8)) else isnull(ord_dtl.ZGLOBAL_CODE, '') end AS CUSTNO, 
                                '' as TCOMMENT, GAMNG AS QTY,ISNULL(ord_dtl. KWMENG,hed.GAMNG) as QTYLot,[PHCD] AS PITEMID, isnull(ord_dtl.VBELN, '') as SNO, isnull(ord_dtl.RRONYU1, '') ODR_TYPE
                                , isnull(wod.PRODUCT_CODE, isnull(ord_dtl.RONAME, case when(SUBSTRING(hed.PHTX, 1, 6) = '[SBS]_') then SUBSTRING(hed.PHTX, 7, len(hed.PHTX)) when(SUBSTRING(hed.PHTX, 1, 6) = '[HF]_%') then SUBSTRING(hed.PHTX, 7, len(hed.PHTX)) when(SUBSTRING(hed.PHTX, 1, 5) = '[HF]_') then SUBSTRING(hed.PHTX, 6, len(hed.PHTX)) else hed.PHTX end) ) AS ProductName, isnull(ord_dtl.ZGLOBAL_CODE, '')  AS CUSTNO_Old 
                                FROM  MANUFA_F_PD_DT_REQ_HED  hed 
                                LEFT JOIN MANUFA_F_PD_DT_ORDER_DTL ord_dtl on(ord_dtl.VBELN = hed.KDAUF  ) 
                                LEFT JOIN MANUFA_F_PD_W_ORDER wod on (ord_dtl.ZGLOBAL_CODE=wod.MPO)
                                WHERE hed.AUFNR = {0}		  
                            ) as a", text_sc);
                            //OracleCommand command = new OracleCommand(query, connection);
                            //command.CommandType = CommandType.Text;
                            //DataGridViewRow row = new DataGridViewRow();
                            //OracleDataAdapter adapter = new OracleDataAdapter(command);

                            System.Data.SqlClient.SqlDataAdapter adapter = new SqlDataAdapter(strSql, connection);
                            DataGridViewRow row = new DataGridViewRow();
                            table.Rows.Clear();

                            adapter.Fill(table);
                            if (table.Rows.Count == 0) { txtScan.Clear(); txtScan.Focus(); }
                            else
                            {
                                //dataGridViewds.Rows.Clear();
                                dataGridViewds.DataSource = table;
                                //dataGridViewds.Rows[0].Cells[4].Selected = true;
                                dataGridViewds.CurrentCell = dataGridViewds.Rows[0].Cells[4];
                                dataGridViewds.BeginEdit(true);

                                //OracleDataReader dr = command.ExecuteReader();
                                //if (dr.HasRows)
                                //{
                                //    if (dr.Read())
                                //    {
                                //        //MessageBox.Show(dr["POREQNO"].ToString());
                                //        //dataGridViewds.Rows[0].Cells[0].Value = dr[0].ToString();
                                //        //dataGridViewds.Rows[0].Cells[1].Value = dr[1].ToString();
                                //        //dataGridViewds.Rows[0].Cells[2].Value = dr[2].ToString();
                                //        //dataGridViewds.Rows[0].Cells[3].Value = dr[3].ToString();
                                //        //dataGridViewds.Rows[0].Cells[4].Value = dr[4].ToString();
                                //        //dataGridViewds.Rows[0].Cells[5].Value = dr[5].ToString();
                                //        //dataGridViewds.Rows[0].Cells[6].Value = dr[6].ToString();
                                //        //dataGridViewds.Rows[0].Cells[7].Value = dr[7].ToString();

                                //    }
                                //}
                                //table.Clear();
                                //row.SetValues(str);
                                //dataGridViewds.Rows.Add(row);
                                txtScan.Clear();
                            }
                            dataGridViewds.Columns["QTY"].ReadOnly = false;
                            connection.Close();
                            connection.Dispose();
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //table.Columns.Add("NHANVIEN-ID", typeof(string));
            table.Columns.Add("POREQNO", typeof(string));            
            table.Columns.Add("SNO", typeof(string));
            table.Columns.Add("CUSTNO", typeof(string));
            table.Columns.Add("ITEMFULL", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("PITEMID", typeof(string));
            table.Columns.Add("TYPE", typeof(string));
            table.Columns.Add("SIJIDT", typeof(string));

            dataGridViewds.DataSource = table;
            foreach (DataGridViewColumn col in dataGridViewds.Columns)
            {
                col.HeaderText = col.Name;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //.Columns["NHANVIEN-ID"].ReadOnly = true;
            dataGridViewds.Columns["POREQNO"].ReadOnly = true;            
            dataGridViewds.Columns["SNO"].ReadOnly = true;
            dataGridViewds.Columns["CUSTNO"].ReadOnly = true;
            dataGridViewds.Columns["ITEMFULL"].ReadOnly = true;
            dataGridViewds.Columns["PITEMID"].ReadOnly = true;
            dataGridViewds.Columns["TYPE"].ReadOnly = true;
            dataGridViewds.Columns["SIJIDT"].ReadOnly = true;
            dataGridViewds.Columns["SIJIDT"].Width = 124;
            dataGridViewds.Columns["QTY"].ReadOnly = true;
        }


        private void dataGridViewds_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape) { txtScan.Focus(); }
            else if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(dataGridViewds.Rows[0].Cells[0].Value.ToString()))
            {
                DialogResult dialogResult = MessageBox.Show("The first, Program will save the data and then print the QR code.\nDo you want to do like this ?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    bool res = Save_data();
                    if (res) { Insert_data(); dataGridViewds.Columns["QTY"].ReadOnly = true; }
                }
                else
                {

                }
            }
        }

        private bool Check_Data()
        {
            bool res = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionDatabase.connString))
                {
                    string sql_check = @"select count(*) from F2_Data_Warehouse where POREQNO = @POREQNO";
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    SqlCommand command = new SqlCommand(sql_check, cn);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@POREQNO", text_sc);
                    int result = (int)command.ExecuteScalar();
                    //MessageBox.Show(result.ToString());
                    if (result > 0) { res = true; }
                    else { res = false; }
                    command.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;
        }

        private bool Save_data()
        {
            bool res = false;
            
            try
            {
                int checkNumber = int.Parse(dataGridViewds.Rows[0].Cells[4].Value.ToString());
                using (SqlConnection cn = new SqlConnection(ConnectionDatabase.connString))
                {
                    string sql_save = @"Insert into F2_Data_Warehouse (POREQNO,SNO,CUSTNO,ITEMFULL,QTY,PITEMID,TYPE,SIJIDT,Note,NhanVienID) " +
                        "values (@POREQNO,@SNO,@CUSTNO,@ITEMFULL,@QTY,@PITEMID,@TYPE,@SIJIDT,@Note,@NhanVienID)";
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    SqlCommand command = new SqlCommand(sql_save, cn);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@POREQNO", dataGridViewds.Rows[0].Cells[0].Value.ToString());
                    command.Parameters.AddWithValue("@SNO", dataGridViewds.Rows[0].Cells[1].Value.ToString());
                    command.Parameters.AddWithValue("@CUSTNO", dataGridViewds.Rows[0].Cells[2].Value.ToString());
                    command.Parameters.AddWithValue("@ITEMFULL", dataGridViewds.Rows[0].Cells[3].Value.ToString());
                    command.Parameters.AddWithValue("@QTY", dataGridViewds.Rows[0].Cells[4].Value.ToString());
                    command.Parameters.AddWithValue("@PITEMID", dataGridViewds.Rows[0].Cells[5].Value.ToString());
                    command.Parameters.AddWithValue("@TYPE", dataGridViewds.Rows[0].Cells[6].Value.ToString());  //6->3
                    command.Parameters.AddWithValue("@SIJIDT", dataGridViewds.Rows[0].Cells[7].Value.ToString());
                    command.Parameters.AddWithValue("@Note", "CHUYEN-KHO");
                    command.Parameters.AddWithValue("@NhanVienID", txtID.Text.Trim());
                    int result = command.ExecuteNonQuery();
                    if (result > 0) { MessageBox.Show("Saved successfully !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); res = true; }
                    else { MessageBox.Show("Save failed !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); res = false; }
                    command.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;
        }

        private void Insert_data()
        {
            string LotNo = "";
            string Note = "";
            //OracleConnection connection = new OracleConnection(ConnectionDatabase.cn_oracle);
            //if (connection.State == ConnectionState.Closed) connection.Open();
            //string query = "Select POREQNO, SNO, CUSTNO, TCOMMENT from T_ORDER where POREQNO='" + text_sc + "'";
            //OracleCommand command = new OracleCommand(query, connection);
            //OracleDataReader dr = command.ExecuteReader();
            SqlConnection connection = new SqlConnection(ConnectionDatabase.connString059);
            if (connection.State == ConnectionState.Closed) connection.Open();
            string query = "";
            query = "SELECT a.AUFNR as POREQNO,c.VBELN as SNO,b.ROODNB as CUSTNO,PRT_ADDCMT1 as TCOMMENT FROM MANUFA_F_PD_DT_REQ_HED a left join MANUFA_F_PD_DT_ORDER_HED b on a.KDAUF =b.VBELN  left join MANUFA_F_PD_DT_ORDER_DTL c on c.VBELN = b.VBELN left join MANUFA_F_PD_DT_REQ_CMT d on d.AUFNR = a.AUFNR where a.AUFNR='" + text_sc + "'";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                if(dr.Read())
                {
                    LotNo = dr["CUSTNO"].ToString();
                    Note = dr["TCOMMENT"].ToString();
                }
            }
           
            OleDbConnection bookCon;
            OleDbCommand cmdBook = new OleDbCommand();
            String connParam = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Data_Insp\Database101.accdb;Persist Security Info=False";
            bookCon = new OleDbConnection(connParam);

            // Thực hiện delete table PrintTemp
            try
            {
                bookCon.Open();
                string sql = "Delete * From DataForPrint";
                OleDbCommand cmd = new OleDbCommand(sql, bookCon);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                bookCon.Close();
            }
            // Kết thúc thực hiện delete table PrintTemp

            // Thực hiện insert table PrintTemp
            try
            {

               

                int row = int.Parse(dataGridViewds.Rows[0].Cells[4].Value.ToString());
                bookCon.Open();
                string sql = "";
                if (LotNo == "")
                {
                   // LotNo = Note;
                    sql = "";
                     sql = "Insert into DataForPrint (LOT,ID,PNAME,TYPE,QTY,Method,TimeQCode,[Note],MadeVN,ControlC)" +
                    " values ('" + Note + "','" + dataGridViewds.Rows[0].Cells[0].Value.ToString() + "','" + dataGridViewds.Rows[0].Cells[3].Value.ToString() + "',"
                    + "'','" + dataGridViewds.Rows[0].Cells[4].Value.ToString() + "','', '" + DateTime.Now.ToString() + "','','','')";

                }
                else
                {
                    sql = "";
                     sql = "Insert into DataForPrint (LOT,ID,PNAME,TYPE,QTY,Method,TimeQCode,[Note],MadeVN,ControlC)" +
                    " values ('" + dataGridViewds.Rows[0].Cells[2].Value.ToString() + "','" + dataGridViewds.Rows[0].Cells[0].Value.ToString() + "','" + dataGridViewds.Rows[0].Cells[3].Value.ToString() + "',"
                    + "'','" + dataGridViewds.Rows[0].Cells[4].Value.ToString() + "','', '" + DateTime.Now.ToString() + "','','','')";

                }



                OleDbCommand cmd = new OleDbCommand(sql, bookCon);
                cmd.ExecuteNonQuery();
                //}
                // Thuc thi lenh in
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.FileName = "C:\\Data_Insp\\PGHuy.lbx";

                //for (int i = 0; i < row; i++)
                //{
                    startInfo.Verb = "Print";

                    startInfo.UseShellExecute = true;
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.CreateNoWindow = true;

                    process.StartInfo = startInfo;

                    process.Start();
                    //process.WaitForExit(10000);
                    process.WaitForExit();
                //}
                //process.CloseMainWindow();
                process.Close();

                // End Thuc thi lenh in
            }
            finally
            {
                bookCon.Close();
                table.Rows.Clear();
                if (cbSPC_no.Checked) txtScan.Focus();
                else txtLOT_no.Focus();
            }
            // Kết thúc thực hiện insert table PrintTemp

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dataGridViewds.Rows[0].Cells[0].Value.ToString()))
            {
                //if (!Check_Data())
                //{
                //    bool res1 = Save_data();
                //    if (res1) btnPrint.Enabled = true;
                //    dataGridViewds.Columns["QTY"].ReadOnly = true;
                //}
                bool res1 = Save_data();
                if (res1) btnPrint.Enabled = true;
                dataGridViewds.Columns["QTY"].ReadOnly = true;

                //else 
                MessageBox.Show("You have saved this the order !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dataGridViewds.Rows[0].Cells[0].Value.ToString()))
            {
                Insert_data();
                btnPrint.Enabled = false;
            }
            txtScan.Focus();
        }

        private void ckbID_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbID.Checked) txtID.Enabled = false;
            else { txtID.Enabled = true; txtID.Clear(); txtID.Focus(); txtScan.Enabled = false; cbSPC_no.Enabled = false;
                cbLOT_no.Enabled = false;
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                if (e.KeyChar == 13)
                {
                    txtID.Enabled = false;
                    txtScan.Enabled = false;
                    txtLOT_no.Enabled = false;
                    ckbID.Checked = true;
                    cbSPC_no.Enabled = true;
                    cbLOT_no.Enabled = true;
                    txtScan.Focus();
                }
            }
        }

        private void cbLOT_no_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLOT_no.Checked) {
                txtLOT_no.Enabled = true; txtLOT_no.Clear(); txtLOT_no.Focus();
                 txtScan.Clear();txtScan.Enabled = false; cbSPC_no.Checked = false;
            }
            else { txtLOT_no.Enabled = false;  }
        }

        private void cbSPC_no_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSPC_no.Checked) {
                txtScan.Enabled = true; txtScan.Clear(); txtScan.Focus();
                txtLOT_no.Clear(); txtLOT_no.Enabled = false; cbLOT_no.Checked = false;
            }
            else { txtScan.Enabled = false;  }
        }

        private void txtLOT_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLOT_no.Text))
            {
                if (e.KeyChar == 13)
                {
                    dataGridViewds.Columns["QTY"].ReadOnly = false;
                    btnPrint.Enabled = false;
                    text_sc = txtLOT_no.Text;
                    txtLOT_no.Clear();
                    txtLOT_no.Focus();
                    try
                    {
                        //using (OracleConnection connection = new OracleConnection(ConnectionDatabase.cn_oracle))
                        //{
                        //    if (connection.State == ConnectionState.Closed) connection.Open();
                            //string query = "Select POREQNO, SNO, CUSTNO, ITEMFULL, QTY, PITEMID, TYPE, SIJIDT from T_ORDER WHERE custno = '" + text_sc + "' and ROWNUM <= 1";
                            //OracleCommand command = new OracleCommand(query, connection);
                            //command.CommandType = CommandType.Text;
                           
                            DataGridViewRow row = new DataGridViewRow();
                            //string[] str = new string[8];
                            //OracleDataAdapter adapter = new OracleDataAdapter(command);

                            SqlConnection connection = new SqlConnection(ConnectionDatabase.connString059);
                            if (connection.State == ConnectionState.Closed) connection.Open();
                            string query = "";
                            query = "SELECT a.AUFNR as POREQNO,c.VBELN as SNO,b.ROODNB as CUSTNO,a.PSTX as ITEMFULL,GAMNG as QTY,PHCD as PITEMID, a.PSTX as TYPE, a.GSTRP as SIJIDT FROM MANUFA_F_PD_DT_REQ_HED a left join MANUFA_F_PD_DT_ORDER_HED b on a.KDAUF =b.VBELN  left join MANUFA_F_PD_DT_ORDER_DTL c on c.VBELN = b.VBELN where b.ROODNB='" + text_sc + "'";
                            SqlCommand command = new SqlCommand(query, connection);
                            //SqlDataReader dr = command.ExecuteReader();
                            command.CommandType = CommandType.Text;
                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            table.Rows.Clear();

                            adapter.Fill(table);
                        if (table.Rows.Count == 0) { txtLOT_no.Clear(); txtLOT_no.Focus(); }
                            else
                            {
                                //dataGridViewds.Rows.Clear();
                                dataGridViewds.DataSource = table;
                                //dataGridViewds.Rows[0].Cells[4].Selected = true;
                                dataGridViewds.CurrentCell = dataGridViewds.Rows[0].Cells[4];
                                dataGridViewds.BeginEdit(true);
                                txtLOT_no.Clear();
                            }
                            dataGridViewds.Columns["QTY"].ReadOnly = false;
                        //}
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

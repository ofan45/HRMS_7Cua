using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVSoft.HRMS.Common;
using EVSoft.HRMS.DO;
using XPTable.Models;

namespace EVSoft.HRMS.UI.Employee
{
    public partial class frmListHospital : Form
    {
        private int selectedRowIndex = -1;
		/// <summary>
		/// 
		/// </summary>
		private DepartmentDO departmentDO = null;
		/// <summary>
		/// 
		/// </summary>
		private DataSet dsPosition = null;
		/// <summary>
		/// 
		/// </summary>
		private DataTable dtPosition = null;
        
        public frmListHospital()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListHospital_Load(object sender, EventArgs e)
        {
            Refresh();
            departmentDO = new DepartmentDO();
            PopulatePositionListView();
        }

        private void PopulatePositionListView()
        {
            dsPosition = departmentDO.GetAllHospitals();

            lvwPosition.BeginUpdate();
            lvwPosition.TableModel.Rows.Clear();
            dtPosition = dsPosition.Tables[0];
            if (dtPosition.Rows.Count > 0)
            {
                //				selectedRowIndex = 0;
                int STT = 0;
                foreach (DataRow dr in dtPosition.Rows)
                {
                    STT++;
                    string PositionName = dr["HospitalName"].ToString();
                    string PositionShortName = dr["HospitalID"].ToString();
                    string Description = dr["HospitalAddress"].ToString();

                    Row row = new Row(new string[] { STT.ToString(), PositionName, PositionShortName, Description });
                    row.Tag = STT - 1;
                    this.lvwPosition.TableModel.Rows.Add(row);
                }
            }
            lvwPosition.EndUpdate();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmHospital frm = new frmHospital();
            frm.PositionDataSet = dsPosition;
            frm.ShowDialog(this);
            PopulatePositionListView();
            selectedRowIndex = -1;
            tableModel1.Selections.Clear();
        }

        private void lvwPosition_SelectionChanged(object sender, XPTable.Events.SelectionEventArgs e)
        {
            if (e.NewSelectedIndicies.Length > 0)
            {
                selectedRowIndex = (int)lvwPosition.TableModel.Rows[e.NewSelectedIndicies[0]].Tag;
            }
        }

        private void lvwPosition_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (lvwPosition.SelectedItems.Length > 0)
                {
                    frmHospital frm = new frmHospital();
                    frm.PositionDataSet = dsPosition;
                    frm.SelectedPosition = selectedRowIndex;
                    frm.ShowDialog(this);
                    PopulatePositionListView();
                }
                selectedRowIndex = -1;
                tableModel1.Selections.Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                //string str = WorkingContext.LangManager.GetString("frmPosition_UpDate_Error_Messa");
                //string str1 = WorkingContext.LangManager.GetString("frmPosition_UpDate_Error_Title");
                MessageBox.Show("Bạn chưa chọn bệnh viện nào", "Thông báo" ,MessageBoxButtons.OK,MessageBoxIcon.Error);
                //MessageBox.Show(str, str1, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmHospital frm = new frmHospital();
                frm.PositionDataSet = dsPosition;
                frm.SelectedPosition = selectedRowIndex;
                frm.ShowDialog(this);
                PopulatePositionListView();
            }
            selectedRowIndex = -1;
            tableModel1.Selections.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                //string str = WorkingContext.LangManager.GetString("frmListPosition_Delete_Error_Messa");
                //string str1 = WorkingContext.LangManager.GetString("frmListPosition_Delete_ThongBao_Title1");
                MessageBox.Show("Chưa chọn bệnh viện cần xóa","Xóa bệnh viện",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //MessageBox.Show(str, str1, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DeleteHospital();
            }
            selectedRowIndex = -1;
            tableModel1.Selections.Clear();
        }

        /// <summary>
        /// Xóa bệnh viện
        /// </summary>
        private void DeleteHospital()
        {
            string PositionName = dtPosition.Rows[selectedRowIndex]["HospitalName"].ToString();
            //string str = WorkingContext.LangManager.GetString("frmListPosition_Delete_ThongBao_Messa1");
            string str = "Bạn chắc chắn muốn xóa bệnh viện ";
            //string str2 = WorkingContext.LangManager.GetString("frmListPosition_Delete_ThongBao_Title2");
            string str2 = "Xóa bệnh viện";
            if (MessageBox.Show(str + "'" + PositionName + "' ?", str2, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                int result = 0;
                try
                {
                    

                    result = departmentDO.DeleteHospital(Convert.ToInt32(dtPosition.Rows[selectedRowIndex]["HospitalCode"].ToString()));
                    
                }
                catch
                {

                }
                if (result == 1)
                {
                    //string str1 = WorkingContext.LangManager.GetString("frmListPosition_Delete_ThongBao_Messa2");
                    //string str3 = WorkingContext.LangManager.GetString("frmListPosition_Delete_ThongBao_Title2");
                    MessageBox.Show("Xóa bệnh viện thành công!", "Xóa bệnh viện", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show(str1, str3, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtPosition.Rows[selectedRowIndex].Delete();
                    dsPosition.AcceptChanges();
                    
                }
                if (result == -1)
                {
                    //string str1 = WorkingContext.LangManager.GetString("frmListPosition_Del_ThongBao_Messa3");
                    //string str3 = WorkingContext.LangManager.GetString("frmListPosition_Delete_ThongBao_Title2");
                    MessageBox.Show("Xóa bệnh viện thất bại! Đã có nhân viên được gán bệnh viện này!", "Xóa bệnh viện", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //MessageBox.Show(str1, str3, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dsPosition.RejectChanges();
                }
                PopulatePositionListView();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVSoft.HRMS.Common;
using EVSoft.HRMS.DO;

namespace EVSoft.HRMS.UI.Employee
{
    public partial class frmDepartmentGroup : Form
    {
        public frmDepartmentGroup()
        {
            InitializeComponent();
        }

        private DepartmentDO departmentDO = null;
        private DataSet dsPosition = null;
        private DataTable dtPosition = null;
        private int selectedPosition = -1;

        public DataSet PositionDataSet
        {
            set { dsPosition = value; }
        }

        public int SelectedPosition
        {
            set { selectedPosition = value; }
        }


        /// <summary>
        /// Nạp lại dữ liệu trong hàng được chọn hiện tại lên các textbox
        /// </summary>
        private void LoadCurrentPosition()
        {
            DataRow dr = dtPosition.Rows[selectedPosition];
            if (dr != null)
            {
                txtPositionName.Text = dr["GroupName"].ToString();
                txtPositionShortName.Text = dr["GroupID"].ToString();
                txtDescription.Text = dr["GroupDescription"].ToString();
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDepartmentGroup_Load(object sender, EventArgs e)
        {
            Refresh();
            departmentDO = new DepartmentDO();
            dtPosition = dsPosition.Tables[0];
            if (selectedPosition >= 0)
            {
                //string str = WorkingContext.LangManager.GetString("frmPosition_Text3");
                this.Text = "Sửa thông tin nhóm phòng ban";
                //this.Text = str;
                LoadCurrentPosition();
            }
            else
            {
                //string str = WorkingContext.LangManager.GetString("frmPosition_Text2");
                this.Text = "Thêm nhóm phòng ban mới";
                //this.Text = str;
            }
        }

        public override void Refresh()
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Refresh();
            }
            base.Refresh();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPositionName.Text.Trim() == "")
            {
                //string str = WorkingContext.LangManager.GetString("frmPosition_Add_Error_Messa1");
                //string str1 = WorkingContext.LangManager.GetString("frmPosition_Add_Error_Title1");
                MessageBox.Show("Bạn chưa nhập tên nhóm phòng ban!", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(str, str1, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPositionShortName.Text.Trim() == "")
            {
                //string str = WorkingContext.LangManager.GetString("frmPosition_Add_Error_Messa2");
                //string str1 = WorkingContext.LangManager.GetString("frmPosition_Add_Error_Title1");
                MessageBox.Show("Bạn chưa nhập mã phòng ban tắt!", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(str, str1, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                decimal.Parse(txtPositionShortName.Text);
            }
            catch
            {
                MessageBox.Show("Mã nhóm là kiểu số !", "Lỗi nhập dữ liệu");
                return;
            }
            
            string groupName = string.Empty;
            int groupID =0;
            string description = String.Empty;
            if (selectedPosition < 0)
            {
                
                groupName= txtPositionName.Text.Trim();
                groupID = Convert.ToInt32(txtPositionShortName.Text.Trim());
                description= txtDescription.Text;

                int result = departmentDO.AddDepartmentGroup(groupID, groupName, description);
                if (result == 2)
                {
                    //string str = WorkingContext.LangManager.GetString("frmPosition_Add_ThongBao_Messa");
                    //string str1 = WorkingContext.LangManager.GetString("frmPosition_Add_ThongBao_Title");
                    MessageBox.Show("Thêm nhóm phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show(str, str1, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsPosition = departmentDO.GetAllGroupDepartments();
                    dsPosition.AcceptChanges();
                    this.Close();
                }
                if (result == 1)
                {
                    //string str = WorkingContext.LangManager.GetString("frmPosition_Add_CanhBao_Messa");
                    //string str1 = WorkingContext.LangManager.GetString("frmPosition_Add_ThongBao_Title");
                    MessageBox.Show("Tên nhóm hoặc mã nhóm đã tồn tại trong hệ thống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //MessageBox.Show(str, str1, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsPosition.RejectChanges();
                }
            }
            else
            {
                groupName = txtPositionName.Text.Trim();
                groupID = Convert.ToInt32(txtPositionShortName.Text.Trim());
                description = txtDescription.Text;

                int result = departmentDO.UpdateDepartmentGroup(groupID,groupName,description);
                dsPosition.AcceptChanges();
                if (result == 2)
                {
                    //string str = WorkingContext.LangManager.GetString("frmPosition_UpDate_ThongBao_Messa");
                    //string str1 = WorkingContext.LangManager.GetString("frmPosition_UpDate_ThongBao_Title");
                    MessageBox.Show("Cập nhật nhóm phòng ban thành công!", "Cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show(str, str1, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsPosition = departmentDO.GetAllGroupDepartments();
                    dsPosition.AcceptChanges();
                    this.Close();
                }
                if (result == 1)
                {
                    //string str = WorkingContext.LangManager.GetString("frmPosition_Add_CanhBao_Messa");
                    //string str1 = WorkingContext.LangManager.GetString("frmPosition_UpDate_ThongBao_Title");
                    MessageBox.Show("Tên nhóm phòng ban đã tồn tại trong hệ thống !", "Cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //MessageBox.Show(str, str1, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsPosition.RejectChanges();
                }
            }
        }
    }
}
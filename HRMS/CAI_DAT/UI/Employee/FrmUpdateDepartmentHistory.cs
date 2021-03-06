using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AMS.TextBox;
using EVSoft.HRMS.Common;
using EVSoft.HRMS.DO;

namespace EVSoft.HRMS.UI.Employee
{
    public partial class FrmUpdateDepartmentHistory : Form
    {
        #region Các biến và hằng
        private EmployeeDO employeeDO = null;
        private DepartmentDO departmentDO = null;
        private DataSet dsDepartmentHistory = null;
        private DataRow rowUpdate = null;

        //Các biến trước khi cập nhật
        private DateTime ModifiedDateBeforeUpdate;
        private string DecNumberBeforeUpdate;
        private string NoteBeforeUpdate;
        #endregion

        #region Các hàm khởi tạo
        public FrmUpdateDepartmentHistory()
        {
            InitializeComponent();
        }

        public FrmUpdateDepartmentHistory(int iEmployeeID, string strDepartmentName, DateTime dtModify, string strDecNumber, string strNote, int iSelectedRow)
        {
            InitializeComponent();
            employeeDO = new EmployeeDO();
            dsDepartmentHistory = employeeDO.GetDepartmentHistory(iEmployeeID);
            rowUpdate = dsDepartmentHistory.Tables[0].Rows[iSelectedRow];

            txtBoPhan.Text = strDepartmentName;
            txtDecNumber.Text = strDecNumber;
            dptDate.Value = dtModify;
            txtNote.Text = strNote;
            //Lưu lại các thông tin trước khi update           
            DecNumberBeforeUpdate = strDecNumber;
            ModifiedDateBeforeUpdate = dtModify.Date;
            NoteBeforeUpdate = strNote;
        }
        #endregion

        #region Các hàm khai báo
        /// <summary>
        /// Thiết lập các giá trị để cập nhật thông tin logDepartment
        /// </summary>
        /// <param name="dtRow"></param>
        private void SetDataRowUpdate(ref DataRow dtRow)
        {
            dtRow.BeginEdit();
            dtRow["DecisionNumber"] = txtDecNumber.Text;
            dtRow["Note"] = txtNote.Text;
            dtRow["ModifiedDate"] = dptDate.Value.Date;
            dtRow.EndEdit();
        }
        #endregion


        #region Các hàm sự kiện
        private void FrmUpdateDepartmentHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bntOK_Click(null, null);
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void cmbDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            //Kiểm tra có sự thay đổi thông tin bộ phận công tác
            if (txtDecNumber.Text == DecNumberBeforeUpdate
                && dptDate.Value.Date == ModifiedDateBeforeUpdate
                && txtNote.Text == NoteBeforeUpdate)
            {
                this.Close();
                return;
            }
            //Xác nhận sự thay đổi bộ phận công tác
            DialogResult rs = MessageBox.Show(this, WorkingContext.LangManager.GetString("frmUpdateDepartmentHistory_Confirm_Messa"),
                WorkingContext.LangManager.GetString("Confirm"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                return;
            }
            //Thực hiện thay đổi bộ phận công tác
            int ret = 0;
            SetDataRowUpdate(ref rowUpdate);
            ret = employeeDO.UpdateDepartmentHistory(dsDepartmentHistory);
            if (ret != 0)
            {
                MessageBox.Show(this, WorkingContext.LangManager.GetString("frmUpdateDepartmentHistory_OK_Messa"),
                    WorkingContext.LangManager.GetString("Message"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
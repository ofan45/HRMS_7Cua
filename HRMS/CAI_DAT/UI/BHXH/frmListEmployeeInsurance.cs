
//------------------------------------------------------------------------------------
//Class	    : 
//Purpose	: 	
//Note	    :		  
//Author	: quandh 14/03/2007
//Note		: Danh sách nhân viên đề nghị cấp sổ BHXH
//------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using EVSoft.HRMS.Common;
using EVSoft.HRMS.DO;
//using GlacialComponents.Controls;
using EVSoft.HRMS.UI.Employee;
using EVSoft.HRMS.UI.Report;
using XPTable.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace EVSoft.HRMS.UI.BHXH
{
    public partial class frmListEmployeeInsurance : Form
    {
        public frmListEmployeeInsurance()
		{
			InitializeComponent();
		}


		private Label lblDepartment;
		private Panel pnDepartment;
		private Panel pnEmployee;
		private TextBox txtSearch;
		private Button btnSearch;
		private Button btnClose;
		private Panel pnButtons;
        private Splitter splitter1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label lblEmployee;
		private XPTable.Models.Table lvwEmployee;
		private XPTable.Models.TableModel tableModel1;
		private XPTable.Models.ColumnModel columnModel1;
		private XPTable.Models.TextColumn cCardID;
		private XPTable.Models.TextColumn cEmployeeName;
		private XPTable.Models.TextColumn cDepartmentName;
		private XPTable.Models.TextColumn cGender;
		private XPTable.Models.TextColumn cDateOfBirth;
		private XPTable.Models.TextColumn cIdentityCard;
		private XPTable.Models.TextColumn cPhone;
		private XPTable.Models.TextColumn cAddress;
		private System.Windows.Forms.Button btnExcel;
        //private XPTable.Models.TextColumn cInsurance;
		private XPTable.Models.NumberColumn cSTT;
		private XPTable.Models.TextColumn cCommune;
		private XPTable.Models.TextColumn cDistrict;
		private XPTable.Models.TextColumn cProvince;
        private System.Windows.Forms.Button btnDeletedEmployee;
		private System.Windows.Forms.Button btnPermanentDelete;
        private EVSoft.HRMS.Controls.DepartmentTreeView departmentTreeView;
		private XPTable.Models.TextColumn cPosition;
		private XPTable.Models.TextColumn cStartTrial;
		private XPTable.Models.TextColumn cStartDate;
		private XPTable.Models.TextColumn cTrinhdo;
		private XPTable.Models.NumberColumn cBasicSalary;
		private int t;
        private int delete = 0;
		private bool checkEmployeeDeleted = false;
		
			
	

	
		
		/// <summary>
		/// 
		/// </summary>
		private DepartmentDO departmentDO = null;
		/// <summary>
		/// 
		/// </summary>
		private EmployeeDO employeeDO = null;
		/// <summary>
		/// 
		/// </summary>
		private DataSet dsEmployee = null;
		/// <summary>
		/// Hàng hiện tại được chọn trong DataSet
		/// </summary>
		private int selectedRowIndex = -1;

		/// <summary>
		/// Chuyển chức vụ sang dạng xâu
		/// </summary>
		/// <param name="pro"></param>
		/// <returns></returns>
		private String ConvertProfessionalLevel2String(int pro)
		{
			string temp="";
			switch(pro)
			{
				case 0:
					temp= "Phổ thông";
					break;
				case 1:
					temp=  "Trung cấp";
					break;
				case 2:
					temp=  "Cao đẳng";
					break;
				case 3:
					temp=  "Đại học";
					break;
				case 4:
					temp=  "Sau đại học";
					break;
			}
			return temp;
		}
		/// <summary>
		/// Hiển thị danh sách nhân viên trong công ty/phòng ban
		/// </summary>
		private void PopulateEmployeeListView()
		{
			lvwEmployee.BeginUpdate();
			lvwEmployee.TableModel.Rows.Clear();

			int STT = 0;
            //if (dsEmployee.Tables.Count>0)
            //    if (dsEmployee.Tables[0].Rows.Count > 0)
			        foreach (DataRow dr in dsEmployee.Tables[0].Rows)
			        {
				        Cell DepartmentName = new Cell();
				        //if (this.lblDepartment.Text.Equals("Danh sách các đơn vị"))
				        //{
					        DepartmentName = new Cell(dr["DepartmentName"].ToString());
				        //}
				        //else
				        //{
				        //	DepartmentName = new Cell(dr["DepartmentNameJP"].ToString());
				        //}
        				
				        Cell CardID = new Cell(dr["CardID"].ToString());
				        Cell EmployeeName = new Cell(dr["EmployeeName"].ToString());
				        Cell Gender = new Cell(Int32.Parse(dr["Gender"].ToString()) == 0 ? "Nam" : "Nữ");
				        Cell DateOfBirth = new Cell(DateTime.Parse(dr["DateOfBirth"].ToString()).ToString("dd/MM/yyyy"));
				        Cell IdentityCard = new Cell(dr["IdentityCard"].ToString());
				        Cell InsuranceID = new Cell(dr["InsuranceID"].ToString());
				        Cell Address = new Cell(dr["Address"].ToString());
				        Cell Phone = new Cell(dr["Phone"].ToString());
				        string professionalLevel = ConvertProfessionalLevel2String(int.Parse(dr["ProfessionalLevel"].ToString()));
				        Cell ProfessionalLevel = new Cell(professionalLevel);
				        Cell Commune = new Cell(dr["Commune"].ToString());
				        Cell District = new Cell(dr["District"].ToString());
				        Cell Province = new Cell(dr["Province"].ToString());
				        Cell Position = new Cell(dr["PositionName"].ToString());

				        Cell StartTrial = new Cell("");
				        if (dr["StartTrial"] != DBNull.Value) 
				        {
					        StartTrial = new Cell(DateTime.Parse(dr["StartTrial"].ToString()).ToString("dd/MM/yyyy"));
				        }
				        int Start_month = 0;
				        int Start_year = 0;
				        Cell StartDate = new Cell("");

				        if (dr["StartDate"] != DBNull.Value) 
				        {
					        StartDate = new Cell(DateTime.Parse(dr["StartDate"].ToString()).ToString("dd/MM/yyyy"));
					        Start_month = DateTime.Parse(dr["StartDate"].ToString()).Month;
					        Start_year = DateTime.Parse(dr["StartDate"].ToString()).Year;
				        }
				        Cell BasicSalary = new Cell(double.Parse(dr["BasicSalary"].ToString()));
        				
				        Row row = new Row(new Cell[]{new Cell(STT + 1), DepartmentName, CardID, EmployeeName,  Gender, DateOfBirth, IdentityCard, InsuranceID, Phone,ProfessionalLevel, Address, Commune, District, Province,Position,StartTrial,StartDate,BasicSalary});
				        row.Tag = STT;
				        lvwEmployee.TableModel.Rows.Add(row);

				        STT++;
			        }
			lvwEmployee.EndUpdate();
			string str = WorkingContext.LangManager.GetString("frmliste_text1");
			lblEmployee.Text = "Tổng số nhân viên trong danh sách: " + dsEmployee.Tables[0].Rows.Count;
			lblEmployee.Text = str + dsEmployee.Tables[0].Rows.Count;
			t = dsEmployee.Tables[0].Rows.Count;
			if (checkEmployeeDeleted == false)
			{
				btnRestore.Visible = false;
				//btnAdd.Visible = true;
				//btnDelete.Visible = true;
				btnPermanentDelete.Visible = true;
			}
			else
			{
				btnRestore.Visible = true;
				//btnAdd.Visible = false;
				//btnDelete.Visible = false;
				btnPermanentDelete.Visible = false;
			}
		}

		private void frmListEmployees_Load(object sender, EventArgs e)
		{
			
			departmentDO = new DepartmentDO();
			employeeDO = new EmployeeDO();
				
			departmentTreeView.DepartmentDataSet = departmentDO.GetAllDepartments();
			departmentTreeView.BuildTree();
			departmentTreeView.SelectedNode = departmentTreeView.TopNode;
			Refresh();
		}


		public override void Refresh()
		{
			ChangeToCurrentLang();

			//BuildTreeAgain();
			
			foreach (Form form in this.MdiChildren)
			{
				form.Refresh();
			}

			base.Refresh ();
		}

		private void ChangeToCurrentLang()
		{
			//this.Text = WorkingContext.LangManager.GetString("frmliste_text");
			this.lblDepartment.Text = WorkingContext.LangManager.GetString("frmListEmployee_lblDepartment");
			this.lblEmployee.Text = WorkingContext.LangManager.GetString("frmListEmployee_lblEmployee");
			//this.btnDeletedEmployee.Text = WorkingContext.LangManager.GetString("frmListEmployee_bntDeletedEmployee");
			//this.btnAdd.Text = WorkingContext.LangManager.GetString("frmListEmployee_bntAdd");
			this.btnSearch.Text = WorkingContext.LangManager.GetString("frmListEmployee_bntSearch");
			this.txtSearch.Text = WorkingContext.LangManager.GetString("frmListEmployee_txtSearch");
			//this.btnExcel.Text = WorkingContext.LangManager.GetString("frmTimeSheet_btnXuatExcel");
            //this.btnDelete.Text = WorkingContext.LangManager.GetString("frmListEmployee_bntDelete");
			//this.btnEdit.Text = WorkingContext.LangManager.GetString("frmListEmployee_bntEdit");
			this.btnClose.Text = WorkingContext.LangManager.GetString("frmListEmployee_bntClose");
			this.cSTT.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_STT");
			this.cDepartmentName.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_Department");
			this.cCardID.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_MaThe");
			this.cEmployeeName.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_TenNhanVien");
			this.cGender.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_GioiTinh");
			this.cDateOfBirth.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_DateOfBirth");
			this.cIdentityCard.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_SCMND");
			//this.cInsurance.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_BHXH");
			this.cPhone.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_Phone");
			this.cTrinhdo.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_TrinhDo");
			this.cAddress.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_Addr");
			this.cCommune.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_PhuongXa");
			this.cDistrict.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_QuanHuyen");
			this.cProvince.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_City");
			this.cPosition.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_Position");
			this.cStartDate.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_NgayChinhThuc");
			this.cStartTrial.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_StartDate");
			this.cBasicSalary.Text = WorkingContext.LangManager.GetString("frmListEmployee_lvwEmployee_BasicSalary");

			//this.btnRestore.Text = WorkingContext.LangManager.GetString("frmE_btnKP");
			//this.btnPermanentDelete.Text = WorkingContext.LangManager.GetString("frmTimeSheet_btnDelete");
			this.lvwEmployee.NoItemsText = WorkingContext.LangManager.GetString("XPtable");
			this.lblEmployee.Text = WorkingContext.LangManager.GetString("frmliste_text1") + dsEmployee.Tables[0].Rows.Count;
			//lblEmployee.Text = "Tổng số nhân viên trong danh sách: " + dsEmployee.Tables[0].Rows.Count;
			
			
		}


		private void departmentTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			
			//checkEmployeeDeleted = false;
			departmentTreeView.ExpandNodes(true);
			//delete = 0;// chon tim kiem theo danh sach nhan vien dang lam viec
            if (delete == 0)
                dsEmployee = employeeDO.GetEmployeeByDepartmentInsurance((int)departmentTreeView.SelectedNode.Tag);
            else if (delete == 1)
            {
                dsEmployee = employeeDO.GetDeletedEmployeeInsurance((int)departmentTreeView.SelectedNode.Tag);
            }
			PopulateEmployeeListView();

//			btnAdd.Visible = true;
//			btnDelete.Visible = true;
//			btnRestore.Visible = false;
//			btnPermanentDelete.Visible = false;
			
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void lvwEmployee_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				if (lvwEmployee.SelectedItems.Length > 0)
				{
					frmEmployee frm = new frmEmployee();
					frm.EmployeeDataSet = dsEmployee;
					frm.SelectedEmployee = selectedRowIndex;
					frm.ShowDialog(this);
					checkEmployeeDeleted = frm.checkkq;
					dsEmployee = employeeDO.GetEmployeeByDepartmentInsurance((int)departmentTreeView.SelectedNode.Tag);
					PopulateEmployeeListView();
				}
			}
		}

		

		
		private void txtSearch_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			txtSearch.SelectAll();
		}

		private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				dsEmployee = employeeDO.GetSearchEmployee((int)departmentTreeView.SelectedNode.Tag, txtSearch.Text,delete);
				PopulateEmployeeListView();
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			dsEmployee = employeeDO.GetSearchEmployee((int)departmentTreeView.SelectedNode.Tag, txtSearch.Text,delete);
			PopulateEmployeeListView();
		}

		private void lvwEmployee_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				if (lvwEmployee.SelectedItems.Length > 0)
				{
					frmEmployee frm = new frmEmployee();
					frm.EmployeeDataSet = dsEmployee;
					frm.SelectedEmployee = selectedRowIndex;
					frm.ShowDialog(this);
					checkEmployeeDeleted = frm.checkkq;
					dsEmployee = employeeDO.GetEmployeeByDepartmentInsurance((int)departmentTreeView.SelectedNode.Tag);
					PopulateEmployeeListView();
				}
			}
		}

		private void lvwEmployee_SelectionChanged(object sender, XPTable.Events.SelectionEventArgs e)
		{
			if (e.NewSelectedIndicies.Length > 0) 
			{
				selectedRowIndex = (int)lvwEmployee.TableModel.Rows[e.NewSelectedIndicies[0]].Tag;
			}
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
            frmListReport frmListReport = new frmListReport();
            frmListReport.ViewEmpInsurance((int)departmentTreeView.SelectedNode.Tag);
		}

       
        
		private void btnDeletedEmployee_Click(object sender, System.EventArgs e)
		{
            if (delete == 0)
            {
                //			btnAdd.Visible = false;
                //			btnDelete.Visible = false;
                btnRestore.Visible = true;
                checkEmployeeDeleted = true;
                btnPermanentDelete.Visible = false;
                delete = 1;// chon tim kiem theo danh sach nhan vien nghi
                //btnPermanentDelete.Visible = true;
                EmployeeDO employeeDO = new EmployeeDO();
                dsEmployee = employeeDO.GetDeletedEmployeeInsurance((int)departmentTreeView.SelectedNode.Tag);
                PopulateEmployeeListView();
            }
		    else if(delete==1)
		    {
                checkEmployeeDeleted = false;
		        delete = 0;
		        departmentTreeView.DepartmentDataSet = departmentDO.GetAllDepartments();
			    departmentTreeView.BuildTree();
			    departmentTreeView.SelectedNode = departmentTreeView.TopNode;
                EmployeeDO employeeDO = new EmployeeDO();
                dsEmployee = employeeDO.GetEmployeeByDepartmentInsurance((int)departmentTreeView.SelectedNode.Tag);
			    Refresh();
                btnRestore.Visible = false;
                btnPermanentDelete.Visible = true;
		    }
		}

		private void btnPermanentDelete_Click(object sender, System.EventArgs e)
		{
			string str1 = WorkingContext.LangManager.GetString("frmListEm_DeleteE_Title");
			if (lvwEmployee.SelectedItems.Length == 0)
			{
				string str2 = WorkingContext.LangManager.GetString("frmListEm_DeleteE_Messa3");
				//MessageBox.Show("Bạn chưa chọn nhân viên nào!", "Xóa nhân viên", MessageBoxButtons.OK,  MessageBoxIcon.Error);
				MessageBox.Show(str2, str1, MessageBoxButtons.OK,  MessageBoxIcon.Error);
				return;
			}
			string EmployeeName = dsEmployee.Tables[0].Rows[selectedRowIndex]["EmployeeName"].ToString();
			string str = WorkingContext.LangManager.GetString("frmListEm_DeleteE_Messa");
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa nhân viên '" + EmployeeName + "' ra khỏi danh sách ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            //DialogResult dr = MessageBox.Show(str+"'" + EmployeeName + "' ?", str1, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (dr == DialogResult.Yes)
			{
				int ret = 0;
				try
				{
					dsEmployee.Tables[0].Rows[selectedRowIndex].Delete();
					ret = employeeDO.DeleteEmployeeInsurance(dsEmployee);
				}
				catch
				{
					dsEmployee.Tables[0].RejectChanges();
				}
				if (ret != 0)
				{
					string str2 = WorkingContext.LangManager.GetString("frmListEm_DeleteE_Messa1");
					//MessageBox.Show("Nhân viên đã được xóa khỏi cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					MessageBox.Show(str2, str1, MessageBoxButtons.OK, MessageBoxIcon.Information);
					dsEmployee.Tables[0].AcceptChanges();
					//dsEmployee = employeeDO.GetDeletedEmployeeInsurance();
					PopulateEmployeeListView();
				}
				else
				{
					string str2 = WorkingContext.LangManager.GetString("frmListEm_DeleteE_Messa2");
					//MessageBox.Show("Không thể xóa nhân viên khỏi cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					MessageBox.Show(str2,str1, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					dsEmployee.Tables[0].RejectChanges();
				}
			}
		}

		private void btnRestore_Click(object sender, System.EventArgs e)
		{
			string str = WorkingContext.LangManager.GetString("frmListEm_KhoiPhucE_Title");
			if (lvwEmployee.SelectedItems.Length == 0)
			{
				string str1 = WorkingContext.LangManager.GetString("frmListEm_DeleteE_Messa3");
				//MessageBox.Show("Bạn chưa chọn nhân viên nào!", "Khôi phục nhân viên", MessageBoxButtons.OK,  MessageBoxIcon.Error);
				MessageBox.Show(str1,str, MessageBoxButtons.OK,  MessageBoxIcon.Error);
				return;
			}
			int EmployeeID = (int)dsEmployee.Tables[0].Rows[selectedRowIndex]["EmployeeID"];
			string EmployeeName = dsEmployee.Tables[0].Rows[selectedRowIndex]["EmployeeName"].ToString();
			string str2 = WorkingContext.LangManager.GetString("frmListEm_KhoiPhucE_Messa");
			//DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn khôi phục nhân viên '" + EmployeeName + "'?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			DialogResult dr = MessageBox.Show(str2+ " '"+EmployeeName + "'?", str, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (dr == DialogResult.Yes)
			{
				int ret = 0;
				try
				{
					ret = employeeDO.RestoreEmployeeInsurance(EmployeeID);
				}
				catch
				{
					dsEmployee.Tables[0].RejectChanges();
				}
				if (ret != 0)
				{
					string str3 = WorkingContext.LangManager.GetString("frmListEm_KhoiPhucE_Messa1");
					//MessageBox.Show("Nhân viên đã được khôi phục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					MessageBox.Show(str3, str, MessageBoxButtons.OK, MessageBoxIcon.Information);
					dsEmployee.Tables[0].AcceptChanges();
                    dsEmployee = employeeDO.GetDeletedEmployeeInsurance((int)departmentTreeView.SelectedNode.Tag);
					PopulateEmployeeListView();
				}
				else
				{
					string str3 = WorkingContext.LangManager.GetString("frmListEm_KhoiPhucE_Messa2");
					//MessageBox.Show("Không thể khôi phục nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					MessageBox.Show(str3, str, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					dsEmployee.Tables[0].RejectChanges();
				}
			}
		}
	}
}
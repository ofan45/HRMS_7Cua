using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVSoft.HRMS.DO;

namespace EVSoft.HRMS.UI.Schedule
{
    public partial class frmAddSalaryType : Form
    {
        int SalaryID = -1;
        string SalaryName = "";
        string SalaryDescription = "";
        string ContractName = "";
        decimal SalaryBasic = 0;
        int ContractID = -1;
        frmListTypeSalarys frmParent = new frmListTypeSalarys();
        public frmAddSalaryType(int SalaryI,string name,string descript,string ContractNam,decimal basicSalary,frmListTypeSalarys parent)
        {

            InitializeComponent();
            SalaryName = name;
            SalaryDescription = descript;
            ContractName= ContractNam;
            SalaryBasic = basicSalary;
            SalaryID= SalaryI;
            frmParent = parent;
            if (SalaryI == -1)
                btnAdd.Text = "Thêm";
            else
                btnAdd.Text = "Cập Nhật";
        }
       public void InitControl()
        {
            txtName.Text = SalaryName;
            txtDescription.Text = SalaryDescription;
            cboContract.Text = ContractName;
            txtbasicsalary.Text = SalaryBasic.ToString();
            PopulateContractCombo();
        }
        public void PopulateContractCombo()
        {
            try
            {
                ContractTypeDO contract = new ContractTypeDO();
                DataSet dsContract = new DataSet();
                dsContract = contract.GetAllContract();
                cboContract.SourceDataString = new string[] { "ContractID", "ContractName" };
                cboContract.SourceDataTable = dsContract.Tables[0];
                cboContract.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show("Phải thêm các loại hợp đồng trước khi thêm nhân viên mới!");
                this.Close();
            }            

        }
         
        private int CheckControl()
        {
            if (txtName.Text == "")
                return 1;
            else if (txtbasicsalary.Text.Trim().Equals(""))
                return 3;
            else if (decimal.Parse(txtbasicsalary.Text) > 0)
                return 0;
            else return 2;
                
                
            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int check = CheckControl();
                switch (check)
                {
                    case 0 :
                     DayTypeDO daytype = new DayTypeDO();
                     ContractID = Int16.Parse(((MTGCComboBoxItem)cboContract.SelectedItem).Col1);        
                     int result=daytype.UpdateTypeSalary(SalaryID, txtName.Text, txtDescription.Text,ContractID,decimal.Parse(txtbasicsalary.Text));
                     if(result>=2)
                     {
                         if (result == 2)
                             MessageBox.Show("Thêm thành công !", "Thông báo");
                         else if (result == 3)
                             MessageBox.Show("Cập nhật thành công !", "Thông báo");
                         frmParent.Init();
                         this.Close();
                     }
                     else MessageBox.Show("Tên kiểu lương đã tồn tại trong hệ thống !", "Thông báo");
                        
                        break;
                    case 1:
                        MessageBox.Show("Vui lòng nhập vào tên kiểu lương !", "Thông báo");
                        break;
                    case 2:
                        MessageBox.Show("Lương cơ bản > 0", "Thông báo");
                        break;
                    case 3:
                        MessageBox.Show("Vui lòng nhập lương cơ bản !", "Thông báo");
                        break;
                }
             }
            catch
            { 

            }
        }
        
       
        private void frmAddSalaryType_Load(object sender, EventArgs e)
        {
            InitControl();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtbasicsalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Lấy về đối tượng TextBox
            TextBox textBox = (TextBox)sender;

            char chrNumberDecimalSeparator = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator.ToCharArray()[0];

            // Lấy về mã ASCII của ký tự vừa được gõ vào TextBox
            char keycode = e.KeyChar;
            int c = (int)keycode;

            // Kiểm tra ký tự vừa nhập vào có phải là các số nằm trong khoảng
            // 0..9
            if ((c >= 48) && (c <= 57))
            {
                e.Handled = false;
            }
            else
                //Kiểm tra xem đã có dấu cách của số thập phân đã tồn tại chưa?
                if (c == (chrNumberDecimalSeparator) && textBox.Text.IndexOf(chrNumberDecimalSeparator) == -1)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            if (c == 8)
            {
                e.Handled = false;
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

      

    }
}
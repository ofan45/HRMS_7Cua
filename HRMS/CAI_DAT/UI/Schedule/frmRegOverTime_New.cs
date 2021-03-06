using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using EVSoft.HRMS.Controls;
using EVSoft.HRMS.DO;
using EVSoft.HRMS.Common;
using Pabo.Calendar;
using XPTable.Models;
using MonthCalendar = Pabo.Calendar.MonthCalendar;
namespace EVSoft.HRMS.UI.Schedule
{
    public partial class frmRegOverTime_New : Form
    {
        public frmRegOverTime_New()
        {
            InitializeComponent();
        }

        #region Các biến tự định nghĩa

        private int selectedRowIndex = -1;
        /// <summary>
        /// 
        /// </summary>
        private RegWorkingTimeDO workingTimeDO = null;

        /// <summary>
        /// 
        /// </summary>
        private ShiftDO shiftDO = null;

        /// <summary>
        /// 
        /// </summary>
        private DataSet dsWorkingTime = null;

        /// <summary>
        /// 
        /// </summary>
        private DataSet dsDepartment = null;

        /// <summary>
        /// 
        /// </summary>
        private int selectedDepartment = 0;

        /// <summary>
        /// 
        /// </summary>
        private DataSet dsShift = null;

        /// <summary>
        /// 
        /// </summary>
        private string[] selectedDates = null;

        /// <summary>
        /// 
        /// </summary>
        private int CurrentMonth;

        /// <summary>
        /// 
        /// </summary>
        private int CurrentYear;
        private EmployeeDO employeeDO = null;
        private DataSet dsEmployee = null;
        //private IContainer components = null;
        private DataRow[] WorkingTimeDataRows = null;
        /// <summary>
        /// 
        /// </summary>
        private string dataFilter = "";
        /// <summary>
        /// 
        /// </summary>
        private string dataSort = "";

        private DataSet dsRegOverTime = null;
        private RegOverTimeDO regOverTimeDO = null;
        private DataTable dtRegOverTime = null;
        private int selectedRegOverTime = -1;
        public DataSet DsOverTime
        {
            get { return dsRegOverTime; }
            set { dsRegOverTime = value; }
        }

        public int CurrentOverTime
        {
            get { return selectedRegOverTime; }
            set { selectedRegOverTime = value; }
        }

        #endregion

        #region Các hàm xử lý chính

        /// <summary>
        /// thiet lap lich lam viec cho nhung nhan vien duoc chon
        /// </summary>
        private void SetWorkingTime()
        {
            int DeparmentID = (int)departmentTreeView.SelectedNode.Tag;
            int employeeID = 0;
            try
            {
                //				dsWorkingTime = workingTimeDO.GetWorkingTimeByMonthNew(1, CurrentMonth, CurrentYear);
                dsEmployee = employeeDO.GetEmployeeByDepartment(DeparmentID);
                WorkingTimeDataRows = dsEmployee.Tables[0].Select(dataFilter, dataSort);
                // hien thi form thong bao trang thai hoan thanh
                frmStatusMessage message = new frmStatusMessage();
                string strStatus = WorkingContext.LangManager.GetString("frmStatus_thongbao");
                //message.Show("Đang sinh dữ liệu bảng chấm công, xin chờ trong giây lát...");
                message.Show("Đang cập nhật lịch làm thêm cho nhân viên ...");
                message.ProgressBar.Value = 0;
                //			int totalEmployees = dataRows.Length;
                Cursor = Cursors.WaitCursor;
                int percentToComplete = 0;
                int percentProcessing = 0;

                for (int i = 0; i < lvwListEmployee.SelectedIndicies.Length; i++)
                {
                    ++percentProcessing;
                    //					AddWorkingTimeByEmployee(dsWorkingTime,1);
                    // chỉ số hàng được chọn
                    int rowIndex = (int)lvwListEmployee.SelectedItems[i].Tag;
                    DataRow dr = dsEmployee.Tables[0].Rows[rowIndex];
                    employeeID = int.Parse(dr["EmployeeID"].ToString());
                    //dsWorkingTime = workingTimeDO.GetWorkingTimeByMonth(employeeID, CurrentMonth, CurrentYear);
                    //if (dsWorkingTime.Tables[0].Rows.Count > 0)
                    //{
                    //    UpdateWorkingTimeByEmployee(dsWorkingTime, employeeID);
                    //}
                    //else
                    //{
                    shiftDO = new ShiftDO();
                    shiftDO.DeleteOverTimeInMonth(CurrentMonth, CurrentYear);
                    AddWorkingTimeByEmployee(employeeID);
                    //}
                    percentToComplete = (percentProcessing * 100) / lvwListEmployee.SelectedIndicies.Length;
                    message.ProgressBar.Value = percentToComplete;

                }
                message.Close();

                Cursor = Cursors.Default;

                string str = WorkingContext.LangManager.GetString("frmRegWork_Up_Messa");
                string str1 = WorkingContext.LangManager.GetString("frmRegWork_Up_Title");
                //MessageBox.Show("Đăng ký thời gian làm việc thành công", "Đăng ký thời gian làm việc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(str, str1, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                string str = WorkingContext.LangManager.GetString("frmLunch_SetLunch_ThongBao");
                string str1 = WorkingContext.LangManager.GetString("frmLunch_SetLunch_Title");
                //MessageBox.Show("Có lỗi xảy ra khi cập nhật dữ liệu ăn trưa", "Thiết lập ăn trưa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(str, str1, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Thêm thông tin đăng ký thời gian làm việc cho tung nhan vien
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        private int AddWorkingTimeByEmployee(int employeeID)
        {
            int ret = 0;
            try
            {
                int NumDays = DateTime.DaysInMonth(CurrentYear, CurrentMonth);
                DateTime DayInMonth = new DateTime(CurrentYear, CurrentMonth, 1);
                //DataRow drEmployee = dsEmployee.Tables[0].Rows[rowIndex];
                for (int i = 1; i <= NumDays; i++)
                {
                    //DataRow dr = dsWorkingTime.Tables[0].NewRow();
                    //dr.BeginEdit();
                    //dr["EmployeeID"] = employeeID;
                    //dr["Day"] = DayInMonth;
                    //int index = 0;
                    DateItem[] dateItem = monthCalendar1.GetDateInfo(DayInMonth);
                    if (dateItem.Length > 0)
                    {
                        DataRow dr = dsRegOverTime.Tables[0].NewRow();
                        //					dr.BeginEdit();

                        dr.BeginEdit();
                        dr["EmployeeID"] = employeeID;
                        ShiftDO shiftDO = new ShiftDO();
                        DataSet dsShiftOver = shiftDO.GetShiftOverByName(dateItem[0].Text);
                        //index++;
                        
                        dr["ShiftOverID"] = dsShiftOver.Tables[0].Rows[0]["ShiftOverID"].ToString();

                        dr["StartOverTime"] = dsShiftOver.Tables[0].Rows[0]["TimeIn"].ToString();
                        DateTime startTime = Convert.ToDateTime(dsShiftOver.Tables[0].Rows[0]["TimeIn"].ToString());
                        DateTime stopTime = Convert.ToDateTime(dsShiftOver.Tables[0].Rows[0]["TimeOut"].ToString());
                        DateTime startLunch = Convert.ToDateTime(dsShiftOver.Tables[0].Rows[0]["LunchStart"].ToString());
                        DateTime stopLunch = Convert.ToDateTime(dsShiftOver.Tables[0].Rows[0]["LunchStop"].ToString());
                        DateTime startDinner = Convert.ToDateTime(dsShiftOver.Tables[0].Rows[0]["DinnerStart"].ToString());
                        DateTime stopDinner = Convert.ToDateTime(dsShiftOver.Tables[0].Rows[0]["DinnerStop"].ToString());
                        TimeSpan leng = stopTime - startTime - (stopLunch - startLunch) - (stopDinner - startDinner);
                        DateTime length = Convert.ToDateTime("12/12/2005 " + leng.Hours + ":" + leng.Minutes + ":" + leng.Milliseconds);

                        dr["Length"] = Convert.ToDateTime(length).ToShortTimeString();
                        //Convert.ToDateTime(stopTime - startTime - (stopLunch - startLunch) - (stopDinner - startDinner))
                        //    .ToShortTimeString();
                        dr["WorkingDay"] = DayInMonth.ToShortDateString();
                        dr["WorkOverTimeInfo"] = txtWorkOverTimeInfo.Text;
                        if (ckHaveDinner.Checked)
                        {
                            dr["DinnerAmount"] = Double.Parse(cboDinnnerAmount.Text);
                        }
                        else
                        {
                            dr["DinnerAmount"] = DBNull.Value;
                        }
                        dr.EndEdit();
                        dsRegOverTime.Tables[0].Rows.Add(dr);

                        ret = regOverTimeDO.AddRegOverTime(dsRegOverTime);
                        
                        //if (dateItem[0].BackColor == lblWorkingDayLegend.BackColor)
                        //{
                        //    DataRow[] drShift = dsShift.Tables[0].Select("ShiftName='" + dateItem[0].Text + "'");
                        //    dr["ShiftID"] = drShift[0]["ShiftID"];
                        //    decimal Times = Convert.ToDecimal(drShift[0]["TimeSheet"]);
                        //    dr["TimeSheet"] = Times;
                        //}
                        //else if (dateItem[0].BackColor == lblNonWorkingDayLegend.BackColor)
                        //{
                        //    dr["ShiftID"] = 0;
                        //}
                        //else if (dateItem[0].BackColor == lblHolidayLegend.BackColor)
                        //{
                        //    dr["ShiftID"] = -1;
                        //}
                        //else if (dateItem[0].BackColor == lblOverTimeLegend.BackColor)
                        //{
                        //    dr["ShiftID"] = -2;
                        //}
                    }
                    else
                    {
                        //dr["ShiftID"] = 0;
                    }
                    //dr.EndEdit();
                    //dsWorkingTime.Tables[0].Rows.Add(dr);
                    DayInMonth = DayInMonth.AddDays(1);
                }
               // ret = workingTimeDO.AddWorkingTime(dsWorkingTime);
            }
            catch
            {
            }
            return ret;
        }
        /// <summary>
        /// Thêm thông tin đăng ký thời gian làm việc cho tung nhan vien
        /// </summary>
        /// <param name="dsWorkingTime"></param>
        /// <returns></returns>
        private int UpdateWorkingTimeByEmployee(DataSet dsWorkingTime, int employeeID)
        {
            int ret = 0;
            try
            {
                foreach (DateItem dateItem in monthCalendar1.Dates)
                {
                    if (dateItem.Date.Month == CurrentMonth)
                    {
                        DataRow dr = dsWorkingTime.Tables[0].Rows[dateItem.Date.Day - 1];
                        dr.BeginEdit();
                        dr["EmployeeID"] = employeeID;
                        if (dateItem.BackColor == lblWorkingDayLegend.BackColor)
                        {
                            DataRow[] drShiftName = dsShift.Tables[0].Select("ShiftName='" + dateItem.Text + "'");
                            dr["ShiftID"] = drShiftName[0]["ShiftID"];
                            string TimeSheet = drShiftName[0]["TimeSheet"].ToString();
                            //float TimeSheet = (float)drShiftName[0]["TimeSheet"];
                            if (TimeSheet != "")
                                dr["TimeSheet"] = Convert.ToDecimal(TimeSheet);

                        }
                        else if (dateItem.BackColor == lblNonWorkingDayLegend.BackColor)
                        {
                            dr["ShiftID"] = 0;
                        }
                        else if (dateItem.BackColor == lblHolidayLegend.BackColor)
                        {
                            dr["ShiftID"] = -1;
                        }
                        else if (dateItem.BackColor == lblOverTimeLegend.BackColor)
                        {
                            dr["ShiftID"] = -2;
                        }
                        dr.EndEdit();
                    }
                }
                ret = workingTimeDO.UpdateWorkingTime(dsWorkingTime);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ret;
        }
        /// <summary>
        /// Thiết lập những ngày được chọn là ngày làm việc
        /// </summary>
        //private void SetWorkingDay()
        //{
        //    foreach (string selectedDate in selectedDates)
        //    {
        //        // Thiết lập ngày làm việc
        //        DateItem dateItem = new DateItem();
        //        dateItem.Date = DateTime.Parse(selectedDate);
        //        dateItem.BackColor = lblWorkingDayLegend.BackColor;
        //        dateItem.DateColor = lblWorkingDayLegend.ForeColor;

        //        dateItem.Text = cboShift.Text;
        //        monthCalendar1.AddDateInfo(dateItem);
        //    }
        //}

        ///// <summary>
        ///// Thiết lập những ngày được chọn là ngày nghỉ
        ///// </summary>
        //private void SetNonWorkingDay()
        //{
        //    foreach (string selectedDate in selectedDates)
        //    {
        //        // Thiết lập ngày nghỉ
        //        DateItem dateItem = new DateItem();
        //        dateItem.Date = DateTime.Parse(selectedDate);
        //        dateItem.BackColor = lblNonWorkingDayLegend.BackColor;
        //        dateItem.DateColor = lblNonWorkingDayLegend.ForeColor;
        //        dateItem.Text = "";
        //        monthCalendar1.AddDateInfo(dateItem);

        //    }
        //}

        ///// <summary>
        ///// Thiết lập những ngày được chọn là ngày nghỉ
        ///// </summary>
        //private void SetHoliday()
        //{
        //    foreach (string selectedDate in selectedDates)
        //    {
        //        // Thiết lập ngày lễ
        //        DateItem dateItem = new DateItem();
        //        dateItem.Date = DateTime.Parse(selectedDate);
        //        dateItem.BackColor = lblHolidayLegend.BackColor;
        //        dateItem.DateColor = lblHolidayLegend.ForeColor;
        //        dateItem.Text = "";
        //        monthCalendar1.AddDateInfo(dateItem);

        //    }
        //}

        /// <summary>
        /// Thiết lập những ngày được chọn là ngày làm thêm hệ số 1
        /// </summary>
        private void SetOverTime()
        {
            foreach (string selectedDate in selectedDates)
            {
                // Thiết lập ngày lễ
                DateItem dateItem = new DateItem();
                dateItem.Date = DateTime.Parse(selectedDate);
                dateItem.BackColor = lblOverTimeLegend.BackColor;
                dateItem.DateColor = lblOverTimeLegend.ForeColor;
                dateItem.Text = cboShift.Text;
                monthCalendar1.AddDateInfo(dateItem);
            }
        }

        /// <summary>
        /// Xóa các thiết lập cũ của những ngày được chọn
        /// </summary>
        private void RemoveOldDateInfo()
        {
            foreach (string selectedDate in selectedDates)
            {
                DateItem[] oldDateItems = monthCalendar1.GetDateInfo(DateTime.Parse(selectedDate));
                if (oldDateItems.Length > 0)
                {
                    foreach (DateItem oldDateItem in oldDateItems)
                    {
                        monthCalendar1.RemoveDateInfo(oldDateItem);
                    }
                }
            }
        }

        /// <summary>
        /// Tạo ComboBox danh sách các ca làm việc
        /// </summary>
        private void PopulateShiftCombo()
        {
            ShiftDO shiftDO = new ShiftDO();
            DataSet dsShift = shiftDO.GetShiftOver();

            cboShift.DataSource = dsShift.Tables[0];
            cboShift.DisplayMember = "ShiftName";
            cboShift.ValueMember = "ShiftOverID";
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadDateStatus()
        {
            //			// Kiểm tra những ngày được chọn có cùng kiểu ngày: Ngày nghỉ, làm việc, mặc định
            //			bool isDayTypeSimilar = true;
            //			// Kiểm tra những ngày được chọn có cùng ca làm việc
            //			bool isShiftSimilar = true;
            // Lay trang thai cua ngay duoc chon dau tien
            DateItem[] firstDateItems = monthCalendar1.GetDateInfo(DateTime.Parse(selectedDates[0]));

            if (selectedDates.Length == 1)
            {
                if (firstDateItems.Length > 0)
                {
                    cboShift.Text = firstDateItems[0].Text;
                    if (firstDateItems[0].DateColor == lblWorkingDayLegend.ForeColor)
                    {
                        //rbtWorkingDay.Checked = true;
                    }
                    else if (firstDateItems[0].DateColor == lblNonWorkingDayLegend.ForeColor)
                    {
                        //rbtNonWorkingDay.Checked = true;
                    }
                    else if (firstDateItems[0].DateColor == lblHolidayLegend.ForeColor)
                    {
                       // rbtHoliday.Checked = true;
                    }
                    else if (firstDateItems[0].DateColor == lblOverTimeLegend.ForeColor)
                    {
                        //rbtOverTime.Checked = true;
                    }
                }
            }
            else
            {
                cboShift.Text = "";
                //rbtWorkingDay.Checked = false;
                //rbtNonWorkingDay.Checked = false;
                //rbtHoliday.Checked = false;
            }

        }

        #endregion

        #region Windows Form event handlers

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string str = WorkingContext.LangManager.GetString("frmRegOverTime1_Messa3");
            string str1 = WorkingContext.LangManager.GetString("frmRegRest_DK_Title");
            //MessageBox.Show("Chức năng này đang được xây dựng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show(str, str1, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmRegWorkingTime_Load(object sender, EventArgs e)
        {
            Refresh();

            cboDinnnerAmount.Enabled = false;
            employeeDO = new EmployeeDO();

            DepartmentDO departnemtDO = new DepartmentDO();
            departmentTreeView.DepartmentDataSet = departnemtDO.GetAllDepartments();
            departmentTreeView.BuildTree();
            departmentTreeView.ExpandNodes(true);
            departmentTreeView.SelectedNode = departmentTreeView.TopNode;

            regOverTimeDO = new RegOverTimeDO();
            dtRegOverTime = dsRegOverTime.Tables[0];

            monthCalendar1.SelectDate(DateTime.Today);

            //CurrentYear = DateTime.Today.Year;
            CurrentYear = DateTime.Now.Year;
            monthCalendar1.ActiveMonth.Year = CurrentYear;
            CurrentMonth = DateTime.Today.Month;
            monthCalendar1.ActiveMonth.Month = CurrentMonth;

            monthCalendar1.SelectDate(DateTime.Today);

            if (selectedRegOverTime >= 0)
            {
                // disable các thuộc tính liên quan đến nhân viên
                string str = WorkingContext.LangManager.GetString("frmRegOverTime1_Text2");
                //this.Text = "Sửa đăng ký làm thêm giờ";
                this.Text = str;
                LoadRegOverTime();
                //				optEmployee.Checked = true;
                departmentTreeView.Enabled = false;
                //				optAll.Enabled = false;
                //dtpDayWorking.Enabled = false;
                //cboEmployeeName.Enabled = false;
                lvwListEmployee.Enabled = false;
            }
            else
            {
                string str = WorkingContext.LangManager.GetString("frmRegOverTime1_Text1");
                //this.Text = "Thêm đăng ký làm thêm giờ";
                this.Text = str;
                //txtEmployeeName.Enabled = false;
                //cboEmployeeName.Enabled = false;


            }
            PopulateShiftCombo();
        }

        /// <summary>
        /// Hiển thị dữ liệu đăng ký làm thêm giờ của một nhân viên
        /// </summary>
        private void LoadRegOverTime()
        {
            DataRow dr = dtRegOverTime.Rows[selectedRegOverTime];
            if (dr != null)
            {
                //cboEmployeeName.Text = dr["CardID"].ToString();
                //dtpDayWorking.Value = DateTime.Parse(dr["WorkingDay"].ToString());
                if (dr["ShiftName"] != null)
                    cboShift.Text = dr["ShiftName"].ToString();
                //dtpStartTimeOver.Value = DateTime.Parse(dr["StartOverTime"].ToString());
                //dtpLength.Value = DateTime.Parse(dr["Length"].ToString());
                txtWorkOverTimeInfo.Text = dr["WorkOverTimeInfo"].ToString();
                if (dr["DinnerAmount"] != DBNull.Value)
                {
                    ckHaveDinner.Checked = true;
                    cboDinnnerAmount.Enabled = true;
                    cboDinnnerAmount.Text = dr["DinnerAmount"].ToString();
                    //					txtDinnerAmount.Enabled = true;
                    //					txtDinnerAmount.Double = Double.Parse(dr["DinnerAmount"].ToString());
                }
                else
                {

                    ckHaveDinner.Checked = false;
                    cboDinnnerAmount.Enabled = false;
                }
            }
        }

        private void monthCalendar1_DaySelected(object sender, DaySelectedEventArgs e)
        {
            selectedDates = e.Days;
            //SetStatus(true);
            //LoadDateStatus();
        }

        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedDates != null)
            {
                RemoveOldDateInfo();
                if (!deleteOverTime.Checked)
                {
                    SetOverTime();

                }
                else
                {
                    shiftDO = new ShiftDO();
                    shiftDO.DeleteOverTimeInMonth(CurrentMonth, CurrentYear);
                }
                
            }
            
            if (monthCalendar1.Dates.Count > 0)
            {
                SetWorkingTime();
            }

        }

        private void monthCalendar1_MonthChanged(object sender, MonthChangedEventArgs e)
        {
            CurrentMonth = e.Month;
            CurrentYear = e.Year;
            //			LoadWorkingCalendar();
        }

        private void cboShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (rbtWorkingDay.Checked)
            //{
                cboShift.Enabled = true;

                if (selectedDates != null)
                {
                    RemoveOldDateInfo();
                    SetOverTime();
                }
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //			LoadWorkingCalendar();
        }

        private void departmentTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedDepartment = (int)departmentTreeView.SelectedNode.Tag;
            departmentTreeView.ExpandNodes(true);
            LoadEmployeeeInDepartment();
            //			LoadWorkingCalendar();
        }
        /// <summary>
        /// Dien thong tin nhan vien un'g voi' phong duoc chon
        /// </summary>
        private void LoadEmployeeeInDepartment()
        {
            //			dsLunch = lunchDO.GetLunch((int)departmentTreeView.SelectedNode.Tag, dtpWorkingDay.Value.Date);
            dsEmployee = employeeDO.GetEmployeeByDepartment((int)departmentTreeView.SelectedNode.Tag);
            //			LunchDataRows = dsLunch.Tables[0].Select(dataFilter, dataSort);


            lvwListEmployee.BeginUpdate();
            lvwListEmployee.TableModel.Rows.Clear();

            int STT = 0;
            foreach (DataRow dr in dsEmployee.Tables[0].Rows)
            {
                string CardID = dr["CardID"].ToString();
                string EmployeeName = dr["EmployeeName"].ToString();
                string EmployeeID = dr["EmployeeID"].ToString();
                Cell[] cells = new Cell[4];
                cells[0] = new Cell(STT + 1);
                cells[1] = new Cell(CardID);
                cells[2] = new Cell(EmployeeName);
                cells[3] = new Cell(EmployeeID);
                Row row = new Row(cells);
                row.Tag = STT;
                lvwListEmployee.TableModel.Rows.Add(row);
                STT++;
            }
            lvwListEmployee.EndUpdate();

        }
        /// <summary>
        /// 
        /// </summary>
        ///// <param name="status"></param>
        //private void SetStatus(bool status)
        //{
        //    rbtHoliday.Enabled = status;
        //    rbtWorkingDay.Enabled = status;
        //    rbtNonWorkingDay.Enabled = status;
        //    rbtOverTime.Enabled = status;
        //}

        public override void Refresh()
        {
            ChangeToCurrentLang();

            foreach (Form form in MdiChildren)
            {
                form.Refresh();
            }

            base.Refresh();
        }

        private void ChangeToCurrentLang()
        {
            //Text = WorkingContext.LangManager.GetString("frmRegWork_Text");
            groupBox2.Text = WorkingContext.LangManager.GetString("frmRegWork_groupbox2");
            groupBox3.Text = WorkingContext.LangManager.GetString("frmRegWork_groupbox3");
            groupBox4.Text = WorkingContext.LangManager.GetString("frmRegWork_groupbox4");
            groupBox5.Text = WorkingContext.LangManager.GetString("frmRegWork_groupbox5");
            //rbtWorkingDay.Text = WorkingContext.LangManager.GetString("frmRegWork_rptWork");
            //rbtOverTime.Text = WorkingContext.LangManager.GetString("frmRegWork_rptOverTime");
            //rbtNonWorkingDay.Text = WorkingContext.LangManager.GetString("frmRegWork_rptNonWork");
            //rbtHoliday.Text = WorkingContext.LangManager.GetString("frmRegWork_rptHoliday");
            lblShift.Text = WorkingContext.LangManager.GetString("frmRegWork_lblShif");
            lblWorkingDay.Text = WorkingContext.LangManager.GetString("frmRegWork_lblWork");
            lblNonWorkingDay.Text = WorkingContext.LangManager.GetString("frmRegWork_lblNonWork");
            lblOverTime.Text = WorkingContext.LangManager.GetString("frmRegWork_lblOverTime");
            label2.Text = WorkingContext.LangManager.GetString("frmRegWork_lable2");
            btnHelp.Text = WorkingContext.LangManager.GetString("frmRegWork_btnHelp");
            btnUpdate.Text = WorkingContext.LangManager.GetString("frmRegWork_btnUpdate");
            btnCancel.Text = WorkingContext.LangManager.GetString("frmRegWork_btnCancel");
            btnClose.Text = WorkingContext.LangManager.GetString("frmRegWork_btnClose");
            btnSelectAll.Text = WorkingContext.LangManager.GetString("frmGroup_cmdSelectAll");
            btnSelectNone.Text = WorkingContext.LangManager.GetString("frmGroup_cmdClearAll");
            btnHelp.Text = WorkingContext.LangManager.GetString("frmChangeTimeInOut_bntHelp");
            groupBox1.Text = WorkingContext.LangManager.GetString("frmEmployeeStatus_grpEmployee");



        }
        #endregion

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            tableModel1.Selections.SelectCells(0, 0, lvwListEmployee.RowCount - 1, 0);
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            tableModel1.Selections.Clear();
        }

        private void lvwListEmployee_Click(object sender, EventArgs e)
        {
            monthCalendar1.TodayColor = Color.Red;
            //			monthCalendar1.BackColor = Color.Red;
            LoadWorkingCalendarByEmployee();
        }
        /// <summary>
        /// 
        /// </summary>
        private void LoadWorkingCalendarByEmployee()
        {
            monthCalendar1.Dates.Clear();
            int DeparmentID = (int)departmentTreeView.SelectedNode.Tag;
            dsEmployee = employeeDO.GetEmployeeByDepartment(DeparmentID);
            int employeeID = (int)dsEmployee.Tables[0].Rows[selectedRowIndex]["EmployeeID"];
            workingTimeDO = new RegWorkingTimeDO();
            dsWorkingTime = workingTimeDO.GetOverTimeByMonth(employeeID, CurrentMonth, CurrentYear);
            shiftDO = new ShiftDO();
            DataSet dsShiftOver = new DataSet();
            if (dsWorkingTime.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsWorkingTime.Tables[0].Rows)
                {
                    DateTime Day = DateTime.Parse(dr["WorkingDay"].ToString());
                    int ShiftOverID = int.Parse(dr["ShiftOverID"].ToString());
                    dsShiftOver = shiftDO.GetShiftOverByID(ShiftOverID);
                    
                    DateItem dateItem = new DateItem();
                    dateItem.DateColor = lblOverTimeLegend.ForeColor;
                    dateItem.BackColor = lblOverTimeLegend.BackColor;
                    dateItem.Date = Day;
                    if (dsShiftOver != null)
                        dateItem.Text = dsShiftOver.Tables[0].Rows[0]["ShiftName"].ToString();
                    monthCalendar1.AddDateInfo(dateItem);
                    
                }
            }
            monthCalendar1.Refresh();
            monthCalendar1.ClearSelection();

        }

        private void lvwListEmployee_SelectionChanged(object sender, XPTable.Events.SelectionEventArgs e)
        {
            if (e.NewSelectedIndicies.Length > 0)
            {
                selectedRowIndex = (int)lvwListEmployee.TableModel.Rows[e.NewSelectedIndicies[0]].Tag;
            }
        }

        private void ckHaveDinner_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHaveDinner.Checked)
            {
                cboDinnnerAmount.Enabled = true;
                cboDinnnerAmount.SelectedIndex = 2;
            }
            else
            {
                cboDinnnerAmount.Enabled = false;
            }
        }

        /// <summary>
        /// Đăng ký làm thêm giờ 
        /// </summary>
        public void RegDepartmentOverTime(DateTime workingDay)
        {
            frmMessage frmMessage = new frmMessage();
            string OverTimeMessage = "";
            int STT = 0;

            for (int i = 0; i < lvwListEmployee.SelectedIndicies.Length; i++)
            {
                // chỉ số hàng được chọn
                int rowIndex = (int)lvwListEmployee.SelectedItems[i].Tag;
                DataRow drEmployee = dsEmployee.Tables[0].Rows[rowIndex];
                //				dr.BeginEdit();

                //			foreach (DataRow drEmployee in dsEmployee.Tables[0].Rows)
                //			{
                int ret = 0;
                try
                {
                    DataRow dr = dsRegOverTime.Tables[0].NewRow();
                    //					dr.BeginEdit();

                    dr.BeginEdit();
                    dr["EmployeeID"] = drEmployee["EmployeeID"];
                    ShiftDO shiftDO = new ShiftDO();
                    DataSet dsShiftOver = shiftDO.GetShiftOverByID(int.Parse(cboShift.SelectedValue.ToString()));
                    dr["ShiftOverID"] = dsShiftOver.Tables[0].Rows[0]["ShiftOverID"].ToString();

                    dr["StartOverTime"] = dsShiftOver.Tables[0].Rows[0]["TimeIn"].ToString();
                    DateTime startTime = Convert.ToDateTime(dsShiftOver.Tables[0].Rows[0]["TimeIn"].ToString());
                    DateTime stopTime = Convert.ToDateTime(dsShiftOver.Tables[0].Rows[0]["TimeOut"].ToString());
                    DateTime startLunch = Convert.ToDateTime(dsShiftOver.Tables[0].Rows[0]["LunchStart"].ToString());
                    DateTime stopLunch = Convert.ToDateTime(dsShiftOver.Tables[0].Rows[0]["LunchStop"].ToString());
                    DateTime startDinner = Convert.ToDateTime(dsShiftOver.Tables[0].Rows[0]["DinnerStart"].ToString());
                    DateTime stopDinner = Convert.ToDateTime(dsShiftOver.Tables[0].Rows[0]["DinnerStop"].ToString());
                    TimeSpan leng = stopTime - startTime - (stopLunch - startLunch) - (stopDinner - startDinner);
                    DateTime length = Convert.ToDateTime("12/12/2005 " + leng.Hours + ":" + leng.Minutes + ":" + leng.Milliseconds);

                    dr["Length"] = Convert.ToDateTime(length).ToShortTimeString();
                    //Convert.ToDateTime(stopTime - startTime - (stopLunch - startLunch) - (stopDinner - startDinner))
                    //    .ToShortTimeString();
                    dr["WorkingDay"] = workingDay.ToShortDateString();
                    dr["WorkOverTimeInfo"] = txtWorkOverTimeInfo.Text;
                    if (ckHaveDinner.Checked)
                    {
                        dr["DinnerAmount"] = Double.Parse(cboDinnnerAmount.Text);
                    }
                    else
                    {
                        dr["DinnerAmount"] = DBNull.Value;
                    }
                    dr.EndEdit();
                    dsRegOverTime.Tables[0].Rows.Add(dr);

                    ret = regOverTimeDO.AddRegOverTime(dsRegOverTime);
                }
                catch
                {
                }
                if (ret == EmployeeStatus.EMPLOYEE_LEAVE)
                {
                    OverTimeMessage = drEmployee["CardID"] + " - " + drEmployee["EmployeeName"] + " đã đi công tác";
                    STT++;
                    frmMessage.AddMessage(STT.ToString() + ". " + OverTimeMessage);
                }

                if (ret == EmployeeStatus.EMPLOYEE_REST)
                {
                    OverTimeMessage = drEmployee["CardID"] + " - " + drEmployee["EmployeeName"] + " đã đăng ký nghỉ";
                    STT++;
                    frmMessage.AddMessage(STT.ToString() + ". " + OverTimeMessage);
                }
                //else if (ret == EmployeeStatus.EMPLOYEE_ABSENT)
                //{

                //    OverTimeMessage = drEmployee["CardID"] + " - " + drEmployee["EmployeeName"] + " vắng mặt";
                //    STT++;
                //    frmMessage.AddMessage(STT.ToString() + ". " + OverTimeMessage);
                //}
            }
            if (STT != 0)
            {
                frmMessage.Show();
            }
            else
            {
                frmMessage.Close();
                string str = WorkingContext.LangManager.GetString("frmRegOverTime1_DangKyOT_Messa1");
                string str1 = WorkingContext.LangManager.GetString("frmRegOverTime1_DangKyOT_Title");
                //MessageBox.Show("Không thể đăng ký làm thêm giờ cho nhân viên này", "Đăng ký làm thêm giờ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(str, str1, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //				if ((this.Text =="Thêm đăng ký làm thêm giờ" )|| (this.Text == "Sửa đăng ký làm thêm giờ"))
                //				{
                //					MessageBox.Show("Đăng ký làm thêm giờ cho bộ phận " + departmentTreeView.SelectedNode.Text + " thành công!", "Đăng ký làm thêm giờ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //				}
                //				else
                //				{
                //					MessageBox.Show(departmentTreeView.SelectedNode.Text +" の部門の残業登録が正常に完了しました !","",MessageBoxButtons.OK, MessageBoxIcon.Information);
                //						
                //				}
            }
        }

        private void deleteOverTime_CheckedChanged(object sender, EventArgs e)
        {
            if(deleteOverTime.Checked)
            {
                RemoveOldDateInfo();
            }
        }
        
    }
}
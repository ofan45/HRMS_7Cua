namespace EVSoft.HRMS.UI.Schedule
{//345
    partial class frmRegOverTime_New
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblOverTime = new System.Windows.Forms.Label();
            this.lblHolidayLegend = new System.Windows.Forms.Label();
            this.lblOverTimeLegend = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvwListEmployee = new XPTable.Models.Table();
            this.columnModel1 = new XPTable.Models.ColumnModel();
            this.cSTT = new XPTable.Models.NumberColumn();
            this.cCardID = new XPTable.Models.TextColumn();
            this.cEmployeeName = new XPTable.Models.TextColumn();
            this.tableModel1 = new XPTable.Models.TableModel();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblNonWorkingDay = new System.Windows.Forms.Label();
            this.lblNonWorkingDayLegend = new System.Windows.Forms.Label();
            this.lblWorkingDay = new System.Windows.Forms.Label();
            this.lblWorkingDayLegend = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.monthCalendar1 = new Pabo.Calendar.MonthCalendar();
            this.btnHelp = new System.Windows.Forms.Button();
            this.cboShift = new System.Windows.Forms.LookupComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deleteOverTime = new System.Windows.Forms.CheckBox();
            this.cboDinnnerAmount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckHaveDinner = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.departmentTreeView = new EVSoft.HRMS.Controls.DepartmentTreeView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWorkOverTimeInfo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvwListEmployee)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblShift
            // 
            this.lblShift.Location = new System.Drawing.Point(10, 16);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(56, 23);
            this.lblShift.TabIndex = 72;
            this.lblShift.Text = "Chọn ca:";
            this.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOverTime
            // 
            this.lblOverTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOverTime.Location = new System.Drawing.Point(152, 16);
            this.lblOverTime.Name = "lblOverTime";
            this.lblOverTime.Size = new System.Drawing.Size(56, 23);
            this.lblOverTime.TabIndex = 7;
            this.lblOverTime.Text = "Làm thêm";
            this.lblOverTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHolidayLegend
            // 
            this.lblHolidayLegend.BackColor = System.Drawing.Color.Salmon;
            this.lblHolidayLegend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHolidayLegend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblHolidayLegend.ForeColor = System.Drawing.Color.Maroon;
            this.lblHolidayLegend.Location = new System.Drawing.Point(120, 40);
            this.lblHolidayLegend.Name = "lblHolidayLegend";
            this.lblHolidayLegend.Size = new System.Drawing.Size(32, 23);
            this.lblHolidayLegend.TabIndex = 6;
            this.lblHolidayLegend.Text = "31";
            this.lblHolidayLegend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOverTimeLegend
            // 
            this.lblOverTimeLegend.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblOverTimeLegend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOverTimeLegend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblOverTimeLegend.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblOverTimeLegend.Location = new System.Drawing.Point(120, 16);
            this.lblOverTimeLegend.Name = "lblOverTimeLegend";
            this.lblOverTimeLegend.Size = new System.Drawing.Size(32, 23);
            this.lblOverTimeLegend.TabIndex = 8;
            this.lblOverTimeLegend.Text = "7";
            this.lblOverTimeLegend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(152, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ngày lễ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectAll.Location = new System.Drawing.Point(87, 641);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 93;
            this.btnSelectAll.Text = "Chọn tất";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lvwListEmployee);
            this.groupBox1.Location = new System.Drawing.Point(7, 256);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 377);
            this.groupBox1.TabIndex = 92;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách nhân viên";
            // 
            // lvwListEmployee
            // 
            this.lvwListEmployee.AlternatingRowColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.lvwListEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwListEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(249)))));
            this.lvwListEmployee.ColumnModel = this.columnModel1;
            this.lvwListEmployee.EnableToolTips = true;
            this.lvwListEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(66)))), ((int)(((byte)(121)))));
            this.lvwListEmployee.FullRowSelect = true;
            this.lvwListEmployee.GridColor = System.Drawing.SystemColors.ControlDark;
            this.lvwListEmployee.GridLines = XPTable.Models.GridLines.Both;
            this.lvwListEmployee.GridLineStyle = XPTable.Models.GridLineStyle.Dot;
            this.lvwListEmployee.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lvwListEmployee.Location = new System.Drawing.Point(8, 16);
            this.lvwListEmployee.MultiSelect = true;
            this.lvwListEmployee.Name = "lvwListEmployee";
            this.lvwListEmployee.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(183)))), ((int)(((byte)(201)))));
            this.lvwListEmployee.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(66)))), ((int)(((byte)(121)))));
            this.lvwListEmployee.SelectionStyle = XPTable.Models.SelectionStyle.Grid;
            this.lvwListEmployee.Size = new System.Drawing.Size(264, 353);
            this.lvwListEmployee.SortedColumnBackColor = System.Drawing.Color.Transparent;
            this.lvwListEmployee.TabIndex = 80;
            this.lvwListEmployee.TableModel = this.tableModel1;
            this.lvwListEmployee.UnfocusedSelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.lvwListEmployee.UnfocusedSelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(66)))), ((int)(((byte)(121)))));
            this.lvwListEmployee.Click += new System.EventHandler(this.lvwListEmployee_Click);
            this.lvwListEmployee.SelectionChanged += new XPTable.Events.SelectionEventHandler(this.lvwListEmployee_SelectionChanged);
            // 
            // columnModel1
            // 
            this.columnModel1.Columns.AddRange(new XPTable.Models.Column[] {
            this.cSTT,
            this.cCardID,
            this.cEmployeeName});
            // 
            // cSTT
            // 
            this.cSTT.Text = "STT";
            this.cSTT.Width = 45;
            // 
            // cCardID
            // 
            this.cCardID.Text = "Mã thẻ";
            // 
            // cEmployeeName
            // 
            this.cEmployeeName.Text = "Tên nhânviên";
            this.cEmployeeName.Width = 120;
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectNone.Location = new System.Drawing.Point(167, 641);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(75, 23);
            this.btnSelectNone.TabIndex = 94;
            this.btnSelectNone.Text = "Bỏ chọn";
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblOverTime);
            this.groupBox3.Controls.Add(this.lblOverTimeLegend);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lblHolidayLegend);
            this.groupBox3.Controls.Add(this.lblNonWorkingDay);
            this.groupBox3.Controls.Add(this.lblNonWorkingDayLegend);
            this.groupBox3.Controls.Add(this.lblWorkingDay);
            this.groupBox3.Controls.Add(this.lblWorkingDayLegend);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(647, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(216, 72);
            this.groupBox3.TabIndex = 90;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Quy ước mầu";
            // 
            // lblNonWorkingDay
            // 
            this.lblNonWorkingDay.Location = new System.Drawing.Point(40, 40);
            this.lblNonWorkingDay.Name = "lblNonWorkingDay";
            this.lblNonWorkingDay.Size = new System.Drawing.Size(80, 23);
            this.lblNonWorkingDay.TabIndex = 1;
            this.lblNonWorkingDay.Text = "Ngày nghỉ";
            this.lblNonWorkingDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNonWorkingDayLegend
            // 
            this.lblNonWorkingDayLegend.BackColor = System.Drawing.Color.MistyRose;
            this.lblNonWorkingDayLegend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNonWorkingDayLegend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNonWorkingDayLegend.ForeColor = System.Drawing.Color.DarkRed;
            this.lblNonWorkingDayLegend.Location = new System.Drawing.Point(8, 40);
            this.lblNonWorkingDayLegend.Name = "lblNonWorkingDayLegend";
            this.lblNonWorkingDayLegend.Size = new System.Drawing.Size(32, 23);
            this.lblNonWorkingDayLegend.TabIndex = 4;
            this.lblNonWorkingDayLegend.Text = "15";
            this.lblNonWorkingDayLegend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorkingDay
            // 
            this.lblWorkingDay.Location = new System.Drawing.Point(40, 16);
            this.lblWorkingDay.Name = "lblWorkingDay";
            this.lblWorkingDay.Size = new System.Drawing.Size(80, 23);
            this.lblWorkingDay.TabIndex = 0;
            this.lblWorkingDay.Text = "Ngày làm việc";
            this.lblWorkingDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWorkingDayLegend
            // 
            this.lblWorkingDayLegend.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblWorkingDayLegend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWorkingDayLegend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblWorkingDayLegend.ForeColor = System.Drawing.Color.Navy;
            this.lblWorkingDayLegend.Location = new System.Drawing.Point(8, 16);
            this.lblWorkingDayLegend.Name = "lblWorkingDayLegend";
            this.lblWorkingDayLegend.Size = new System.Drawing.Size(32, 23);
            this.lblWorkingDayLegend.TabIndex = 3;
            this.lblWorkingDayLegend.Text = "1";
            this.lblWorkingDayLegend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(791, 641);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 85;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.Location = new System.Drawing.Point(631, 641);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 84;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.ActiveMonth.Month = 6;
            this.monthCalendar1.ActiveMonth.RaiseEvent = true;
            this.monthCalendar1.ActiveMonth.Year = 2006;
            this.monthCalendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.monthCalendar1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            //this.monthCalendar1.Culture = new System.Globalization.CultureInfo(global::EVSoft.HRMS.Common.Lang.LangResource_ja_JP.frmShift_label8);
            this.monthCalendar1.Footer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendar1.Header.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthCalendar1.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendar1.Header.TextColor = System.Drawing.Color.White;
            this.monthCalendar1.ImageList = null;
            this.monthCalendar1.Location = new System.Drawing.Point(8, 16);
            this.monthCalendar1.MaxDate = new System.DateTime(2020, 11, 9, 0, 0, 0, 0);
            this.monthCalendar1.MinDate = new System.DateTime(1995, 11, 9, 19, 19, 39, 781);
            this.monthCalendar1.Month.Colors.Background = System.Drawing.Color.GhostWhite;
            this.monthCalendar1.Month.Colors.FocusBackground = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.monthCalendar1.Month.Colors.FocusBorder = System.Drawing.SystemColors.ActiveCaption;
            this.monthCalendar1.Month.Colors.FocusDate = System.Drawing.Color.Black;
            this.monthCalendar1.Month.Colors.FocusText = System.Drawing.Color.Black;
            this.monthCalendar1.Month.Colors.SelectedBackground = System.Drawing.SystemColors.ActiveCaption;
            this.monthCalendar1.Month.Colors.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(185)))));
            this.monthCalendar1.Month.Colors.SelectedDate = System.Drawing.Color.Black;
            this.monthCalendar1.Month.Colors.SelectedText = System.Drawing.Color.Black;
            this.monthCalendar1.Month.Colors.WeekendBackground = System.Drawing.Color.MistyRose;
            this.monthCalendar1.Month.Colors.WeekendDate = System.Drawing.Color.DarkRed;
            this.monthCalendar1.Month.DateFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.monthCalendar1.Month.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.SelectionMode = Pabo.Calendar.mcSelectionMode.MultiExtended;
            this.monthCalendar1.SelectTrailingDates = false;
            this.monthCalendar1.ShowTrailingDates = false;
            this.monthCalendar1.Size = new System.Drawing.Size(552, 446);
            this.monthCalendar1.TabIndex = 67;
            this.monthCalendar1.WeekDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar1.WeekDays.TextColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthCalendar1.WeekNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar1.WeekNumbers.TextColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthCalendar1.DaySelected += new Pabo.Calendar.DaySelectedEventHandler(this.monthCalendar1_DaySelected);
            this.monthCalendar1.MonthChanged += new Pabo.Calendar.MonthChangedEventHandler(this.monthCalendar1_MonthChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHelp.Location = new System.Drawing.Point(7, 641);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 86;
            this.btnHelp.Text = "Trợ giúp";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // cboShift
            // 
            this.cboShift.AllowTypeAllSymbols = false;
            this.cboShift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShift.DropDownWidth = 200;
            this.cboShift.ItemHeight = 13;
            this.cboShift.Location = new System.Drawing.Point(66, 16);
            this.cboShift.Name = "cboShift";
            this.cboShift.Size = new System.Drawing.Size(152, 21);
            this.cboShift.TabIndex = 0;
            this.cboShift.SelectedIndexChanged += new System.EventHandler(this.cboShift_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.monthCalendar1);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(295, 163);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(568, 470);
            this.groupBox4.TabIndex = 87;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lịch làm việc";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(711, 641);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 89;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.deleteOverTime);
            this.groupBox2.Controls.Add(this.cboDinnnerAmount);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ckHaveDinner);
            this.groupBox2.Controls.Add(this.lblShift);
            this.groupBox2.Controls.Add(this.cboShift);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(295, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 72);
            this.groupBox2.TabIndex = 91;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thiết lập ngày";
            // 
            // deleteOverTime
            // 
            this.deleteOverTime.Location = new System.Drawing.Point(221, 16);
            this.deleteOverTime.Name = "deleteOverTime";
            this.deleteOverTime.Size = new System.Drawing.Size(119, 20);
            this.deleteOverTime.TabIndex = 87;
            this.deleteOverTime.Text = "Xóa ca làm thêm";
            this.deleteOverTime.Visible = false;
            this.deleteOverTime.CheckedChanged += new System.EventHandler(this.deleteOverTime_CheckedChanged);
            // 
            // cboDinnnerAmount
            // 
            this.cboDinnnerAmount.Items.AddRange(new object[] {
            "4000",
            "5000",
            "6000",
            "7000",
            "8000",
            "9000",
            "10000",
            "15000"});
            this.cboDinnnerAmount.Location = new System.Drawing.Point(251, 45);
            this.cboDinnnerAmount.Name = "cboDinnnerAmount";
            this.cboDinnnerAmount.Size = new System.Drawing.Size(56, 21);
            this.cboDinnnerAmount.TabIndex = 86;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(167, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 21);
            this.label1.TabIndex = 85;
            this.label1.Text = "PC tiền ăn";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckHaveDinner
            // 
            this.ckHaveDinner.Location = new System.Drawing.Point(13, 44);
            this.ckHaveDinner.Name = "ckHaveDinner";
            this.ckHaveDinner.Size = new System.Drawing.Size(162, 20);
            this.ckHaveDinner.TabIndex = 84;
            this.ckHaveDinner.Text = "Hưởng suất ăn thêm";
            this.ckHaveDinner.CheckedChanged += new System.EventHandler(this.ckHaveDinner_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.departmentTreeView);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox5.Location = new System.Drawing.Point(7, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(280, 240);
            this.groupBox5.TabIndex = 88;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Danh sách phòng ban";
            // 
            // departmentTreeView
            // 
            this.departmentTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.departmentTreeView.BackColor = System.Drawing.Color.GhostWhite;
            this.departmentTreeView.DepartmentDataSet = null;
            this.departmentTreeView.ImageIndex = 0;
            this.departmentTreeView.Location = new System.Drawing.Point(8, 16);
            this.departmentTreeView.Name = "departmentTreeView";
            this.departmentTreeView.SelectedImageIndex = 0;
            this.departmentTreeView.Size = new System.Drawing.Size(264, 216);
            this.departmentTreeView.TabIndex = 4;
            this.departmentTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.departmentTreeView_AfterSelect);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(292, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 18);
            this.label5.TabIndex = 83;
            this.label5.Text = "Nội dung công việc";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWorkOverTimeInfo
            // 
            this.txtWorkOverTimeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkOverTimeInfo.Location = new System.Drawing.Point(295, 113);
            this.txtWorkOverTimeInfo.Multiline = true;
            this.txtWorkOverTimeInfo.Name = "txtWorkOverTimeInfo";
            this.txtWorkOverTimeInfo.Size = new System.Drawing.Size(568, 44);
            this.txtWorkOverTimeInfo.TabIndex = 95;
            // 
            // frmRegOverTime_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 671);
            this.Controls.Add(this.txtWorkOverTimeInfo);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSelectNone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Name = "frmRegOverTime_New";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký làm thêm giờ";
            this.Load += new System.EventHandler(this.frmRegWorkingTime_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvwListEmployee)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label lblOverTime;
        private System.Windows.Forms.Label lblHolidayLegend;
        private System.Windows.Forms.Label lblOverTimeLegend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private XPTable.Models.Table lvwListEmployee;
        private XPTable.Models.ColumnModel columnModel1;
        private XPTable.Models.NumberColumn cSTT;
        private XPTable.Models.TextColumn cCardID;
        private XPTable.Models.TextColumn cEmployeeName;
        private XPTable.Models.TableModel tableModel1;
        private System.Windows.Forms.Button btnSelectNone;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblNonWorkingDay;
        private System.Windows.Forms.Label lblNonWorkingDayLegend;
        private System.Windows.Forms.Label lblWorkingDay;
        private System.Windows.Forms.Label lblWorkingDayLegend;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private Pabo.Calendar.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.LookupComboBox cboShift;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private EVSoft.HRMS.Controls.DepartmentTreeView departmentTreeView;
        private System.Windows.Forms.ComboBox cboDinnnerAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckHaveDinner;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWorkOverTimeInfo;
        private System.Windows.Forms.CheckBox deleteOverTime;
    }
}
namespace CtyTinLuong
{
    partial class frmTesst
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_ChiTietMuaHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_MuaHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_VTHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDonGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTonTai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNgungTheoDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMaVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenVTHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clHienThi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clThanhTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btXoa2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit2,
            this.btXoa2,
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(751, 523);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clSTT,
            this.clID_ChiTietMuaHang,
            this.clID_MuaHang,
            this.clID_VTHH,
            this.clSoLuong,
            this.clDonGia,
            this.clTonTai,
            this.clNgungTheoDoi,
            this.clMaVT,
            this.clTenVTHH,
            this.clDonViTinh,
            this.clHienThi,
            this.clThanhTien,
            this.clXoa});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThanhTien", this.clThanhTien, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged_1);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            // 
            // clSTT
            // 
            this.clSTT.Caption = "STT";
            this.clSTT.Name = "clSTT";
            this.clSTT.OptionsColumn.AllowEdit = false;
            this.clSTT.OptionsColumn.FixedWidth = true;
            this.clSTT.Visible = true;
            this.clSTT.VisibleIndex = 0;
            this.clSTT.Width = 43;
            // 
            // clID_ChiTietMuaHang
            // 
            this.clID_ChiTietMuaHang.Caption = "ID_ChiTietMuaHang";
            this.clID_ChiTietMuaHang.FieldName = "ID_ChiTietMuaHang";
            this.clID_ChiTietMuaHang.Name = "clID_ChiTietMuaHang";
            // 
            // clID_MuaHang
            // 
            this.clID_MuaHang.Caption = "ID_MuaHang";
            this.clID_MuaHang.FieldName = "ID_MuaHang";
            this.clID_MuaHang.Name = "clID_MuaHang";
            // 
            // clID_VTHH
            // 
            this.clID_VTHH.Caption = "ID_VTHH";
            this.clID_VTHH.FieldName = "ID_VTHH";
            this.clID_VTHH.Name = "clID_VTHH";
            // 
            // clSoLuong
            // 
            this.clSoLuong.Caption = "Số lượng";
            this.clSoLuong.FieldName = "SoLuong";
            this.clSoLuong.Name = "clSoLuong";
            this.clSoLuong.OptionsColumn.FixedWidth = true;
            this.clSoLuong.Visible = true;
            this.clSoLuong.VisibleIndex = 3;
            this.clSoLuong.Width = 80;
            // 
            // clDonGia
            // 
            this.clDonGia.AppearanceCell.Options.UseTextOptions = true;
            this.clDonGia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.clDonGia.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clDonGia.Caption = "Đơn giá (đ)";
            this.clDonGia.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.clDonGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clDonGia.FieldName = "DonGia";
            this.clDonGia.GroupFormat.FormatString = "{0:#,##0.00}";
            this.clDonGia.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clDonGia.Name = "clDonGia";
            this.clDonGia.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.clDonGia.Visible = true;
            this.clDonGia.VisibleIndex = 5;
            this.clDonGia.Width = 160;
            // 
            // clTonTai
            // 
            this.clTonTai.Caption = "TonTai";
            this.clTonTai.FieldName = "TonTai";
            this.clTonTai.Name = "clTonTai";
            // 
            // clNgungTheoDoi
            // 
            this.clNgungTheoDoi.Caption = "NgungTheoDoi";
            this.clNgungTheoDoi.FieldName = "NgungTheoDoi";
            this.clNgungTheoDoi.Name = "clNgungTheoDoi";
            // 
            // clMaVT
            // 
            this.clMaVT.Caption = "Mã VT";
            this.clMaVT.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.clMaVT.FieldName = "MaVT";
            this.clMaVT.Name = "clMaVT";
            this.clMaVT.OptionsColumn.FixedWidth = true;
            this.clMaVT.Visible = true;
            this.clMaVT.VisibleIndex = 1;
            this.clMaVT.Width = 90;
            // 
            // clTenVTHH
            // 
            this.clTenVTHH.AppearanceCell.Options.UseTextOptions = true;
            this.clTenVTHH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.clTenVTHH.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clTenVTHH.Caption = "Tên hàng hóa";
            this.clTenVTHH.FieldName = "TenVTHH";
            this.clTenVTHH.Name = "clTenVTHH";
            this.clTenVTHH.Visible = true;
            this.clTenVTHH.VisibleIndex = 2;
            this.clTenVTHH.Width = 261;
            // 
            // clDonViTinh
            // 
            this.clDonViTinh.Caption = "ĐVT";
            this.clDonViTinh.FieldName = "DonViTinh";
            this.clDonViTinh.Name = "clDonViTinh";
            this.clDonViTinh.OptionsColumn.AllowEdit = false;
            this.clDonViTinh.OptionsColumn.FixedWidth = true;
            this.clDonViTinh.Visible = true;
            this.clDonViTinh.VisibleIndex = 4;
            this.clDonViTinh.Width = 60;
            // 
            // clHienThi
            // 
            this.clHienThi.Caption = "HienThi";
            this.clHienThi.FieldName = "HienThi";
            this.clHienThi.Name = "clHienThi";
            // 
            // clThanhTien
            // 
            this.clThanhTien.AppearanceCell.Options.UseTextOptions = true;
            this.clThanhTien.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.clThanhTien.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clThanhTien.Caption = "Thành tiền (đ)";
            this.clThanhTien.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.clThanhTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clThanhTien.FieldName = "ThanhTien";
            this.clThanhTien.GroupFormat.FormatString = "{0:#,##0.00}";
            this.clThanhTien.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clThanhTien.Name = "clThanhTien";
            this.clThanhTien.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThanhTien", "{0:#,##0.00} (đ)")});
            this.clThanhTien.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.clThanhTien.Visible = true;
            this.clThanhTien.VisibleIndex = 6;
            this.clThanhTien.Width = 160;
            // 
            // clXoa
            // 
            this.clXoa.Caption = "Xóa";
            this.clXoa.ColumnEdit = this.btXoa2;
            this.clXoa.Name = "clXoa";
            this.clXoa.OptionsColumn.FixedWidth = true;
            this.clXoa.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.clXoa.Visible = true;
            this.clXoa.VisibleIndex = 7;
            this.clXoa.Width = 40;
            // 
            // btXoa2
            // 
            this.btXoa2.AutoHeight = false;
            this.btXoa2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CtyTinLuong.Properties.Resources.ico_Delete, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.btXoa2.Name = "btXoa2";
            this.btXoa2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.EditValueChanged += new System.EventHandler(this.repositoryItemLookUpEdit1_EditValueChanged);
            // 
            // frmTesst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 523);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmTesst";
            this.Text = "frmTesst";
            this.Load += new System.EventHandler(this.frmTesst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Columns.GridColumn clID_ChiTietMuaHang;
        private DevExpress.XtraGrid.Columns.GridColumn clID_MuaHang;
        private DevExpress.XtraGrid.Columns.GridColumn clID_VTHH;
        private DevExpress.XtraGrid.Columns.GridColumn clSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn clDonGia;
        private DevExpress.XtraGrid.Columns.GridColumn clTonTai;
        private DevExpress.XtraGrid.Columns.GridColumn clNgungTheoDoi;
        private DevExpress.XtraGrid.Columns.GridColumn clMaVT;
        private DevExpress.XtraGrid.Columns.GridColumn clTenVTHH;
        private DevExpress.XtraGrid.Columns.GridColumn clDonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn clHienThi;
        private DevExpress.XtraGrid.Columns.GridColumn clThanhTien;
        private DevExpress.XtraGrid.Columns.GridColumn clXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btXoa2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
    }
}
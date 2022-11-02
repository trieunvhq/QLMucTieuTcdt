using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing.Printing;

namespace QLMucTieu
{
    public partial class frmMain : Form
    {
        public static bool mbAddKQ = false;
        public static bool mb_SuaKQ = false;
        public static bool mbCopyKQ = false;

        public static int ID;
        public static string QuocGia;
        public static string VungBien;
        public static string DanhHieu;
        public static string SoHieu;
        public static string FullName;
        public static string KieuLoai;
        public static int SoLuong;
        public static Double KinhDo;
        public static Double ViDo;
        public static string ToaDo;
        public static int Distance;
        public static string KhuVucDuKien;
        public static string KhuVucHoatDong;
        public static DateTime DateCurent;
        public static string MoTa;


        public  DateTime _ngay_batdau;
        public  DateTime _ngay_ketthuc;
        public string _sSearch;
        public static int _SoTrang = 1;
        private bool isload = false;
        private int _STT = 1;
        private int _RowPage_curent = 0;
        private int _TongSoTrang = 0;
        private int _TongMucTieu = 0;

        //
        public static bool mbAdd_HQ = false;
        public static bool mb_Sua_HQ = false;
        public static bool mbCopy_HQ = false;

        public static int ID_HQ;
        public static string QuocGia_HQ;
        public static string VungBien_HQ;
        public static string DanhHieu_HQ;
        public static string SoHieu_HQ;
        public static string FullName_HQ;
        public static string KieuLoai_HQ;
        public static int SoLuong_HQ;
        public static Double KinhDo_HQ;
        public static Double ViDo_HQ;
        public static string ToaDo_HQ;
        public static int Distance_HQ;
        public static string KhuVucDuKien_HQ;
        public static string KhuVucHoatDong_HQ;
        public static DateTime DateCurent_HQ;
        public static string MoTa_HQ;


        public DateTime _ngay_batdau_HQ;
        public DateTime _ngay_ketthuc_HQ;
        public string _sSearch_HQ;
        public static int _SoTrang_HQ = 1;
        private bool isload_HQ = false;
        private int _STT_HQ = 1;
        private int _RowPage_curent_HQ = 0;
        private int _TongSoTrang_HQ = 0;
        private int _TongMucTieu_HQ = 0;


        public void LoadData(int sotrang, bool isLoadLanDau)
        {
            isload = true;
            if (isLoadLanDau)
            {
                dteTuNgay.EditValue = DateTime.Now.AddDays(-30);
                dteDenNgay.EditValue = DateTime.Now;
                txtTimKiem.Text = "";
            }
            else { }
            _sSearch = txtTimKiem.Text;
            _ngay_batdau = (DateTime)dteTuNgay.EditValue;
            _ngay_ketthuc = dteDenNgay.DateTime;
            _SoTrang = sotrang;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("STT", typeof(int));
            dt2.Columns.Add("ID", typeof(int));
            dt2.Columns.Add("QuocGia", typeof(string));
            dt2.Columns.Add("VungBien", typeof(string));
            dt2.Columns.Add("DanhHieu", typeof(string));
            dt2.Columns.Add("SoHieu", typeof(string));
            dt2.Columns.Add("FullName", typeof(string));
            dt2.Columns.Add("KieuLoai", typeof(string));
            dt2.Columns.Add("SoLuong", typeof(int));
            dt2.Columns.Add("KinhDo", typeof(double));
            dt2.Columns.Add("ViDo", typeof(double));
            dt2.Columns.Add("ToaDo", typeof(string));
            dt2.Columns.Add("Distance", typeof(int));
            dt2.Columns.Add("KhuVucDuKien", typeof(string));
            dt2.Columns.Add("KhuVucHoatDong", typeof(string));
            dt2.Columns.Add("DateCurent", typeof(DateTime));
            dt2.Columns.Add("DateChange", typeof(DateTime));
            dt2.Columns.Add("MoTa", typeof(string));

            using (clsTabKhongQuan cls_ = new clsTabKhongQuan())
            {
                DataTable dt_ = cls_.pr_SelecPageKhongQuan(_SoTrang, _ngay_batdau, _ngay_ketthuc, _sSearch);

                _RowPage_curent = dt_.Rows.Count;

                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_.Rows.Count; i++)
                    {
                        DataRow _ravi = dt2.NewRow();

                        _ravi["STT"] = _STT.ToString(); _STT++;
                        _ravi["ID"] = Convert.ToInt32(dt_.Rows[i]["Id"].ToString());
                        _ravi["QuocGia"] = dt_.Rows[i]["QuocGia"].ToString(); 
                        _ravi["VungBien"] = dt_.Rows[i]["VungBien"].ToString();
                        _ravi["DanhHieu"] = dt_.Rows[i]["DanhHieu"].ToString();
                        _ravi["SoHieu"] = dt_.Rows[i]["SoHieu"].ToString();
                        _ravi["FullName"] = dt_.Rows[i]["FullName"].ToString();
                        _ravi["KieuLoai"] = dt_.Rows[i]["KieuLoai"].ToString();
                        _ravi["SoLuong"] = Convert.ToInt32(dt_.Rows[i]["SoLuong"].ToString());
                        _ravi["KinhDo"] = Convert.ToDouble(dt_.Rows[i]["KinhDo"].ToString());
                        _ravi["ViDo"] = Convert.ToDouble(dt_.Rows[i]["ViDo"].ToString());
                        _ravi["ToaDo"] = dt_.Rows[i]["ToaDo"].ToString();
                        _ravi["Distance"] = Convert.ToInt32(dt_.Rows[i]["Distance"].ToString());
                        _ravi["KhuVucDuKien"] = dt_.Rows[i]["KhuVucDuKien"].ToString();
                        _ravi["KhuVucHoatDong"] = dt_.Rows[i]["KhuVucHoatDong"].ToString();
                        _ravi["DateCurent"] = Convert.ToDateTime(dt_.Rows[i]["DateCurent"].ToString());
                        _ravi["DateChange"] = Convert.ToDateTime(dt_.Rows[i]["DateChange"].ToString());
                        _ravi["MoTa"] = dt_.Rows[i]["MoTa"].ToString();

                        dt2.Rows.Add(_ravi);
                    }
                }
            }
            gridControl1.DataSource = dt2;

            isload = false;
        }

        public void LoadData_HQ(int sotrang, bool isLoadLanDau)
        {
            isload_HQ = true;
            if (isLoadLanDau)
            {
                dteTuNgay_HQ.EditValue = DateTime.Now.AddDays(-30);
                dteDenNgay_HQ.EditValue = DateTime.Now;
                txtTimKiem_HQ.Text = "";
            }
            else { }
            _sSearch_HQ = txtTimKiem_HQ.Text;
            _ngay_batdau_HQ = (DateTime)dteTuNgay_HQ.EditValue;
            _ngay_ketthuc_HQ = dteDenNgay_HQ.DateTime;
            _SoTrang_HQ = sotrang;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("STT", typeof(int));
            dt2.Columns.Add("ID", typeof(int));
            dt2.Columns.Add("QuocGia", typeof(string));
            dt2.Columns.Add("VungBien", typeof(string));
            dt2.Columns.Add("DanhHieu", typeof(string));
            dt2.Columns.Add("SoHieu", typeof(string));
            dt2.Columns.Add("FullName", typeof(string));
            dt2.Columns.Add("KieuLoai", typeof(string));
            dt2.Columns.Add("SoLuong", typeof(int));
            dt2.Columns.Add("KinhDo", typeof(double));
            dt2.Columns.Add("ViDo", typeof(double));
            dt2.Columns.Add("ToaDo", typeof(string));
            dt2.Columns.Add("Distance", typeof(int));
            dt2.Columns.Add("KhuVucDuKien", typeof(string));
            dt2.Columns.Add("KhuVucHoatDong", typeof(string));
            dt2.Columns.Add("DateCurent", typeof(DateTime));
            dt2.Columns.Add("DateChange", typeof(DateTime));
            dt2.Columns.Add("MoTa", typeof(string));

            using (clsTabHaiQuan cls_ = new clsTabHaiQuan())
            {
                DataTable dt_ = cls_.pr_SelecPageHaiQuan(_SoTrang_HQ, _ngay_batdau_HQ, _ngay_ketthuc_HQ, _sSearch_HQ);

                _RowPage_curent_HQ = dt_.Rows.Count;

                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_.Rows.Count; i++)
                    {
                        DataRow _ravi = dt2.NewRow();

                        _ravi["STT"] = _STT_HQ.ToString(); _STT_HQ++;
                        _ravi["ID"] = Convert.ToInt32(dt_.Rows[i]["Id"].ToString());
                        _ravi["QuocGia"] = dt_.Rows[i]["QuocGia"].ToString();
                        _ravi["VungBien"] = dt_.Rows[i]["VungBien"].ToString();
                        _ravi["DanhHieu"] = dt_.Rows[i]["DanhHieu"].ToString();
                        _ravi["SoHieu"] = dt_.Rows[i]["SoHieu"].ToString();
                        _ravi["FullName"] = dt_.Rows[i]["FullName"].ToString();
                        _ravi["KieuLoai"] = dt_.Rows[i]["KieuLoai"].ToString();
                        _ravi["SoLuong"] = Convert.ToInt32(dt_.Rows[i]["SoLuong"].ToString());
                        _ravi["KinhDo"] = Convert.ToDouble(dt_.Rows[i]["KinhDo"].ToString());
                        _ravi["ViDo"] = Convert.ToDouble(dt_.Rows[i]["ViDo"].ToString());
                        _ravi["ToaDo"] = dt_.Rows[i]["ToaDo"].ToString();
                        _ravi["Distance"] = Convert.ToInt32(dt_.Rows[i]["Distance"].ToString());
                        _ravi["KhuVucDuKien"] = dt_.Rows[i]["KhuVucDuKien"].ToString();
                        _ravi["KhuVucHoatDong"] = dt_.Rows[i]["KhuVucHoatDong"].ToString();
                        _ravi["DateCurent"] = Convert.ToDateTime(dt_.Rows[i]["DateCurent"].ToString());
                        _ravi["DateChange"] = Convert.ToDateTime(dt_.Rows[i]["DateChange"].ToString());
                        _ravi["MoTa"] = dt_.Rows[i]["MoTa"].ToString();

                        dt2.Rows.Add(_ravi);
                    }
                }
            }
            gridControl2.DataSource = dt2;

            isload_HQ = false;
        }

        public frmMain()
        {
            InitializeComponent();
            this.Text = "Phần mềm quản lý mục tiêu - Ban TCĐT/BTL Vùng 1 HQ" 
                + "                                                                             "
                + "Xin chào: " + frmDangNhap._sCapBac + " " + frmDangNhap._sFullname
                + " - " + frmDangNhap._sChucVu;

            if (frmDangNhap._sChucVu.Contains("Trưởng ban"))
            {
                txtChucVu_PrintBC.Text = "TRƯỞNG BAN TÁC CHIẾN ĐIỆN TỬ";
            }
            else
            {
                txtChucVu_PrintBC.Text = "   TRỢ LÝ TÁC CHIẾN ĐIỆN TỬ";
            }

            //
            txtNguoiTongHop.Text = frmDangNhap._sCapBac + " " + frmDangNhap._sFullname;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //fixdata();
            _STT = 1;
            LoadData(1, true);
            ResetSoTrang_BB();

            _STT_HQ = 1;
            LoadData_HQ(1, true);
            ResetSoTrang_HQ();

            dteTuNgay_Print.EditValue = DateTime.Now.AddDays(-7);
            dteDenNgay_Print.EditValue = DateTime.Now;
            datePrintBC.EditValue = DateTime.Now;
            checkKQ_My.Checked = true;
            checkChapPhap_My.Checked = true;
            checkNCKS_My.Checked = true;
            checkQuanSu_My.Checked = true;
            checkQS_TQ.Checked = true;

            Cursor.Current = Cursors.Default;
        }

        public void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmMain_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

     

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.Column == clSTT)
            //{
            //    e.DisplayText = (e.RowHandle + 1).ToString();
            //}
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID).ToString() != "")
                {
                    Cursor.Current = Cursors.WaitCursor;

                    mbAddKQ = false;
                    mb_SuaKQ = true;
                    mbCopyKQ = true;

                    //
                    DateCurent = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(clDateCurent).ToString());
                    VungBien = gridView1.GetFocusedRowCellValue(clVungBien).ToString().Trim();
                    ID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID).ToString());
                    QuocGia = gridView1.GetFocusedRowCellValue(clQuocGia).ToString();
                    DanhHieu = gridView1.GetFocusedRowCellValue(clDanhHieu).ToString().Trim();
                    SoHieu = gridView1.GetFocusedRowCellValue(clSoHieu).ToString().Trim();
                    FullName = gridView1.GetFocusedRowCellValue(clFullName).ToString();
                    KieuLoai = gridView1.GetFocusedRowCellValue(clKieuLoai).ToString().Trim();
                    SoLuong = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clSoLuong).ToString());
                    KinhDo = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clKinhDo).ToString().Trim());
                    ViDo = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clViDo).ToString());
                    ToaDo = gridView1.GetFocusedRowCellValue(clToaDo).ToString();
                    Distance = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clDistance).ToString());
                    KhuVucDuKien = gridView1.GetFocusedRowCellValue(clKhuVucDuKien).ToString();
                    KhuVucHoatDong = gridView1.GetFocusedRowCellValue(clKhuVucHoatDong).ToString();
                    MoTa = gridView1.GetFocusedRowCellValue(clMoTa).ToString().Trim();

                    frmChiTiet_KhongQuan ff = new frmChiTiet_KhongQuan(this);
                    ff.ShowDialog();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            clsTabKhongQuan cls = new clsTabKhongQuan();
            cls.iId = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID).ToString());

            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu tại dòng: \n"
                + "STT: " + gridView1.GetFocusedRowCellValue(clSTT).ToString() + " | "
                + "Thời gian: " + Convert.ToDateTime(gridView1.GetFocusedRowCellValue(clDateCurent).ToString()).ToString("HH:mm - dd/MM/yyyy") + " | "
                + "Kiểu loại: " + gridView1.GetFocusedRowCellValue(clKieuLoai).ToString() + " | "
                + "Khu vực hoạt động: " + gridView1.GetFocusedRowCellValue(clKhuVucHoatDong).ToString()
                + " " + gridView1.GetFocusedRowCellValue(clDistance).ToString() + " hl"
                + "...", "Delete", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {
                if (cls.Delete())
                {
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _STT -= _RowPage_curent;
                    LoadData(_SoTrang, false);
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu thất bại. Kiểm tra lại kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            Cursor.Current = Cursors.Default;
        }


        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //try
            //{

            //    clsPhieu_tbPhieu cls = new clsPhieu_tbPhieu();
            //    cls.iID_SoPhieu = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_BienBan).ToString());
            //    cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clLoaiGiay).ToString());
            //    cls.Update_NgungTheoDoi();
            //}
            //catch
            //{

            //}
        }

     
        private void btChiTiet_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (gridView1.GetFocusedRowCellValue(clID_BienBan).ToString() != "")
            //    {
            //        msTenSoPhieu = gridView1.GetFocusedRowCellValue(clLoaiHang).ToString();
            //        mID_iD_SoPhieu = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_BienBan).ToString());
            //        SanXuat_frmChiTietSoPhieu_RutGon ff = new CtyTinLuong.SanXuat_frmChiTietSoPhieu_RutGon();
            //        ff.ShowDialog();
            //    }
            //}
            //catch
            //{

            //}
        }


        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{
            //    bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["GuiDuLieu"]));
            //    if (category == false)
            //    {
            //        e.Appearance.BackColor = Color.Bisque;
                  
            //    }
            //}
        }

        private void btThemMoi_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            mbAddKQ = true;
            mbCopyKQ = false;
            mb_SuaKQ = false;

            //
            frmChiTiet_KhongQuan ff = new frmChiTiet_KhongQuan(this);
            ff.ShowDialog();

            Cursor.Current = Cursors.Default;
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (isload)
                return;

            try
            {
                _ngay_batdau = Convert.ToDateTime(dteTuNgay.DateTime);
                ResetSoTrang_BB();
                _STT = 1;
                LoadData(1, false);
            }
            catch
            { }
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (isload)
                return;
            try
            {
                _ngay_ketthuc = Convert.ToDateTime(dteDenNgay.DateTime);
                ResetSoTrang_BB();
                _STT = 1;
                LoadData(1, false);
            }
            catch
            { }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (isload)
                return;
            _sSearch = txtTimKiem.Text;
            ResetSoTrang_BB();
            _STT = 1;
            LoadData(1, false);
        }    

        private void btCopY_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID).ToString() != "")
                {
                    Cursor.Current = Cursors.WaitCursor;

                    mbAddKQ = true;
                    mb_SuaKQ = false;
                    mbCopyKQ = true;

                    //
                    DateCurent = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(clDateCurent).ToString());
                    VungBien = gridView1.GetFocusedRowCellValue(clVungBien).ToString().Trim();
                    ID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID).ToString());
                    QuocGia = gridView1.GetFocusedRowCellValue(clQuocGia).ToString();
                    DanhHieu = gridView1.GetFocusedRowCellValue(clDanhHieu).ToString().Trim();
                    SoHieu = gridView1.GetFocusedRowCellValue(clSoHieu).ToString().Trim();
                    FullName = gridView1.GetFocusedRowCellValue(clFullName).ToString();
                    KieuLoai = gridView1.GetFocusedRowCellValue(clKieuLoai).ToString().Trim();
                    SoLuong = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clSoLuong).ToString());
                    KinhDo = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clKinhDo).ToString().Trim());
                    ViDo = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clViDo).ToString());
                    ToaDo = gridView1.GetFocusedRowCellValue(clToaDo).ToString();
                    Distance = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clDistance).ToString());
                    KhuVucDuKien = gridView1.GetFocusedRowCellValue(clKhuVucDuKien).ToString();
                    KhuVucHoatDong = gridView1.GetFocusedRowCellValue(clKhuVucHoatDong).ToString();
                    MoTa = gridView1.GetFocusedRowCellValue(clMoTa).ToString().Trim();

                    frmChiTiet_KhongQuan ff = new frmChiTiet_KhongQuan(this);
                    ff.ShowDialog();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {

            }

        }

        //
        public void ResetSoTrang_BB()
        {
            btnTrangSau.Visible = true;
            btnTrangTiep.Visible = true;
            lbTongSoTrang.Visible = true;
            txtSoTrang.Visible = true;
            btnTrangSau.LinkColor = Color.Black;
            btnTrangTiep.LinkColor = Color.Blue;
            txtSoTrang.Text = "1";

            using (clsTabKhongQuan cls = new clsTabKhongQuan())
            {
                DataTable dt_ = cls.pr_TongMucTieuKhongQuan(_ngay_batdau, _ngay_ketthuc, _sSearch);
                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    _TongSoTrang = Convert.ToInt32(Math.Ceiling(CheckString.ConvertToDouble_My(dt_.Rows[0]["tongso"].ToString()) / (double)100));
                    _TongMucTieu = Convert.ToInt32(dt_.Rows[0]["totalSL"].ToString());
                    txtTongSoLuong.Text = _TongMucTieu.ToString("N0");
                    lbTongSoTrang.Text = "/" + _TongSoTrang.ToString();
                }
                else
                {
                    lbTongSoTrang.Text = "/1";
                }
            }
            if (lbTongSoTrang.Text == "0")
                lbTongSoTrang.Text = "/1";
            if (lbTongSoTrang.Text == "/1")
            {
                btnTrangSau.LinkColor = Color.Black;
                btnTrangTiep.LinkColor = Color.Black;
            }
        }

        //
        public void ResetSoTrang_HQ()
        {
            btnTrangSau_HQ.Visible = true;
            btnTrangTiep_HQ.Visible = true;
            lbTongSoTrang_HQ.Visible = true;
            txtSoTrang_HQ.Visible = true;
            btnTrangSau_HQ.LinkColor = Color.Black;
            btnTrangTiep_HQ.LinkColor = Color.Blue;
            txtSoTrang_HQ.Text = "1";

            using (clsTabHaiQuan cls = new clsTabHaiQuan())
            {
                DataTable dt_ = cls.pr_TongMucTieuHaiQuan(_ngay_batdau_HQ, _ngay_ketthuc_HQ, _sSearch_HQ);
                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    _TongSoTrang_HQ = Convert.ToInt32(Math.Ceiling(CheckString.ConvertToDouble_My(dt_.Rows[0]["tongso"].ToString()) / (double)100));
                    if (dt_.Rows[0]["totalSL"].ToString() != null)
                        _TongMucTieu_HQ = Convert.ToInt32(dt_.Rows[0]["totalSL"].ToString());
                    else _TongMucTieu_HQ = 0;
                    txtTongSoLuong_HQ.Text = _TongMucTieu_HQ.ToString("N0");
                    lbTongSoTrang_HQ.Text = "/" + _TongSoTrang_HQ.ToString();
                }
                else
                {
                    lbTongSoTrang_HQ.Text = "/1";
                }
            }
            if (lbTongSoTrang_HQ.Text == "0")
                lbTongSoTrang_HQ.Text = "/1";
            if (lbTongSoTrang_HQ.Text == "/1")
            {
                btnTrangSau_HQ.LinkColor = Color.Black;
                btnTrangTiep_HQ.LinkColor = Color.Black;
            }
        }
        private void btnTrangTiep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (isload)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                btnTrangSau.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                int max_ = Convert.ToInt32(lbTongSoTrang.Text.Replace(" ", "").Replace("/", ""));
                if (sotrang_ < max_)
                {
                    txtSoTrang.Text = (sotrang_ + 1).ToString();
                    if (sotrang_ + 1 == _TongSoTrang)
                    {
                        btnTrangTiep.LinkColor = Color.Black;
                    }

                    Load_BBKtraHHSX(false);
                }
                else
                {
                    txtSoTrang.Text = (max_).ToString();
                    btnTrangTiep.LinkColor = Color.Black;
                }
            }
            catch
            {
                btnTrangTiep.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
        }

        private void btnTrangSau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (isload)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                btnTrangTiep.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                if (sotrang_ <= 1)
                {
                    txtSoTrang.Text = "1";
                    btnTrangSau.LinkColor = Color.Black;
                    _STT = 1;

                }
                else
                {
                    txtSoTrang.Text = (sotrang_ - 1).ToString();

                    _STT -= (100 + _RowPage_curent);

                    if (sotrang_ - 1 == 1)
                    {
                        btnTrangSau.LinkColor = Color.Black;
                    }

                    Load_BBKtraHHSX(false);
                }
            }
            catch
            {
                btnTrangSau.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
                _STT = 1;
            }
        }

        private void Load_BBKtraHHSX(bool islandau)
        {
            int sotrang_ = 1;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
            }
            catch
            {
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
            LoadData(sotrang_, islandau);
        }

        private void Load_HQ(bool islandau)
        {
            int sotrang_ = 1;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang_HQ.Text);
            }
            catch
            {
                sotrang_ = 1;
                txtSoTrang_HQ.Text = "1";
            }
            LoadData_HQ(sotrang_, islandau);
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void fixdata()
        {
            clsTabKhongQuan cl = new clsTabKhongQuan();
            clsTabHaiQuan cls = new clsTabHaiQuan();

            DataTable dt = cls.SelectAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cl.sToaDo = toString_KinhDo(Convert.ToDouble(dt.Rows[i]["KinhDo"].ToString())) + "/"
                            + toString_ViDo(Convert.ToDouble(dt.Rows[i]["ViDo"].ToString()));
                cl.iId = Convert.ToInt32(dt.Rows[i]["Id"].ToString());

                cl.pr_tabKhongQuan_Update_rootMy();
            }
        }

        private string toString_KinhDo(double kinhDo)
        {
            string result = "";
            if (kinhDo > 0)
            {
                int Do = (int)kinhDo;
                int phut = (int)(60*(kinhDo - Do));
                int giay = (int)(60*(60 * (kinhDo - Do) - phut));
                result = Do.ToString() + "°" + phut.ToString() + "'" + giay.ToString() + "\"B";
            }
            else
            {
                kinhDo = Math.Abs(kinhDo);
                int Do = (int)kinhDo;
                int phut = (int)(60 * (kinhDo - Do));
                int giay = (int)(60 * (60 * (kinhDo - Do) - phut));
                result = Do.ToString() + "°" + phut.ToString() + "'" + giay.ToString() + "\"N";
            }

            return result;
        }

        //
        private string toString_ViDo(double viDo)
        {
            string result = "";
            if (viDo > 0)
            {
                int Do = (int)viDo;
                int phut = (int)(60 * (viDo - Do));
                int giay = (int)(60 * (60 * (viDo - Do) - phut));
                result = Do.ToString() + "°" + phut.ToString() + "'" + giay.ToString() + "\"Đ";
            }
            else
            {
                viDo = Math.Abs(viDo);
                int Do = (int)viDo;
                int phut = (int)(60 * (viDo - Do));
                int giay = (int)(60 * (60 * (viDo - Do) - phut));
                result = Do.ToString() + "°" + phut.ToString() + "'" + giay.ToString() + "\"T";
            }

            return result;
        }

        private void btnTrangSau_HQ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (isload_HQ)
                return;
            if (btnTrangSau_HQ.LinkColor == Color.Black)
                return;
            if (btnTrangTiep_HQ.LinkColor == Color.Black)
                btnTrangTiep_HQ.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang_HQ.Text);
                if (sotrang_ <= 1)
                {
                    txtSoTrang_HQ.Text = "1";
                    btnTrangSau_HQ.LinkColor = Color.Black;
                    _STT = 1;

                }
                else
                {
                    txtSoTrang_HQ.Text = (sotrang_ - 1).ToString();

                    _STT_HQ -= (100 + _RowPage_curent_HQ);

                    if (sotrang_ - 1 == 1)
                    {
                        btnTrangSau_HQ.LinkColor = Color.Black;
                    }

                    Load_HQ(false);
                }
            }
            catch
            {
                btnTrangSau_HQ.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang_HQ.Text = "1";
                _STT_HQ = 1;
            }
        }

        private void btnTrangTiep_HQ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (isload_HQ)
                return;
            if (btnTrangTiep_HQ.LinkColor == Color.Black)
                return;
            if (btnTrangSau_HQ.LinkColor == Color.Black)
                btnTrangSau_HQ.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang_HQ.Text);
                int max_ = Convert.ToInt32(lbTongSoTrang_HQ.Text.Replace(" ", "").Replace("/", ""));
                if (sotrang_ < max_)
                {
                    txtSoTrang_HQ.Text = (sotrang_ + 1).ToString();
                    if (sotrang_ + 1 == _TongSoTrang_HQ)
                    {
                        btnTrangTiep_HQ.LinkColor = Color.Black;
                    }

                    Load_HQ(false);
                }
                else
                {
                    txtSoTrang_HQ.Text = (max_).ToString();
                    btnTrangTiep_HQ.LinkColor = Color.Black;
                }
            }
            catch
            {
                btnTrangTiep_HQ.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang_HQ.Text = "1";
            }
        }

        private void txtTimKiem_HQ_TextChanged(object sender, EventArgs e)
        {
            if (isload_HQ)
                return;
            _sSearch_HQ = txtTimKiem_HQ.Text;
            ResetSoTrang_HQ();
            _STT_HQ = 1;
            LoadData_HQ(1, false);
        }

        private void dteTuNgay_HQ_EditValueChanged(object sender, EventArgs e)
        {
            if (isload_HQ)
                return;

            try
            {
                _ngay_batdau_HQ = Convert.ToDateTime(dteTuNgay_HQ.DateTime);
                ResetSoTrang_HQ();
                _STT_HQ = 1;
                LoadData_HQ(1, false);
            }
            catch
            { }
        }

        private void dteDenNgay_HQ_EditValueChanged(object sender, EventArgs e)
        {
            if (isload_HQ)
                return;
            try
            {
                _ngay_ketthuc_HQ = Convert.ToDateTime(dteDenNgay_HQ.DateTime);
                ResetSoTrang_HQ();
                _STT_HQ = 1;
                LoadData_HQ(1, false);
            }
            catch
            { }
        }

        private void btnRefresh_HQ_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmMain_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView2.GetFocusedRowCellValue(clID_HQ).ToString() != "")
                {
                    Cursor.Current = Cursors.WaitCursor;

                    mbAdd_HQ = false;
                    mb_Sua_HQ = true;
                    mbCopy_HQ = true;

                    //
                    DateCurent_HQ = Convert.ToDateTime(gridView2.GetFocusedRowCellValue(clDateCurent_HQ).ToString());
                    VungBien_HQ = gridView2.GetFocusedRowCellValue(clVungBien_HQ).ToString().Trim();
                    ID_HQ = Convert.ToInt32(gridView2.GetFocusedRowCellValue(clID_HQ).ToString());
                    QuocGia_HQ = gridView2.GetFocusedRowCellValue(clQuocGia_HQ).ToString();
                    DanhHieu_HQ = gridView2.GetFocusedRowCellValue(clDanhHieu_HQ).ToString().Trim();
                    SoHieu_HQ = gridView2.GetFocusedRowCellValue(clSoHieu_HQ).ToString().Trim();
                    FullName_HQ = gridView2.GetFocusedRowCellValue(clFullName_HQ).ToString();
                    KieuLoai_HQ = gridView2.GetFocusedRowCellValue(clKieuLoai_HQ).ToString().Trim();
                    SoLuong_HQ = Convert.ToInt32(gridView2.GetFocusedRowCellValue(clSoLuong_HQ).ToString());
                    KinhDo_HQ = Convert.ToDouble(gridView2.GetFocusedRowCellValue(clKinhDo_HQ).ToString().Trim());
                    ViDo_HQ = Convert.ToDouble(gridView2.GetFocusedRowCellValue(clViDo_HQ).ToString());
                    ToaDo_HQ = gridView2.GetFocusedRowCellValue(clToaDo_HQ).ToString();
                    Distance_HQ = Convert.ToInt32(gridView2.GetFocusedRowCellValue(clDistance_HQ).ToString());
                    KhuVucDuKien_HQ = gridView2.GetFocusedRowCellValue(clKhuVucDuKien_HQ).ToString();
                    KhuVucHoatDong_HQ = gridView2.GetFocusedRowCellValue(clKhuVucHoatDong_HQ).ToString();
                    MoTa_HQ = gridView2.GetFocusedRowCellValue(clMoTa_HQ).ToString().Trim();

                    frmChiTiet_HaiQuan ff = new frmChiTiet_HaiQuan(this);
                    ff.ShowDialog();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {

            }
        }

        private void btnCopy_HQ_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView2.GetFocusedRowCellValue(clID_HQ).ToString() != "")
                {
                    Cursor.Current = Cursors.WaitCursor;

                    mbAdd_HQ = true;
                    mb_Sua_HQ = false;
                    mbCopy_HQ = true;

                    //
                    DateCurent_HQ = Convert.ToDateTime(gridView2.GetFocusedRowCellValue(clDateCurent_HQ).ToString());
                    VungBien_HQ = gridView2.GetFocusedRowCellValue(clVungBien_HQ).ToString().Trim();
                    ID_HQ = Convert.ToInt32(gridView2.GetFocusedRowCellValue(clID_HQ).ToString());
                    QuocGia_HQ = gridView2.GetFocusedRowCellValue(clQuocGia_HQ).ToString();
                    DanhHieu_HQ = gridView2.GetFocusedRowCellValue(clDanhHieu_HQ).ToString().Trim();
                    SoHieu_HQ = gridView2.GetFocusedRowCellValue(clSoHieu_HQ).ToString().Trim();
                    FullName_HQ = gridView2.GetFocusedRowCellValue(clFullName_HQ).ToString();
                    KieuLoai_HQ = gridView2.GetFocusedRowCellValue(clKieuLoai_HQ).ToString().Trim();
                    SoLuong_HQ = Convert.ToInt32(gridView2.GetFocusedRowCellValue(clSoLuong_HQ).ToString());
                    KinhDo_HQ = Convert.ToDouble(gridView2.GetFocusedRowCellValue(clKinhDo_HQ).ToString().Trim());
                    ViDo_HQ = Convert.ToDouble(gridView2.GetFocusedRowCellValue(clViDo_HQ).ToString());
                    ToaDo_HQ = gridView2.GetFocusedRowCellValue(clToaDo_HQ).ToString();
                    Distance_HQ = Convert.ToInt32(gridView2.GetFocusedRowCellValue(clDistance_HQ).ToString());
                    KhuVucDuKien_HQ = gridView2.GetFocusedRowCellValue(clKhuVucDuKien_HQ).ToString();
                    KhuVucHoatDong_HQ = gridView2.GetFocusedRowCellValue(clKhuVucHoatDong_HQ).ToString();
                    MoTa_HQ = gridView2.GetFocusedRowCellValue(clMoTa_HQ).ToString().Trim();

                    frmChiTiet_HaiQuan ff = new frmChiTiet_HaiQuan(this);
                    ff.ShowDialog();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {

            }
        }

        private void btnXoa_HQ_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            clsTabHaiQuan cls = new clsTabHaiQuan();
            cls.iId = Convert.ToInt32(gridView2.GetFocusedRowCellValue(clID_HQ).ToString());

            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu tại dòng: \n"
                + "STT: " + gridView2.GetFocusedRowCellValue(clSTT_HQ).ToString() + " | "
                + "Thời gian: " + Convert.ToDateTime(gridView2.GetFocusedRowCellValue(clDateCurent_HQ).ToString()).ToString("HH:mm - dd/MM/yyyy") + " | "
                + "Kiểu loại: " + gridView2.GetFocusedRowCellValue(clKieuLoai_HQ).ToString() + " | "
                + "Khu vực hoạt động: " + gridView2.GetFocusedRowCellValue(clKhuVucHoatDong_HQ).ToString()
                + " " + gridView2.GetFocusedRowCellValue(clDistance_HQ).ToString() + " hl"
                + "...", "Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {
                if (cls.Delete())
                {
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _STT_HQ -= _RowPage_curent_HQ;
                    LoadData_HQ(_SoTrang_HQ, false);
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu thất bại. Kiểm tra lại kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            Cursor.Current = Cursors.Default;
        }

        private void btnThemMoi_HQ_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            mbAdd_HQ = true;
            mbCopy_HQ = false;
            mb_Sua_HQ = false;

            //
            frmChiTiet_HaiQuan ff = new frmChiTiet_HaiQuan(this);
            ff.ShowDialog();

            Cursor.Current = Cursors.Default;
        }

        //=================IN ấn =============================================>>>>>>>>>>
        PaperSize paperSize = new PaperSize("A4", 860, 1150);//set the paper size840, 1100)
        bool flag = true;
        string _KyTen = "";
        string _VBBchapPhap = "";
        string _VBBNCKS = "";
        string _VBBNCKSMy = "";
        string _VBBquansu = "";
        string _2My = "";
        string _VBBKqMy = "";
        string _VBBchapPhapMy = "";
        string _VBBquansuMy = "";
        string[] abcde = { "a)", "b)", "c)", "d)", "e)", "f)" };
        int _indexABC = 0;
        int _hightA4 = 1050;

        //
        DataTable dt;
        DataTable dtcp;
        DataTable dtks;
        DataTable dtqs;
        //DataTable dthc;
        DataTable dtkq_My;
        DataTable dtcp_My;
        DataTable dtks_My;
        DataTable dtqs_My;
        //DataTable dthc_My;

        int _KqCount = 0;
        int _KsCount = 0;
        int _CpCount = 0;
        int _QsCount = 0;
        int _KqCount_My = 0;
        int _KsCount_My = 0;
        int _CpCount_My = 0;
        int _QsCount_My = 0;

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int y = 70;
            int x = 65;
            int lineTile = 22;
            int line = 22;
            try
            {
                line = Convert.ToInt32(lineSpace.Text.Trim());
            }
            catch
            {
                line = 22;
            }

            if (!flag) y -= line;

            if (flag)
            {
                e.Graphics.DrawString("PHÒNG THAM MƯU", new Font("Times New Roman", 14, FontStyle.Regular),
                    Brushes.Black, new Point(x + 55, y));

                e.Graphics.DrawString("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", new Font("Times New Roman", 14, FontStyle.Bold),
                    Brushes.Black, new Point(x + 310, y));

                y += lineTile;

                e.Graphics.DrawString("BAN TÁC CHIẾN ĐIỆN TỬ", new Font("Times New Roman", 14, FontStyle.Bold),
                    Brushes.Black, new Point(x + 20, y));

                e.Graphics.DrawString("Độc lập - Tự do - Hạnh phúc", new Font("Times New Roman", 14, FontStyle.Bold),
                    Brushes.Black, new Point(x + 397, y));

                y += lineTile + 2;
                // Sets the value of charactersOnPage to the number of characters
                // of stringToPrint that will fit within the bounds of the page.

                DateTime d = datePrintBC.DateTime;
                Bitmap bmp = Properties.Resources.gach_chan;
                Image newImage = bmp;
                e.Graphics.DrawImage(newImage, 80, y, 715, 4);

                y += lineTile - 10;
                e.Graphics.DrawString("Hải Phòng, ngày " + d.ToString("dd") + " tháng " + d.ToString("MM") + " năm " + d.Year,
                    new Font("Times New Roman", 14, FontStyle.Italic),
                    Brushes.Black, new Point(x + 355, y));

                y += lineTile + 25;
                e.Graphics.DrawString("BÁO CÁO", new Font("Times New Roman", 14, FontStyle.Bold),
                    Brushes.Black, new Point(x + 315, y));

                y += lineTile;
                e.Graphics.DrawString(txtTitle.Text,
                    new Font("Times New Roman", 14, FontStyle.Bold),
                    Brushes.Black, new Point(x + 200, y));

                y += lineTile;
                e.Graphics.DrawString("(Từ ngày " + dteTuNgay_Print.Text + " đến ngày " + dteDenNgay_Print.Text + ")",
                    new Font("Times New Roman", 14, FontStyle.Italic),
                    Brushes.Black, new Point(245, y));

                StringFormat format1 = new StringFormat();
                format1.Trimming = StringTrimming.EllipsisWord;

                y += lineTile + 25;
                e.Graphics.DrawString("      I. TÌNH HÌNH CHUNG", new Font("Times New Roman", 14, FontStyle.Bold),
                    Brushes.Black, new Point(x, y));

                string s = "      " + txtDgiaChung.Text;
                y += line;
                e.Graphics.DrawString(s, new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black,
                                        new RectangleF(x, y, 750, 50), format1);

                y += 50;
                e.Graphics.DrawString("      II. KHU VỰC VỊNH BẮC BỘ", new Font("Times New Roman", 14, FontStyle.Bold),
                    Brushes.Black, new Point(x, y));

                y += line;
                e.Graphics.DrawString("      1. Trung Quốc", new Font("Times New Roman", 14, FontStyle.Bold),
                    Brushes.Black, new Point(x, y));

                y += line;
                if (dt.Rows.Count > 0)
                {
                    int total_MTKQ = 0;
                    string str = "";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        total_MTKQ += Convert.ToInt32(dt.Rows[i]["SoLuong"].ToString());
                    }

                    if (total_MTKQ < 10) str = "0" + total_MTKQ.ToString();
                    else str = total_MTKQ.ToString();

                    if (checkKQ_TQ.Checked)
                    {
                        e.Graphics.DrawString("      a) Không quân: " + str + " l/c", new Font("Times New Roman", 14, FontStyle.Bold),
                            Brushes.Black, new Point(x, y));
                    }
                    else
                    {
                        bool tmp_kiemTra_khuVuc = false;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow dr = dt.Rows[i];
                            string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();
                            if (hd.Contains("bạch long") ||
                                hd.Contains("bach long") ||
                                hd.Contains("bạch  long") ||
                                hd.Contains("blv") ||
                                hd.Contains("trần") ||
                                hd.Contains("tran") ||
                                hd.Contains("trà bản") ||
                                hd.Contains("tra ban") ||
                                hd.Contains("cô tô") ||
                                hd.Contains("co to"))
                            {
                                tmp_kiemTra_khuVuc = true;
                            }
                        }

                        if (tmp_kiemTra_khuVuc)
                        {
                            e.Graphics.DrawString("      a) Không quân: " + str + " l/c. Trong đó đáng chú ý:", new Font("Times New Roman", 14, FontStyle.Bold),
                                Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      a) Không quân: " + str + " l/c", new Font("Times New Roman", 14, FontStyle.Bold),
                                Brushes.Black, new Point(x, y));
                        }
                    }

                }
                else
                {
                    e.Graphics.DrawString("      a) Không quân: Không có mục tiêu", new Font("Times New Roman", 14, FontStyle.Bold),
                        Brushes.Black, new Point(x, y));
                }
            }


            if (checkKQ_TQ.Checked)
            {
                while (_KqCount < dt.Rows.Count)
                {
                    DataRow dr = dt.Rows[_KqCount];
                    _KqCount++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();

                    int total_MT = 0;
                    string str = "";

                    total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                    if (total_MT == 1) str = "";
                    else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                    else str = total_MT.ToString();

                    if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }

                    }
                    else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() + 
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() + 
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() + 
                                " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() +
                              " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                              " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                              " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                              new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }
            else
            {
                while (_KqCount < dt.Rows.Count)
                {
                    DataRow dr = dt.Rows[_KqCount];
                    _KqCount++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();
                    if (hd.Contains("bạch long") ||
                        hd.Contains("bach long") ||
                        hd.Contains("bạch  long") ||
                        hd.Contains("blv") ||
                        hd.Contains("trần") ||
                        hd.Contains("tran") ||
                        hd.Contains("trà bản") ||
                        hd.Contains("tra ban") ||
                        hd.Contains("cô tô") ||
                        hd.Contains("co to"))
                    {
                        int total_MT = 0;
                        string str = "";

                        total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                        if (total_MT == 1) str = "";
                        else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                        else str = total_MT.ToString();

                        if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }

                        }
                        else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() +
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() + 
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() +
                                    " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() +
                                  " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                  " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                                  " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                  new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") + 
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }

            if (flag || _VBBchapPhap == "")
            {
                y += line;

                if (dtcp.Rows.Count > 0)
                {
                    int total_MT = 0;
                    string str = "";

                    for (int i = 0; i < dtcp.Rows.Count; i++)
                    {
                        total_MT += Convert.ToInt32(dtcp.Rows[i]["SoLuong"].ToString());
                    }

                    if (total_MT < 10) str = "0" + total_MT.ToString();
                    else str = total_MT.ToString();

                    if (checkChapPhap_TQ.Checked)
                    {
                        e.Graphics.DrawString("      b) Tàu chấp pháp: " + str + " l/c", new Font("Times New Roman", 14, FontStyle.Bold),
                            Brushes.Black, new Point(x, y));
                    }
                    else
                    {
                        bool tmp_kiemTra_khuVuc = false;
                        for (int i = 0; i < dtcp.Rows.Count; i++)
                        {
                            DataRow dr = dtcp.Rows[i];
                            string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();
                            if (hd.Contains("bạch long") ||
                                hd.Contains("bach long") ||
                                hd.Contains("bạch  long") ||
                                hd.Contains("blv") ||
                                hd.Contains("trần") ||
                                hd.Contains("tran") ||
                                hd.Contains("trà bản") ||
                                hd.Contains("tra ban") ||
                                hd.Contains("cô tô") ||
                                hd.Contains("co to"))
                            {
                                tmp_kiemTra_khuVuc = true;
                            }
                        }

                        if (tmp_kiemTra_khuVuc)
                        {
                            e.Graphics.DrawString("      b) Tàu chấp pháp: " + str + " l/c. Trong đó đáng chú ý:", new Font("Times New Roman", 14, FontStyle.Bold),
                            Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      b) Tàu chấp pháp: " + str + " l/c", new Font("Times New Roman", 14, FontStyle.Bold),
                            Brushes.Black, new Point(x, y));
                        }
                    }
                }
                else
                {
                    e.Graphics.DrawString("      b) Tàu chấp pháp: Không có mục tiêu", new Font("Times New Roman", 14, FontStyle.Bold),
                        Brushes.Black, new Point(x, y));
                }

                _VBBchapPhap = "đã in";
            }

            if (checkChapPhap_TQ.Checked)
            {
                while (_CpCount < dtcp.Rows.Count)
                {
                    DataRow dr = dtcp.Rows[_CpCount];
                    _CpCount++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();

                    int total_MT = 0;
                    string str = "";

                    total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                    if (total_MT == 1) str = "";
                    else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                    else str = total_MT.ToString();

                    if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu" +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }

                    }
                    else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu" +
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu" +
                              " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                              " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                              " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                              new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }
            else
            {
                while (_CpCount < dtcp.Rows.Count)
                {
                    DataRow dr = dtcp.Rows[_CpCount];
                    _CpCount++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();
                    if (hd.Contains("bạch long") ||
                        hd.Contains("bach long") ||
                        hd.Contains("bạch  long") ||
                        hd.Contains("blv") ||
                        hd.Contains("trần") ||
                        hd.Contains("tran") ||
                        hd.Contains("trà bản") ||
                        hd.Contains("tra ban") ||
                        hd.Contains("cô tô") ||
                        hd.Contains("co to"))
                    {
                        int total_MT = 0;
                        string str = "";

                        total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                        if (total_MT == 1) str = "";
                        else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                        else str = total_MT.ToString();

                        if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu" +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }

                        }
                        else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu" +
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu" +
                                  " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                  " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                  " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                  new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }

            if (flag || _VBBquansu == "")
            {
                y += line;

                if (dtqs.Rows.Count > 0)
                {
                    int total_MT = 0;
                    string str = "";

                    for (int i = 0; i < dtqs.Rows.Count; i++)
                    {
                        total_MT += Convert.ToInt32(dtqs.Rows[i]["SoLuong"].ToString());
                    }

                    if (total_MT < 10) str = "0" + total_MT.ToString();
                    else str = total_MT.ToString();

                    if (checkQS_TQ.Checked)
                    {
                        e.Graphics.DrawString("      c) Tàu quân sự: " + str + " l/c", new Font("Times New Roman", 14, FontStyle.Bold),
                            Brushes.Black, new Point(x, y));
                    }
                    else
                    {
                        bool tmp_kiemTra_khuVuc = false;
                        for (int i = 0; i < dtqs.Rows.Count; i++)
                        {
                            DataRow dr = dtqs.Rows[i];
                            string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();
                            if (hd.Contains("bạch long") ||
                                hd.Contains("bach long") ||
                                hd.Contains("bạch  long") ||
                                hd.Contains("blv") ||
                                hd.Contains("trần") ||
                                hd.Contains("tran") ||
                                hd.Contains("trà bản") ||
                                hd.Contains("tra ban") ||
                                hd.Contains("cô tô") ||
                                hd.Contains("co to"))
                            {
                                tmp_kiemTra_khuVuc = true;
                            }
                        }

                        if (tmp_kiemTra_khuVuc)
                        {
                            e.Graphics.DrawString("      c) Tàu quân sự: " + str + " l/c. Trong đó đáng chú ý:", new Font("Times New Roman", 14, FontStyle.Bold),
                                Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      c) Tàu quân sự: " + str + " l/c", new Font("Times New Roman", 14, FontStyle.Bold),
                                Brushes.Black, new Point(x, y));
                        }
                    }
                }
                else
                {
                    e.Graphics.DrawString("      c) Tàu quân sự: Không có mục tiêu", new Font("Times New Roman", 14, FontStyle.Bold),
                        Brushes.Black, new Point(x, y));
                }

                _VBBquansu = "đã in";
            }

            if (checkQS_TQ.Checked)
            {
                while (_QsCount < dtqs.Rows.Count)
                {
                    DataRow dr = dtqs.Rows[_QsCount];
                    _QsCount++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();

                    int total_MT = 0;
                    string str = "";

                    total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                    if (total_MT == 1) str = "";
                    else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                    else str = total_MT.ToString();

                    if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu" +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }

                    }
                    else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu" +
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu" +
                              " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                              " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                              " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                              new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }
            else
            {
                while (_QsCount < dtqs.Rows.Count)
                {
                    DataRow dr = dtqs.Rows[_QsCount];
                    _QsCount++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();
                    if (hd.Contains("bạch long") ||
                        hd.Contains("bach long") ||
                        hd.Contains("bạch  long") ||
                        hd.Contains("blv") ||
                        hd.Contains("trần") ||
                        hd.Contains("tran") ||
                        hd.Contains("trà bản") ||
                        hd.Contains("tra ban") ||
                        hd.Contains("cô tô") ||
                        hd.Contains("co to"))
                    {
                        int total_MT = 0;
                        string str = "";

                        total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                        if (total_MT == 1) str = "";
                        else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                        else str = total_MT.ToString();

                        if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu" +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }

                        }
                        else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu" +
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu" +
                                  " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                  " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                  " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                  new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }
            
            //------------????????
            if (flag || _VBBNCKS == "")
            {
                y += line;

                if (dtks.Rows.Count > 0)
                {
                    int total_MT = 0;
                    string str = "";

                    for (int i = 0; i < dtks.Rows.Count; i++)
                    {
                        total_MT += Convert.ToInt32(dtks.Rows[i]["SoLuong"].ToString());
                    }

                    if (total_MT < 10) str = "0" + total_MT.ToString();
                    else str = total_MT.ToString();

                    if (checkNCKS_TQ.Checked)
                    {
                        e.Graphics.DrawString("      d) Tàu nghiên cứu khảo sát: " + str + " l/c", new Font("Times New Roman", 14, FontStyle.Bold),
                            Brushes.Black, new Point(x, y));
                    }
                    else
                    {
                        bool tmp_kiemTra_khuVuc = false;
                        for (int i = 0; i < dtks.Rows.Count; i++)
                        {
                            DataRow dr = dtks.Rows[i];
                            string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();
                            if (hd.Contains("bạch long") ||
                                hd.Contains("bach long") ||
                                hd.Contains("bạch  long") ||
                                hd.Contains("blv") ||
                                hd.Contains("trần") ||
                                hd.Contains("tran") ||
                                hd.Contains("trà bản") ||
                                hd.Contains("tra ban") ||
                                hd.Contains("cô tô") ||
                                hd.Contains("co to"))
                            {
                                tmp_kiemTra_khuVuc = true;
                            }
                        }

                        if (tmp_kiemTra_khuVuc)
                        {
                            e.Graphics.DrawString("      d) Tàu nghiên cứu khảo sát: " + str + " l/c. Trong đó đáng chú ý:", new Font("Times New Roman", 14, FontStyle.Bold),
                                Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      d) Tàu nghiên cứu khảo sát: " + str + " l/c", new Font("Times New Roman", 14, FontStyle.Bold),
                                Brushes.Black, new Point(x, y));
                        }
                    }
                }
                else
                {
                    e.Graphics.DrawString("      d) Tàu nghiên cứu khảo sát: Không có mục tiêu", new Font("Times New Roman", 14, FontStyle.Bold),
                        Brushes.Black, new Point(x, y));
                }
                _VBBNCKS = "đã in";
            }

            //
            if (checkNCKS_TQ.Checked)
            {
                while (_KsCount < dtks.Rows.Count)
                {
                    DataRow dr = dtks.Rows[_KsCount];
                    _KsCount++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();

                    int total_MT = 0;
                    string str = "";

                    total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                    if (total_MT == 1) str = "";
                    else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                    else str = total_MT.ToString();

                    if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }

                    }
                    else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " +
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " +
                              " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                              " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                              " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                              new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }
            else
            {
                while (_KsCount < dtks.Rows.Count)
                {
                    DataRow dr = dtks.Rows[_KsCount];
                    _KsCount++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();
                    if (hd.Contains("bạch long") ||
                        hd.Contains("bach long") ||
                        hd.Contains("bạch  long") ||
                        hd.Contains("blv") ||
                        hd.Contains("trần") ||
                        hd.Contains("tran") ||
                        hd.Contains("trà bản") ||
                        hd.Contains("tra ban") ||
                        hd.Contains("cô tô") ||
                        hd.Contains("co to"))
                    {
                        int total_MT = 0;
                        string str = "";

                        total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                        if (total_MT == 1) str = "";
                        else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                        else str = total_MT.ToString();

                        if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }

                        }
                        else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " +
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " +
                                  " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                  " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                  " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                  new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }

            //=========================================Lực lượng Mỹ======================>>>>>>>>
            if (flag || _2My == "")
            {
                if (dtqs_My.Rows.Count == 0 && dtkq_My.Rows.Count == 0 && dtcp_My.Rows.Count == 0)
                {
                    y += line;
                    e.Graphics.DrawString("      2. Mỹ: Không có mục tiêu", new Font("Times New Roman", 14, FontStyle.Bold),
                        Brushes.Black, new Point(x, y));
                    _2My = "đã in";
                }
                else
                {
                    y += line;
                    e.Graphics.DrawString("      2. Mỹ", new Font("Times New Roman", 14, FontStyle.Bold),
                        Brushes.Black, new Point(x, y));
                    _2My = "đã in";
                }

                //ngắt trang:
                if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                {
                    e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                }

                else // if the number of item(per page) is more than 20 then add one page
                {
                    flag = false;
                    e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                    return;//It will call PrintPage event again
                }
            }

            //Mỹ:
            if (flag || _VBBKqMy == "")
            {
                if (dtkq_My.Rows.Count > 0)
                {
                    y += line;

                    int total_MT = 0;
                    string str = "";

                    for (int i = 0; i < dtkq_My.Rows.Count; i++)
                    {
                        total_MT += Convert.ToInt32(dtkq_My.Rows[i]["SoLuong"].ToString());
                    }

                    if (total_MT < 10) str = "0" + total_MT.ToString();
                    else str = total_MT.ToString();

                    e.Graphics.DrawString("      " + abcde[_indexABC] + " Không quân: " + str + " l/c", new Font("Times New Roman", 14, FontStyle.Bold),
                        Brushes.Black, new Point(x, y));
                    _VBBKqMy = "đã in";
                    _indexABC++;

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }

            //
            if (checkKQ_My.Checked)
            {
                while (_KqCount_My < dtkq_My.Rows.Count)
                {
                    DataRow dr = dtkq_My.Rows[_KqCount_My];
                    _KqCount_My++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();

                    int total_MT = 0;
                    string str = "";

                    total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                    if (total_MT == 1) str = "";
                    else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                    else str = total_MT.ToString();

                    if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }

                    }
                    else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() +
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() +
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() +
                                " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() +
                              " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                              " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                              " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                              new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }
            else
            {
                while (_KqCount_My < dtkq_My.Rows.Count)
                {
                    DataRow dr = dtkq_My.Rows[_KqCount_My];
                    _KqCount_My++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();
                    if (hd.Contains("bạch long") ||
                        hd.Contains("bach long") ||
                        hd.Contains("bạch  long") ||
                        hd.Contains("blv") ||
                        hd.Contains("trần") ||
                        hd.Contains("tran") ||
                        hd.Contains("trà bản") ||
                        hd.Contains("tra ban") ||
                        hd.Contains("cô tô") ||
                        hd.Contains("co to"))
                    {
                        int total_MT = 0;
                        string str = "";

                        total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                        if (total_MT == 1) str = "";
                        else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                        else str = total_MT.ToString();

                        if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }

                        }
                        else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() +
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() +
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() +
                                    " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() +
                                  " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                  " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                  " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                  new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Máy bay " + dr["KieuLoai"].ToString().Trim() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " máy bay " + dr["KieuLoai"].ToString().Trim() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }
            
            //
            if (flag || _VBBchapPhapMy == "")
            {
                if (dtcp_My.Rows.Count > 0)
                {
                    y += line;

                    int total_MT = 0;
                    string str = "";

                    for (int i = 0; i < dtcp_My.Rows.Count; i++)
                    {
                        total_MT += Convert.ToInt32(dtcp_My.Rows[i]["SoLuong"].ToString());
                    }

                    if (total_MT < 10) str = "0" + total_MT.ToString();
                    else str = total_MT.ToString();

                    e.Graphics.DrawString("      " + abcde[_indexABC] + " Tàu chấp pháp: " + str + " l/c", new Font("Times New Roman", 14, FontStyle.Bold),
                        Brushes.Black, new Point(x, y));
                    _VBBchapPhapMy = "đã in";
                    _indexABC++;

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }

            //
            //
            if (checkChapPhap_My.Checked)
            {
                while (_CpCount_My < dtcp_My.Rows.Count)
                {
                    DataRow dr = dtcp_My.Rows[_CpCount_My];
                    _CpCount_My++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();

                    int total_MT = 0;
                    string str = "";

                    total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                    if (total_MT == 1) str = "";
                    else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                    else str = total_MT.ToString();

                    if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }

                    }
                    else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " +
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " +
                              " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                              " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                              " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                              new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }
            else
            {
                while (_CpCount_My < dtcp_My.Rows.Count)
                {
                    DataRow dr = dtcp_My.Rows[_CpCount_My];
                    _CpCount_My++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();
                    if (hd.Contains("bạch long") ||
                        hd.Contains("bach long") ||
                        hd.Contains("bạch  long") ||
                        hd.Contains("blv") ||
                        hd.Contains("trần") ||
                        hd.Contains("tran") ||
                        hd.Contains("trà bản") ||
                        hd.Contains("tra ban") ||
                        hd.Contains("cô tô") ||
                        hd.Contains("co to"))
                    {
                        int total_MT = 0;
                        string str = "";

                        total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                        if (total_MT == 1) str = "";
                        else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                        else str = total_MT.ToString();

                        if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }

                        }
                        else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " +
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " +
                                  " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                  " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                  " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                  new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }
            
            //quân sự mỹ:
            if (flag || _VBBquansuMy == "")
            {
                if (dtqs_My.Rows.Count > 0)
                {
                    y += line;

                    int total_MT = 0;
                    string str = "";

                    for (int i = 0; i < dtqs_My.Rows.Count; i++)
                    {
                        total_MT += Convert.ToInt32(dtqs_My.Rows[i]["SoLuong"].ToString());
                    }

                    if (total_MT < 10) str = "0" + total_MT.ToString();
                    else str = total_MT.ToString();

                    e.Graphics.DrawString("      " + abcde[_indexABC] + " Tàu quân sự: " + str + " l/c", new Font("Times New Roman", 14, FontStyle.Bold),
                        Brushes.Black, new Point(x, y));
                    _VBBquansuMy = "đã in";
                    _indexABC++;

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }

            //
            //
            if (checkQuanSu_My.Checked)
            {
                while (_QsCount_My < dtqs_My.Rows.Count)
                {
                    DataRow dr = dtqs_My.Rows[_QsCount_My];
                    _QsCount_My++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();

                    int total_MT = 0;
                    string str = "";

                    total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                    if (total_MT == 1) str = "";
                    else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                    else str = total_MT.ToString();

                    if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }

                    }
                    else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " +
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " +
                              " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                              " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                              " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                              new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }
            else
            {
                while (_QsCount_My < dtqs_My.Rows.Count)
                {
                    DataRow dr = dtqs_My.Rows[_QsCount_My];
                    _QsCount_My++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();
                    if (hd.Contains("bạch long") ||
                        hd.Contains("bach long") ||
                        hd.Contains("bạch  long") ||
                        hd.Contains("blv") ||
                        hd.Contains("trần") ||
                        hd.Contains("tran") ||
                        hd.Contains("trà bản") ||
                        hd.Contains("tra ban") ||
                        hd.Contains("cô tô") ||
                        hd.Contains("co to"))
                    {
                        int total_MT = 0;
                        string str = "";

                        total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                        if (total_MT == 1) str = "";
                        else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                        else str = total_MT.ToString();

                        if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }

                        }
                        else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " +
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " +
                                  " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                  " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                  " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                  new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }
            

            // khảo sát mỹ:

            if (flag || _VBBNCKSMy == "")
            {
                if (dtks_My.Rows.Count > 0)
                {
                    y += line;

                    int total_MT = 0;
                    string str = "";

                    for (int i = 0; i < dtks_My.Rows.Count; i++)
                    {
                        total_MT += Convert.ToInt32(dtks_My.Rows[i]["SoLuong"].ToString());
                    }

                    if (total_MT < 10) str = "0" + total_MT.ToString();
                    else str = total_MT.ToString();

                    e.Graphics.DrawString("      " + abcde[_indexABC] + " Tàu nghiên cứu khảo sát: " + str + " l/c", new Font("Times New Roman", 14, FontStyle.Bold),
                        Brushes.Black, new Point(x, y));
                    _VBBNCKSMy = "đã in";
                    _indexABC++;

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }

            //
            //
            if (checkNCKS_My.Checked)
            {
                while (_KsCount_My < dtks_My.Rows.Count)
                {
                    DataRow dr = dtks_My.Rows[_KsCount_My];
                    _KsCount_My++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();

                    int total_MT = 0;
                    string str = "";

                    total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                    if (total_MT == 1) str = "";
                    else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                    else str = total_MT.ToString();

                    if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " +
                                " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" +
                                " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }

                    }
                    else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " +
                                " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" +
                                " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " +
                              " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                              " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                              " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                              new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }
                    else
                    {
                        y += line;
                        if (total_MT == 1)
                        {
                            e.Graphics.DrawString("      - Tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                        else
                        {
                            e.Graphics.DrawString("      - " + str + " tàu " + " tại " + dr["KhuVucHoatDong"].ToString() +
                                " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }
            else
            {
                while (_KsCount_My < dtks_My.Rows.Count)
                {
                    DataRow dr = dtks_My.Rows[_KsCount_My];
                    _KsCount_My++;
                    string hd = (dr["KhuVucHoatDong"].ToString()).ToLower();
                    if (hd.Contains("bạch long") ||
                        hd.Contains("bach long") ||
                        hd.Contains("bạch  long") ||
                        hd.Contains("blv") ||
                        hd.Contains("trần") ||
                        hd.Contains("tran") ||
                        hd.Contains("trà bản") ||
                        hd.Contains("tra ban") ||
                        hd.Contains("cô tô") ||
                        hd.Contains("co to"))
                    {
                        int total_MT = 0;
                        string str = "";

                        total_MT += Convert.ToInt32(dr["SoLuong"].ToString());

                        if (total_MT == 1) str = "";
                        else if (1 < total_MT && total_MT < 10) str = "0" + total_MT.ToString();
                        else str = total_MT.ToString();

                        if (!string.IsNullOrWhiteSpace(dr["FullName"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " +
                                    " " + dr["FullName"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" +
                                    " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }

                        }
                        else if (!string.IsNullOrWhiteSpace(dr["SoHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " +
                                    " số hiệu " + dr["SoHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(dr["DanhHieu"].ToString()))
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" +
                                    " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " +
                                  " danh hiệu " + dr["DanhHieu"].ToString() + " tại " + dr["KhuVucHoatDong"].ToString() +
                                  " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                  " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                  new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                        else
                        {
                            y += line;
                            if (total_MT == 1)
                            {
                                e.Graphics.DrawString("      - Tàu" + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                            else
                            {
                                e.Graphics.DrawString("      - " + str + " tàu " + " tại " + dr["KhuVucHoatDong"].ToString() +
                                    " " + dr["Distance"].ToString() + "hl" + " (lúc " + Convert.ToDateTime(dr["DateCurent"]).ToString("HH:mm") +
                                    " ngày " + Convert.ToDateTime(dr["DateCurent"]).ToString("dd/MM") + ").",
                                    new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(x, y));
                            }
                        }
                    }

                    //ngắt trang:
                    if (y < _hightA4) // check whether  the number of item(per page) is more than 20 or not
                    {
                        e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added
                    }

                    else // if the number of item(per page) is more than 20 then add one page
                    {
                        flag = false;
                        e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                        return;//It will call PrintPage event again
                    }
                }
            }


            //Phần ký tên:
            if (flag || _KyTen == "")
            {
                y += lineTile + 20;
                e.Graphics.DrawString("Nơi nhận:", new Font("Times New Roman", 13, FontStyle.Italic),
                    Brushes.Black, new Point(x, y));

                e.Graphics.DrawString(txtChucVu_PrintBC.Text.ToUpper(), new Font("Times New Roman", 14, FontStyle.Bold),
                    Brushes.Black, new Point(x + 355, y));

                y += lineTile;
                e.Graphics.DrawString("- PTMT-TC;", new Font("Times New Roman", 11, FontStyle.Regular),
                    Brushes.Black, new Point(x, y));

                y += lineTile;
                e.Graphics.DrawString("- Lưu: TCĐT, " + returnLuutru(txtNguoiTongHop.Text) + "02.", new Font("Times New Roman", 11, FontStyle.Regular),
                    Brushes.Black, new Point(x, y));

                y += lineTile + 60;
                e.Graphics.DrawString(txtNguoiTongHop.Text, new Font("Times New Roman", 14, FontStyle.Bold),
                    Brushes.Black, new Point(x + 395, y));
                _KyTen = "đã in";
            }
        }

        //
        private string returnLuutru(string str)
        {
            string result = "";
            if (string.IsNullOrEmpty(str))
            {
                result = "T";
            }
            else
            {
                str = str.Trim();
                string[] strSplit = str.Split();
                result = strSplit[strSplit.Length - 1].Substring(0, 1);
            }
            return result;
        }

        //
        private void print_start()
        {
            _KqCount = 0;
            _KsCount = 0;
            _CpCount = 0;
            _QsCount = 0;
            _KqCount_My = 0;
            _KsCount_My = 0;
            _CpCount_My = 0;
            _QsCount_My = 0;
            _indexABC = 0;

            flag = true;
            _KyTen = "";
            _VBBchapPhap = "";
            _VBBNCKS = "";
            _VBBNCKSMy = "";
            _VBBquansu = "";
            _2My = "";
            _VBBKqMy = "";
            _VBBchapPhapMy = "";
            _VBBquansuMy = "";


            clsTabKhongQuan clsKQ = new clsTabKhongQuan();
            clsTabHaiQuan clsHQ = new clsTabHaiQuan();

            //Load mục tiêu không quân trung quốc -VBB:
            dt = clsKQ.pr_SelecPageKhongQuan_TQVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Load mục tiêu tàu chấp pháp trung quốc -VBB:
            dtcp = clsHQ.pr_SelecHaiQuan_ChapPhap_TQVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Load mục tiêu tàu nghiên cứu khảo sát trung quốc -VBB:
            dtks = clsHQ.pr_SelecHaiQuan_NCKS_TQVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Load mục tiêu tàu Quân sự trung quốc -VBB:
            dtqs = clsHQ.pr_SelecHaiQuan_QuanSu_TQVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Load mục tiêu tàu Hải cảnh trung quốc -VBB:
            //dthc = SelectVBB_HCTQ(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Mỹ:
            //Load mục tiêu không quân Mỹ -VBB:
            dtkq_My = clsKQ.pr_SelecPageKhongQuan_MyVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Load mục tiêu tàu chấp pháp Mỹ -VBB:
            dtcp_My = clsHQ.pr_SelecHaiQuan_ChapPhap_MyVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Load mục tiêu tàu nghiên cứu khảo sát Mỹ -VBB:
            dtks_My = clsHQ.pr_SelecHaiQuan_NCKS_MyVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Load mục tiêu tàu Quân sự Mỹ -VBB:
            dtqs_My = clsHQ.pr_SelecHaiQuan_QuanSu_MyVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            printDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.PaperSize = paperSize;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            print_start();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            print_Preview();
        }
        //
        private void print_Preview()
        {
            _KqCount = 0;
            _KsCount = 0;
            _CpCount = 0;
            _QsCount = 0;
            _KqCount_My = 0;
            _KsCount_My = 0;
            _CpCount_My = 0;
            _QsCount_My = 0;
            _indexABC = 0;

            flag = true;
            _KyTen = "";
            _VBBchapPhap = "";
            _VBBNCKS = "";
            _VBBNCKSMy = "";
            _VBBquansu = "";
            _2My = "";
            _VBBKqMy = "";
            _VBBchapPhapMy = "";
            _VBBquansuMy = "";

            clsTabKhongQuan clsKQ = new clsTabKhongQuan();
            clsTabHaiQuan clsHQ = new clsTabHaiQuan();


            //Load mục tiêu không quân trung quốc -VBB:
            dt = clsKQ.pr_SelecPageKhongQuan_TQVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Load mục tiêu tàu chấp pháp trung quốc -VBB:
            dtcp = clsHQ.pr_SelecHaiQuan_ChapPhap_TQVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Load mục tiêu tàu nghiên cứu khảo sát trung quốc -VBB:
            dtks = clsHQ.pr_SelecHaiQuan_NCKS_TQVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Load mục tiêu tàu Quân sự trung quốc -VBB:
            dtqs = clsHQ.pr_SelecHaiQuan_QuanSu_TQVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Mỹ:
            //Load mục tiêu không quân Mỹ -VBB:
            dtkq_My = clsKQ.pr_SelecPageKhongQuan_MyVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Load mục tiêu tàu chấp pháp Mỹ -VBB:
            dtcp_My = clsHQ.pr_SelecHaiQuan_ChapPhap_MyVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Load mục tiêu tàu nghiên cứu khảo sát Mỹ -VBB:
            dtks_My = clsHQ.pr_SelecHaiQuan_NCKS_MyVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Load mục tiêu tàu Quân sự Mỹ -VBB:
            dtqs_My = clsHQ.pr_SelecHaiQuan_QuanSu_MyVBB(dteTuNgay_Print.DateTime, dteDenNgay_Print.DateTime);

            //Load mục tiêu tàu Hải cảnh Mỹ -VBB:
            //dthc_My = SelectVBB_HCMy(dteTuNgay.DateTime, dteDenNgay.DateTime);

            printPreviewDialog1.Document = printDocument1;

            //((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled
            //= false;//disable the direct print from printpreview.as when we click that Print button PrintPage event fires again.


            printDocument1.DefaultPageSettings.PaperSize = paperSize;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.PrintPreviewControl.Size = MaximumSize;
            printPreviewDialog1.ShowDialog();
        }

        private void Print_BC_Click(object sender, EventArgs e)
        {
            print_start();
        }

        private void Print_Preview_BC_Click(object sender, EventArgs e)
        {
            print_Preview();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        //
    }
}

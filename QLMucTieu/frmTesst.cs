using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class frmTesst : Form
    {
        public frmTesst()
        {
            InitializeComponent();
        }

        private void frmTesst_Load(object sender, EventArgs e)
        {

            DataTable dt2 = new DataTable();

            dt2.Columns.Add("ID_ChiTietMuaHang"); // ID của tbChi tiet don hàng
            dt2.Columns.Add("ID_MuaHang");
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(decimal));

            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");


            dt2.Columns.Add("ThanhTien", typeof(decimal));
            dt2.Columns.Add("HienThi", typeof(string));

            gridControl1.DataSource = dt2;

            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv2 = dt.DefaultView;
            DataTable dtxx2 = dv2.ToTable();

            repositoryItemLookUpEdit1.DataSource = dtxx2;
            repositoryItemLookUpEdit1.ValueMember = "ID_VTHH";
            repositoryItemLookUpEdit1.DisplayMember = "MaVT";


          
        }

        

        private void gridView1_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string kk2 = gridView1.GetFocusedRowCellValue(clMaVT).ToString();
            MessageBox.Show(kk2);

            //decimal fffsoluong = 0;
            //decimal ffdongia = 0;
            ////decimal fffthanhtien = 0;

            if (e.Column == clMaVT)
            {

                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();


                cls.iID_VTHH = Convert.ToInt16(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt16(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                MessageBox.Show(kk.ToString());
                DataTable dt = cls.SelectOne();
            }
            //    if (dt != null)
            //    {
            //        Decimal dongiamua_macdinh;
            //        gridView1.SetRowCellValue(e.RowHandle, clID_VTHH, kk);
            //        gridView1.SetRowCellValue(e.RowHandle, clTenVTHH, dt.Rows[0]["TenVTHH"].ToString());
            //        gridView1.SetRowCellValue(e.RowHandle, clDonViTinh, dt.Rows[0]["DonViTinh"].ToString());
            //        gridView1.SetRowCellValue(e.RowHandle, clHienThi, "1");
            //        if (dt.Rows[0]["DonGiaMua"].ToString() == "")
            //            dongiamua_macdinh = 0;
            //        else
            //            dongiamua_macdinh = Convert.ToDecimal(dt.Rows[0]["DonGiaMua"].ToString());
            //        gridView1.SetRowCellValue(e.RowHandle, clDonGia, dongiamua_macdinh);
            //        if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
            //            ffdongia = 0;
            //        else
            //            ffdongia = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(clDonGia));
            //        if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
            //            fffsoluong = 0;
            //        else
            //            fffsoluong = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(clSoLuong));
            //        fffthanhtien = fffsoluong * ffdongia;
            //        string.Format("{0:#,##0.00}", fffthanhtien);
            //        gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);

            //    }
            //}

            //if (e.Column == clSoLuong)
            //{

            //    if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
            //        ffdongia = 0;
            //    else
            //        ffdongia = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(clDonGia));
            //    if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
            //        fffsoluong = 0;
            //    else
            //        fffsoluong = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(clSoLuong));
            //    fffthanhtien = fffsoluong * ffdongia;
            //    string.Format("{0:#,##0.00}", fffthanhtien);
            //    gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);

            //}
            //if (e.Column == clDonGia)
            //{

            //    if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
            //        ffdongia = 0;
            //    else
            //        ffdongia = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(clDonGia));
            //    if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
            //        fffsoluong = 0;
            //    else
            //        fffsoluong = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(clSoLuong));
            //    fffthanhtien = fffsoluong * ffdongia;
            //    string.Format("{0:#,##0.00}", fffthanhtien);
            //    gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);

            //}
            //decimal deTOngtien;
            //DataTable dataTable = (DataTable)gridControl1.DataSource;

            //string shienthi = "1";
            //object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
            //if (xxxx.ToString() != "")
            //    deTOngtien = Convert.ToDecimal(xxxx);
            //else deTOngtien = 0;
            ////txtTongTienHang.Text = deTOngtien.ToString();
        }

        private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //string kk = gridView1.GetFocusedRowCellValue(clMaVT).ToString();
            //MessageBox.Show(kk);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
           
        }
    }
}

package fpo.thanh.coffeeshop.presentation.ui.activity;

import android.os.Bundle;
import android.util.Log;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import java.util.List;

import fpo.thanh.coffeeshop.R;
import fpo.thanh.coffeeshop.domain.Room.AppDatabase;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.BanAn;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.DsMon;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.HoaDon;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.LoaiThucDon;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.Tang;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.ThucDon;
import fpo.thanh.coffeeshop.domain.executor.impl.ThreadExecutor;
import fpo.thanh.coffeeshop.domain.repository.Impl.GetAllDataRepositoryImpl;
import fpo.thanh.coffeeshop.presentation.presenter.GetAllDataPresenter;
import fpo.thanh.coffeeshop.presentation.presenter.impl.GetAllDataPresenterImpl;
import fpo.thanh.coffeeshop.shareModel.BanAnModel;
import fpo.thanh.coffeeshop.shareModel.DsMonModel;
import fpo.thanh.coffeeshop.shareModel.HoaDonModel;
import fpo.thanh.coffeeshop.shareModel.LoaiThucDonModel;
import fpo.thanh.coffeeshop.shareModel.ResultModel;
import fpo.thanh.coffeeshop.shareModel.TangModel;
import fpo.thanh.coffeeshop.shareModel.ThucDonModel;
import fpo.thanh.coffeeshop.threading.MainThreadImpl;

public class SplashScreen extends AppCompatActivity implements GetAllDataPresenter.View {

    AppDatabase mDB;
    Tang tang;
    HoaDon hoaDon;
    GetAllDataPresenter presenter;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_splashscreen);
        presenter=new GetAllDataPresenterImpl(ThreadExecutor.getInstance(), MainThreadImpl.getInstance(),this,new GetAllDataRepositoryImpl());
        presenter.onRequestAllData();
        try{
            mDB=AppDatabase.getDatabase(this);
        }catch (Exception e){
            e.printStackTrace();
        }

    }

    @Override
    public void onShowResultGetAllData(ResultModel result) {
        try{
            createDbTableBanAn(result.getData().getBanAn());
            createDbTableHoaDon(result.getData().getHoaDon());
            createDbTableLoaiThucDoc(result.getData().getLoaiThucDon());
            createDbTableTang(result.getData().getTang());
            createDbTableThucDon(result.getData().getThucDon());

        }catch (Exception e){

        }

    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        mDB.close();
    }
    private void createDbTableBanAn(List<BanAnModel> banAnModels){
        BanAn banAn=new BanAn();
        BanAnModel banAnModel=new BanAnModel();
        mDB.banAnDAO().deleteAllBanAn();
        Log.e("Bàn Ăn "+"Delete",mDB.banAnDAO().getSizeBanAn()+"");

        for(int i =0;i<banAnModels.size();++i){
            banAnModel=banAnModels.get(i);
            banAn.maBan=banAnModel.getMaBan();
            banAn.maTang=banAnModel.getMaTang();
            banAn.tenBan=banAnModel.getTenBan();
            mDB.banAnDAO().insertTang(banAn);
            Log.e(""+i,mDB.banAnDAO().getSizeBanAn()+"");
        }
        Log.e("banan","finished");

    }
    private void createDbTableDsMon(List<DsMonModel> dsMonModels){
        DsMon dsMon=new DsMon();
        DsMonModel dsMonModel=new DsMonModel();
        for(int i=0;i<dsMonModels.size();++i){
            dsMonModel=dsMonModels.get(i);
            dsMon.donGia=dsMonModel.getDonGia();
            dsMon.giaMon=dsMonModel.getGiaMon();
            dsMon.maChiTiet=dsMonModel.getMaChiTiet();
            dsMon.maChiTietLocal=dsMonModel.getMaChiTietLocal();
            dsMon.maHoaDon=dsMonModel.getMaHoaDon();
            dsMon.maThucDon=dsMonModel.getMaThucDon();
            dsMon.soLuong=dsMonModel.getSoLuong();
            dsMon.tenThucDon=dsMonModel.getTenThucDon();
            dsMon.trangThai=dsMonModel.getTrangThai();
            mDB.dsMonDAO().insertTang(dsMon);
        }
        Log.e("dsmon","finished");

    }
    private void createDbTableHoaDon(List<HoaDonModel> hoaDonModels){
        HoaDon hoaDon=new HoaDon();
        HoaDonModel hoaDonModel=new HoaDonModel();
        mDB.hoaDonDAO().deleteAllHoaDon();

        for(int i=0;i<hoaDonModels.size();i++){
            hoaDonModel=hoaDonModels.get(i);
            hoaDon.maBan=hoaDonModel.getMaBan();
            hoaDon.maHoaDon=hoaDonModel.getMaHoaDon();
            hoaDon.maHoaDonLocal=hoaDonModel.getMaHoaDonLocal();
            hoaDon.maNhanVien=hoaDonModel.getMaNhanVien();
            hoaDon.thoiGianLap=hoaDonModel.getThoiGianLap();
            hoaDon.trangThai=hoaDonModel.getTrangThai();
            hoaDon.tongTien=hoaDonModel.getTongTien();
            mDB.hoaDonDAO().insertHoaDon(hoaDon);
            createDbTableDsMon(hoaDonModel.getDsMon());
        }
        Log.e("hoadon","finished");

    }
    private void createDbTableLoaiThucDoc(List<LoaiThucDonModel> loaiThucDonModels){
        LoaiThucDon loaiThucDon=new LoaiThucDon();
        LoaiThucDonModel loaiThucDonModel=new LoaiThucDonModel();
        mDB.loaiThucDonDAO().deleteAllLoaiThucDon();
        for(int i=0;i<loaiThucDonModels.size();i++){
            loaiThucDonModel=loaiThucDonModels.get(i);
            loaiThucDon.maLoai=loaiThucDonModel.getMaLoai();
            loaiThucDon.maLoaiCha=loaiThucDonModel.getMaLoaiCha();
            loaiThucDon.tenLoai=loaiThucDonModel.getTenLoai();
            mDB.loaiThucDonDAO().insertTang(loaiThucDon);
        }
        Log.e("loai thuc don","finished");

    }
    private void createDbTableTang(List<TangModel> tangModels){
        Tang tang=new Tang();
        TangModel tangModel=new TangModel();
        for(int i=0;i<tangModels.size();++i){
            tangModel=tangModels.get(i);
            tang.maTang=tangModel.getMaTang();
            tang.tenTang=tangModel.getTenTang();
            mDB.tangDAO().insertTang(tang);
        }
        Log.e("tang","finished");

    }
    private void createDbTableThucDon(List<ThucDonModel> thucDonModels){
        ThucDon thucDon=new ThucDon();
        ThucDonModel thucDonModel=new ThucDonModel();
        mDB.thucDonDAO().deleteAllThucDon();
        for(int i=0;i<thucDonModels.size();++i){
            thucDonModel=thucDonModels.get(i);
            thucDon.gia=thucDonModel.getGia();
            thucDon.getGiaKhuyenMai=thucDonModel.getGiaKhuyenMai();
            thucDon.giaKhuyenMai=thucDonModel.getGiaKhuyenMai();
            thucDon.hinhAnh=thucDonModel.getHinhAnh();
            thucDon.khuyenMai=thucDonModel.getKhuyenMai();
            thucDon.maLoai=thucDonModel.getMaLoai();
            thucDon.maThucDon=thucDonModel.getMaThucDon();
            thucDon.moTa=thucDonModel.getMoTa();
            thucDon.tenLoai=thucDonModel.getTenLoai();
            thucDon.tenThucDon=thucDonModel.getTenThucDon();
            mDB.thucDonDAO().insertTang(thucDon);
        }
        Log.e("loai thuc don","finished");

    }

}

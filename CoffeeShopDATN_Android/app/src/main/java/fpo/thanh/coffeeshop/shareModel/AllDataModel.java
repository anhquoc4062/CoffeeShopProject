package fpo.thanh.coffeeshop.shareModel;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.List;

public class AllDataModel {
    @SerializedName("loaiThucDon")
    @Expose
    private List<LoaiThucDonModel> loaiThucDon = null;
    @SerializedName("thucDon")
    @Expose
    private List<ThucDonModel> thucDon = null;
    @SerializedName("banAn")
    @Expose
    private List<BanAnModel> banAn = null;
    @SerializedName("tang")
    @Expose
    private List<TangModel> tang = null;
    @SerializedName("hoaDon")
    @Expose
    private List<HoaDonModel> hoaDon = null;

    public List<LoaiThucDonModel> getLoaiThucDon() {
        return loaiThucDon;
    }

    public void setLoaiThucDon(List<LoaiThucDonModel> loaiThucDon) {
        this.loaiThucDon = loaiThucDon;
    }

    public List<ThucDonModel> getThucDon() {
        return thucDon;
    }

    public void setThucDon(List<ThucDonModel> thucDon) {
        this.thucDon = thucDon;
    }

    public List<BanAnModel> getBanAn() {
        return banAn;
    }

    public void setBanAn(List<BanAnModel> banAn) {
        this.banAn = banAn;
    }

    public List<TangModel> getTang() {
        return tang;
    }

    public void setTang(List<TangModel> tang) {
        this.tang = tang;
    }

    public List<HoaDonModel> getHoaDon() {
        return hoaDon;
    }

    public void setHoaDon(List<HoaDonModel> hoaDon) {
        this.hoaDon = hoaDon;
    }
}

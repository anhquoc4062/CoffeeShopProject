package fpo.thanh.coffeeshop.shareModel;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class DsMonModel {
    @SerializedName("tenThucDon")
    @Expose
    private String tenThucDon;
    @SerializedName("giaMon")
    @Expose
    private Double giaMon;
    @SerializedName("maChiTiet")
    @Expose
    private Integer maChiTiet;
    @SerializedName("maHoaDon")
    @Expose
    private Integer maHoaDon;
    @SerializedName("maThucDon")
    @Expose
    private Integer maThucDon;
    @SerializedName("soLuong")
    @Expose
    private Integer soLuong;
    @SerializedName("donGia")
    @Expose
    private Double donGia;
    @SerializedName("maChiTietLocal")
    @Expose
    private Integer maChiTietLocal;
    @SerializedName("trangThai")
    @Expose
    private Integer trangThai;

    public String getTenThucDon() {
        return tenThucDon;
    }

    public void setTenThucDon(String tenThucDon) {
        this.tenThucDon = tenThucDon;
    }

    public Double getGiaMon() {
        return giaMon;
    }

    public void setGiaMon(Double giaMon) {
        this.giaMon = giaMon;
    }

    public Integer getMaChiTiet() {
        return maChiTiet;
    }

    public void setMaChiTiet(Integer maChiTiet) {
        this.maChiTiet = maChiTiet;
    }

    public Integer getMaHoaDon() {
        return maHoaDon;
    }

    public void setMaHoaDon(Integer maHoaDon) {
        this.maHoaDon = maHoaDon;
    }

    public Integer getMaThucDon() {
        return maThucDon;
    }

    public void setMaThucDon(Integer maThucDon) {
        this.maThucDon = maThucDon;
    }

    public Integer getSoLuong() {
        return soLuong;
    }

    public void setSoLuong(Integer soLuong) {
        this.soLuong = soLuong;
    }

    public Double getDonGia() {
        return donGia;
    }

    public void setDonGia(Double donGia) {
        this.donGia = donGia;
    }

    public Integer getMaChiTietLocal() {
        return maChiTietLocal;
    }

    public void setMaChiTietLocal(Integer maChiTietLocal) {
        this.maChiTietLocal = maChiTietLocal;
    }

    public Integer getTrangThai() {
        return trangThai;
    }

    public void setTrangThai(Integer trangThai) {
        this.trangThai = trangThai;
    }
}

package fpo.thanh.coffeeshop.shareModel;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class LoaiThucDonModel {
    @SerializedName("maLoai")
    @Expose
    private Integer maLoai;
    @SerializedName("tenLoai")
    @Expose
    private String tenLoai;
    @SerializedName("maLoaiCha")
    @Expose
    private Integer maLoaiCha;

    public Integer getMaLoai() {
        return maLoai;
    }

    public void setMaLoai(Integer maLoai) {
        this.maLoai = maLoai;
    }

    public String getTenLoai() {
        return tenLoai;
    }

    public void setTenLoai(String tenLoai) {
        this.tenLoai = tenLoai;
    }

    public Integer getMaLoaiCha() {
        return maLoaiCha;
    }

    public void setMaLoaiCha(Integer maLoaiCha) {
        this.maLoaiCha = maLoaiCha;
    }
}

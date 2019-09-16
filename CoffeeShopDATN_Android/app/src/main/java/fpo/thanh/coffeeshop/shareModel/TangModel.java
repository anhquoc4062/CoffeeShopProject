package fpo.thanh.coffeeshop.shareModel;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class TangModel {
    @SerializedName("maTang")
    @Expose
    private Integer maTang;
    @SerializedName("tenTang")
    @Expose
    private String tenTang;

    public Integer getMaTang() {
        return maTang;
    }

    public void setMaTang(Integer maTang) {
        this.maTang = maTang;
    }

    public String getTenTang() {
        return tenTang;
    }

    public void setTenTang(String tenTang) {
        this.tenTang = tenTang;
    }
}

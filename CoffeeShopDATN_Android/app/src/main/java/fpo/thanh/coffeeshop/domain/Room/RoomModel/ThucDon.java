package fpo.thanh.coffeeshop.domain.Room.RoomModel;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.PrimaryKey;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

@Entity
public class ThucDon {

    @PrimaryKey(autoGenerate = false)
    public Integer maThucDon;
    @ColumnInfo(name ="tenLoai")
    public String tenLoai;
    @ColumnInfo(name ="getGiaKhuyenMai")
    public Double getGiaKhuyenMai;
    @ColumnInfo(name ="tenThucDon")
    public String tenThucDon;
    @ColumnInfo(name ="hinhAnh")
    public String hinhAnh;
    @ColumnInfo(name ="maLoai")
    public Integer maLoai;
    @ColumnInfo(name ="gia")
    public Double gia;
    @ColumnInfo(name ="khuyenMai")
    public Integer khuyenMai;
    @ColumnInfo(name ="moTa")
    public String moTa;
    @ColumnInfo(name ="giaKhuyenMai")
    public Double giaKhuyenMai;
}

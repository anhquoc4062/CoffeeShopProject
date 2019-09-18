package fpo.thanh.coffeeshop.domain.Room.RoomModel;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.PrimaryKey;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

@Entity
public class BanAn {
    @Override
    public String toString() {
        return "BanAn{" +
                "maBan=" + maBan +
                ", tenBan='" + tenBan + '\'' +
                ", maTang=" + maTang +
                '}';
    }

    @PrimaryKey(autoGenerate = false)
    public Integer maBan;
    @ColumnInfo(name = "tenBan")
    public String tenBan;
    @ColumnInfo(name = "maTang")
    public Integer maTang;
}

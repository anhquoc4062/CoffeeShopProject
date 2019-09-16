package fpo.thanh.coffeeshop.domain.Room.RoomDAO;

import androidx.room.Dao;
import androidx.room.Insert;
import androidx.room.Query;

import fpo.thanh.coffeeshop.domain.Room.RoomModel.HoaDon;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.LoaiThucDon;

import static androidx.room.OnConflictStrategy.REPLACE;

@Dao
public interface LoaiThucDonDAO {
    @Insert(onConflict = REPLACE)
    public void insertTang(LoaiThucDon loaiThucDon);
    @Query("SELECT COUNT(*) FROM LoaiThucDon")
    public int getSizeLoaiThucDon();
    @Query("DELETE FROM LoaiThucDon")
    public void deleteAllLoaiThucDon();

}

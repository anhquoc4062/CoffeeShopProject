package fpo.thanh.coffeeshop.domain.Room.RoomDAO;

import androidx.room.Dao;
import androidx.room.Insert;
import androidx.room.Query;

import fpo.thanh.coffeeshop.domain.Room.RoomModel.HoaDon;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.Tang;

import static androidx.room.OnConflictStrategy.REPLACE;

@Dao
public interface HoaDonDAO {
    @Insert(onConflict = REPLACE)
    public void insertHoaDon(HoaDon hoaDon);
    @Query("SELECT COUNT(*) FROM HoaDon")
    public int getSizeHoaDon();
    @Query("DELETE FROM HoaDon")
    public void deleteAllHoaDon();
}

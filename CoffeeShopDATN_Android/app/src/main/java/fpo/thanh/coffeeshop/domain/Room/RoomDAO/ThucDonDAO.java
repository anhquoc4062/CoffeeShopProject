package fpo.thanh.coffeeshop.domain.Room.RoomDAO;

import androidx.room.Dao;
import androidx.room.Insert;
import androidx.room.Query;

import java.util.List;

import fpo.thanh.coffeeshop.domain.Room.RoomModel.HoaDon;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.ThucDon;

import static androidx.room.OnConflictStrategy.REPLACE;

@Dao
public interface ThucDonDAO {
    @Insert(onConflict = REPLACE)
    public void insertTang(ThucDon thucDon);
    @Query("SELECT COUNT(*) FROM ThucDon")
    public int getSizeThucDon();
    @Query("DELETE FROM ThucDon")
    public void deleteAllThucDon();
    @Query("SELECT * FROM THUCDON")
    public List<ThucDon> getAllThucDon();

}

package fpo.thanh.coffeeshop.domain.Room.RoomDAO;

import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.Query;

import java.util.List;

import fpo.thanh.coffeeshop.domain.Room.RoomModel.BanAn;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.HoaDon;

import static androidx.room.OnConflictStrategy.REPLACE;

@Dao
public interface BanAnDAO {
    @Insert(onConflict = REPLACE)
    public void insertTang(BanAn banAn);
    @Query("SELECT COUNT(*) FROM BanAn")
    public int getSizeBanAn();
    @Query("DELETE FROM BanAn")
    public void deleteAllBanAn();
    @Query("SELECT * FROM BanAn")
    public List<BanAn> getListBanAn();
}

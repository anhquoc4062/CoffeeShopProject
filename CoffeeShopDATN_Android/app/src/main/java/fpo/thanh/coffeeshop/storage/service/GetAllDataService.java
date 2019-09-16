package fpo.thanh.coffeeshop.storage.service;

import fpo.thanh.coffeeshop.shareModel.ResultModel;
import retrofit2.Call;
import retrofit2.http.POST;

public interface GetAllDataService {
    @POST("/api/getdata")
    Call<ResultModel> getAllData();
}

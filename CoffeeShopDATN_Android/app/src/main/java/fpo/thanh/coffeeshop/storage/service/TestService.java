package fpo.thanh.coffeeshop.storage.service;


import fpo.thanh.coffeeshop.shareModel.TestModel;
import retrofit2.Call;
import retrofit2.http.Header;
import retrofit2.http.POST;

public interface TestService {
    @POST("/system/decode")
    Call<TestModel> getTest(@Header("x-access-token") String token);
}

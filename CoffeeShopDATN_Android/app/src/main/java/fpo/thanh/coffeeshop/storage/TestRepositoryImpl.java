package fpo.thanh.coffeeshop.storage;

import android.content.Context;

import java.io.IOException;

import fpo.thanh.coffeeshop.domain.repository.TestRepository;
import fpo.thanh.coffeeshop.shareModel.TestModel;
import fpo.thanh.coffeeshop.storage.network.RestClient;
import fpo.thanh.coffeeshop.storage.service.TestService;
import retrofit2.Response;

public class TestRepositoryImpl implements TestRepository {
    Context context;
    public TestRepositoryImpl(Context context){
        this.context=context;
    }
    @Override
    public TestModel getTest(String token) {
        TestService service= RestClient.createService(TestService.class);
        try {

            Response<TestModel> response=service.getTest(token).execute();

            if(response.isSuccessful()){
                return response.body();
            }

        } catch (IOException e) {

        }
        return null;
    }
}

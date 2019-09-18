package fpo.thanh.coffeeshop.domain.repository.Impl;

import fpo.thanh.coffeeshop.domain.repository.GetAllDataRepository;
import fpo.thanh.coffeeshop.shareModel.ResultModel;
import fpo.thanh.coffeeshop.storage.network.RestClient;
import fpo.thanh.coffeeshop.storage.service.GetAllDataService;
import retrofit2.Response;

public class GetAllDataRepositoryImpl implements GetAllDataRepository {
    @Override
    public ResultModel getData() {
        GetAllDataService service= RestClient.createService(GetAllDataService.class);
        try{
            Response<ResultModel> response=service.getAllData().execute();
            if(response.isSuccessful()){
                return response.body();
            }


        }catch (Exception e){
            e.printStackTrace();
        }
        return new ResultModel();
    }
}

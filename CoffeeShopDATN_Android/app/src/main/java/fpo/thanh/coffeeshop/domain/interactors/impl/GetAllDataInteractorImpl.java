package fpo.thanh.coffeeshop.domain.interactors.impl;

import fpo.thanh.coffeeshop.domain.executor.Executor;
import fpo.thanh.coffeeshop.domain.executor.MainThread;
import fpo.thanh.coffeeshop.domain.interactors.GetAllDataInteractor;
import fpo.thanh.coffeeshop.domain.interactors.base.AbstractInteractor;
import fpo.thanh.coffeeshop.domain.repository.GetAllDataRepository;
import fpo.thanh.coffeeshop.shareModel.ResultModel;

public class GetAllDataInteractorImpl extends AbstractInteractor implements GetAllDataInteractor {
    private final Callback callback;
    private final GetAllDataRepository repository;

    public GetAllDataInteractorImpl(Executor threadExecutor, MainThread mainThread, Callback callback, GetAllDataRepository repository) {
        super(threadExecutor, mainThread);
        this.callback = callback;
        this.repository = repository;
    }

    @Override
    public void run() {
        final ResultModel result=repository.getData();
        mMainThread.post(()->callback.onFinish(result));
    }
}

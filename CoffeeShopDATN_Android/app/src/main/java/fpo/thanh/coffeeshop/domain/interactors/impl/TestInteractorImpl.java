package fpo.thanh.coffeeshop.domain.interactors.impl;


import fpo.thanh.coffeeshop.domain.executor.Executor;
import fpo.thanh.coffeeshop.domain.executor.MainThread;
import fpo.thanh.coffeeshop.domain.interactors.TestInteractor;
import fpo.thanh.coffeeshop.domain.interactors.base.AbstractInteractor;
import fpo.thanh.coffeeshop.domain.repository.TestRepository;
import fpo.thanh.coffeeshop.shareModel.TestModel;

public class TestInteractorImpl extends AbstractInteractor implements TestInteractor {
    private final Callback callback;
    private final TestRepository repository;
    private final String token;

    public TestInteractorImpl(Executor threadExecutor, MainThread mainThread, Callback callback, TestRepository repository,
                              String token) {
        super(threadExecutor, mainThread);
        this.callback = callback;
        this.repository = repository;
        this.token = token;
    }

    @Override
    public void run() {
        final TestModel result=repository.getTest(token);
        mMainThread.post(new Runnable() {
            @Override
            public void run() {
                callback.onFinish(result);
            }
        });

    }
}

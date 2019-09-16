package fpo.thanh.coffeeshop.domain.repository;

import fpo.thanh.coffeeshop.shareModel.TestModel;

public interface TestRepository {
    TestModel getTest(String token);
}

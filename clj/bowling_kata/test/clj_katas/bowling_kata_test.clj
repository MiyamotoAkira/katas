(ns  clj-katas.bowling-kata-test
  (:require [clj-katas.bowling-kata :as sut]
            [clojure.test :refer :all]))

(deftest single-roll
  (testing "Not spare"
    (is (= 0 (sut/single-roll "-")))
    (is (= 1 (sut/single-roll "1")))
    (is (= 2 (sut/single-roll "2")))
    (is (= 3 (sut/single-roll "3")))
    (is (= 4 (sut/single-roll "4")))
    (is (= 5 (sut/single-roll "5")))
    (is (= 6 (sut/single-roll "6")))
    (is (= 7 (sut/single-roll "7")))
    (is (= 8 (sut/single-roll "8")))
    (is (= 9 (sut/single-roll "9")))
    (is (= 10 (sut/single-roll "X"))))
  (testing "Spare"
    (is (= 5 (sut/single-roll "/" :previous-score "5")))
    (is (= 8 (sut/single-roll "/" :previous-score "2")))
    (is (= 3 (sut/single-roll "/" :previous-score "7")))))

(deftest roll
  (testing "two singles"
    (is (= 9 (sut/roll "45"))))
  (testing "spare"
    (is (= 12 (sut/roll "5/1"))))
  (testing "strike with singles"
    (is (= 24 (sut/roll "X34"))))
  (testing "strike with strike and singles"
    (is (= 58 (sut/roll "XX3456")))))

(deftest roll-is-strike?
  (is (sut/roll-is-strike? "X"))
  (is (not (sut/roll-is-strike? "/")))
  (is (not (sut/roll-is-strike? "3"))))

(deftest roll-is-spare?
  (is (sut/roll-is-spare? "/"))
  (is (not (sut/roll-is-spare? "X")))
  (is (not (sut/roll-is-spare? "3"))))

(deftest roll-is-strike-or-spare?
  (is (sut/roll-is-strike-or-spare? "X"))
  (is (sut/roll-is-strike-or-spare? "/"))
  (is (not (sut/roll-is-strike-or-spare? "3"))))

(deftest roll-with-last-two
  (testing "number with strike/spare and strike"
    (is (= 15) (sut/roll-with-last-two 5 "X" true)))
  (testing "number with nothing and strike"
    (is (= 10 (sut/roll-with-last-two 5 "3" true))))
  (testing "number with strike/spare and nothing"
    (is (= 10 (sut/roll-with-last-two 5 "X" false))))
  (testing "number with nothing and nothing"
    (is (= 5 (sut/roll-with-last-two 5 3 false)))))

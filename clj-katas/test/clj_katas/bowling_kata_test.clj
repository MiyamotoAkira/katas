(ns clj-katas.bowling-kata-test
  (:require [clj-katas.bowling-kata :as sut]
            [clojure.test :refer :all]))

(deftest single-roll
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
  (is (= 10 (sut/single-roll "/")))
  (is (= 10 (sut/single-roll "X"))))

(deftest roll
  (is (= 9 (sut/roll "45"))))

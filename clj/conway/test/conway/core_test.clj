(ns conway.core-test
  (:require [clojure.test :refer :all]
            [conway.core :refer :all]))

(deftest neighbours-test
  (testing "locate correct neighbours 0,0"
    (let [expected [[-1 -1] [-1  0] [-1  1] [0  -1] [0  1] [1  -1] [1  0] [1  1]]]
      (is (= expected (get-neighbours [0 0])))))
  (testing "locate correct neighbours 2,1"
    (let [expected [[1 0] [1  1] [1  2] [2  0] [2  2] [3  -0] [3  1] [3  2]]]
      (is (= expected (get-neighbours [2 1]))))))


(deftest is-neighbour-test
  (testing "cell is neighbour"
    (is (is-neighbour [2 1] [3 0])))
  (testing "cell is not neighbour"
    (is (not (is-neighbour [2 1] [4 5])))))


(deftest rule-alive-test
  (testing "size 2"
    (is (rule-alive 2)))
  (testing "size 3"
    (is (rule-alive 3)))
  (testing "size 4"
    (is (not (rule-alive 4))))
  (testing "size 1"
    (is (not (rule-alive 1)))))


(deftest find-alive-neighbours-test
  (testing "No alive neighbours"
    (is (= [] (find-alive-neighbours [0 0] [[3 3] [4 5]]))))
  (testing "Find two  neighbours"
    (is (= [[0 1] [1 1]] (find-alive-neighbours [0 0] [[0 1] [3 3] [1 1] [4 5]])))))


(deftest dying
  (testing "Single cell"
    (is (not (new-cell-status [0 0] [[3 3] [0 1] [5 4]]))))
  (testing "Four Cells"
    (is (not (new-cell-status [0 0] [[1 1] [1 0] [-1 -1] [-1 0]])))))


(deftest staying-alive
  (testing "Two cells"
    (is (new-cell-status [0 0] [[1 0] [2 4] [-1 0] [5 6]])))
  (testing "Three cells"
    (is (new-cell-status [0 0] [[1 0] [2 4] [-1 0] [5 6] [1 1]]))))


(deftest rule-born-tests
  (testing "There are three neighbours"
    (is (rule-born 3)))
  (testing "There are two neighbours"
    (is (not (rule-born 2))))
  (testing "There are four neighbours"
    (is (not (rule-born 4)))))


(deftest find-all-neighbours-tests
  (testing "Empty Universe"
    (is (= #{} (find-all-neighbours []))))  
  (testing "Single cell in universe"
    (is (= #{[0 0] [0 1] [0 2] [1 0] [1 2] [2 0] [2 1] [2 2]} (find-all-neighbours [[1 1]]))))
  (testing "Three cells in universe"
    (is (= #{[0 0] [0 1] [0 2] [1 0] [1 2] [2 0] [2 1] [2 2] [-1 0] [-1 -1] [0 -1] [-1 1] [1 -1] [1 1] [2 -1]} (find-all-neighbours [[1 1] [0 0] [1 0]])))))


(deftest skip-alive-tests
  (testing "Alives are eliminated"
    (is (= (set [[0 1] [0 2] [1 2] [2 0] [2 1] [2 2] [-1 0] [-1 -1] [0 -1] [-1 1] [1 -1] [2 -1]]) (skip-alive #{[0 0] [0 1] [0 2] [1 0] [1 2] [2 0] [2 1] [2 2] [-1 0] [-1 -1] [0 -1] [-1 1] [1 -1] [1 1] [2 -1]}  [[1 1] [0 0] [1 0]])))))


(deftest born
  (testing "Dead cell with three neighbours"
    (is (= '([1 1]) (find-new-borns [[1 0] [0 1] [0 0] [5 5]]))))

  (testing "Dead cell with two neighbours"
    (is (= '() (find-new-borns [[1 0] [0 0] [5 5]]))))

  (testing "Dead cell with four neighbours"
    (is (= '() (find-new-borns [[1 0] [0 1] [2 1] [0 0] [5 5]])))))

(deftest skip-alive-tests
  (testing "With single alive cell returns all neighbours"
    (is (= #{[1 0] [-1 0] [1 1] [-1 -1] [1 -1] [-1 1] [0 -1] [0 1]} (skip-alive (get-neighbours [0 0]) [[0 0]]))))

  (testing "Eliminates the two alive cells"
    (is (= #{[1 0] [-1 0] [1 -1] [-1 1] [0 -1] [0 1]} (skip-alive (get-neighbours [0 0]) [ [1 1] [-1 -1]])))))

(deftest single-pass
  (testing "Block still life"
    (is (= [[0 0] [0 1] [1 0] [1 1]] (conway-steps 1 [[0 0] [0 1] [1 0] [1 1]]))))
  (testing "Simple Oscillator one step"
    (is (= #{[0 0] [0 1] [0 -1]} (set (conway-steps 1 [[0 0] [1 0] [-1 0]])))))
  (testing "Simple glider creates the next step"
    (= [] (conway-steps 1 [[0 0] [0 1] [1 1] [2 1]]))))

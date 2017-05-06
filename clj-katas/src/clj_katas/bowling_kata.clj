(ns clj-katas.bowling-kata)

(defn single-roll [input]
  (let [roll (str input)]
    (cond
      (= "-" roll) 0
      (= "/" roll) 10
      (= "X" roll) 10
      :else (Integer. roll))))

(defn roll [score]
  (reduce + (map single-roll score)))

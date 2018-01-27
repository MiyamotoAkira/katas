(ns clj-katas.bowling-kata)

(defn single-roll
  [input & {:keys [previous-score] :or {previous-score "-"}}]
  (let [roll (str input)]
    (cond
      (= "-" roll) 0
      (= "/" roll) (- 10 (Integer. (str previous-score)))
      (= "X" roll) 10
      :else (Integer. roll))))

(defn roll-is-strike? [roll] (= (str roll) "X"))
(defn roll-is-spare? [roll] (= (str roll) "/"))
(defn roll-is-strike-or-spare? [roll] (or (roll-is-strike? roll) (roll-is-spare? roll)))

(defn roll-with-last-two
  [input previous-score previous-previous-strike?]
  (let [multiplier 1
        multiplier (if (roll-is-strike-or-spare? previous-score) (inc multiplier)  multiplier)
        multiplier (if previous-previous-strike? (inc multiplier)  multiplier)]
    (* (single-roll input :previous-score previous-score) multiplier)))

(defn roll-with-previous
  [[first & last] previous-score previous-previous-strike? total]
  (if (= last nil)
    (+ total (roll-with-last-two first previous-score previous-previous-strike?))
    (recur
     last
     first
     (roll-is-strike? previous-score)
     (+ total (roll-with-last-two first previous-score previous-previous-strike?)))))


(defn roll [score]
  (roll-with-previous score "-" false 0))

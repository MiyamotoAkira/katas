(ns conway.core)

(def neighbours [[-1 -1] [-1 0] [-1 1] [0 -1] [0 1] [1 -1] [1 0] [1 1]])

(defn add-for-neighbour
  [cell neighbour]
  (vector (+ (first cell) (first neighbour)) (+ (second cell)  (second neighbour))))


(defn get-neighbours
  [cell]
  (map #(add-for-neighbour cell %) neighbours))

(defn get-neighbours-s
  [cell]
  (let [add-for (partial add-for-neighbour cell)]
    (map add-for neighbours)))

(defn get-neighbours-r
  [cell]
  (loop [neighbour (first neighbours)
         rest-n (rest neighbours)
         result []]
    (if-not neighbour
      result
      (recur
       (first rest-n)
       (rest rest-n)
       (conj result (add-for-neighbour cell neighbour))))))

(defn rule-alive [size]
  (or (= 2 size) (= 3 size)))

(defn rule-born [neighbours]
  (= 3 neighbours))

(defn is-neighbour?
  [cell possible]
  (some #{possible} (get-neighbours cell)))

(defn find-alive-neighbours
  [universe cell]
  (filter #(is-neighbour? cell %) universe))

(defn new-cell-status
  [universe cell]
  (-> (find-alive-neighbours universe cell)
      count
      rule-alive))

(def is-alive? (comp rule-alive count find-alive-neighbours))

(defn new-cell-status-s
  [universe cell] 
  (is-alive? cell universe))

(defn find-all-neighbours
  [universe]
  (set (mapcat identity (map #(get-neighbours %) universe))))

(defn skip-alive
  [selected universe]
  (set (filter #(not ((set universe) %)) selected)))

(defn is-newborn?
  [universe cell]
  (rule-born (count (find-alive-neighbours universe cell))))


(defn all-dead-cells
  [universe]
  (skip-alive (find-all-neighbours universe) universe))


(defn find-new-borns
  [universe]
  (filter #(is-newborn? universe %) (all-dead-cells  universe)))


(defn find-new-borns-i
  [universe]
  (-> universe
      find-all-neighbours))

(defn get-staying-alive
  [universe]
  (filter #(new-cell-status universe %) universe))

(defn conway-steps
  [steps universe]
  (concat (find-new-borns universe) (filter #(new-cell-status universe %) universe)))

(defn conway-step
  [universe]
  (concat (find-new-borns universe) (get-staying-alive universe)))

(defn conway-step-l
  [universe]
  (let [alive (get-staying-alive universe)
        new-borns (find-new-borns universe)]
    (concat new-borns alive)))

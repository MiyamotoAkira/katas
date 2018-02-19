(ns conway.core)

(def neighbours [[-1 -1] [-1 0] [-1 1] [0 -1] [0 1] [1 -1] [1 0] [1 1]])

(defn get-neighbours
  [cell]
  (map #(vector (+ (first cell) (first %)) (+ (second cell)  (second %))) neighbours))

(defn rule-alive [size]
  (or (= 2 size) (= 3 size)))

(defn rule-born [neighbours]
  (= 3 neighbours))

(defn is-neighbour
  [cell possible]
  (some #{possible} (get-neighbours cell)))

(defn find-alive-neighbours
  [cell universe]
  (filter #(is-neighbour cell %) universe))

(defn new-cell-status
  [cell universe]
  (rule-alive (count (find-alive-neighbours cell universe))))

(defn find-all-neighbours
  [universe]
  (set (mapcat identity (map #(get-neighbours %) universe))))

(defn skip-alive
  [selected universe]
  (set (filter #(not ((set universe) %)) selected)))

(defn find-new-borns
  [universe]
  (filter #(rule-born (count (find-alive-neighbours % universe))) (skip-alive (find-all-neighbours universe) universe)))

(defn conway-steps
  [steps universe]
  (concat (find-new-borns universe) (filter #(new-cell-status % universe) universe)))

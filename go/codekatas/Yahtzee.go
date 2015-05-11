package codekatas

type PlayCall int
const(
	ONES PlayCall = 0 + iota
	TWOS
	THREES
	FOURS
	FIVES
	SIXES
	SMALL
	LARGE
	FULL
	YAHTZEE
)

var plays = [...]string {
	"ONES",
	"TWOS",
	"THREES",
	"FOURS",
	"FIVES",
	"SIXES",
	"SMALL",
	"LARGE",
	"FULL",
	"YAHTZEE",
}

func (play PlayCall) String() string {
	 return plays[play]
}

func CalculateRoll(dice []int, play PlayCall) int {
	 return 0;
}
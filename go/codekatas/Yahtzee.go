package codekatas

type PlayCall int
const(
	ONES PlayCall = 0 + iota
	TWOS
	THREES
	FOURS
	FIVES
	SIXES
	PAIR
	TWOPAIR
	THREEKIND
	FOURKIND
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
	"PAIR",
	"TWOPAIR",
	"THREEKIND",
	"FOURKIND",
	"SMALL",
	"LARGE",
	"FULL",
	"YAHTZEE",
}

func (play PlayCall) String() string {
	 return plays[play]
}

func CalculateRoll(dice []int, play PlayCall) int {
	 switch play {
	 	case ONES, TWOS, THREES, FOURS, FIVES, SIXES:
			 return Numbers(dice, play)
		case PAIR:
			 return Pair(dice)
		case THREEKIND:
			 return Three(dice)
	 }

	 return 0
}

func Three(dice []int) int {
	 var values  = []int {0,0,0,0,0,0}
	 for _, die := range dice {
	 	 values[die -1] += 1
	 }

	 for die := 6; die > 0; die-- {
	 	 if values[die -1] > 2 {
		 	return die * 3
		 }
	 }

	 return 0
}

func Pair(dice []int) int {
	 var values  = []int {0,0,0,0,0,0}
	 for _, die := range dice {
	 	 values[die -1] += 1
	 }

	 for die := 6; die > 0; die-- {
	 	 if values[die -1] > 1 {
		 	return die * 2
		 }
	 }

	 return 0
}

func Numbers(dice []int, play PlayCall) int {
	 var valuetocheck int
	 switch play {
	 	case ONES:
			 valuetocheck = 1
		case TWOS:
			 valuetocheck = 2
		case THREES:
			 valuetocheck = 3
		case FOURS:
			 valuetocheck = 4
		case FIVES:
			 valuetocheck = 5
		case SIXES:
			 valuetocheck = 6
	 }
	 
	 total := 0
	 for _, value := range dice {
	 	 if value == valuetocheck {
		 	total += value
		 }
	 }
	 
	 return total;
}
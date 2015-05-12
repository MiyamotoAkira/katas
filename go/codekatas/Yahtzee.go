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
		case FOURKIND:
			 return Four(dice)
		case YAHTZEE:
			 return Yahtzee(dice)
		case TWOPAIR:
			 return TwoPair(dice)
		case FULL:
			 return Full(dice)
	 }

	 return 0
}

func Full(dice []int) int {
	 var values  = []int {0,0,0,0,0,0}
	 for _, die := range dice {
	 	 values[die -1] += 1
	 }

	 three := 0
	 two := 0
	 for die, counter := range values {
	 	 if counter == 2 {
		 	two = die + 1
		 }
		 if counter == 3 {
		 	three = die + 1
		 }
	 }

	 if three != 0 && two != 0 {
	 	return (three * 3) + (two * 2)
	 }

	 return 0
}

func TwoPair(dice []int) int {
	 var values  = []int {0,0,0,0,0,0}
	 for _, die := range dice {
	 	 values[die -1] += 1
	 }

	 var pairsfound = 0
	 var pairs = []int {0,0}
	 for die := 6; die > 0 && pairsfound < 2; die-- {
	 	 if values[die -1] > (1) {
		 	pairs[pairsfound] = die
			pairsfound++
		 }
	 }

	 if pairsfound == 2 {
	 	return (pairs[0] * 2) + (pairs[1] *2)
	 }
	 
	 return 0
}

func Yahtzee(dice []int) int {
	for index, die := range dice {
	 	if index > 0 && die != dice[index -1] {
		   return 0
		}
	}

	return 50
}

func Four(dice []int) int {
	 return MultipleMatches(dice, 4)
}

func Three(dice []int) int {
	 return MultipleMatches(dice, 3)
}

func Pair(dice []int) int {
	 return MultipleMatches(dice, 2)
}

func MultipleMatches(dice []int, kind int) int {
	 var values  = []int {0,0,0,0,0,0}
	 for _, die := range dice {
	 	 values[die -1] += 1
	 }

	 for die := 6; die > 0; die-- {
	 	 if values[die -1] > (kind -1) {
		 	return die * kind
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
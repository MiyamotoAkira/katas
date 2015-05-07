package codekatas

import (
	   "strconv"
	   "strings"
	   )

func FizzBuzzSingle(number int) string {
	 switch {
	 	case number%3 == 0 && number%5 == 0:
			 return "FizzBuzz"
		case number%3 == 0:
			 return "Fizz"
		case number%5 == 0:
			 return "Buzz"
	 }
	 
	 return strconv.Itoa(number)
}

func FizzBuzz(number int) string {
	 temp := []string{}
	 for counter := 1; counter <= number; counter ++ {
	 	 temp = append(temp, FizzBuzzSingle(counter))
	 }

	 return strings.Join(temp, " " ) 
}
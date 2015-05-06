package katatests

import (
	   "testing"
	   "github.com/miyamotoakira/katas/go/codekatas"
	   )

type testnumbers struct {
	 number int
	 expected string
}

var testSingles = []testnumbers {
	{1,"1"},
	{2,"2"},
	{3,"Fizz"},
	{4,"4"},
	{5,"Buzz"},
	{6,"Fizz"},
	{7,"7"},
	{15,"FizzBuzz"},
}

func TestSingleDigitOutput(t *testing.T) {
	 for _, pair  := range testSingles {
	 	 result := codekatas.FizzBuzzSingle(pair.number)
		 if result != pair.expected {
		 	t.Error("For", pair.number, "it is expected", pair.expected, "got", result, )
		 }
	 }
}
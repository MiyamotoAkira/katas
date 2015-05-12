package katatests

import (
	"github.com/miyamotoakira/katas/go/codekatas"
	"testing"
)

type testnumbers struct {
	number   int
	expected string
}

var testSingles = []testnumbers{
	{1, "1"},
	{2, "2"},
	{3, "Fizz"},
	{4, "4"},
	{5, "Buzz"},
	{6, "Fizz"},
	{7, "7"},
	{15, "FizzBuzz"},
}

func TestSingleDigitOutput(t *testing.T) {
	for _, pair := range testSingles {
		result := codekatas.FizzBuzzSingle(pair.number)
		if result != pair.expected {
			t.Error("For", pair.number, "it is expected", pair.expected, "got", result)
		}
	}
}

func TestAllDigitsOutput(t *testing.T) {
	result := codekatas.FizzBuzz(20)
	expected := "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz"
	if result != expected {
		t.Error("The output of", 20, "was expected as", expected, "but was", result)
	}
}

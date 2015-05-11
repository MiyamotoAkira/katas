package codekatas

func ConvertOnesToNumerals(number int) string {
	 switch number {
	 	case 0:
			 return ""
		case 1:
			 return "I"
		case 2:
			 return "II"
		case 3:
			 return "III"
		case 4:
			 return "IV"
		case 5:
			 return "V"
		case 6:
			 return "VI"
		case 7:
			 return "VII"
		case 8:
			 return "VIII"
		case 9:
			 return "IX"
	 }

	 return "NoNo"
}

func ConvertTensToNumerals(number int) string {
	 switch number {
	 	case 0:
			 return ""
	 	case 1:
			 return "X"
		case 2:
			 return "XX"
		case 3:
			 return "XXX"
		case 4:
			 return "XL"
		case 5:
			 return "L"
		case 6:
			 return "LX"
		case 7:
			 return "LXX"
		case 8:
			 return "LXXX"
		case 9:
			 return "XC"
	 }

	 return "NoNo"
}

func ConvertHundredsToNumerals(number int) string {
	 switch number {
	 	case 0:
			 return ""
	 	case 1:
			 return "C"
		case 2:
			 return "CC"
		case 3:
			 return "CCC"
		case 4:
			 return "CD"
		case 5:
			 return "D"
		case 6:
			 return "DC"
		case 7:
			 return "DCC"
		case 8:
			 return "DCCC"
		case 9:
			 return "CM"
	 }

	 return "NoNo"
}


func ConvertThousandsToNumerals(number int) string {
	 switch number {
	 	case 0:
			 return ""
	 	case 1:
			 return "M"
		case 2:
			 return "MM"
		case 3:
			 return "MMM"
	 }

	 return "NoNo"
}

func ConvertToRomans(number int) string {
	 ones := number % 10
	 tens := number / 10 % 10
	 hundreds := number / 100 % 10
	 thousands := number / 1000 % 10
	 onesNumeral := ConvertOnesToNumerals(ones)
	 tensNumeral := ConvertTensToNumerals(tens)
	 hundredsNumeral := ConvertHundredsToNumerals(hundreds)
	 thousandsNumeral := ConvertThousandsToNumerals(thousands)
	 return thousandsNumeral + hundredsNumeral + tensNumeral + onesNumeral
}

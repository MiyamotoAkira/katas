def convert_ones(number):
    return convert_digit_to_roman(number, "I", "V", "X")

def convert_tens(number):
    return convert_digit_to_roman(number, "X", "L", "C")

def convert_hundreds(number):
    return convert_digit_to_roman(number, "C", "D", "M")

def convert_thousands(number):
    return convert_digit_to_roman(number, "M", "What?", "I Shouldn't Be Here")

def convert_digit_to_roman(number, unit, half, over):
    if number == 1:
        return unit
    elif number == 2:
        return unit + unit
    elif number == 3:
        return unit + unit + unit
    elif number == 4:
        return unit + half
    elif number == 5:
        return half
    elif number == 6:
        return half + unit
    elif number == 7:
        return half + unit + unit
    elif number == 8:
        return half + unit + unit + unit
    elif number == 9:
        return unit + over

    return "NoNo"

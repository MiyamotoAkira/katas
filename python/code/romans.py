def convert_ones(number):
    if number == 1:
        return "I"
    elif number == 2:
        return "II"
    elif number == 3:
        return "III"
    elif number == 4:
        return "IV"
    elif number == 5:
        return "V"
    elif number == 6:
        return "VI"
    elif number == 7:
        return "VII"
    elif number == 8:
        return "VIII"
    elif number == 9:
        return "IX"
    
    return "NonNo"


def convert_tens(number):
    if number == 1:
        return "X"
    elif number == 2:
        return "XX"
    elif number == 3:
        return "XXX"
    elif number == 4:
        return "XL"
    elif number == 5:
        return "L"
    elif number == 6:
        return "LX"
    elif number == 7:
        return "LXX"
    elif number == 8:
        return "LXXX"
    elif number == 9:
        return "XC"

    return "NoNo"

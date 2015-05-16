def single_one(number):
    divBy3 = number % 3 == 0
    divBy5 = number % 5 == 0

    if (divBy3 and divBy5):
        return "FizzBuzz"
    
    if (divBy3):
        return "Fizz"

    if (divBy5):
        return "Buzz"
    
    return str(number)

def fizz_buzz(limit):
    literals = []
    for number in range(1, limit+1):
        literals.append(single_one(number))

    return ' '.join(literals)

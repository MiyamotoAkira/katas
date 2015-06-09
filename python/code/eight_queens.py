class EightQueen():
    '''This class resolves the Eight Queens problem. The problem stipulates to put 8 queen chess pieces on a chess board without any of them attacking another of the other queens'''
    
    def __init__(self):
        self.table = dict()
        self.board = {(row,column) for row in range(1,9) for column in range(1,9)}
        
    def add_queen_to_square(self, square):
        row, column = square
        if row not in self.table:
            self.table[row] = column
            return True
        else:
            return False

    def eliminate_possibilities(self, square):
        new_row, new_column = square
        self.board = {(row, column) for (row,column) in self.board if row != new_row}
        self.board = {(row, column) for (row,column) in self.board if column != new_column}
        while new_row < 8 and new_column < 8:
            new_row += 1
            new_column += 1
            if (new_row, new_column) in self.board:
                self.board.remove((new_row, new_column))

        while new_row < 8 and new_column > 1:
            new_row += 1
            new_column -= 1
            if (new_row, new_column) in self.board:
                self.board.remove((new_row, new_column))
                
    def get_table(self):
        return self.table

    def remove_queen(self, square):
        row, column = square
        del self.table[row]

    def find_next_square(self):
        sorted_list = sorted(self.table.keys())
        next_row = sorted_list[-1] + 1
        print (next_row)
        for square in self.board:
            print (square)
        possibilities = [(row, column) for (row, column) in self.board if row == next_row]
        print (possibilities)
        
        sorted_possibilities = sorted(possibilities)
        return sorted_possibilities[0]
        
        # generate a set of all possible options on the board
        # each time anew one is added, delete the current one and delete all diagonals
        # actually, only need to look at diagonals in which the row grows. The others get deleted
        # anyway
        # get first option available on a given row


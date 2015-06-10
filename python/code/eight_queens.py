class EightQueen():
    '''This class resolves the Eight Queens problem. The problem stipulates to put 8 queen chess pieces on a chess board without any of them attacking another of the other queens.
    This solution doesn't use recursion and keeps the cmplete state of the board as history to be able to undo placements. So on that regards is O(1) to undo speed wise but O(n) on space usage
    '''
    
    def __init__(self):
        self.table = dict()
        self.board = {(row,column) for row in range(1,9) for column in range(1,9)}
        self.history = list()
        
    def add_queen_to_square(self, square):
        row, column = square
        if row not in self.table:
            self.history.append(dict(self.table))
            self.table[row] = column
            return True
        else:
            return False

    def eliminate_possibilities(self, square):
        self.history.append(set(self.board))
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
        possibilities = [(row, column) for (row, column) in self.board if row == next_row]
        
        sorted_possibilities = sorted(possibilities)
        return sorted_possibilities[0]
        
    def undo_last_queen(self):
        self.board = self.history.pop()
        self.table = self.history.pop()
        

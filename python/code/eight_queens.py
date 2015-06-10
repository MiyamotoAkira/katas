import pdb

class EightQueen():
    '''This class resolves the Eight Queens problem. The problem stipulates to put 8 queen chess pieces on a chess board without any of them attacking another of the other queens.
    This solution doesn't use recursion and keeps the cmplete state of the board as history to be able to undo placements. So on that regards is O(1) to undo speed wise but O(n) on space usage
    '''
    
    def __init__(self):
        self.initialize()
        
    def add_queen_to_square(self, square):
        row, column = square
        if row not in self.table:
            self.save_history()
            self.table[row] = column
            self.eliminate_possibilities(square)
            return True
        else:
            return False

    def save_history(self):
        self.history.append(dict(self.table))
        self.history.append(set(self.board))
        self.history.append(self.last_possibility)

    def eliminate_possibilities(self, square):
        new_row, new_column = square
        self.board = {(row, column) for (row,column) in self.board if row != new_row}
        self.board = {(row, column) for (row,column) in self.board if column != new_column}

        counter_row, counter_column = new_row, new_column
        while counter_row < 8 and counter_column < 8:
            counter_row += 1
            counter_column += 1
            if (counter_row, counter_column) in self.board:
                self.board.remove((counter_row, counter_column))

        counter_row, counter_column = new_row, new_column
        while counter_row < 8 and counter_column > 1:
            counter_row += 1
            counter_column -= 1
            if (counter_row, counter_column) in self.board:
                self.board.remove((counter_row, counter_column))
                
    def get_table(self):
        return self.table

    def remove_queen(self, square):
        row, column = square
        del self.table[row]

    def setup_possibilities(self):
        sorted_list = sorted(self.table.keys())
        if len(sorted_list) > 0:
            next_row = sorted_list[-1] + 1
        else:
            next_row = 1

        possibilities = [(row, column) for (row, column) in self.board if row == next_row]
        
        self.sorted_possibilities = sorted(possibilities)
        
    def undo_last_queen(self):
        self.last_possibility = self.history.pop()
        self.board = self.history.pop()
        self.table = self.history.pop()

    def find_next_square(self):
        self.last_possibility += 1
        if self.are_there_possibilities_left():
            return self.sorted_possibilities[self.last_possibility]
        else:
            return None

    def are_there_possibilities_left(self):
        return len(self.sorted_possibilities) > self.last_possibility
        
    def initialize(self):
        self.table = dict()
        self.board = {(row,column) for row in range(1,9) for column in range(1,9)}
        self.history = list()
        self.last_possibility = -1
        
    def resolve_one(self):
        self.initialize()
        while len(self.table) < 8:
            self.setup_possibilities()
            square = None
            while square is None and self.are_there_possibilities_left():
                square = self.find_next_square()
            if square is not None:
                self.add_queen_to_square(square)
                self.last_possibility = -1
            else:
                if len(self.table) > 0:
                    self.undo_last_queen()
                else:
                    return "No solution found"

        return self.table

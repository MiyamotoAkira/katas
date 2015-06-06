class EightQueen():
    def __init__(self):
        self.table = dict()
        
    def add_queen_to_square(self, square):
        row, column = square
        if row not in self.table:
            self.table[row] = column
            return True
        else:
            return False

    def get_table(self):
        return self.table


    def remove_queen(self, square):
        row, column = square
        del self.table[row]

    def find_next_square(self):
        sortedList = self.table.keys().sort()


PLAYER_MOVE = 'o'
COMPUTER_MOVE = 'x'
EMPTY_CELL = ' '


class TicTacToeBoard:
    def __init__(self, size):
        self.size = size
        self.has_winner = False
        self.state = [EMPTY_CELL] * size**2

    def empty_cells(self):
        for (i, value) in enumerate(self.state):
            if value == EMPTY_CELL:
                yield i

    def copy(self):
        board = TicTacToeBoard(size)
        for (i, value) in enumerate(self.state):
            board.update(i, value)
        return board

    def can_continue(self):
        if self.has_winner:
            return False

        return EMPTY_CELL in self.state

    def update(self, position, fill):
        self.state[position] = fill
        self.has_winner = self.find_winner(position, fill)

    def find_winner(self, position, fill):
        pattern = fill * self.size
        row = position // self.size
        column = position % self.size

        def check(lo, hi, stride):
            return ''.join(self.state[lo: hi:stride]).find(pattern) >= 0

        def check_row():
            lo = row * self.size
            hi = lo + self.size
            return check(lo, hi, 1)

        def check_column():
            return check(column, len(self.state), self.size)

        def check_direct_diagonal():
            return check(0, len(self.state), self.size + 1)

        def check_opposite_diagonal():
            lo = self.size - 1
            hi = len(self.state) - lo
            return check(lo, hi, lo)

        if check_row():
            return True

        if check_column():
            return True

        if check_direct_diagonal():
            return True

        if check_opposite_diagonal():
            return True

        return False

    def __str__(self):
        rows = {}
        for i in range(len(self.state)):
            key = i // self.size
            rows.setdefault(key, [])
            rows[key].append(self.state[i])

        res = ''
        for v in rows.values():
            res += '|'
            res += '|'.join(v)
            res += '|'
            res += '\n'
        return res


class TicTacToeMinMaxSolver:
    def __init__(self):
        self.mem = {}

    def next_move(self, board):
        min_score = 100
        min_index = None
        for x in board.empty_cells():
            cp = board.copy()
            cp.update(x, COMPUTER_MOVE)

            score = self.__evaluate(cp, PLAYER_MOVE)
            if score < min_score:
                min_score = score
                min_index = x

        return min_index

    def __evaluate(self, board, move):
        if not board.can_continue():
            return self.__score(board, move)

        key = (move, str(board.state))
        if key in self.mem:
            print(key, self.mem[key])
            return self.mem[key]

        values = []
        for x in board.empty_cells():
            cp = board.copy()
            cp.update(x, move)
            next_move = PLAYER_MOVE if move == COMPUTER_MOVE else COMPUTER_MOVE
            values.append(self.__evaluate(cp, next_move))

        if move == PLAYER_MOVE:
            value = min(values)
        else:
            value = max(values)

        self.mem[key] = value
        return self.mem[key]

    def __score(self, board, move):
        if board.has_winner:
            if move == PLAYER_MOVE:
                return -10
            else:
                return 10
        else:
            return 0


class TicTacToeProbSolver:
    def next_move(self, board):
        return 0


if __name__ == '__main__':
    size = int(input('Enter field size:'))

    board = TicTacToeBoard(size)
    # computer_player = TicTacToeMinMaxSolver()
    computer_player = TicTacToeProbSolver()

    def check_board(board, winner):
        if not board.can_continue():
            print(board)
            if board.has_winner:
                print('Winner is {}'.format(winner))
            else:
                print("It's a draw!")
            return True
        return False

    while True:
        player_position = int(input("Enter position:"))
        board.update(player_position - 1, PLAYER_MOVE)
        if check_board(board, 'human player'):
            break

        '''
        player_position = int(input("Enter position:"))
        board.update(player_position - 1, COMPUTER_CHAR)
        if check_board(board, 'human player 2'):
            break
        '''

        computer_position = computer_player.next_move(board)
        board.update(computer_position, COMPUTER_MOVE)
        if check_board(board, 'computer player'):
            break

        print(board)

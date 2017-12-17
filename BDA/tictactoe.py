from joblib import Parallel, delayed
import multiprocessing
import time

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


class HumanPlayer:
    def __str__(self):
        return 'human player'

    def next_move(self, board):
        return int(input("Enter position:")) - 1


class MinMaxPlayer:
    def __init__(self):
        self.mem = {}

    def __str__(self):
        return 'computer player'

    def next_move(self, board):
        max_score = None
        max_index = None
        for x in board.empty_cells():
            cp = board.copy()
            cp.update(x, COMPUTER_MOVE)

            score = self.evaluate(cp, COMPUTER_MOVE, PLAYER_MOVE, 1)
            if max_score is None or score > max_score:
                max_score = score
                max_index = x
        return max_index

    def evaluate(self, board, prev_move, next_move, depth):
        if not board.can_continue():
            return self.__score(board, prev_move)

        key = (next_move, str(board.state))
        if key in self.mem:
            return self.mem[key]

        summ = 0
        for x in board.empty_cells():
            cp = board.copy()
            cp.update(x, next_move)

            pm = next_move
            nm = PLAYER_MOVE if next_move == COMPUTER_MOVE else COMPUTER_MOVE
            summ += self.evaluate(cp, pm, nm, depth + 1)

        self.mem[key] = summ / depth
        return self.mem[key]

    def __score(self, board, move):
        if board.has_winner:
            if move == PLAYER_MOVE:
                return -10
            else:
                return 10
        else:
            return 0


class ParallelMinMaxPlayer(MinMaxPlayer):
    def next_move(self, board):
        num_cores = multiprocessing.cpu_count()
        scores = Parallel(n_jobs=num_cores)(
            delayed(self.process)(x) for x in board.empty_cells()
        )
        m = max(scores, key=lambda x: x[1])
        return m[0]

    def process(self, x):
        cp = board.copy()
        cp.update(x, COMPUTER_MOVE)
        return (x, self.evaluate(cp, COMPUTER_MOVE, PLAYER_MOVE, 1))

    def __str__(self):
        return 'parallel computer player'


if __name__ == '__main__':
    def check_board(board, winner):
        if not board.can_continue():
            print(board)
            if board.has_winner:
                print('Winner is {}'.format(winner))
            else:
                print("It's a draw!")
            return True
        return False

    size = int(input('Enter field size:'))
    board = TicTacToeBoard(size)

    playerA = ParallelMinMaxPlayer()
    playerB = MinMaxPlayer()

    while True:
        start = time.time()
        board.update(playerA.next_move(board), PLAYER_MOVE)
        end = time.time()
        print('Time per move for {0} is {1}'.format(playerA, end - start))

        if check_board(board, playerA):
            break

        start = time.time()
        board.update(playerB.next_move(board), COMPUTER_MOVE)
        end = time.time()
        print('Time per move for {0} is {1}'.format(playerB, end - start))

        if check_board(board, playerB):
            break

        print(board)

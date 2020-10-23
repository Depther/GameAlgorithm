using System;

namespace Algorithm {
    public class Board {
        private const char CIRCLE_LETTER = '\u25cf';

        private const int SIZE = 25;
        private mapType[,] map = new mapType[SIZE, SIZE];

        private enum mapType {
            empty = 0,
            wall = 1
        }

        public Board() {
            generateBinaryTreeMaze();
        }

        private void generateBinaryTreeMaze() {
            Random random = new Random();

            // 일단 길을 전부 막아버린다.
            for (int y = 0; y < SIZE; y++) {
                for (int x = 0; x < SIZE; x++) {
                    if (x % 2 == 0 || y % 2 == 0) {
                        map[y, x] = mapType.wall;
                    } else {
                        map[y, x] = mapType.empty;
                    }
                }
            }

            // 랜덤으로 우측 혹은 아래로 길을 뚫는다.
            for (int y = 0; y < SIZE; y++) {
                for (int x = 0; x < SIZE; x++) {
                    if (x % 2 == 0 || y % 2 == 0) {
                        continue;
                    }
                    
                    int randomNum = random.Next(0, 2);
                        
                    if (x == SIZE - 2) {
                        map[y + 1, x] = mapType.empty;
                    } else if (y == SIZE - 2) {
                        map[y, x + 1] = mapType.empty;
                    } else if (randomNum == 0) {
                        map[y + 1, x] = mapType.empty;
                    } else {
                        map[y, x + 1] = mapType.empty;
                    }
                }
            }
        }

        public void render() {
            for (int y = 0; y < SIZE; y++) {
                for (int x = 0; x < SIZE; x++) {
                    if (map[y, x] == mapType.empty) {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write(CIRCLE_LETTER);
                }

                Console.WriteLine();
            }
        }
    }
}
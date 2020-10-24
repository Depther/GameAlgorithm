using System;

namespace Algorithm {
    public class SideWinder {
        private const char CIRCLE_LETTER = '\u25cf';
        
        private const int SIZE = 25;
        private Constants.mapType[,] map = new Constants.mapType[SIZE, SIZE];
        
        public SideWinder() {
            blockPath();
            generateSideWinderMaze();
        }

        private void blockPath() {
            for (int y = 0; y < SIZE; y++) {
                for (int x = 0; x < SIZE; x++) {
                    if (x % 2 == 0 || y % 2 == 0) {
                        map[y, x] = Constants.mapType.wall;
                    } else {
                        map[y, x] = Constants.mapType.empty;
                    }
                }
            }
        }
        
        private void generateSideWinderMaze() {
            Random random = new Random();

            // 랜덤으로 우측 혹은 아래로 길을 뚫는다.
            for (int y = 0; y < SIZE; y++) {
                for (int x = 0; x < SIZE; x++) {
                    if (x % 2 == 0 || y % 2 == 0) {
                        continue;
                    }
                    
                    int randomNum = random.Next(0, 2);

                    int count = 1;
                    if (x == SIZE - 2) {
                        map[y + 1, x] = Constants.mapType.empty;
                    } else if (y == SIZE - 2) {
                        map[y, x + 1] = Constants.mapType.empty;
                    } else if (randomNum == 0) {
                        int randmonIndex = random.Next(0, count);
                        map[y + 1, x - (randmonIndex * 2)] = Constants.mapType.empty;
                        count = 1;
                    } else {
                        map[y, x + 1] = Constants.mapType.empty;
                        count++;
                    }
                }
            }
        }
        
        public void render() {
            for (int y = 0; y < SIZE; y++) {
                for (int x = 0; x < SIZE; x++) {
                    if (map[y, x] == Constants.mapType.empty) {
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
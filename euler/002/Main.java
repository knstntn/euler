package com.euler;

public class Main {
    public static void main(String[] args) {
        int limit = 4000000;
        int prev = 0;
        int current = 1;
        int sum = 0;

        while (current < limit) {
            if ((current % 2) == 0) {
                sum += current;
            }

            int tmp = current;
            current = current + prev;
            prev = tmp;
        }

        System.out.println(sum);
    }
}

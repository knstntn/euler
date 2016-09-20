package com.euler;

public class Main {
    public static void main(String[] args) {
        int s = 1000;

        for (int a = 1; a < s; a++) {
            for (int b = a + 1; b < s - a; b++) {
                double square = Math.pow(a, 2) + Math.pow(b, 2);
                double c = Math.sqrt(square);
                if (c == (long) c) {
                    long ci = (long) c;

                    if (a + b + ci == 1000) {
                        System.out.println(a * b * ci);
                    }
                }
            }
        }
    }
}

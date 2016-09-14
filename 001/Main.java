package com.euler;

import java.util.stream.IntStream;

public class Main {
    public static void main(String[] args) {
        int sum = IntStream.range(1, 1000).filter(x -> (x % 3) == 0 || (x % 5) == 0).sum();

        System.out.println(sum);
    }
}

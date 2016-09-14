package com.euler;

import java.util.HashMap;
import java.util.Map;

public class Main {
    public static void main(String[] args) {
        long n = 600851475143L;
        long max = 1;
        Map<Long, Boolean> memo = new HashMap<>();

        for (long i = 3; i * i < n; i++) {
            if ((n % i) == 0 && isPrime(memo, i)) {
                max = i;
            }
        }
        System.out.println(max);
    }

    private static boolean isPrime(Map<Long, Boolean> memo, long n) {
        if (memo.containsKey(n)) {
            return memo.get(n);
        }

        if ((n % 2) == 0) {
            memo.put(n, false);
            return false;
        }

        for (long i = 3; i * i <= n; i++) {
            if ((n % i) == 0) {
                memo.put(n, false);
                return false;
            }
        }

        memo.put(n, true);
        return true;
    }
}

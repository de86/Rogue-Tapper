using UnityEngine;
using System.Collections.Generic;

public static class Helpers {

    public static int getNormalDistribution (int rolls, int maxValue) {
        int result = 0;

        for(int i = 0; i < rolls; i++) {
            result += Random.Range(0, maxValue);
        }

        return result;
    }

    public static int getNormalDistribution (int rolls, int maxValue, int offset) {
        int result = 0;

        for(int i = 0; i < rolls; i++) {
            result += Random.Range(0, maxValue) + offset;
        }

        if(result < 0) result = 0;

        return result;
    }
}

#include <iostream>
#include <vector>
#include <algorithm>
#include <chrono>

using namespace std;

// Рекурсивный метод
int lcs_recursive(int lenx, const string& x, int leny, const string& y) {
    if (lenx == 0 || leny == 0)
        return 0;
    if (x[lenx - 1] == y[leny - 1])
        return 1 + lcs_recursive(lenx - 1, x, leny - 1, y);
    else
        return max(lcs_recursive(lenx, x, leny - 1, y), lcs_recursive(lenx - 1, x, leny, y));
}

// Динамическое программирование
int lcs_dp(const string& x, const string& y) {
    int lenx = x.size(), leny = y.size();
    vector<vector<int>> dp(lenx + 1, vector<int>(leny + 1, 0));

    for (int i = 1; i <= lenx; i++) {
        for (int j = 1; j <= leny; j++) {
            if (x[i - 1] == y[j - 1])
                dp[i][j] = dp[i - 1][j - 1] + 1;
            else
                dp[i][j] = max(dp[i - 1][j], dp[i][j - 1]);
        }
    }
    return dp[lenx][leny];
}

int main() {
    string S1 = "ABCDFGIABCDFGI";
    string S2 = "EATUFIEATUFI";
    int len1 = S1.size();
    int len2 = S2.size();

    vector<double> k_values = { 1.0 / 25, 1.0 / 20, 1.0 / 15, 1.0 / 10, 1.0 / 5, 1.0 / 2, 1.0 };

    for (double k : k_values) {
        int len_prefix1 = max(1, static_cast<int>(k * len1));
        int len_prefix2 = max(1, static_cast<int>(k * len2));

        string prefix1 = S1.substr(0, len_prefix1);
        string prefix2 = S2.substr(0, len_prefix2);

        // Динамическое программирование    
        auto start = chrono::high_resolution_clock::now();
        int dp_result = lcs_dp(prefix1, prefix2);
        auto end = chrono::high_resolution_clock::now();
        chrono::duration<double> time_dp = end - start;
        cout << "DP (" << prefix1 << ", " << prefix2 << "): " << dp_result << " | Time: " << time_dp.count() << "s" << endl;

        // Рекурсивный метод
        start = chrono::high_resolution_clock::now();
        int rec_result = lcs_recursive(prefix1.size(), prefix1, prefix2.size(), prefix2);
        end = chrono::high_resolution_clock::now();
        chrono::duration<double> time_rec = end - start;
        cout << "Recursive (" << prefix1 << ", " << prefix2 << "): " << rec_result << " | Time: " << time_rec.count() << "s" << endl;

        cout << "------------------------------------------------------" << endl;
    }
    return 0;
}
from math import pow

def find_fixed_payment(balance, annualInterestRate):
    monthlyInterestRate = annualInterestRate/12
    
    lower = balance/12
    upper = balance*pow(1+monthlyInterestRate, 12)/12

    while(True):
        epsilon = 0.01
        monthlyFixedPayment = (lower + upper)/2
        val = calc(12, balance, monthlyFixedPayment, monthlyInterestRate)
        if abs(val) > epsilon:
            if val > 0:
                lower = monthlyFixedPayment
            elif val < 0:
                upper = monthlyFixedPayment
        else:
            return monthlyFixedPayment

def calc(month, balance, monthlyFixedPayment, monthlyInterestRate):
    if month == 0: return balance
    
    ub = balance - monthlyFixedPayment
    balance = ub + monthlyInterestRate*ub
    
    return calc(month - 1, balance, monthlyFixedPayment, monthlyInterestRate)

calculated = find_fixed_payment(999999, 0.18)
print("Remaining balance:", round(calculated, 2))

def find_fixed_payment(balance, annualInterestRate):
    monthlyInterestRate = annualInterestRate/12
    monthlyFixedPayment = 10
    while(True):
        b = calc(12, balance, monthlyFixedPayment, monthlyInterestRate)
        if b <= 0:
            break
        monthlyFixedPayment += 10
    return monthlyFixedPayment
    

def calc(month, balance, monthlyFixedPayment, monthlyInterestRate):
    if month == 0: return balance
    
    ub = balance - monthlyFixedPayment
    balance = ub + monthlyInterestRate*ub
    
    return calc(month - 1, balance, monthlyFixedPayment, monthlyInterestRate)

calculated = find_fixed_payment(3926, 0.2)
print("Remaining balance:", round(calculated, 2))

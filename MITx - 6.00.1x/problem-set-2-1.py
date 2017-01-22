balance = 42; annualInterestRate = 0.2; monthlyPaymentRate = 0.04

def calc(month, balance, monthlyPaymentRate, monthlyInterestRate):
    if month == 0: return balance
    
    payment = balance*monthlyPaymentRate
    ub = balance - payment
    balance = ub + monthlyInterestRate*ub
    
    return calc(month - 1, balance, monthlyPaymentRate, monthlyInterestRate)

calculated = calc(12, balance, monthlyPaymentRate, annualInterestRate/12)
print("Remaining balance:", round(calculated, 2))

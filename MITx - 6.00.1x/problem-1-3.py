s = 'abcdefghijklmnopqrstuvwxyz'
max = ''
tmp = ''

prev = ''
for c in range(0, len(s)):
    print(prev, s[c], prev < s[c])

    if prev <= s[c]:
        tmp += s[c]
    else:
        if len(max) < len(tmp):
            max = tmp
        tmp = s[c]
    prev = s[c]

if len(max) < len(tmp):
    max = tmp
    
print(max)
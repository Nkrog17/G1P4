og = '''

'''
l = og.split('\n')
l = list(filter(None, l))

hr = []
hr_time = []
gsr = []
gsr_time = []

for i in l:
    if 'HR' in i:
        s = i.split('=')
        s = s[-1].split()
        hr.append(s[0])
        hr_time.append(s[1])
        hr.append('\n')
        hr_time.append('\n')
    elif 'GSR' in i:
        s = i.split('=')
        s = s[-1].split()
        gsr.append(s[0])
        gsr_time.append(s[1])
        gsr.append('\n')
        gsr_time.append('\n')
    else:
        s = i.split('=')
        if len(s) > 1 and s[-1].isdigit() or i.isdigit():
            o = s + " UNKNOWN"
            gsr.append(o)
            gsr.append('\n')
            hr.append(o)
            hr.append('\n')

print('HR \n')
print(''.join(hr))
print('HR TIME\n')
print(''.join(hr_time))
print('-----')
print('GSR \n')
print(''.join(gsr))
print('GSR TIME\n')
print(''.join(gsr_time))
            

'''
Whack Python script for formatting only GSR, which
will be needed to find average GSR for each measurement.
'''

#Bør egentlig fjerne overflødige målinger, så der kun er en i sekundet.

def open_files():
    list_text = []
    for i in range(28):
        text = ''
        file = open('testpersonM' + str(i) + '.txt')
        text += '\n' + file.read()
        list_text.append(text)
        file.close()
    return list_text

def save_file(text):
    output = open('allGSR.txt', 'w')
    output.write(text)
    output.close()

def event_to_int(event):
    if event == 'poundevent':
        return 1
    elif event == 'slamevent':
        return 2
    elif event == 'ladyevent':
        return 3
    elif event == 'vaseevent':
        return 4
    else:
        return 0

def spike_to_int(spike):
    if spike == 'spikehr':
        return 1
    elif spike == 'spikegsr':
        return 2
    else:
        0

def format_text(list_text):
    output = []
    cline = 0
    for t in list_text:
        index = 0
        for l in t.split('\n'):
            if l:
                l = l.split()
                gsr = l[1][4:]
                if len(output)>index:
                    output[index] += '\t{}'.format(gsr)
                else:
                    output.append('NaN\t'*cline + '{}'.format(gsr))
                index += 1
                
        for i in range(len(output)-index):
            output[index+i] += '\tNaN'
        cline += 1

    return '\n'.join(output)
        
    
def run():
    text = open_files()
    text = format_text(text)
    save_file(text)
    print("Done")

run()

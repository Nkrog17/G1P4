'''
This script takes log data and finds mean values for HR and GSR
for each participant.

HR    GSR
75    130
'''

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
    output = open('avgScare.txt', 'w')
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
        hr = []
        gsr = []
        index = 0
        for l in t.split('\n'):
            if l:
                l = l.split()
                hr.append(int(l[0][3:]))
                gsr.append(int(l[1][4:]))
                index += 1
        avg_hr = sum(hr)/len(hr)
        avg_gsr = sum(gsr)/len(gsr)
        output.append('\n{}\t{}'.format(avg_hr, avg_gsr))
        cline += 1

    return ''.join(output)
        
    
def run():
    text = open_files()
    text = format_text(text)
    save_file(text)
    print("Done")

run()

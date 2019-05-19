'''
Output-formatet er følgende:
1    2   3  4  5   6    7         8
HR  GSR  X  Y  Z  TIME  EVENT#  SPIKE#

event 0 = none
event 1 = pound door
event 2 = slam event
event 3 = lady event
event 4 = vase event

spike 0 = none
spike 1 = spike HR
spike 2 = spike GSR
'''

def open_files():
    text = ''
    for i in range(28):
        file = open('testpersonM' + str(i) + '.txt')
        text += '\n' + file.read()
        file.close()
    return text

def save_file(text):
    output = open('Output.txt', 'w')
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

def format_text(text):
    output = []
    text = text.split('\n')
    index = 0
    event_indices = []
    for l in text:
        if l:
            try:
                event = 0
                spike = 0
                l = l.split()
                hr = l[0][3:]
                gsr = l[1][4:]
                x = l[2][9:-1]
                y = l[3][:-1]
                z = l[4][:-1]
                time = l[5][5:]
                if len(l) == 7:
                    event = event_to_int(l[6].lower())
                    if event == 3:
                        event_indices.append(index)
                    elif event == 0:
                        spike = spike_to_int(l[6].lower())
                line = "{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}".format(hr, gsr, x, y, z, time, event, spike).replace(',','.')
                output.append(line)
                index += 1
            except Exception as e:
                print("WARNING: Kunne ikke formattere ", l, e)
    for i in event_indices[1:-1]:
        output[i] = output[i][:-3] + '0' + output[i][-2:]
    return '\n'.join(output)
        
    
def run():
    text = open_files()
    text = format_text(text)
    save_file(text)

run()

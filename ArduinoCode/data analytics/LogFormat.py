'''
Output-formatet er følgende:
HR  GSR  X  Y  Z  TIME  EVENT#
'''

def open_file():
    file = open('LogFile.txt')
    text = file.read()
    file.close()
    return text

def save_file(text):
    output = open('Output.txt', 'w')
    output.write(text)
    output.close()

def event_to_int(event):
    if event == 'poundevent': #Pounding door er egentlig ikke et rigtigt event.
        return 0
    elif event == 'slamevent':
        return 1
    elif event == 'ladyevent':
        return 2
    elif event == 'vaseevent':
        return 3
    else:
        return 0

def format_text(text):
    output = []
    text = text.split('\n')
    for l in text:
        if l:
            try:
                event = ''
                l = l.split()
                hr = l[0][3:]
                gsr = l[1][4:]
                x = l[2][9:-1]
                y = l[3][:-1]
                z = l[4][:-1]
                time = l[5][5:]
                if len(l) > 6:
                    event = l[6]
                line = "{}\t{}\t{}\t{}\t{}\t{}\t{}".format(hr, gsr, x, y, z, time, event_to_int(event.lower()))
                output.append(line)
            except:
                print("WARNING: Kunne ikke formattere ", l)
    return '\n'.join(output)
        
    
def run():
    text = open_file()
    text = format_text(text)
    save_file(text)

run()

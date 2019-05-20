'''
Script for isolating number of spikes recorded for each person.
SPIKES    HR Spikes    GSR Spikes
'''

def open_files():
    list_text = []
    for i in range(27):
        text = ''
        file = open('testpersonU' + str(i) + '.txt')
        text += '\n' + file.read()
        list_text.append(text)
        file.close()
    return list_text

def save_file(text):
    output = open('SpikesU.txt', 'w')
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
        spikes = 0
        hrspikes = 0
        gsrspikes = 0
        for l in t.split('\n'):
            if l:
                l = l.split()
                if len(l) == 7:
                    event = event_to_int(l[6].lower())
                    if event == 0:
                        spikes += 1
                        if spike_to_int(l[6].lower()) == 1:
                            hrspikes += 1
                        elif spike_to_int(l[6].lower()) == 2:
                            gsrspikes += 1
                            
                index += 1
                
                
        output.append("{}\t{}\t{}".format(spikes, hrspikes, gsrspikes))
        cline += 1

    return '\n'.join(output)
        
    
def run():
    text = open_files()
    text = format_text(text)
    save_file(text)
    print("Done")

run()

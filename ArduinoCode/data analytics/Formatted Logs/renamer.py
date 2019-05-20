import os

index = 0
for filename in os.listdir('.'):
    filename = filename.lower()
    if 'u' in filename:
        os.rename(filename, 'testpersonU' + str(index) + '.txt')
        index += 1

index = 0
for filename in os.listdir('.'):
    filename = filename.lower()
    if 'm' in filename and '.py' not in filename:
        os.rename(filename, 'testpersonM' + str(index) + '.txt')
        index += 1
        
print('Renamed files')

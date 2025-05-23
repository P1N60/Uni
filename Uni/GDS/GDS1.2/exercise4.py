# Import regular expression module
import re

data = '''# Measurements started
Sep 9, 9:05, T=22deg
SEP 9, 10:15, T=25deg
# Taking a coffee break
Sep 9, 11:15, T=-10deg
# Weekend
Sept 12, 09:00AM, T=32deg
Oct12 13:00, T=32degr''' 

# Create regular expression
pattern = re.compile(r'(^[A-Za-z]+) ?([0-9]*)[, ]*([0-9]+:[0-9]+)[A-Za-z]*[, ]*[A-Za-z=]*([+-]*[0-9]*)[A-Za-z]*')

for data_line in data.split('\n'):
    match = pattern.search(data_line)
    if match:
        temp = match.group(4)
        if int(temp) > 0:
            print(match.group())
hr = load('hr.txt');
gsr = load('gsr.txt');
hr_time = load('hr_time.txt');
gsr_time = load('gsr_time.txt');

hr_time = hr_time/6000;
gsr_time = gsr_time/6000;

hr_yaxis = (0:150);


yyaxis left;
plot(hr_time, hr, 'linewidth', 1.0);
ylim([0 300]);
ylabel('Heart Rate');
hold on;

yyaxis right;
plot(gsr_time, gsr, '--');
set(gca, 'YDir','reverse')
ylabel('Galvanic Skin Response');
ylim([0 300]);
xlim([0 hr_time(end)]);

legend({'HR','GSR'});
xlabel('Time in minutes');
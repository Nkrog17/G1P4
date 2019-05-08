%Load data and assign variables
data = load('Output.txt');
hr = data(6:end,1);
gsr = data(6:end,2);
pos = data(6:end,3:5);
time = data(6:end,6);
event = data(6:end,7);
spike = data(6:end,8);

%Isolate events
event_plot = event;
event_plot(event_plot==0) = nan;
event_plot_indices = find(event_plot>0);

%Isolate relevant spikes for HR and GSR.
hr_spike_plot = spike;
hr_spike_plot(hr_spike_plot==0) = nan;
hr_spike_plot(hr_spike_plot==2) = nan;
hr_spike_indices = find(hr_spike_plot==1);
hr_spike_plot(hr_spike_indices) = hr(hr_spike_indices);

gsr_spike_plot = spike;
gsr_spike_plot(gsr_spike_plot==0) = nan;
gsr_spike_plot(gsr_spike_plot==1) = nan;
gsr_spike_indices = find(gsr_spike_plot==2);
gsr_spike_plot(gsr_spike_indices) = gsr(gsr_spike_indices);

%Plot HR
yyaxis left;
plot(time, hr, 'linewidth', 1.0);
ylim([0 350]);
ylabel('Heart Rate');
hold on;

%Plot HR spikes
plot(time, hr_spike_plot, 'gx');
hold on;

%Plot GSR
yyaxis right;
plot(time, gsr, '--');
set(gca, 'YDir','reverse')
ylabel('Galvanic Skin Response');
ylim([-50 300]);
xlim([6 time(end)]);
hold on;

%Plot GSR spikes
plot(time, gsr_spike_plot, 'k+');
hold on;

%Plot event lines
line([event_plot_indices event_plot_indices],[-50 300]);

legend({'HR','HR Spike','GSR','GSR Spike'});
xlabel('Time in seconds');
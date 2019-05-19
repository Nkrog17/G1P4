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
figure();
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
line([time(event_plot_indices) time(event_plot_indices)],[-100 350],'LineStyle',':');
h = text(time(event_plot_indices), [280 280 280 280 280] , {'Event 1', 'Event 2', 'Event 3', ['Event 3',newline,'finished'], 'Event 4'}, 'Color', [0.6 0.6 0.6]); 
set(h,'Rotation',90)
hold off;

legend({'HR','HR Spike','GSR','GSR Spike'});
xlabel('Time in seconds');

%Plot player posittion. Just for fun.
I = imread('FinalMap.png');
RI = imref2d(size(I));
RI.XWorldLimits = [-42 30];
RI.YWorldLimits = [-21 70];
figure(2); imshow(I, RI);
hold on;

set(gca, 'YDir','normal') %Tag et bedre billede
x = pos(:,3)+2;
y = pos(:,1)*-1;
s = 1.1.^(hr*0.5)+100;
c = [gsr/max(gsr) gsr/max(gsr) gsr/max(gsr*0.5)];
scatter(x,y,s,c,'filled');   
hold on;
%Plot hr spikes
scatter_hr = hr_spike_plot;
scatter_hr(scatter_hr>0) = 1;
s = scatter_hr * 50;
c = [0 0 1];
scatter(x,y,s,c,'filled');
hold on;
%plot gsr spikes
scatter_gsr = gsr_spike_plot;
scatter_gsr(scatter_gsr>0) = 1;
s = scatter_gsr * 20;
c = [1 0.5 0];
scatter(x,y,s,c,'filled');
hold on;
%plot events
scatter_event = event_plot;
scatter_event(scatter_event>0) = 1;
s = scatter_event * 400;
c = [1 0 0];
scatter(x,y,s,c,'LineWidth', 1.5);
h = text(x(event_plot_indices)-3.5, y(event_plot_indices)-3, {'Event 1', 'Event 2', 'Event 3', ['Event 3',newline,'finished'], 'Event 4'}, 'Color', [1 1 0], 'FontSize', 12, 'FontWeight', 'Bold'); 
h = set(h,'Rotation',0);
set(h,'Rotation',90)

legend({'Position in map', 'HR spike', 'GSR spike'});

%Plot percentage change in GSR
figure(3);

gsr_diff = gsr-gsr(1);
gsr_percent = gsr_diff/gsr(1);

plot(gsr_percent);


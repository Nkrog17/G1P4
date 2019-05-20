excel = importdata('ScareSurvey.xlsx');
data = excel.data.Ark1;

allspikesM = load('spikesM.txt');
allspikesU = load('spikesU.txt');
spikesM = allspikesM(:,1);
spikesU = allspikesU(:,1);
hr_spikesM = allspikesM(:,2);
gsr_spikesM = allspikesM(:,3);
hr_spikesU = allspikesU(:,2);
gsr_spikesU = allspikesU(:,3);

dataM = data(1:27, :);
dataU = data(29:end, :);
avg_dataM = mean(dataM,2);
avg_dataU = mean(dataU,2);

corrU = corr(avg_dataU, spikesU);
corrM = corr(avg_dataM, spikesM);

%Plot it!
figure(1);
plot(avg_dataU, spikesU, 'go');
ylabel('Number of spikes');
xlabel('Average score in survey');
title({'Correlation between average score in survey and number of spikes recorded', 'Without biofeedback'});

figure(2);
plot(avg_dataM, spikesM, 'ko');
ylabel('Number of spikes');
xlabel('Average score in survey');
title({'Correlation between average score in survey and number of spikes recorded', 'With biofeedback'});


%Correlation without Approach
data_noapp = excel.data.Ark2;

noapp_dataM = data_noapp(1:27, :);
noapp_dataU = data_noapp(29:end, :);
avg_noapp_dataM = mean(noapp_dataM,2);
avg_noapp_dataU = mean(noapp_dataU,2);

corr_noappU = corr(avg_noapp_dataU, spikesU);
corr_noappM = corr(avg_noapp_dataM, spikesM);

%Plot dat shit
figure(3);
plot(avg_noapp_dataM, spikesM, 'ro');
ylabel('Number of spikes');
xlabel('Average score in survey');
title({'Correlation between average score in survey and number of spikes recorded', 'Approach question removed - With biofeedback'});

figure(4);
plot(avg_noapp_dataU, spikesU, 'bo');
ylabel('Number of spikes');
xlabel('Average score in survey');
title({'Correlation between average score in survey and number of spikes recorded', 'Approach question removed - Without biofeedback'});

%GSR HR Correlation
anx_data =  excel.data.Ark4;
fear_data =  excel.data.Ark3;

anx_dataM = anx_data(1:27, :);
anx_dataU = anx_data(29:end, :);
avg_anx_dataM = mean(anx_dataM,2);
avg_anx_dataU = mean(anx_dataU,2);

corr_anxU = corr(avg_anx_dataU, gsr_spikesU);
corr_anxM = corr(avg_anx_dataM, gsr_spikesM);

fear_dataM = fear_data(1:27, :);
fear_dataU = fear_data(29:end, :);
avg_fear_dataM = mean(fear_dataM,2);
avg_fear_dataU = mean(fear_dataU,2);

corr_fearU = corr(avg_fear_dataU, hr_spikesU);
corr_fearM = corr(avg_fear_dataM, hr_spikesM);

figure(5);
plot(avg_anx_dataU, gsr_spikesU, 'bo');
ylabel('Number of spikes');
xlabel('Average score in survey');
title({'Correlation between average anxiety score in survey and number of GSR spikes recorded', 'Without biofeedback'});

figure(6);
plot(avg_anx_dataM, gsr_spikesM, 'ro');
ylabel('Number of spikes');
xlabel('Average score in survey');
title({'Correlation between average anxiety score in survey and number of GSR spikes recorded', 'With biofeedback'});

figure(7);
plot(avg_fear_dataU, gsr_spikesU, 'ko');
ylabel('Number of spikes');
xlabel('Average score in survey');
title({'Correlation between average fear score in survey and number of HR spikes recorded', 'Without biofeedback'});

figure(8);
plot(avg_fear_dataM, gsr_spikesM, 'go');
ylabel('Number of spikes');
xlabel('Average score in survey');
title({'Correlation between average fear score in survey and number of HR spikes recorded', 'With biofeedback'});



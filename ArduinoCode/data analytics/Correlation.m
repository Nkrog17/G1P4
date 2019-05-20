data = importdata('ScareSurveyNoApp.xlsx');
data = data.data;

scareM = load('avgScareM.txt');
scareU = load('avgScareU.txt');

dataM = data(1:27, :);
dataU = data(30:end, :);

avg_dataM = mean(dataM,2);
avg_dataU = mean(dataU,2);

corr_HRU = corr(avg_dataU, scareU(:,1));
corr_GSRU = corr(avg_dataU, scareU(:,2));
corr_HRM = corr(avg_dataM, scareM(:,1));
corr_GSRM = corr(avg_dataM, scareM(:,2));


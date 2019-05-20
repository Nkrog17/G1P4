gsr = load('allGSR.txt');

gsr_diffs = gsr(61:end,:) - gsr(60,:);
gsr_percent = gsr_diffs./gsr(3,:);
gsr_percent(~isfinite(gsr_percent))=1;

nm = nanmean(gsr_percent);

final = mean(nm)
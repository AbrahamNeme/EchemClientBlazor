
// Function to generate a random color
const getRandomColor = () => {
    const letters = '0123456789ABCDEF';
    let color = '#';
    for (let i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}; 

const charts = {};

window.drawCyclicVoltammogram = (canvasId, title, datasetName, jData, eData) => {
    const ctx = document.getElementById(canvasId).getContext('2d');

    charts[canvasId] = new Chart(ctx, {
        type: 'scatter',
        data: {
            labels: eData,
            datasets: [{
                label: datasetName,
                data: jData.map((y, index) => ({ x: eData[index], y })),
                borderColor: getRandomColor(), // Set the line color to dark blue
                showLine: true,
                borderWidth: 2, // Optional: Set the line width
                //fill: false // Optional: Do not fill the area under the line
            }]
        },
        options: {
            title: {
                display: true,
                text: title
            },
            scales: {
                x: {
                    type: 'linear',
                    position: 'bottom',
                    title: {
                        display: true,
                        text: 'x-label'
                    }
                },
                y: {
                    //min: Math.min(...jData),
                    //max: Math.max(...jData)
                    type: 'linear',
                    position: 'left',
                    title: {
                        display: true,
                        text: 'y-label'
                    }
                }
            },
            maintainAspectRatio: false, // Set to false to control chart size
            responsive: true,
            maxWidth: 800,
            maxHeight: 600,
            interaction: {
                mode: 'nearest'
            },
            tooltips: {
                callbacks: {
                    label: (tooltipItem, data) => {
                        const value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
                        return `E: ${value.x}, j: ${value.y}`;
                    }
                }
            }
        }
    });
};

window.updateCyclicVoltammogram = (canvasId, title, datasetName, jData, eData) => {
    const chart = charts[canvasId];
    if (chart) {
        chart.options.title.text = title;
        chart.data.labels = eData;
        chart.data.datasets[0].label = datasetName;
        chart.data.datasets[0].data = jData.map((y, index) => ({ x: eData[index], y }));
        chart.update();
    }
};

window.deleteCyclicVoltammogram = (chartId) => {
    const chart = charts[chartId];
    if (chart) {
        chart.destroy();
        delete charts[chartId];
    }
};



const createChartDatasets = (datasetNames, jDatas, eDatas) => {
    const datasets = [];

    for (let i = 0; i < datasetNames.length; i++) {
        const datasetName = datasetNames[i];
        const jData = jDatas[i];
        const eData = eDatas[i];

        const chartDataset = {
            label: datasetName,
            data: jData.map((y, dataIndex) => ({ x: eData[dataIndex], y })),
            borderColor: getRandomColor(),
            showLine: true,
            borderWidth: 2,
            fill: false,
        };
        datasets.push(chartDataset);
    }
    return datasets;
}

window.drawMultipleCyclicVoltammogram = (canvasId, title, datasetNames, jDatas, eDatas) => {
    const ctx = document.getElementById(canvasId).getContext('2d');

    charts[canvasId] = new Chart(ctx, {
        type: 'scatter',
        data: {
            labels: eDatas, // We leave this empty since each dataset may have different eData
            datasets: createChartDatasets(datasetNames, jDatas, eDatas),
        },
        options: {
            title: {
                display: true,
                text: title,
            },
            scales: {
                x: {
                    type: 'linear',
                    position: 'bottom',
                    title: {
                        display: true,
                        text: 'x-label',
                    },
                },
                y: {
                    type: 'linear',
                    position: 'left',
                    title: {
                        display: true,
                        text: 'y-label',
                    },
                },
            },
            maintainAspectRatio: false,
            responsive: true,
            maxWidth: 800,
            maxHeight: 600,
            interaction: {
                mode: 'nearest',
            },
            
        },
    });
};

window.updateMultipleCyclicVoltammogram = (canvasId, datasetNames, jDatas, eDatas) => {
    const chart = charts[canvasId];

    if (!chart) {
        console.error(`Chart with ID ${canvasId} not found.`);
        return;
    }
    // Clear existing datasets
    chart.data.datasets = [];

    chart.data.labels = eDatas; // Update labels if needed
    chart.data.datasets = createChartDatasets(datasetNames, jDatas, eDatas);
    chart.update(); // Update the chart
};
<script setup>
</script>

<template>
    <div class="container mt-4">
        <h1 class="text-center">CircleSet ID: {{ id }}</h1>
        <div v-if="data" class="mt-4">
            <h2>Add a Circle</h2>
            <form @submit.prevent="addCircle" class="row g-3">
                <div class="col-md-4">
                    <label for="coordX" class="form-label">X Coordinate</label>
                    <input v-model.number="newCircle.coordX" type="number" id="coordX" class="form-control" required />
                </div>
                <div class="col-md-4">
                    <label for="coordY" class="form-label">Y Coordinate</label>
                    <input v-model.number="newCircle.coordY" type="number" id="coordY" class="form-control" required />
                </div>
                <div class="col-md-4 d-flex align-items-end">
                    <button type="submit" class="btn btn-primary w-100">Submit</button>
                </div>
            </form>
            <div class="mt-4">
                <canvas ref="canvas" width="1000" height="1000" class="border"></canvas>
            </div>
        </div>
        <div v-else>
            <p>Loading data...</p>
        </div>
    </div>
</template>

<script>
    import { nextTick } from 'vue';
    export default {
        name: 'MainView',
        props: ['id'],
        data() {
            return {
                data: null,
                newCircle: {
                    coordX: 0,
                    coordY: 0,
                    diameter: 0,
                    color: '#ffff00'
                }
            };
        },
        mounted() {
            this.fetchData(this.id);
        },
        methods: {
            async fetchData(id) {
                try {
                    const response = await fetch(`https://localhost:7072/api/circles/${id}`);
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    }
                    const result = await response.json();

                    this.data = result;
                    await nextTick();
                    this.drawCircles();

                } catch (error) {
                    console.error('Error fetching data:', error);
                }
            },
            drawCircles() {
                if (!this.data || !this.$refs.canvas) return;

                const canvas = this.$refs.canvas;
                const context = canvas.getContext('2d');

                context.clearRect(0, 0, canvas.width, canvas.height);

                this.data.circleSet.circles.forEach(circle => {
                    context.beginPath();
                    context.arc(circle.coordX, circle.coordY, circle.diameter / 2, 0, 2 * Math.PI);
                    context.fillStyle = circle.color;
                    context.fill();
                    context.closePath();
                });
            },
            drawCircle(circle) {
                const canvas = this.$refs.canvas;
                const context = canvas.getContext('2d');

                context.beginPath();
                context.arc(circle.x, circle.y, circle.radius, 0, 2 * Math.PI);
                context.fillStyle = circle.color;
                context.fill();
                context.closePath();
            },
            async addCircle() {
                if (this.newCircle.coordX > 1000 || this.newCircle.coordY > 1000) {
                    alert("Coords must be less then 1000!");
                    return;
                }

                this.newCircle.diameter = this.getRandomRadius(1, 1000);
                this.newCircle.color = this.getRandomColor();

                const response = await fetch(`https://localhost:7072/api/circles/${this.id}`,
                    {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json",
                        },
                        body: JSON.stringify(this.newCircle),
                    });

                if (!response.ok) {
                    alert(`HTTP error! status: ${response.status}`);
                    throw new Error(`HTTP error! status: ${response.status}`);
                }

                try {
                    const newCircle = { ...this.newCircle };

                    this.data.circleSet.circles.push(newCircle);
                    this.drawCircles();
                }
                catch (error) {
                    console.log(error);
                }

            },
            getRandomRadius(min, max) {
                return Math.floor(Math.random() * (max - min + 1)) + min;
            },
            getRandomColor() {
                const letters = '0123456789ABCDEF';
                let color = '#';
                for (let i = 0; i < 6; i++) {
                    color += letters[Math.floor(Math.random() * 16)];
                }
                return color;
            }
        }
    };
</script>


<style scoped>
    canvas {
        border: 5px solid #919191b7;
    }
    body {
        background-color: #121212; /* Темный фон */
        color: #ffffff; /* Светлый текст */
    }

    .container {
        background-color: #1e1e1e; /* Темный цвет контейнера */
        border-radius: 8px;
    }

</style>
import { createRouter, createWebHistory } from 'vue-router'

import MainView from '../components/MainView.vue'

const routes = [
    {
        path: '/',
        name: 'Home',
        beforeEnter: (to, from, next) => {
            // Creating new Circle Set
            fetch('https://localhost:7072/api/circles/create')
                .then(response => response.json())
                .then(data => {
                    next(`/${data.circleSetId}`);
                });
        }
    },
    {
        path: '/:id',
        component: MainView,
        name: 'MainView',
        props: true
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router
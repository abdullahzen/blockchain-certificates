import Vue from 'vue';
import Router from 'vue-router';
import Main from '@/views/Main';
import Verify from '@/views/Verify';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'mainview',
      component: Main,
    },
    {
      path: '/verify',
      name: 'verifyview',
      component: Verify,
    },
  ],
});

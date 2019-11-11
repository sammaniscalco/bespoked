import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Products from '@/components/Products'
import ProductDetail from '@/components/ProductDetail'
import Salespersons from '@/components/Salespersons'
import SalespersonDetail from '@/components/SalespersonDetail'
import Customers from '@/components/Customers'
import Sales from '@/components/Sales'
import SaleDetail from '@/components/SaleDetail'
import Report from '@/components/Report'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    }, {
      path: '/Products',
      name: 'Products',
      component: Products
    },
    {
      path: '/Products/:id',
      name: 'ProductDetail',
      props: true,
      component: ProductDetail
    }, {
      path: '/Salespersons',
      name: 'Salespersons',
      component: Salespersons
    },
    {
      path: '/Salespersons/:id',
      name: 'SalespersonDetail',
      props: true,
      component: SalespersonDetail
    }, {
      path: '/Customers',
      name: 'Customers',
      component: Customers
    },
     {
      path: '/Sales',
      name: 'Sales',
      component: Sales
    },
    {
      path: '/Sales/New',
      name: 'SaleDetail',
      props: true,
      component: SaleDetail
    },
    {
      path: '/Report',
      name: 'Report',
      component: Report
    }
  ]
})

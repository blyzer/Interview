import Vue from 'vue'
import Router from 'vue-router'

import Default from '@/components/Default'
import PermisosIndex from '@/components/permisos/Index'
import PermisosCreateOrUpdate from '@/components/permisos/CreateOrUpdate'
import TipoPermisosIndex from '@/components/tipoPermisos/Index'
import TipoPermisosCreateOrUpdate from '@/components/tipoPermisos/CreateOrUpdate'

Vue.use(Router)

const routes = [
  { path: '/', name: 'Default', component: Default },
  { path: '/permisos/', name: 'PermisosIndex', component: PermisosIndex },
  { path: '/permisos/add', name: 'PermisosCreate', component: PermisosCreateOrUpdate },
  { path: '/permisos/:id/edit', name: 'PermisosEdit', component: PermisosCreateOrUpdate },
  { path: '/tipoPermisos/', name: 'TipoPermisosIndex', component: TipoPermisosIndex },
  { path: '/tipoPermisos/add', name: 'TipoPermisosCreate', component: TipoPermisosCreateOrUpdate },
  { path: '/tipoPermisos/:id/edit', name: 'TipoPermisosEdit', component: TipoPermisosCreateOrUpdate },
]

export default new Router({
  routes
})

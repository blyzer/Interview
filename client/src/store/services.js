import Axios from 'axios'
import permisoService from '../services/PermisoService'
import tipoPermisoService from '../services/TipoPermisoService'

let apiUrl = 'http://localhost:62553/'

// Axios Configuration
Axios.defaults.headers.common.Accept = 'application/json'

export default {
    permisoService: new permisoService(Axios, apiUrl),
    tipoPermisoService: new tipoPermisoService(Axios, apiUrl)
}
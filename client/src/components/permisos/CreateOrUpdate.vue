<template>
<div>
    <h2>{{ pageTitle }}</h2>
    <el-form v-loading="loading" :model="form" :rules="rules" ref="ruleForm">
      <el-form-item label="Nombre" prop="NombreEmpleado">
        <el-input v-model="form.NombreEmpleado"></el-input>
      </el-form-item>
      <el-form-item label="Apellido" prop="ApellidosEmpleado">
        <el-input v-model="form.ApellidosEmpleado"></el-input>
      </el-form-item>
      <el-form-item label="Tipo" prop="TipoPermiso">
        <el-input type="textarea" v-model="form.TipoPermiso"></el-input>
      </el-form-item>
      <el-select
        :value="selected"
        @input="dispatch"
        placeholder="Filtrado por descripción"
        :filterable="true"
        :remote="true"
        :remote-method="filter"
        :loading="loading">
        <el-option
          v-for="item in TipoPermiso"
          :key="item.id"
          :label="item.descripcion"
          :value="item.id">
        </el-option>
      </el-select>
      <el-form-item label="Fecha" prop="FechaPermiso">
        <el-input type="textarea" v-model="form.FechaPermiso"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button @click="save" type="primary">Guardar</el-button>
      </el-form-item>
    </el-form>
</div>
</template>

<script>
export default {
  name: "PermisoCreateOrUpdate",
  data() {
    return {
      loading: false,
      form: {
        Id: 0,
        NombreEmpleado: null,
        ApellidosEmpleado: null,
        TipoPermiso: [{Id: 0, Descripcion: null}],
        FechaPermiso: null
      },
      TipoPermiso: [],
      rules: {
        NombreEmpleado: [
          { required: true, message: "Debe ingresar un nombre" },
          { min: 3, message: "Debe contener como mínimo 3 caracteres" }
        ],
        ApellidosEmpleado: [{ required: true, message: "El apellido es requerido" }],
        TipoPermiso: [{ required: true, message: "Este campo es requerido" }],
        FechaPermiso: [{requierd: true, message: "debe elegir una fecha"}]
      }
    };
  },
  computed: {
    pageTitle() {
      return this.form.Id === 0 ? "Nuevo permiso" : `${this.form.ApellidosEmpleado}, ${this.form.NombreEmpleado}`;
    }
  },
  created() {
    let self = this;
    self.get(self.$route.params.id);
  },
  methods: {
    get(id) {
      if(id == undefined) return;

      let self = this;

      self.loading = true;
      self.$store.state.services.permisoService
        .get(id)
        .then(r => {
          self.loading = false;
          self.form.Id = r.data.Id;
          self.form.NombreEmpleado = r.data.NombreEmpleado;
          self.form.ApellidosEmpleado = r.data.ApellidosEmpleado;
          self.form.TipoPermiso = r.data.TipoPermiso;
          self.form.FechaPermiso = r.data.FechaPermiso;
        })
        .catch(r => {
          self.$message({
            message: "Ocurrió un error inesperado",
            type: "error"
          });
        });
    },
    filter(query){
      if(query != ''){
        self.$store.state.services.tipopermisoService
          .getAll()
          .then(r => {
            self.loading = false;
            self.data = r.data;
          })
          .catch(r => {
            self.$message({
              message: "Ocurrió un error inesperado",
              type: "error"
            });
          });
      }
      else{
        this.TipoPermiso = []
      }
    },
    save() {
      let self = this;
      self.$refs["ruleForm"].validate(valid => {
        if (valid) {
          self.loading = true;

          if(self.form.Id > 0) {
            self.$store.state.services.permisoService
            .update(self.form)
            .then(r => {
              self.loading = false;
              self.$router.push('/permisos');
            })
            .catch(r => {
              self.$message({
                message: "Ocurrió un error inesperado",
                type: "error"
              });
            });
          } else {
            self.$store.state.services.permisoService
              .add(self.form)
              .then(r => {
                self.loading = false;
                self.$router.push('/permisos');
              })
              .catch(r => {
                self.$message({
                  message: "Ocurrió un error inesperado",
                  type: "error"
                });
              });
          }
        }
      });
    }
  }
};
</script>
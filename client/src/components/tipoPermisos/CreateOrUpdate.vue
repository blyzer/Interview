<template>
<div>
    <h2>{{ pageTitle }}</h2>
    <el-form v-loading="loading" :model="form" :rules="rules" ref="ruleForm">
      <el-form-item label="Descripcion" prop="Descrcipcion">
        <el-input v-model="form.Descripcion"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button @click="save" type="primary">Guardar</el-button>
      </el-form-item>
    </el-form>
</div>
</template>

<script>
export default {
  name: "tipoPermisosCreateOrUpdate",
  data() {
    return {
      loading: false,
      form: {
        Id: 0,
        Descripcion: null,
      },
      rules: {
        Descripcion: [
          { required: true, message: "Debe ingresar una descripcion" },
          { min: 3, message: "Debe contener como mínimo 3 caracteres" }
        ]
      }
    };
  },
  computed: {
    pageTitle() {
      return this.form.Id === 0 ? "Nuevo tipo de permiso" : `${this.form.Descripcion}`;
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
      self.$store.state.services.tipoPermisoService
        .get(id)
        .then(r => {
          self.loading = false;
          self.form.Id = r.data.Id;
          self.form.Descripcion = r.data.Descripcion;
        })
        .catch(r => {
          self.$message({
            message: "Ocurrió un error inesperado",
            type: "error"
          });
        });
    },
    save() {
      let self = this;
      self.$refs["ruleForm"].validate(valid => {
        if (valid) {
          self.loading = true;

          if(self.form.Id > 0) {
            self.$store.state.services.tipoPermisoService
            .update(self.form)
            .then(r => {
              self.loading = false;
              self.$router.push('/tipoPermisos');
            })
            .catch(r => {
              self.$message({
                message: "Ocurrió un error inesperado",
                type: "error"
              });
            });
          } else {
            debugger;
            self.$store.state.services.tipoPermisoService
              .add(self.form)
              .then(r => {
                self.loading = false;
                self.$router.push('/tipoPermisos');
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
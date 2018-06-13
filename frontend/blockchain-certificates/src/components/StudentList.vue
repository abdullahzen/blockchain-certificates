<template>
  <div id="studentlist">
    <studentops :student="currStudent" :closeDialog="closeDialog" :showDialog="showDialog"/>
    <studentpill v-for="(item, index) in students" :student="item" :key="index" :openDialog="openDialog" :setCurrentStudent="setCurrentStudent"/>
  </div>
</template>

<script>
import studentpill from "@/components/StudentPill";
import studentops from "@/components/StudentOps";

import * as apiService from "../services/apiService";

export default {
  name: "studentlist",
  data() {
    return {
      showDialog: false,
      currStudent: {},
      students: []
    };
  },
  methods: {
    openDialog() {
      this.showDialog = true;
    },
    closeDialog() {
      this.showDialog = false;
    },
    getStudents() {
      apiService.getStudents().then(body => this.students = body.data);
    },
    setCurrentStudent(student){
      this.currStudent = student;
    }
  },
  components: {
    studentpill,
    studentops
  },
  mounted() {
    this.getStudents();
  }
};
</script>

<style lang="scss" scoped>
#studentlist {
  padding-top: 64px;
}
</style>
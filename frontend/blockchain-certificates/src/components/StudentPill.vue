<template>
  <md-list class="hover-cursor" @click="onPillClick">
    <md-list-item>
        <md-avatar>
          <img :src="student.imageUrl">
        </md-avatar>

        <div class="md-list-item-text">
          <span id="name">{{student.firstName}} {{student.lastName}}</span>
          <p id="program">{{student.program}}</p>
        </div>
    </md-list-item>
  </md-list>
</template>

<script>
export default {
  props: ["openDialog", "setCurrentStudent", "student"],
  name: "studentpill",
  methods: {
    onPillClick() {
      this.openDialog();
      this.setCurrentStudent(this.student);
    }
  }
};
</script>

<style lang="scss" scoped>
.md-avatar {
  width: 50px;
  height: 50px;
}
.md-list {
  width: 300px;
  margin: 15px;
  max-width: 100%;
  display: inline-block;
  vertical-align: top;
  border: 1px solid rgba(#000, 0.12);
}
.hover-cursor:hover {
  cursor: pointer;
}
#name {
  font-size: 1.1em;
}
#program {
  font-size: 0.8em;
}
</style>

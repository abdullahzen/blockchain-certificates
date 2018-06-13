<template>
  <div>
    <md-toolbar id="toolbar">
      <div class="md-toolbar-section-start">
        <img id="logo" src="../assets/logo.png">
        <h3 class="md-title">{{title}}</h3>
      </div>
      
      <!-- <div class="md-toolbar-section-end">
        <md-field md-inline id="searchbar">
          <md-icon>search</md-icon>
          <label>Search</label>
          <md-input v-model="inline"></md-input>
        </md-field>

        <md-button class="md-icon-button">
          <md-icon>add</md-icon>
        </md-button>
      </div> -->
    </md-toolbar>
  </div>
</template>

<script>
export default {
  name: "headerbar",
  data() {
    return {
      title: "Mantle University",
      inline: null
    };
  }
};
</script>

<style lang="scss" scoped>
.md-focused label {
  font-weight: 500;
}
#toolbar {
  position: fixed;
  z-index: 10;
  background-color: #f2f2f2;
}
#searchbar {
  width: 200px;
}
#logo {
  width: 50px;
}
</style>

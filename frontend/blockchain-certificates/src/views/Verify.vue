<template>
  <div id="verifyDiv">
    <headerbar/>
    <uploadbox/>
  </div>
</template>

<script>
import headerbar from "@/components/HeaderBar";
import uploadbox from "@/components/UploadBox";
export default {
  name: "verifyview",
  components: {
    headerbar,
    uploadbox
  }
};
</script>

<style lang="scss" scoped>
#verifyDiv {
  height: 100%;
}
</style>
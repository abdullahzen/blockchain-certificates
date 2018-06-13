<template>
  <div>
    <headerbar/>
    <studentlist/>
  </div>
</template>

<script>
import studentlist from "@/components/StudentList";
import headerbar from "@/components/HeaderBar";
export default {
  name: "mainview",
  components: {
    headerbar,
    studentlist
  }
};
</script>

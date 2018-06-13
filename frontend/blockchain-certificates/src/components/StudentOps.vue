<template>
  <div>
    <md-dialog :md-active="showDialog">
      <md-tabs md-dynamic-height>
        <!-- <md-tab md-label="Edit">
          <div>
            <md-field>
              <label>First Name</label>
              <md-input v-model="firstname" readonly></md-input>
            </md-field>
            <md-field>
              <label>Last Name</label>
              <md-input v-model="lastname" readonly></md-input>
            </md-field>
            <md-field>
              <label>Program</label>
              <md-input v-model="program"></md-input>
            </md-field>
          </div>
        </md-tab>

        <md-tab md-label="Courses">
          <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
          <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
          <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
        </md-tab> -->

        <md-tab md-label="Certificate">
          <div>
            <md-button id="generatebutton" class="md-raised md-primary"  @click="generateCert">Generate Certificate</md-button>
          </div>
        </md-tab>
      </md-tabs>

      <md-dialog-actions>
        <md-button class="md-primary" @click="closeDialog">Close</md-button>
        <!-- <md-button class="md-primary" @click="closeDialog">Save</md-button> -->
      </md-dialog-actions>
    </md-dialog>
  </div>
</template>

<script>
import * as apiService from "../services/apiService";

export default {
  props: ["closeDialog", "showDialog", "student"],
  name: "studentops",
  methods: {
    generateCert() {
      apiService.issueCertificate(this.student.id).then(body => {
        var a = document.createElement("a");
        a.href = "data:image/png;base64," + body.data.fileContents;
        a.download = this.student.lastName + "_certificate.png";
        a.click();
      });
    }
  }
};
</script>

<style lang="scss" scoped>
.md-dialog {
  max-width: 400px;
  z-index: 20;
  background-color: #f2f2f2;
}
.md-field {
  max-width: 400px;
}
.md-tabs {
  max-width: 400px;
}
.md-tab {
  max-width: 400px;
  text-align: center;
}
#generatebutton {
  background-color: #448aff;
  color: white;
}
</style>